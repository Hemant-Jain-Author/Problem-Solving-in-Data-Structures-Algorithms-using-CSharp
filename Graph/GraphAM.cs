using System;

public class GraphAM
{
    private int count;
    private int[,] adj;

    public GraphAM(int cnt)
    {
        count = cnt;
        adj = new int[count, count];
    }

    public void AddDirectedEdge(int src, int dst, int cost = 1)
    {
        adj[src, dst] = cost;
    }

    public void AddUndirectedEdge(int src, int dst, int cost = 1)
    {
        adj[src, dst] = cost;
        adj[dst, src] = cost;
    }

    public void Print()
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write("Vertex " + i + " is connected to : ");
            for (int j = 0; j < count; j++)
            {
                if (adj[i, j] != 0)
                {
                    Console.Write(j + "(cost: " + adj[i, j] + ") ");
                }
            }
            Console.WriteLine();
        }
    }

    // Testing code.
    public static void Main1()
    {
        GraphAM graph = new GraphAM(4);
        graph.AddUndirectedEdge(0, 1);
        graph.AddUndirectedEdge(0, 2);
        graph.AddUndirectedEdge(1, 2);
        graph.AddUndirectedEdge(2, 3);
        graph.Print();
    }

    /*
Vertex 0 is connected to : 1(cost: 1) 2(cost: 1) 
Vertex 1 is connected to : 0(cost: 1) 2(cost: 1) 
Vertex 2 is connected to : 0(cost: 1) 1(cost: 1) 3(cost: 1) 
Vertex 3 is connected to : 2(cost: 1) 
    */
    private class Edge : IComparable<Edge>
    {
        internal int src, dest, cost;

        public Edge(int s, int d, int c)
        {
            src = s;
            dest = d;
            cost = c;
        }

        public int CompareTo(Edge compareEdge)
        {
            return this.cost - compareEdge.cost;
        }
    }

    public void Dijkstra(int source)
    {
        int[] previous = new int[count];
        int[] dist = new int[count];
        bool[] visited = new bool[count];
        Array.Fill(previous, -1);
        Array.Fill(dist, int.MaxValue); // infinite

        dist[source] = 0;
        previous[source] = source;

        PriorityQueue<Edge> pq = new PriorityQueue<Edge>();
        Edge node = new Edge(source, source, 0);
        pq.Enqueue(node);
        int curr;

        while (pq.IsEmpty() != true)
        {
            node = pq.Dequeue();
            curr = node.dest;
            visited[curr] = true;
            for (int dest = 0; dest < count; dest++)
            {
                int cost = adj[curr, dest];
                if (cost != 0)
                {
                    int alt = cost + dist[curr];
                    if (dist[dest] > alt && visited[dest] == false)
                    {

                        dist[dest] = alt;
                        previous[dest] = curr;
                        node = new Edge(curr, dest, alt);
                        pq.Enqueue(node);
                    }
                }
            }
        }
        PrintPath(previous, dist, count, source);
    }

    string PrintPathUtil(int[] previous, int source, int dest)
    {
        string path = "";
        if (dest == source)
            path += source;
        else
        {
            path += PrintPathUtil(previous, source, previous[dest]);
            path += ("->" + dest);
        }
        return path;
    }

    public void PrintPath(int[] previous, int[] dist, int count, int source)
    {
        string output = "Shortest Paths: ";
        for (int i = 0; i < count; i++)
        {
            if (dist[i] == 99999)
                output += ("(" + source + "->" + i + " @ Unreachable) ");
            else if (i != previous[i])
            {
                output += "(";
                output += PrintPathUtil(previous, source, i);
                output += (" @ " + dist[i] + ") ");
            }
        }
        Console.WriteLine(output);
    }

    public void PrimsMST()
    {
        int[] previous = new int[count];
        int[] dist = new int[count];
        int source = 0;
        bool[] visited = new bool[count];
        Array.Fill(previous, -1);
        Array.Fill(dist, int.MaxValue); // infinite

        dist[source] = 0;
        previous[source] = source;
        PriorityQueue<Edge> pq = new PriorityQueue<Edge>();
        Edge node = new Edge(source, source, 0);
        pq.Enqueue(node);

        while (pq.IsEmpty() != true)
        {
            node = pq.Dequeue();
            source = node.dest;
            visited[source] = true;
            for (int dest = 0; dest < count; dest++)
            {
                int cost = adj[source, dest];
                if (cost != 0)
                {
                    if (dist[dest] > cost && visited[dest] == false)
                    {
                        dist[dest] = cost;
                        previous[dest] = source;
                        node = new Edge(source, dest, cost);
                        pq.Enqueue(node);
                    }
                }
            }
        }

        // Printing result.
        int sum = 0;
        bool isMst = true;
        string output = "Edges are ";
        for (int i = 0; i < count; i++)
        {
            if (dist[i] == 99999)
            {
                output += ("(" + i + ", Unreachable) ");
                isMst = false;
            }
            else if (previous[i] != i)
            {
                output += ("(" + previous[i] + "->" + i + " @ " + dist[i] + ") ");
                sum += dist[i];
            }
        }

        if (isMst)
        {
            Console.WriteLine(output);
            Console.WriteLine("Total MST cost: " + sum);
        }
        else
        {
            Console.WriteLine("Can't get a Spanning Tree");
        }
    }

    // Testing code.
    public static void Main2()
    {
        GraphAM gph = new GraphAM(9);
        gph.AddUndirectedEdge(0, 1, 4);
        gph.AddUndirectedEdge(0, 7, 8);
        gph.AddUndirectedEdge(1, 2, 8);
        gph.AddUndirectedEdge(1, 7, 11);
        gph.AddUndirectedEdge(2, 3, 7);
        gph.AddUndirectedEdge(2, 8, 2);
        gph.AddUndirectedEdge(2, 5, 4);
        gph.AddUndirectedEdge(3, 4, 9);
        gph.AddUndirectedEdge(3, 5, 14);
        gph.AddUndirectedEdge(4, 5, 10);
        gph.AddUndirectedEdge(5, 6, 2);
        gph.AddUndirectedEdge(6, 7, 1);
        gph.AddUndirectedEdge(6, 8, 6);
        gph.AddUndirectedEdge(7, 8, 7);
        gph.PrimsMST();
        gph.Dijkstra(0);
    }
    /*
Edges are (0->0 @ 0) (0->1 @ 4) (5->2 @ 4) (2->3 @ 7) (3->4 @ 9) (6->5 @ 2) (7->6 @ 1) (0->7 @ 8) (2->8 @ 2) 
Total MST cost: 37
Shortest Paths: (0->1 @ 4) (0->1->2 @ 12) (0->1->2->3 @ 19) (0->7->6->5->4 @ 21) (0->7->6->5 @ 11) (0->7->6 @ 9) (0->7 @ 8) (0->1->2->8 @ 14) 
    */

    public bool HamiltonianPathUtil(int[] path, int pSize, int[] added)
    {
        // Base case full length path is found
        if (pSize == count)
        {
            return true;
        }
        for (int vertex = 0; vertex < count; vertex++)
        {
            // There is an edge from last element of path and next vertex
            // and the next vertex is not already included in the path.
            if (pSize == 0 || (adj[path[pSize - 1], vertex] == 1 && added[vertex] == 0))
            {
                path[pSize++] = vertex;
                added[vertex] = 1;
                if (HamiltonianPathUtil(path, pSize, added))
                {
                    return true;
                }
                // backtracking
                pSize--;
                added[vertex] = 0;
            }
        }
        return false;
    }

    public bool HamiltonianPath()
    {
        int[] path = new int[count];
        int[] added = new int[count];

        if (HamiltonianPathUtil(path, 0, added))
        {
            Console.Write("Hamiltonian Path found :: ");
            for (int i = 0; i < count; i++)
            {
                Console.Write(" " + path[i]);
            }
            Console.WriteLine();
            return true;
        }

        Console.WriteLine("Hamiltonian Path not found");
        return false;
    }

    public bool HamiltonianCycleUtil(int[] path, int pSize, int[] added)
    {
        // Base case full length path is found
        // this last check can be modified to make it a path.
        if (pSize == count)
        {
            if (adj[path[pSize - 1], path[0]] == 1)
            {
                path[pSize] = path[0];
                return true;
            }
            else
            {
                return false;
            }
        }
        for (int vertex = 0; vertex < count; vertex++)
        {
            // there is a path from last element and next vertex
            if (pSize == 0 || (adj[path[pSize - 1], vertex] == 1 && added[vertex] == 0))
            {
                path[pSize++] = vertex;
                added[vertex] = 1;
                if (HamiltonianCycleUtil(path, pSize, added))
                {
                    return true;
                }
                // backtracking
                pSize--;
                added[vertex] = 0;
            }
        }
        return false;
    }

    public bool HamiltonianCycle()
    {
        int[] path = new int[count + 1];
        int[] added = new int[count];
        if (HamiltonianCycleUtil(path, 0, added))
        {
            Console.Write("Hamiltonian Cycle found :: ");
            for (int i = 0; i <= count; i++)
            {
                Console.Write(" " + path[i]);
            }
            Console.WriteLine();
            return true;
        }
        Console.WriteLine("Hamiltonian Cycle not found");
        return false;
    }

    // Testing code.
    public static void Main3()
    {
        int count = 5;
        GraphAM graph = new GraphAM(count);
        int[,] adj = new int[,]
        {
        {0, 1, 0, 1, 0},
        {1, 0, 1, 1, 0},
        {0, 1, 0, 0, 1},
        {1, 1, 0, 0, 1},
        {0, 1, 1, 1, 0}
        };

        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                if (adj[i, j] == 1)
                {
                    graph.AddDirectedEdge(i, j, 1);
                }
            }
        }
        Console.WriteLine("HamiltonianPath : " + graph.HamiltonianPath());

        GraphAM graph2 = new GraphAM(count);
        int[,] adj2 = new int[,]
        {
        {0, 1, 0, 1, 0},
        {1, 0, 1, 1, 0},
        {0, 1, 0, 0, 1},
        {1, 1, 0, 0, 0},
        {0, 1, 1, 0, 0}
        };
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                if (adj2[i, j] == 1)
                {
                    graph2.AddDirectedEdge(i, j, 1);
                }
            }
        }
        Console.WriteLine("HamiltonianPath :  " + graph2.HamiltonianPath());
    }

    /*
Hamiltonian Path found ::  0 1 2 4 3
HamiltonianPath : True
Hamiltonian Path found ::  0 3 1 2 4
HamiltonianPath :  True
     */

    // Testing code.
    public static void Main4()
    {
        int count = 5;
        GraphAM graph = new GraphAM(count);
        int[,] adj = new int[,]
        {
        {0, 1, 0, 1, 0},
        {1, 0, 1, 1, 0},
        {0, 1, 0, 0, 1},
        {1, 1, 0, 0, 1},
        {0, 1, 1, 1, 0}
        };

        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                if (adj[i, j] == 1)
                {
                    graph.AddDirectedEdge(i, j, 1);
                }
            }
        }
        Console.WriteLine("HamiltonianCycle : " + graph.HamiltonianCycle());

        GraphAM graph2 = new GraphAM(count);
        int[,] adj2 = new int[,]
        {
        {0, 1, 0, 1, 0},
        {1, 0, 1, 1, 0},
        {0, 1, 0, 0, 1},
        {1, 1, 0, 0, 0},
        {0, 1, 1, 0, 0}
        };
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                if (adj2[i, j] == 1)
                {
                    graph2.AddDirectedEdge(i, j, 1);
                }
            }
        }

        Console.WriteLine("HamiltonianCycle :  " + graph2.HamiltonianCycle());
    }

    /*
Hamiltonian Cycle found ::  0 1 2 4 3 0
HamiltonianCycle : True
Hamiltonian Cycle not found
HamiltonianCycle :  False
    */
    public static void Main(string[] args)
    {
        Main1();
        Main2();
        Main3();
        Main4();
    }
}


