import javax.swing.JPanel;
import java.awt.Color;
import java.awt.Graphics;
import java.io.FileNotFoundException;

public class DrawMaze extends JPanel {
    private static Maze myMaze;
    private final int squareSize;

    DrawMaze() throws FileNotFoundException {
        myMaze = new Maze();
        squareSize = 50;
        setSize(myMaze.COLUMNS * squareSize + 16, myMaze.LINES * squareSize + 39);
    }

    public static void MarkMaze() {
        myMaze.Mark();
    }

    protected void paintComponent(Graphics g) {
        for (int line = 0; line < myMaze.LINES; ++line)
            for (int column = 0; column < myMaze.COLUMNS; ++column) {
                switch (myMaze.mazeTable[line][column]) {
                    case 0 -> g.setColor(Color.BLACK);
                    case 2 -> g.setColor(Color.BLUE);
                    case 3, -3 -> g.setColor(Color.RED);
                    case 4 -> g.setColor(Color.GREEN);
                    default -> g.setColor(Color.WHITE);
                }
                g.fillRect(column * squareSize, line * squareSize, squareSize, squareSize);
                g.setColor(Color.BLACK);
                g.drawRect(column * squareSize, line * squareSize, squareSize, squareSize);
            }
    }
}
