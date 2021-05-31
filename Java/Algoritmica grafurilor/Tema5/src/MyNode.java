import java.awt.Color;
import java.awt.Graphics;

public class MyNode {
    private int id;
    private float x;
    private float y;

    public MyNode(int id, float x, float y) {
        this.id = id;
        this.x = x;
        this.y = y;
    }

    public int getId() {
        return id;
    }

    public float getX() {
        return x;
    }

    public float getY() {
        return y;
    }

    public void setX(float x) {
        this.x = x;
    }

    public void setY(float y) {
        this.y = y;
    }

    public void draw(Graphics g, int width, int height) {
        g.setColor(Color.BLUE);
        g.fillOval((int) (x * width), (int) (y * height), 1, 1);
    }

    public void drawCourseNode(Graphics g, int width, int height) {
        g.setColor(Color.red);
        g.fillOval((int) (x * width) - 3, (int) (y * height) - 3, 6, 6);
    }
}
