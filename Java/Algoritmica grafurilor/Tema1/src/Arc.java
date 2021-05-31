import java.awt.*;
import java.awt.geom.AffineTransform;

public class Arc {
    private Point start;
    private Point end;
    private final int nodeStart;
    private final int nodeEnd;

    public Arc(Point start, Point end, int nodeStart, int nodeEnd) {
        this.start = start;
        this.end = end;
        this.nodeStart = nodeStart;
        this.nodeEnd = nodeEnd;
    }

    public int getNodeEnd() {
        return nodeEnd;
    }

    public int getNodeStart() {
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
        g.fillPolygon(new int[]{len - 15, len - ARR_SIZE - 20, len - ARR_SIZE - 20, len - 15},
                new int[]{0, -ARR_SIZE, ARR_SIZE, 0}, 4);
    }

    public void drawArc(Graphics g, boolean oriented) {
        if (start != null) {
            g.setColor(Color.black);
            if (oriented)
                drawArrow(g, start.x, start.y, end.x, end.y);
            else
                g.drawLine(start.x, start.y, end.x, end.y);
        }
    }
}
