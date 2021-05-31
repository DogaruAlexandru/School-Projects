import java.awt.Point;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Scanner;

public class Maze {
    public final int LINES;
    public final int COLUMNS;
    public final int[][] mazeTable;
    public final Point entryPoint;

    Maze() throws FileNotFoundException {
        final Scanner scanner = new Scanner(new File("maze.txt"));

        LINES = scanner.nextInt();
        COLUMNS = scanner.nextInt();
        mazeTable = new int[LINES][COLUMNS];

        for (int line = 0; line < LINES; ++line)
            for (int column = 0; column < COLUMNS; ++column)
                mazeTable[line][column] = scanner.nextInt();

        entryPoint = new Point();
        for (int line = 0; line < LINES; ++line)
            for (int column = 0; column < COLUMNS; ++column)
                if (mazeTable[line][column] == 2) {
                    entryPoint.setLocation(column, line);
                    return;
                }
    }

    public void Mark() {
        Queue<Point> myQueue = new LinkedList<>();
        Queue<Point> path = new LinkedList<>();
        myQueue.add(entryPoint);
        mazeTable[entryPoint.x][entryPoint.y] = 5;

        while (!myQueue.isEmpty()) {
            if (myQueue.peek().x - 1 >= 0)
                if (mazeTable[myQueue.peek().y][myQueue.peek().x - 1] == 1) {
                    mazeTable[myQueue.peek().y][myQueue.peek().x - 1] = mazeTable[myQueue.peek().y][myQueue.peek().x] + 1;
                    myQueue.add(new Point(myQueue.peek().x - 1, myQueue.peek().y));
                } else if (mazeTable[myQueue.peek().y][myQueue.peek().x - 1] == 3) {
                    path.add(new Point(myQueue.peek().x, myQueue.peek().y));
                    mazeTable[myQueue.peek().y][myQueue.peek().x - 1] = -3;
                }
            if (myQueue.peek().y - 1 >= 0)
                if (mazeTable[myQueue.peek().y - 1][myQueue.peek().x] == 1) {
                    mazeTable[myQueue.peek().y - 1][myQueue.peek().x] = mazeTable[myQueue.peek().y][myQueue.peek().x] + 1;
                    myQueue.add(new Point(myQueue.peek().x, myQueue.peek().y - 1));
                } else if (mazeTable[myQueue.peek().y - 1][myQueue.peek().x] == 3) {
                    path.add(new Point(myQueue.peek().x, myQueue.peek().y));
                    mazeTable[myQueue.peek().y - 1][myQueue.peek().x] = -3;
                }
            if (myQueue.peek().x + 1 < COLUMNS)
                if (mazeTable[myQueue.peek().y][myQueue.peek().x + 1] == 1) {
                    mazeTable[myQueue.peek().y][myQueue.peek().x + 1] = mazeTable[myQueue.peek().y][myQueue.peek().x] + 1;
                    myQueue.add(new Point(myQueue.peek().x + 1, myQueue.peek().y));
                } else if (mazeTable[myQueue.peek().y][myQueue.peek().x + 1] == 3) {
                    path.add(new Point(myQueue.peek().x, myQueue.peek().y));
                    mazeTable[myQueue.peek().y][myQueue.peek().x + 1] = -3;
                }
            if (myQueue.peek().y + 1 < LINES)
                if (mazeTable[myQueue.peek().y + 1][myQueue.peek().x] == 1) {
                    mazeTable[myQueue.peek().y + 1][myQueue.peek().x] = mazeTable[myQueue.peek().y][myQueue.peek().x] + 1;
                    myQueue.add(new Point(myQueue.peek().x, myQueue.peek().y + 1));
                } else if (mazeTable[myQueue.peek().y + 1][myQueue.peek().x] == 3) {
                    path.add(new Point(myQueue.peek().x, myQueue.peek().y));
                    mazeTable[myQueue.peek().y + 1][myQueue.peek().x] = -3;
                }
            myQueue.remove();
        }

        mazeTable[entryPoint.x][entryPoint.y] = 2;
        FindPath(path);
    }

    private void FindPath(Queue<Point> path) {
        while (!path.isEmpty()) {
            if (path.peek().x - 1 >= 0)
                if (mazeTable[path.peek().y][path.peek().x - 1] == mazeTable[path.peek().y][path.peek().x] - 1) {
//                    mazeTable[path.peek().y][path.peek().x - 1] = 4;
                    path.add(new Point(path.peek().x - 1, path.peek().y));
                }
            if (path.peek().y - 1 >= 0)
                if (mazeTable[path.peek().y - 1][path.peek().x] == mazeTable[path.peek().y][path.peek().x] - 1) {
//                    mazeTable[path.peek().y - 1][path.peek().x] = 4;
                    path.add(new Point(path.peek().x, path.peek().y - 1));
                }
            if (path.peek().x + 1 < COLUMNS)
                if (mazeTable[path.peek().y][path.peek().x + 1] == mazeTable[path.peek().y][path.peek().x] - 1) {
//                    mazeTable[path.peek().y][path.peek().x + 1] = 4;
                    path.add(new Point(path.peek().x + 1, path.peek().y));
                }
            if (path.peek().y + 1 < LINES)
                if (mazeTable[path.peek().y + 1][path.peek().x] == mazeTable[path.peek().y][path.peek().x] - 1) {
//                    mazeTable[path.peek().y + 1][path.peek().x] = 4;
                    path.add(new Point(path.peek().x, path.peek().y + 1));
                }
            mazeTable[path.peek().y][path.peek().x] = 4;
            path.remove();
        }
    }
}