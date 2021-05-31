import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Point;
import java.lang.Math;

public class Node {
    private int coordX;
    private int coordY;
    private final int number;

    public Node(int coordX, int coordY, int number) {
        this.coordX = coordX;
        this.coordY = coordY;
        this.number = number;
    }

    public int getCoordX() {
        return coordX;
    }

    public int getCoordY() {
        return coordY;
    }

    public void drawNode(Graphics g, int node_diam) {
        g.setColor(Color.RED);
        g.setFont(new Font("TimesRoman", Font.BOLD, 15));
        g.fillOval(coordX, coordY, node_diam, node_diam);
        g.setColor(Color.WHITE);
        g.drawOval(coordX, coordY, node_diam, node_diam);
        if (number < 10)
            g.drawString(((Integer) number).toString(), coordX + 10, coordY + 20);
        else if (number < 100)
            g.drawString(((Integer) number).toString(), coordX + 5, coordY + 20);
        else
            g.drawString(((Integer) number).toString(), coordX + 1, coordY + 20);
    }

    public void moveNode(int x, int y) {
        coordX = x;
        coordY = y;
    }

    public double distanceBetweenPointAndNode(Point pointStart) {
        return Math.sqrt(Math.pow((pointStart.getX() - coordX - (double) MyPanel.node_diam / 2), 2)
                + Math.pow((pointStart.getY() - coordY - (double) MyPanel.node_diam / 2), 2));
    }
}
