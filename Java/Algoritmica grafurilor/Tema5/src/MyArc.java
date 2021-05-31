import java.awt.*;

public class MyArc {
    private final MyNode begin;
    private final MyNode end;
    private final int weight;

    public MyArc(MyNode begin, MyNode end, int weight) {
        this.begin = begin;
        this.end = end;
        this.weight = weight;
    }

    public MyNode getBegin() {
        return begin;
    }

    public MyNode getEnd() {
        return end;
    }

    public int getWeight() {
        return weight;
    }

    public void draw(Graphics g, int width, int height) {
        g.setColor(Color.BLACK);
        g.drawLine((int) (begin.getX() * width), (int) (begin.getY() * height),
                (int) (end.getX() * width), (int) (end.getY() * height));
    }

    public void drawCourseArc(Graphics g, int width, int height) {
        g.setColor(Color.RED);
        g.drawLine((int) (begin.getX() * width), (int) (begin.getY() * height),
                (int) (end.getX() * width), (int) (end.getY() * height));
    }
}
