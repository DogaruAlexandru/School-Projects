import javax.swing.JFrame;
import javax.swing.SwingUtilities;

public class Graf {
    private static void initUI() {
        JFrame f = new JFrame("Algoritmica Grafurilor");
        f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        f.add(new MyPanel());
        f.setSize(800, 600);
        f.setVisible(true);
    }

    public static void main(String[] args) {
        //pornesc firul de executie grafic
        //fie prin implementarea interfetei Runnable, fie printr-un ob al clasei Thread
        //new Thread()
        SwingUtilities.invokeLater(Graf::initUI);
    }
}
