import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.SwingUtilities;
import java.io.FileNotFoundException;

public class Main {

    private static void initUI() {
        JFrame f = new JFrame("Maze");
        f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        JPanel myPanel = null;
        try {
            myPanel = new DrawMaze();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
        f.add(myPanel);
        f.setSize(myPanel.getSize());
        f.setVisible(true);

        myPanel.paintImmediately(0, 0,myPanel.getWidth(), myPanel.getHeight());
        try {
            Thread.sleep(5000);
        } catch (InterruptedException interruptedException) {
            interruptedException.printStackTrace();
        }
        DrawMaze.MarkMaze();
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(Main::initUI);
    }
}
