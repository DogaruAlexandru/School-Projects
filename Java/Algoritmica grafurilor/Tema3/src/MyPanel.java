import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseMotionAdapter;
import java.util.Set;
import java.util.Vector;
import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JPanel;
import java.io.FileWriter;
import java.io.IOException;
import java.awt.event.MouseEvent;

public class MyPanel extends JPanel {
    private int nodeNr = 0;
    private int nodeStart = -1;
    private int nodeEnd = -1;

    private Vector<Node> listaNoduri;
    private Vector<Arc> listaArce;
    private Vector<Vector<Integer>> adjacencyMatrix;

    private Point pointStart = null;
    private Point pointEnd = null;

    boolean isDragging = false;
    private boolean move = false;

    JButton buttonMove;
    JButton buttonRestart;
    JButton buttonTopologicalSorting;
    JButton buttonConnectedComponents;
    JButton buttonStronglyConnectedComponents;

    public MyPanel() {
        listaNoduri = new Vector<>();
        listaArce = new Vector<>();
        adjacencyMatrix = new Vector<>();

        buttonMove = new JButton("Muta: Oprit");
        buttonRestart = new JButton("Restart");
        buttonTopologicalSorting = new JButton("Sortare topologica");
        buttonConnectedComponents = new JButton("Componente conexe");
        buttonStronglyConnectedComponents = new JButton("Componente tari conexe");

        add(buttonMove);
        add(buttonRestart);
        add(buttonTopologicalSorting);
        add(buttonConnectedComponents);
        add(buttonStronglyConnectedComponents);
        writeAdjacencyMatrix();

        // borderul panel-ului
        setBorder(BorderFactory.createLineBorder(Color.black));
        addMouseListener(new MouseAdapter() {
            //evenimentul care se produce la apasarea mousse-ului
            public void mousePressed(MouseEvent e) {
                pointStart = e.getPoint();
                nodeStart = -1;
                for (int i = 0; i < listaNoduri.size() && nodeStart == -1; ++i) {
                    //verific existenta nodului de inceput
                    if (listaNoduri.elementAt(i).distanceBetweenPointAndNode(pointStart) <
                            (float)listaNoduri.elementAt(i).getNode_diam() / 2) {
                        nodeStart = i;
                    }
                }
            }

            //evenimentul care se produce la eliberarea mousse-ului
            public void mouseReleased(MouseEvent e) {

                if (!isDragging) {
                    if (!move) {
                        boolean ok = true;
                        for (int i = 0; i < listaNoduri.size() && ok; i++) {
                            //verific distanta dintre noduri
                            if (listaNoduri.elementAt(i).distanceBetweenPointAndNode(pointStart) <
                                    (float) listaNoduri.elementAt(i).getNode_diam() / 2 + 45) {
                                ok = false;
                            }
                        }
                        if (ok) {
                            //adaug nod nou in matricea de adiacenta
                            adjacencyMatrix.add(new Vector<>());
                            for (int index = 0; index < adjacencyMatrix.size() - 1; ++index) {
                                adjacencyMatrix.elementAt(index).add(0);
                                adjacencyMatrix.elementAt(nodeNr).add(0);
                            }
                            adjacencyMatrix.elementAt(nodeNr).add(0);

                            addNode(e.getX() - Node.basicNodeDiam / 2, e.getY() - Node.basicNodeDiam / 2);
                            writeAdjacencyMatrix();
                        }
                    }
                } else {
                    nodeEnd = -1;
                    for (int i = 0; i < listaNoduri.size() && (nodeEnd == -1); ++i) {
                        if (listaNoduri.elementAt(i).distanceBetweenPointAndNode(pointEnd) <
                                (float) listaNoduri.elementAt(i).getNode_diam() / 2)
                            nodeEnd = i;
                    }
                    if (!move) {
                        if (nodeStart != -1 && nodeEnd != -1 && nodeStart != nodeEnd
                                && adjacencyMatrix.elementAt(nodeStart).elementAt(nodeEnd) == 0) {
                            adjacencyMatrix.elementAt(nodeStart).set(nodeEnd, 1);

                            int valueStart = listaNoduri.elementAt(nodeStart).getNode_diam() / 2;
                            int valueEnd = listaNoduri.elementAt(nodeEnd).getNode_diam() / 2;
                            Point start = new Point(listaNoduri.elementAt(nodeStart).getCoordX() + valueStart,
                                    listaNoduri.elementAt(nodeStart).getCoordY() + valueStart);
                            Point end = new Point(listaNoduri.elementAt(nodeEnd).getCoordX() + valueEnd,
                                    listaNoduri.elementAt(nodeEnd).getCoordY() + valueEnd);
                            Arc arc = new Arc(start, end, listaNoduri.elementAt(nodeStart), listaNoduri.elementAt(nodeEnd));
                            listaArce.add(arc);
                            writeAdjacencyMatrix();
                        }
                        repaint();
                    }
                }
                pointStart = null;
                isDragging = false;
            }
        });

        addMouseMotionListener(new MouseMotionAdapter() {
            //evenimentul care se produce la drag&drop pe mousse
            public void mouseDragged(MouseEvent e) {
                pointEnd = e.getPoint();
                isDragging = true;
                repaint();
            }
        });

        buttonMove.addActionListener(e -> {
            if (move) {
                move = false;
                buttonMove.setText("Muta: Oprit");
            } else {
                move = true;
                buttonMove.setText("Muta: Pornit");
            }
        });

        buttonRestart.addActionListener(e -> {
            nodeNr = 0;
            adjacencyMatrix.clear();
            listaArce.clear();
            listaNoduri.clear();
            repaint();
        });

        buttonTopologicalSorting.addActionListener(e -> Graph.TopologicalSorting(adjacencyMatrix));

        buttonConnectedComponents.addActionListener(e -> {
            Color[] componentsColor = Graph.ConnectedComponents(adjacencyMatrix);
            for (Node node : listaNoduri)
                node.setColor(componentsColor[node.getNumber()]);
            repaint();
        });

        buttonStronglyConnectedComponents.addActionListener(e -> {
            Vector<Set<Integer>> components = Graph.StronglyConnectedComponents(adjacencyMatrix);
            System.out.println(components);
            Convert(components);
            repaint();
        });
    }