public class PriorityQueue<T> where T : IComparable<T>
{
    private int CAPACITY = 32;
    private int count; // Number of elements in Heap
    private T[] arr; // The Heap array
    private bool isMinHeap;

    public PriorityQueue(bool isMin = true)
    {
        arr = new T[CAPACITY];
        count = 0;
        isMinHeap = isMin;
    }

    public PriorityQueue(T[] array, bool isMin = true)
    {
        CAPACITY = count = array.Length;
        arr = array;
        isMinHeap = isMin;
        // Build Heap operation over array
        for (int i = (count / 2); i >= 0; i--)
        {
            PercolateDown(i);
        }
    }

    // Other Methods.
    private bool Compare(T[] arr, int first, int second)
    {
        if (isMinHeap)
            return arr[first].CompareTo(arr[second]) > 0;
        else
            return arr[first].CompareTo(arr[second]) < 0;
    }

    private void PercolateDown(int parent)
    {
        int lChild = 2 * parent + 1;
        int rChild = lChild + 1;
        int child = -1;
        T temp;

        if (lChild < count)
        {
            child = lChild;
        }

        if (rChild < count && Compare(arr, lChild, rChild))
        {
            child = rChild;
        }

        if (child != -1 && Compare(arr, parent, child))
        {
            temp = arr[parent];
            arr[parent] = arr[child];
            arr[child] = temp;
            PercolateDown(child);
        }
    }

