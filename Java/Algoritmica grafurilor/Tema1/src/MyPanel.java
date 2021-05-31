import java.awt.Point;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseMotionAdapter;
import java.util.Vector;
import javax.swing.BorderFactory;
import javax.swing.JPanel;
import javax.swing.JButton;
import java.io.FileWriter;
import java.io.IOException;
import java.awt.event.MouseEvent;

public class MyPanel extends JPanel {
    private int nodeNr = 0;
    private int nodeStart = -1;
    private int nodeEnd = -1;
    public static int node_diam = 30;
    private final Vector<Node> listaNoduri;
    private final Vector<Arc> listaArce;
    private final Vector<Vector<Integer>> adjacencyMatrix;
    private Point pointStart = null;
    private Point pointEnd = null;
    boolean isDragging = false;
    private boolean oriented = false;
    private boolean move = false;
    JButton buttonGraph;
    JButton buttonMove;

    public MyPanel() {
        listaNoduri = new Vector<>();
        listaArce = new Vector<>();
        adjacencyMatrix = new Vector<>();
        buttonGraph = new JButton("Graf: Neorientat");
        buttonMove = new JButton("Muta: Oprit");
        add(buttonGraph);
        add(buttonMove);
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
                    if (listaNoduri.elementAt(i).distanceBetweenPointAndNode(pointStart) < (double) node_diam / 2) {
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
                            if (listaNoduri.elementAt(i).distanceBetweenPointAndNode(pointStart) < node_diam * 2) {
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

                            addNode(e.getX() - node_diam / 2, e.getY() - node_diam / 2);
                            writeAdjacencyMatrix();
                        }
                    }
                } else {
                    nodeEnd = -1;
                    for (int i = 0; i < listaNoduri.size() && (nodeEnd == -1); ++i) {
                        if (listaNoduri.elementAt(i).distanceBetweenPointAndNode(pointEnd) < (double) node_diam / 2) {
                            nodeEnd = i;
                        }
                    }
                    if (!move) {
                        if (nodeStart != -1 && nodeEnd != -1 && nodeStart != nodeEnd
                                && adjacencyMatrix.elementAt(nodeStart).elementAt(nodeEnd) == 0) {
                            adjacencyMatrix.elementAt(nodeStart).set(nodeEnd, 1);
                            if (!oriented)
                                adjacencyMatrix.elementAt(nodeEnd).set(nodeStart, 1);

                            Arc arc = new Arc(new Point(listaNoduri.elementAt(nodeStart).getCoordX() + node_diam / 2,
                                    listaNoduri.elementAt(nodeStart).getCoordY() + node_diam / 2),
                                    new Point(listaNoduri.elementAt(nodeEnd).getCoordX() + node_diam / 2,
                                            listaNoduri.elementAt(nodeEnd).getCoordY() + node_diam / 2), nodeStart, nodeEnd);
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

        buttonGraph.addActionListener(e -> {
            if (oriented) {
                oriented = false;
                buttonGraph.setText("Graf: Neorientat");
            } else {
                oriented = true;
                buttonGraph.setText("Graf: Orientat");
            }
            nodeNr = 0;
            adjacencyMatrix.clear();
            listaArce.clear();
            listaNoduri.clear();
            writeAdjacencyMatrix();
            repaint();
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
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
    }

    //metoda care se apeleaza la eliberarea mouse-ului
    private void addNode(int x, int y) {
        ++nodeNr;
        Node node = new Node(x, y, nodeNr);
        listaNoduri.add(node);
        repaint();
    }

    //se executa atunci cand apelam repaint()
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);//apelez metoda paintComponent din clasa de baza
        for (Arc a : listaArce) {
            a.drawArc(g, oriented);
        }
        //ce e in curs de desenare
        if (pointStart != null) {
            if (!move) {
                g.setColor(Color.RED);
                if (oriented)
                    Arc.drawArrow(g, pointStart.x, pointStart.y, pointEnd.x, pointEnd.y);
                else
                    g.drawLine(pointStart.x, pointStart.y, pointEnd.x, pointEnd.y);
            } else {
                if (nodeStart != -1) {
                    boolean ok = true;
                    for (int index = 0; index < listaNoduri.size(); ++index)
                        if (index != nodeStart && listaNoduri.elementAt(index).distanceBetweenPointAndNode(pointEnd) < node_diam * 2)
                            ok = false;
                    if (ok) {
                        listaNoduri.elementAt(nodeStart).moveNode(pointEnd.x - node_diam / 2, pointEnd.y - node_diam / 2);
                        for (Arc a : listaArce) {
                            if (a.getNodeStart() == nodeStart)
                                a.setStart(pointEnd);
                            if (a.getNodeEnd() == nodeStart)
                                a.setEnd(pointEnd);
                        }
                    }
                }
            }
        }
        for (Node nod : listaNoduri) {
            nod.drawNode(g, node_diam);
        }
    }
}
