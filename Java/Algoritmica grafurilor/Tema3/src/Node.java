import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Point;
import java.lang.Math;

public class Node {
    private int coordX;
    private int coordY;
    private Color color;
    private final String name;
    static int basicNodeDiam = 30;
    private int node_diam;
    private final int number;

    public int getNode_diam() {
        return node_diam;
    }

    public Node(int coordX, int coordY, int number, String name) {
        this.coordX = coordX;
        this.coordY = coordY;
        this.number = number;
        this.name = name;
        color = Color.BLACK;
        node_diam = basicNodeDiam;
        if (name.length() > 1)
            node_diam += (name.length() - 2) * 6;
    }

    public int getNumber() {
        return number;
    }

    public Node(int coordX, int coordY, int number) {
        this.coordX = coordX;
        this.coordY = coordY;
        this.number = number;
        this.name = ((Integer) number).toString();
        color = Color.BLACK;
        node_diam = basicNodeDiam;
        if (name.length() > 1)
            node_diam += (name.length() - 2) * 6;
    }

    public int getCoordX() {
        return coordX;
    }

    public int getCoordY() {
        return coordY;
    }

    public void drawNode(Graphics g, int node_diam) {
        g.setColor(color);
        g.setFont(new Font("TimesRoman", Font.BOLD, 15));
        g.fillOval(coordX, coordY, node_diam, node_diam);
        g.setColor(Color.BLACK);
        g.drawOval(coordX, coordY, node_diam, node_diam);
        g.setColor(Color.WHITE);
        if (name.length() == 1)
            g.drawString(name, coordX + 10, coordY + node_diam / 2 + 5);
        else
            g.drawString(name, coordX + 5, coordY + node_diam / 2 + 5);
    }

    public void moveNode(int x, int y) {
        coordX = x;
        coordY = y;
    }

    public double distanceBetweenPointAndNode(Point pointStart) {
        return Math.sqrt(Math.pow((pointStart.getX() - coordX - (double) node_diam / 2), 2)
                + Math.pow((pointStart.getY() - coordY - (double) node_diam / 2), 2));
    }

    public Color getColor() {
        return color;
    }

    public void setColor(Color color) {
        this.color = color;
    }
}
