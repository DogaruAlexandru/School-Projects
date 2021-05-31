import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Point;
import java.awt.geom.AffineTransform;

public class Arc {
    private Point start;
    private Point end;
    private final Node nodeStart;
    private final Node nodeEnd;

    public Arc(Point start, Point end, Node nodeStart, Node nodeEnd) {
        this.start = start;
        this.end = end;
        this.nodeStart = nodeStart;
        this.nodeEnd = nodeEnd;
    }

    public Node getNodeEnd() {
        return nodeEnd;
    }

    public Node getNodeStart() {
        return nodeStart;
    }

    public void setEnd(Point end) {
        this.end = end;
    }

    public void setStart(Point start) {
        this.start = start;
    }

    public static void drawArrow(Graphics g1, int x1, int y1, int x2, int y2) {
        Graphics2D g = (Graphics2D) g1.create();

        double dx = x2 - x1, dy = y2 - y1;
        double angle = Math.atan2(dy, dx);
        int len = (int) Math.sqrt(dx * dx + dy * dy);
        AffineTransform at = AffineTransform.getTranslateInstance(x1, y1);
        at.concatenate(AffineTransform.getRotateInstance(angle));
        g.transform(at);

        g.drawLine(0, 0, len, 0);
        int ARR_SIZE = 10;
        g.fillPolygon(new int[]{len, len - ARR_SIZE - 5, len - ARR_SIZE - 5, len},
                new int[]{0, -ARR_SIZE, ARR_SIZE, 0}, 4);
    }

    public static void drawArrow(Graphics g1, Node n1, Node n2) {
        Graphics2D g = (Graphics2D) g1.create();

        double dx = n2.getCoordX() - n1.getCoordX() + (float) (n2.getNode_diam() - n1.getNode_diam()) / 2,
                dy = n2.getCoordY() - n1.getCoordY() + (float) (n2.getNode_diam() - n1.getNode_diam()) / 2;
        double angle = Math.atan2(dy, dx);
        int len = (int) Math.sqrt(dx * dx + dy * dy);
        AffineTransform at = AffineTransform.getTranslateInstance(n1.getCoordX() + (float) n1.getNode_diam() / 2,
                n1.getCoordY() + (float) n1.getNode_diam() / 2);
        at.concatenate(AffineTransform.getRotateInstance(angle));
        g.transform(at);

        g.drawLine(0, 0, len, 0);
        int ARR_SIZE = 10;
        g.fillPolygon(new int[]{len - n2.getNode_diam() / 2, len - ARR_SIZE - n2.getNode_diam() / 2 - 5,
                        len - ARR_SIZE - n2.getNode_diam() / 2 - 5, len - n2.getNode_diam() / 2},
                new int[]{0, -ARR_SIZE, ARR_SIZE, 0}, 4);
    }

    public void drawArc(Graphics g) {
        if (start != null) {
            g.setColor(Color.BLACK);
            drawArrow(g, nodeStart, nodeEnd);
        }
    }
}