    private void PercolateUp(int child)
    {
        int parent = (child - 1) / 2;
        T temp;
        if (parent < 0)
        {
            return;
        }

        if (Compare(arr, parent, child))
        {
            temp = arr[child];
            arr[child] = arr[parent];
            arr[parent] = temp;
            PercolateUp(parent);
        }
    }

    public void Enqueue(T value)
    {
        if (count == CAPACITY)
        {
            DoubleSize();
        }

        arr[count++] = value;
        PercolateUp(count - 1);
    }

    private void DoubleSize()
    {
        T[] old = arr;
        arr = new T[arr.Length * 2];
        CAPACITY *= 2;
        Array.Copy(old, 0, arr, 0, count);
    }

    public T Dequeue()
    {
        if (count == 0)
        {
            throw new System.InvalidOperationException();
        }

        T value = arr[0];
        arr[0] = arr[count - 1];
        count--;
        PercolateDown(0);
        return value;
    }

    public void Print()
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    public bool IsEmpty()
    {
        return (count == 0);
    }

    public int Size()
    {
        return count;
    }

    public T Peek()
    {
        if (count == 0)
        {
            throw new System.InvalidOperationException();
        }
        return arr[0];
    }

    public static void HeapSort(int[] array, bool inc)
    {
        // Create max heap for increasing order sorting.
        PriorityQueue<int> hp = new PriorityQueue<int>(array, !inc);
        for (int i = 0; i < array.Length; i++)
        {
            array[array.Length - i - 1] = hp.Dequeue();
        }
    }
}
