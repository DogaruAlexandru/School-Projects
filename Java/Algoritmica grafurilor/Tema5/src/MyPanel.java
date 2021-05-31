import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import javax.swing.*;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class MyPanel extends JPanel {
    private final Vector nodes;
    private final Vector arcs;

    boolean bellmanChosen;
    MyArc[] path = null;
    private MyNode nodeStart = null;
    private MyNode nodeEnd = null;

    public MyPanel() {
        try {
            bellmanChosen = ReadAlgorithmOption();
        } catch (IOException e) {
            e.printStackTrace();
        }

        nodes = new Vector<MyNode>();
        arcs = new Vector<Vector<MyArc>>();
        try {
            ReadMap(nodes, arcs);
        } catch (ParserConfigurationException | IOException | SAXException e) {
            e.printStackTrace();
        }

        addMouseListener(new MouseAdapter() {
            public void mousePressed(MouseEvent e) {
                if (nodeStart == null)
                    nodeStart = GetNode(e.getPoint());
                else if (nodeEnd == null) {
                    nodeEnd = GetNode(e.getPoint());
                    if (bellmanChosen)
                        BellmanFord();
                    else
                        Dijkstra();
                } else
                    Reset();
                repaint();
            }
        });
    }

    private void ReadMap(Vector<MyNode> nodes, Vector<Vector<MyArc>> arcs)
            throws ParserConfigurationException, IOException, SAXException {
        System.out.println("Time before reading: " + java.time.LocalTime.now());

        File inputFile = new File("map2.xml");
        DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
        DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
        Document doc = dBuilder.parse(inputFile);
        //doc.getDocumentElement().normalize();

        System.out.println("Time after loading the .xml file: " + java.time.LocalTime.now());

        NodeList nList = doc.getElementsByTagName("node");
        int size = nList.getLength();
        int minLongitude = Integer.MAX_VALUE, minLatitude = Integer.MAX_VALUE;
        int maxLongitude = 0, maxLatitude = 0;
        int nodeLongitude, nodeLatitude;
        for (int index = 0; index < size; ++index) {
            Element element = (Element) nList.item(index);
            nodeLongitude = Integer.parseInt(element.getAttribute("longitude"));
            nodeLatitude = Integer.parseInt(element.getAttribute("latitude"));

            if (nodeLongitude > maxLongitude)
                maxLongitude = nodeLongitude;
            if (nodeLongitude < minLongitude)
                minLongitude = nodeLongitude;
            if (nodeLatitude > maxLatitude)
                maxLatitude = nodeLatitude;
            if (nodeLatitude < minLatitude)
                minLatitude = nodeLatitude;

            nodes.add(new MyNode(Integer.parseInt(element.getAttribute("id")), nodeLongitude, nodeLatitude));
            arcs.add(new Vector<>());
        }

        System.out.println("Time after reading the nodes: " + java.time.LocalTime.now());

        NodeList aList = doc.getElementsByTagName("arc");
        size = aList.getLength();
        for (int index = 0; index < size; ++index) {
            Element element = (Element) aList.item(index);
            int beginIndex = Integer.parseInt(element.getAttribute("from"));
            arcs.elementAt(beginIndex).add(new MyArc(nodes.elementAt(beginIndex),
                    nodes.elementAt(Integer.parseInt(element.getAttribute("to"))),
                    Integer.parseInt(element.getAttribute("length"))));
        }

        System.out.println("Time after reading the arcs: " + java.time.LocalTime.now());

        maxLatitude -= minLatitude;
        maxLongitude -= minLongitude;
        for (MyNode n : nodes) {
            n.setX((n.getX() - minLongitude) / maxLongitude);
            n.setY((n.getY() - minLatitude) / maxLatitude);
        }

        System.out.println("Time after converting nodes coordinates to float: " + java.time.LocalTime.now() + '\n');
    }

    private MyNode GetNode(Point point) {
        System.out.println("Time before searching closest node: " + java.time.LocalTime.now());

        double minDistance = Double.MAX_VALUE;
        double distance;
        MyNode nodeFound = null;

        for (Object n : nodes) {
            distance = Math.sqrt(Math.pow(point.getX() - ((MyNode) n).getX() * getWidth(), 2) +
                    Math.pow(point.getY() - ((MyNode) n).getY() * getHeight(), 2));
            if (distance < minDistance) {
                nodeFound = (MyNode) n;
                minDistance = distance;
            }
        }

        System.out.println("Time after searching closest node: " + java.time.LocalTime.now() + '\n');

        return nodeFound;
    }

    private void Dijkstra() {
        System.out.println("Time before running Dijkstra: " + java.time.LocalTime.now());

        int[] weights = new int[nodes.size()];
        Arrays.fill(weights, Integer.MAX_VALUE);

        path = new MyArc[nodes.size()];
        Arrays.fill(path, null);

        PriorityQueue<MyPair> pq = new PriorityQueue<>(new Comp());

        int index = nodeStart.getId();
        weights[index] = 0;
        pq.add(new MyPair(index, 0));

        while (!pq.isEmpty()) {
            MyPair pair = pq.poll();
            index = pair.nodeIndex;
            //int weight = pair.weight;

            for (int indexList = 0; indexList < ((Vector<MyArc>) arcs.elementAt(index)).size(); ++indexList) {
                MyArc arc = ((Vector<MyArc>) arcs.elementAt(index)).elementAt(indexList);
                int auxWeight = weights[index] + arc.getWeight();
                if (auxWeight < weights[arc.getEnd().getId()]) {
                    weights[arc.getEnd().getId()] = auxWeight;
                    path[arc.getEnd().getId()] = arc;
                    pq.add(new MyPair(arc.getEnd().getId(), auxWeight));
                }
            }
        }

        System.out.println("Time after running Dijkstra: " + java.time.LocalTime.now());
    }

    private void BellmanFord() {
        System.out.println("Time before running Bellman-Ford: " + java.time.LocalTime.now());

        int[] weights = new int[nodes.size()];
        Arrays.fill(weights, Integer.MAX_VALUE);
        weights[nodeStart.getId()] = 0;

        path = new MyArc[nodes.size()];
        Arrays.fill(path, null);

        int weight;
        boolean changed;

        for (int index = 0; index < nodes.size() - 1; ++index) {
            changed = false;
            for (int nodeIndex = 0; nodeIndex < nodes.size(); ++nodeIndex) {
                if (weights[nodeIndex] != Integer.MAX_VALUE)
                    for (MyArc arc : (Vector<MyArc>) arcs.elementAt(nodeIndex)) {
                        weight = weights[nodeIndex] + arc.getWeight();
                        if (weight < weights[arc.getEnd().getId()]) {
                            weights[arc.getEnd().getId()] = weight;
                            path[arc.getEnd().getId()] = arc;
                            changed = true;
                        }
                    }
            }
            if (!changed)
                break;
        }

        System.out.println("Time after running Bellman-Ford: " + java.time.LocalTime.now());
    }

    private boolean ReadAlgorithmOption() throws IOException {
        System.out.print("Please write 0 for Dijkstra or 1 for Bellman-Ford:");
        Scanner in = new Scanner(System.in);
        String userInput = in.next();
        while (!(userInput.equals("0") || userInput.equals("1"))) {
            System.out.print("Please write 0 for Dijkstra or 1 for Bellman-Ford:");
            userInput = in.next();
        }
        System.out.println();

        return !userInput.equals("0");
    }

    private void Reset() {
        nodeStart = null;
        nodeEnd = null;
        path = null;
        System.out.println();
    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
        for (Object v : arcs)
            for (Object a : (Vector) v)
                ((MyArc) a).draw(g, getWidth(), getHeight());
        for (Object n : nodes)
            ((MyNode) n).draw(g, getWidth(), getHeight());

        if (nodeStart != null)
            nodeStart.drawCourseNode(g, getWidth(), getHeight());
        if (nodeEnd != null) {
            nodeEnd.drawCourseNode(g, getWidth(), getHeight());
        }

        MyNode node = nodeEnd;
        if (nodeEnd != null) {
            do {
                path[node.getId()].drawCourseArc(g, getWidth(), getHeight());

                node = path[node.getId()].getBegin();
            } while (node != nodeStart);
        }
    }
}

class Comp implements Comparator<MyPair> {
    public int compare(MyPair i1, MyPair i2) {
        if (i1.weight > i2.weight)
            return 1;
        else if (i1.weight < i2.weight)
            return -1;
        return 0;
    }
}

class MyPair {
    public final int nodeIndex;
    public final int weight;

    public MyPair(int nodeIndex, int weight) {
        this.weight = weight;
        this.nodeIndex = nodeIndex;
    }
}