    private void Convert(Vector<Set<Integer>> components) {
        Vector<Node> nodes = new Vector<>();
        Vector<Arc> arcs = new Vector<>();
        Vector<Vector<Integer>> matrix = new Vector<>(components.size());

        for (int index1 = 0; index1 < components.size(); ++index1) {
            matrix.add(new Vector<>(components.size()));
            for (int index2 = 0; index2 < components.size(); ++index2)
                matrix.elementAt(index1).add(0);
        }

        for (int index1 = 0; index1 < components.size(); ++index1) {
            String name = Integer.toString(index1);
            if (components.elementAt(index1).size() > 1) {
                name += "(";
                for (Integer i : components.elementAt(index1))
                    name += i.toString() + ",";
                name = name.substring(0, name.length() - 1);
                name += ")";
            }

            for (int index2 = 0; index2 < listaNoduri.size(); ++index2) {
                if (components.elementAt(index1).contains(listaNoduri.elementAt(index2).getNumber())) {
                    nodes.add(new Node(listaNoduri.elementAt(index2).getCoordX(),
                            listaNoduri.elementAt(index2).getCoordY(), index1, name));
                    nodes.lastElement().setColor(listaNoduri.elementAt(index2).getColor());
                    break;
                }
            }
        }

        for (Arc a : listaArce) {
            int pos1 = -1, pos2 = -1;
            for (int index = 0; index < components.size() && (pos1 == -1 || pos2 == -1); ++index) {
                if (components.elementAt(index).contains(a.getNodeStart().getNumber()))
                    pos1 = index;
                if (components.elementAt(index).contains(a.getNodeEnd().getNumber()))
                    pos2 = index;
            }
            if (pos1 != pos2) {
                int valueStart = listaNoduri.elementAt(pos1).getNode_diam() / 2;
                int valueEnd = listaNoduri.elementAt(pos2).getNode_diam() / 2;
                Point start = new Point(nodes.elementAt(pos1).getCoordX() + valueStart,
                        nodes.elementAt(pos1).getCoordY() + valueStart);
                Point end = new Point(nodes.elementAt(pos2).getCoordX() + valueEnd,
                        nodes.elementAt(pos2).getCoordY() + valueEnd);
                arcs.add(new Arc(start, end, nodes.elementAt(pos1), nodes.elementAt(pos2)));

                matrix.elementAt(pos1).set(pos2, 1);
            }
        }

        listaArce = arcs;
        listaNoduri = nodes;
        adjacencyMatrix = matrix;
        nodeNr = components.size();
        writeAdjacencyMatrix();
    }

    private void writeAdjacencyMatrix() {
        try {
            FileWriter myFile = new FileWriter("Adjacency Matrix.txt", false);
            myFile.write(Integer.toString(nodeNr) + '\n');
            for (int index1 = 0; index1 < adjacencyMatrix.size(); ++index1) {
                for (int index2 = 0; index2 < adjacencyMatrix.size(); ++index2)
                    myFile.write(Integer.toString(adjacencyMatrix.elementAt(index1).elementAt(index2)) + ' ');
                myFile.write('\n');
            }
            myFile.close();
        } catch (IOException e) {
            System.out.println("An error occurred!");
            e.printStackTrace();
        }
    }

    //metoda care se apeleaza la eliberarea mouse-ului
    private void addNode(int x, int y) {
        Node node = new Node(x, y, nodeNr);
        ++nodeNr;
        listaNoduri.add(node);
        repaint();
    }

    //se executa atunci cand apelam repaint()
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);//apelez metoda paintComponent din clasa de baza

        for (Arc a : listaArce) {
            a.drawArc(g);
        }

        //ce e in curs de desenare
        if (pointStart != null) {
            if (!move) {
                g.setColor(Color.RED);
                Arc.drawArrow(g, pointStart.x, pointStart.y, pointEnd.x, pointEnd.y);
            } else {
                if (nodeStart != -1) {
                    boolean ok = true;
                    for (int index = 0; index < listaNoduri.size() && ok; ++index)
                        if (index != nodeStart && listaNoduri.elementAt(index).distanceBetweenPointAndNode(pointEnd) <
                                (float) listaNoduri.elementAt(nodeStart).getNode_diam() / 2 +
                                        (float) listaNoduri.elementAt(index).getNode_diam() / 2 + Node.basicNodeDiam)
                            ok = false;
                    if (ok) {
                        listaNoduri.elementAt(nodeStart).moveNode(pointEnd.x - listaNoduri.elementAt(nodeStart).getNode_diam() / 2,
                                pointEnd.y - listaNoduri.elementAt(nodeStart).getNode_diam() / 2);
                        for (Arc a : listaArce) {
                            if (a.getNodeStart().getNumber() == nodeStart)
                                a.setStart(pointEnd);
                            if (a.getNodeEnd().getNumber() == nodeStart)
                                a.setEnd(pointEnd);
                        }
                    }
                }
            }
        }

        for (Node nod : listaNoduri) {
            nod.drawNode(g, nod.getNode_diam());
        }
    }
}
