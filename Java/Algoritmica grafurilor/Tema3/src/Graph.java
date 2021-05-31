import java.awt.Color;
import java.util.Arrays;
import java.util.HashSet;
import java.util.LinkedHashSet;
import java.util.Random;
import java.util.Set;
import java.util.Stack;
import java.util.Vector;

public class Graph {

    static public void TopologicalSorting(Vector<Vector<Integer>> adjacencyMatrix) {
        Set[] myArray = new Set[adjacencyMatrix.size()];
        for (int index1 = 0; index1 < adjacencyMatrix.size(); ++index1) {
            myArray[index1] = new HashSet();
            for (int index2 = 0; index2 < adjacencyMatrix.size(); ++index2)
                if (adjacencyMatrix.elementAt(index1).elementAt(index2) == 1)
                    myArray[index1].add(index2);
        }

        Stack<Integer> myStack = new Stack<>();
        Set<Integer> visited = new LinkedHashSet<>();
        Set<Integer> nodesInStack = new HashSet<>();

        for (int index = 0; index < myArray.length; ++index) {
            if (!visited.contains(index)) {
                visited.add(index);
                nodesInStack.add(index);
                myStack.push(index);
                while (!myStack.empty()) {
                    boolean ok = false;
                    for (Object pos : myArray[myStack.peek()]) {
                        if (nodesInStack.contains(pos)) {
                            System.out.println("Graful are circuite!");
                            return;
                        }
                        if (!visited.contains(pos)) {
                            visited.add((Integer) pos);
                            nodesInStack.add((Integer) pos);
                            myStack.push((Integer) pos);
                            ok = true;
                            break;
                        }
                    }
                    if (!ok) {
                        nodesInStack.remove(myStack.peek());
                        myStack.pop();
                    }
                }
            }
        }
        System.out.println("Sortare topologica: " + visited);
    }

    static public Color[] ConnectedComponents(Vector<Vector<Integer>> adjacencyMatrix) {
        System.out.println("Componente conexe");

        Set[] myArray = new Set[adjacencyMatrix.size()];
        for (int index1 = 0; index1 < adjacencyMatrix.size(); ++index1) {
            myArray[index1] = new HashSet();
            for (int index2 = 0; index2 < index1 + 1; ++index2)
                if (adjacencyMatrix.elementAt(index1).elementAt(index2) == 1 ||
                        adjacencyMatrix.elementAt(index2).elementAt(index1) == 1) {
                    myArray[index1].add(index2);
                    myArray[index2].add(index1);
                }
        }

        Stack<Integer> myStack = new Stack<>();
        Color[] componentsColor = new Color[myArray.length];
        Random rand = new Random();

        for (int index = 0; index < myArray.length; ++index) {
            Color color = new Color(rand.nextFloat(), rand.nextFloat(), rand.nextFloat());
            if (componentsColor[index] == null) {
                componentsColor[index] = color;
                myStack.push(index);
                while (!myStack.empty()) {
                    boolean ok = false;
                    for (Object pos : myArray[myStack.peek()]) {
                        if (componentsColor[(int) pos] == null) {
                            componentsColor[(int) pos] = color;
                            myStack.push((Integer) pos);
                            ok = true;
                            break;
                        }
                    }
                    if (!ok)
                        myStack.pop();
                }
            }
        }
        return componentsColor;
    }

    static public Vector<Set<Integer>> StronglyConnectedComponents(Vector<Vector<Integer>> adjacencyMatrix) {
        System.out.println("Componente tari conexe");

        Set[] graphArray= new Set[adjacencyMatrix.size()];
        Set[] reversedGraphArray= new Set[adjacencyMatrix.size()];

        for (int index1 = 0; index1 < adjacencyMatrix.size(); ++index1) {
            graphArray[index1] = new HashSet();
            reversedGraphArray[index1] = new HashSet();
            for (int index2 = 0; index2 < adjacencyMatrix.size(); ++index2) {
                if (adjacencyMatrix.elementAt(index1).elementAt(index2) == 1)
                    graphArray[index1].add(index2);
                if (adjacencyMatrix.elementAt(index2).elementAt(index1) == 1)
                    reversedGraphArray[index1].add(index2);
            }
        }

        Stack<Integer> myStack = new Stack<>();
        boolean[] visited = new boolean[reversedGraphArray.length];
        int[] order = new int[reversedGraphArray.length];
        int indexComponent = reversedGraphArray.length-1;

        for (int index = 0; index < reversedGraphArray.length; ++index)
            if (!visited[index]) {
                visited[index] = true;
                myStack.push(index);
                while (!myStack.empty()) {
                    boolean ok = false;
                    for (Object pos : reversedGraphArray[myStack.peek()]) {
                        if (!visited[(int) pos]) {
                            visited[(int) pos] = true;
                            myStack.push((Integer) pos);
                            ok = true;
                            break;
                        }
                    }
                    if (!ok) {
                        order[indexComponent] = myStack.peek();
                        --indexComponent;
                        myStack.pop();
                    }
                }
            }

        Arrays.fill(visited, false);
        Vector<Set<Integer>> components = new Vector<>();

        for (int i : order)
            if (!visited[i]) {
                components.add(new HashSet<>());
                components.elementAt(components.size() - 1).add(i);
                visited[i] = true;
                myStack.push(i);
                while (!myStack.empty()) {
                    boolean ok = false;
                    for (Object pos : graphArray[myStack.peek()]) {
                        if (!visited[(int) pos]) {
                            components.elementAt(components.size() - 1).add((Integer) pos);
                            visited[(int) pos] = true;
                            myStack.push((Integer) pos);
                            ok = true;
                            break;
                        }
                    }
                    if (!ok)
                        myStack.pop();
                }
            }

        return components;
    }
}

