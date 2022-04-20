
using System;
using System.Collections.Generic;

public class Graph
{
    private int count;
    private List<List<Edge>> Adj;
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

    public Graph(int cnt)
    {
        count = cnt;
        Adj = new List<List<Edge>>();
        for (int i = 0; i < cnt; i++)
        {
            Adj.Add(new List<Edge>());
        }
    }

    public void AddDirectedEdge(int source, int dest, int cost)
    {
        Edge edge = new Edge(source, dest, cost);
        Adj[source].Add(edge);
    }

    public void AddDirectedEdge(int source, int dest)
    {
        AddDirectedEdge(source, dest, 1);
    }

    public void AddUndirectedEdge(int source, int dest, int cost)
    {
        AddDirectedEdge(source, dest, cost);
        AddDirectedEdge(dest, source, cost);
    }

    public void AddUndirectedEdge(int source, int dest)
    {
        AddUndirectedEdge(source, dest, 1);
    }

    public void Print()
    {
        for (int i = 0; i < count; i++)
        {
            List<Edge> ad = Adj[i];
            Console.Write("Vertex " + i + " is connected to : ");
            foreach (Edge adn in ad)
            {
                Console.Write(adn.dest + "(cost: " + adn.cost + ") ");
            }
            Console.WriteLine();
        }
    }

    public bool DFSStack(int source, int target)
    {
        bool[] visited = new bool[count];
        Stack<int> stk = new Stack<int>();
        stk.Push(source);
        visited[source] = true;

        while (stk.Count > 0)
        {
            int curr = stk.Pop();
            List<Edge> adl = Adj[curr];
            foreach (Edge adn in adl)
            {
                if (visited[adn.dest] == false)
                {
                    visited[adn.dest] = true;
                    stk.Push(adn.dest);
                }
            }
        }
        return visited[target];
    }

    public bool DFS(int source, int target)
    {
        bool[] visited = new bool[count];
        DFSUtil(source, visited);
        return visited[target];
    }

    private void DFSUtil(int index, bool[] visited)
    {
        visited[index] = true;
        List<Edge> adl = Adj[index];
        foreach (Edge adn in adl)
        {
            if (visited[adn.dest] == false)
            {
                DFSUtil(adn.dest, visited);
            }
        }
    }

    public void DFSUtil2(int index, bool[] visited, Stack<int> stk)
    {
        visited[index] = true;
        List<Edge> adl = Adj[index];
        foreach (Edge adn in adl)
        {
            if (visited[adn.dest] == false)
            {
                DFSUtil2(adn.dest, visited, stk);
            }
        }
        stk.Push(index);
    }

    public bool BFS(int source, int target)
    {
        bool[] visited = new bool[count];
        Queue<int> que = new Queue<int>();
        que.Enqueue(source);
        visited[source] = true;

        while (que.Count > 0)
        {
            int curr = que.Dequeue();
            List<Edge> adl = Adj[curr];
            foreach (Edge adn in adl)
            {
                if (visited[adn.dest] == false)
                {
                    visited[adn.dest] = true;
                    que.Enqueue(adn.dest);
                }
            }
        }
        return visited[target];
    }

    // Testing Code
    public static void Main1()
    {
        Graph gph = new Graph(4);
        gph.AddDirectedEdge(0, 1);
        gph.AddDirectedEdge(0, 2);
        gph.AddDirectedEdge(1, 2);
        gph.AddDirectedEdge(2, 3);
        gph.Print();
    }

    // Testing Code
    public static void Main2()
    {
        Graph gph = new Graph(8);
        gph.AddUndirectedEdge(0, 3);
        gph.AddUndirectedEdge(0, 2);
        gph.AddUndirectedEdge(0, 1);
        gph.AddUndirectedEdge(1, 4);
        gph.AddUndirectedEdge(2, 5);
        gph.AddUndirectedEdge(3, 6);
        gph.AddUndirectedEdge(6, 7);
        gph.AddUndirectedEdge(5, 7);
        gph.AddUndirectedEdge(4, 7);

        Console.WriteLine("Path between 0 & 6 : " + gph.DFS(0, 6));
        Console.WriteLine("Path between 0 & 6 : " + gph.BFS(0, 6));
        Console.WriteLine("Path between 0 & 6 : " + gph.DFSStack(0, 6));
    }

    /*
Path between 0 & 6 : True
Path between 0 & 6 : True
Path between 0 & 6 : True
    */

    public void TopologicalSort()
    {
        Stack<int> stk = new Stack<int>();
        bool[] visited = new bool[count];

        for (int i = 0; i < count; i++)
        {
            if (visited[i] == false)
            {
                DFSUtil2(i, visited, stk);
            }
        }
        Console.Write("Topological Sort::");
        while (stk.Count == 0 != true)
        {
            Console.Write(" " + stk.Pop());
        }
    }

    // Testing Code
    public static void Main3()
    {
        Graph gph = new Graph(9);
        gph.AddDirectedEdge(0, 2);
        gph.AddDirectedEdge(1, 2);
        gph.AddDirectedEdge(1, 3);
        gph.AddDirectedEdge(1, 4);
        gph.AddDirectedEdge(3, 2);
        gph.AddDirectedEdge(3, 5);
        gph.AddDirectedEdge(4, 5);
        gph.AddDirectedEdge(4, 6);
        gph.AddDirectedEdge(5, 7);
        gph.AddDirectedEdge(6, 7);
        gph.AddDirectedEdge(7, 8);
        gph.TopologicalSort();
    }

    /*
        TopologicalSort ::  1 4 6 3 5 7 8 0 2
    */

    public bool PathExist(int source, int dest)
    {
        bool[] visited = new bool[count];
        DFSUtil(source, visited);
        return visited[dest];
    }

    public int CountAllPathDFS(bool[] visited, int source, int dest)
    {
        if (source == dest)
        {
            return 1;
        }
        int count = 0;
        visited[source] = true;
        List<Edge> adl = Adj[source];
        foreach (Edge adn in adl)
        {
            if (visited[adn.dest] == false)
            {
                count += CountAllPathDFS(visited, adn.dest, dest);
            }
        }
        visited[source] = false;
        return count;
    }

    public int CountAllPath(int src, int dest)
    {
        bool[] visited = new bool[count];
        return CountAllPathDFS(visited, src, dest);
    }

    public void PrintAllPathDFS(bool[] visited, int source, int dest, Stack<int> path)
    {
        path.Push(source);
        if (source == dest)
        {
            foreach(int item in path)
                Console.Write(item + " ");
            Console.WriteLine();
            path.Pop();
            return;
        }
        visited[source] = true;
        List<Edge> adl = Adj[source];
        foreach (Edge adn in adl)
        {
            if (visited[adn.dest] == false)
            {
                PrintAllPathDFS(visited, adn.dest, dest, path);
            }
        }
        visited[source] = false;
        path.Pop();
    }

    public void PrintAllPath(int src, int dest)
    {
        bool[] visited = new bool[count];
        Stack<int> path = new Stack<int>();
        PrintAllPathDFS(visited, src, dest, path);
    }

    // Testing Code
    public static void Main4()
    {
        Graph gph = new Graph(5);
        gph.AddDirectedEdge(0, 1);
        gph.AddDirectedEdge(0, 2);
        gph.AddDirectedEdge(2, 3);
        gph.AddDirectedEdge(1, 3);
        gph.AddDirectedEdge(3, 4);
        gph.AddDirectedEdge(1, 4);
        Console.WriteLine("PathExist :: " + gph.PathExist(0, 4));
        Console.WriteLine("Path Count :: " + gph.CountAllPath(0, 4));
        gph.PrintAllPath(0, 4);
    }

    /*
PathExist :: True
Path Count :: 3
4 3 1 0 
4 1 0 
4 3 2 0 
    */

    public int RootVertex()
    {
        bool[] visited = new bool[count];
        int retVal = -1;
        for (int i = 0; i < count; i++)
        {
            if (visited[i] == false)
            {
                DFSUtil(i, visited);
                retVal = i;
            }
        }
        Console.Write("Root vertex is :: " + retVal);
        return retVal;
    }

    // Testing Code
    public static void Main5()
    {
        Graph gph = new Graph(7);
        gph.AddDirectedEdge(0, 1);
        gph.AddDirectedEdge(0, 2);
        gph.AddDirectedEdge(1, 3);
        gph.AddDirectedEdge(4, 1);
        gph.AddDirectedEdge(6, 4);
        gph.AddDirectedEdge(5, 6);
        gph.AddDirectedEdge(5, 2);
        gph.AddDirectedEdge(6, 0);
        gph.RootVertex();
    }

    /*
    Root vertex is :: 5
    */

    /*
    * Given a directed graph, Find transitive closure matrix or reach ability
    * matrix vertex v is reachable form vertex u if their is a path from u to v.
    */

    public void TransitiveClosureUtil(int source, int dest, int[,] tc)
    {
        tc[source, dest] = 1;
        List<Edge> adl = Adj[dest];
        foreach (Edge adn in adl)
        {
            if (tc[source, adn.dest] == 0)
            {
                TransitiveClosureUtil(source, adn.dest, tc);
            }
        }
    }

    public int[,] TransitiveClosure()
    {
        int[, ] tc = new int[count, count];
        for (int i = 0; i < count; i++)
        {
            TransitiveClosureUtil(i, i, tc);
        }
        return tc;
    }

    // Testing Code
    public static void Main6()
    {
        Graph gph = new Graph(4);
        gph.AddDirectedEdge(0, 1);
        gph.AddDirectedEdge(0, 2);
        gph.AddDirectedEdge(1, 2);
        gph.AddDirectedEdge(2, 0);
        gph.AddDirectedEdge(2, 3);
        gph.AddDirectedEdge(3, 3);
        int[,] tc = gph.TransitiveClosure();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(tc[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    /*
    1 1 1 1 
    1 1 1 1 
    1 1 1 1 
    0 0 0 1 
    */

    public void BFSLevelNode(int source)
    {
        bool[] visited = new bool[count];
        int[] level = new int[count];
        visited[source] = true;
        Queue<int> que = new Queue<int>();
        que.Enqueue(source);
        level[source] = 0;
        Console.WriteLine("Node  - Level");

        while (que.Count > 0)
        {
            int curr = que.Dequeue();
            int depth = level[curr];
            List<Edge> adl = Adj[curr];
            Console.WriteLine(curr + " - " + depth);
            foreach (Edge adn in adl)
            {
                if (visited[adn.dest] == false)
                {
                    visited[adn.dest] = true;
                    que.Enqueue(adn.dest);
                    level[adn.dest] = depth + 1;
                }
            }
        }
    }

    public int BFSDistance(int source, int dest)
    {
        bool[] visited = new bool[count];
        Queue<int> que = new Queue<int>();
        que.Enqueue(source);
        visited[source] = true;
        int[] level = new int[count];
        level[source] = 0;

        while (que.Count > 0)
        {
            int curr = que.Dequeue();
            int depth = level[curr];
            List<Edge> adl = Adj[curr];
            foreach (Edge adn in adl)
            {
                if (adn.dest == dest)
                {
                    return depth + 1;
                }
                if (visited[adn.dest] == false)
                {
                    visited[adn.dest] = true;
                    que.Enqueue(adn.dest);
                    level[adn.dest] = depth + 1;
                }
            }
        }
        return -1;
    }

    // Testing Code
    public static void Main7()
    {
        Graph gph = new Graph(7);
        gph.AddUndirectedEdge(0, 1);
        gph.AddUndirectedEdge(0, 2);
        gph.AddUndirectedEdge(0, 4);
        gph.AddUndirectedEdge(1, 2);
        gph.AddUndirectedEdge(2, 5);
        gph.AddUndirectedEdge(3, 4);
        gph.AddUndirectedEdge(4, 5);
        gph.AddUndirectedEdge(4, 6);
        gph.BFSLevelNode(1);
        Console.WriteLine("BfsDistance(1, 6) : " + gph.BFSDistance(1, 6));
    }
    /*
Node  - Level
1 - 0
0 - 1
2 - 1
4 - 2
5 - 2
3 - 3
6 - 3

BfsDistance(1, 6) : 3
    */

    public bool IsCyclePresentUndirectedDFS(int index, int parentIndex, bool[] visited)
    {
        visited[index] = true;
        int dest;
        List<Edge> adl = Adj[index];
        foreach (Edge adn in adl)
        {
            dest = adn.dest;
            if (visited[dest] == false)
            {
                if (IsCyclePresentUndirectedDFS(dest, index, visited))
                {
                    return true;
                }
            }
            else if (parentIndex != dest)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsCyclePresentUndirected()
    {
        bool[] visited = new bool[count];
        for (int i = 0; i < count; i++)
        {
            if (visited[i] == false && IsCyclePresentUndirectedDFS(i, -1, visited))
            {
                    return true;
            }
        }
        return false;
    }

    public int Find(int[] parent, int index)
    {
        int p = parent[index];
        while (p != -1)
        {
            index = p;
            p = parent[index];
        }
        return index;
    }

    public void union(int[] parent, int x, int y)
    {
        parent[y] = x;
    }

    public bool IsCyclePresentUndirected2()
    {
        int[] parent = new int[count];
        Array.Fill(parent, -1);
        List<Edge> edge = new List<Edge>();
        bool[, ] flags = new bool[count, count];
        for (int i = 0; i < count; i++)
        {
            List<Edge> ad = Adj[i];
            foreach (Edge adn in ad)
            {
                // Using flags[, ] array, if considered edge x to y, 
                // then ignore edge y to x.
                if (flags[adn.dest, adn.src] == false)
                {
                    edge.Add(adn);
                    flags[adn.src, adn.dest] = true;
                }
            }
        }

        foreach (Edge e in edge)
        {
            int x = Find(parent, e.src);
            int y = Find(parent, e.dest);
            if (x == y)
            {
                return true;
            }
            union(parent, x, y);
        }
        return false;
    }

    public bool IsCyclePresentUndirected3()
    {
        //Different subsets are created.
        Sets[] sets = new Sets[count];
        for (int i = 0; i < count; i++)
        {
            sets[i] = new Sets(i, 0);
        }

        List<Edge> edge = new List<Edge>();
        bool[, ] flags = new bool[count, count];
        for (int i = 0; i < count; i++)
        {
            List<Edge> ad = Adj[i];
            foreach (Edge adn in ad)
            {
                // Using flags[, ] array, if considered edge x to y, 
                // then ignore edge y to x.
                if (flags[adn.dest, adn.src] == false)
                {
                    edge.Add(adn);
                    flags[adn.src, adn.dest] = true;
                }
            }
        }

        foreach (Edge e in edge)
        {
            int x = Find(sets, e.src);
            int y = Find(sets, e.dest);
            if (x == y)
            {
                return true;
            }
            union(sets, x, y);
        }
        return false;
    }

    // Testing Code
    public static void Main8()
    {
        Graph gph = new Graph(6);
        gph.AddUndirectedEdge(0, 1);
        gph.AddUndirectedEdge(1, 2);
        gph.AddUndirectedEdge(3, 4);
        gph.AddUndirectedEdge(4, 2);
        gph.AddUndirectedEdge(2, 5);
        Console.WriteLine("Cycle Presen : " + gph.IsCyclePresentUndirected());
        Console.WriteLine("Cycle Presen : " + gph.IsCyclePresentUndirected2());
        Console.WriteLine("Cycle Presen : " + gph.IsCyclePresentUndirected3());
        gph.AddUndirectedEdge(4, 1);
        Console.WriteLine("Cycle Presen : " + gph.IsCyclePresentUndirected());
        Console.WriteLine("Cycle Presen : " + gph.IsCyclePresentUndirected2());
        Console.WriteLine("Cycle Presen : " + gph.IsCyclePresentUndirected3());
    }

    /*
Cycle Presen : False
Cycle Presen : False
Cycle Presen : False
Cycle Presen : True
Cycle Presen : True
Cycle Presen : True
    */


    public bool IsCyclePresentDFS(int index, bool[] visited, int[] marked)
    {
        visited[index] = true;
        marked[index] = 1;
        List<Edge> adl = Adj[index];
        foreach (Edge adn in adl)
        {
            int dest = adn.dest;
            if (marked[dest] == 1)
            {
                return true;
            }

            if (visited[dest] == false)
            {
                if (IsCyclePresentDFS(dest, visited, marked))
                {
                    return true;
                }
            }
        }
        marked[index] = 0;
        return false;
    }

    public bool IsCyclePresent()
    {

        bool[] visited = new bool[count];
        int[] marked = new int[count];
        for (int index = 0; index < count; index++)
        {
            if (!visited[index])
            {
                if (IsCyclePresentDFS(index, visited, marked))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool IsCyclePresentDFSColour(int index, int[] visited)
    {
        visited[index] = 1; // 1 = grey
        int dest;
        List<Edge> adl = Adj[index];
        foreach (Edge adn in adl)
        {
            dest = adn.dest;
            if (visited[dest] == 1) // "Grey":
            {
                return true;
            }

            if (visited[dest] == 0) // "White":
            {
                if (IsCyclePresentDFSColour(dest, visited))
                {
                    return true;
                }
            }
        }
        visited[index] = 2; // "Black"
        return false;
    }

    public bool IsCyclePresentColour()
    {

        int[] visited = new int[count];
        for (int i = 0; i < count; i++)
        {
            if (visited[i] == 0) // "White"
            {
                if (IsCyclePresentDFSColour(i, visited))
                {
                    return true;
                }
            }
        }
        return false;
    }

    // Testing Code
    public static void Main9()
    {
        Graph gph = new Graph(5);
        gph.AddDirectedEdge(0, 1);
        gph.AddDirectedEdge(0, 2);
        gph.AddDirectedEdge(2, 3);
        gph.AddDirectedEdge(1, 3);
        gph.AddDirectedEdge(3, 4);
        Console.WriteLine("isCyclePresent : " + gph.IsCyclePresent());
        Console.WriteLine("isCyclePresent : " + gph.IsCyclePresentColour());
        gph.AddDirectedEdge(4, 1);
        Console.WriteLine("isCyclePresent : " + gph.IsCyclePresent());
        Console.WriteLine("isCyclePresent : " + gph.IsCyclePresentColour());
    }

    /*
isCyclePresent : False
isCyclePresent : False
isCyclePresent : True
isCyclePresent : True
    */

    public Graph TransposeGraph()
    {
        Graph g = new Graph(count);
        for (int i = 0; i < count; i++)
        {
            List<Edge> adl = Adj[i];
            foreach (Edge adn in adl)
            {
                int dest = adn.dest;
                g.AddDirectedEdge(dest, i);
            }
        }
        return g;
    }

    // Testing Code
    public static void Main10()
    {
        Graph gph = new Graph(5);
        gph.AddDirectedEdge(0, 1);
        gph.AddDirectedEdge(0, 2);
        gph.AddDirectedEdge(2, 3);
        gph.AddDirectedEdge(1, 3);
        gph.AddDirectedEdge(3, 4);
        gph.AddDirectedEdge(4, 1);

        Graph gReversed = gph.TransposeGraph();
        gReversed.Print();
    }

    /*
Vertex 0 is connected to : 
Vertex 1 is connected to : 0(cost: 1) 4(cost: 1) 
Vertex 2 is connected to : 0(cost: 1) 
Vertex 3 is connected to : 1(cost: 1) 2(cost: 1) 
Vertex 4 is connected to : 3(cost: 1) 
    */



    public bool IsConnectedUndirected()
    {
        bool[] visited = new bool[count];

        DFSUtil(0, visited);
        for (int i = 0; i < count; i++)
        {
            if (visited[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    public static void Main11()
    {
        Graph gph = new Graph(6);
        gph.AddUndirectedEdge(0, 1);
        gph.AddUndirectedEdge(1, 2);
        gph.AddUndirectedEdge(3, 4);
        gph.AddUndirectedEdge(2, 5);
        gph.AddUndirectedEdge(4, 2);
        Console.WriteLine("IsConnectedUndirected:: " + gph.IsConnectedUndirected());
    }

    /*
    IsConnectedUndirected:: True
    */
    
    public bool IsStronglyConnected()
    {
        bool[] visited = new bool[count];

        DFSUtil(0, visited);
        for (int i = 0; i < count; i++)
        {
            if (visited[i] == false)
            {
                return false;
            }
        }
        Graph gReversed = TransposeGraph();
        for (int i = 0; i < count; i++)
        {
            visited[i] = false;
        }
        gReversed.DFSUtil(0, visited);
        for (int i = 0; i < count; i++)
        {
            if (visited[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    // Testing Code
    public static void Main12()
    {
        Graph gph = new Graph(5);
        gph.AddDirectedEdge(0, 1);
        gph.AddDirectedEdge(1, 2);
        gph.AddDirectedEdge(2, 3);
        gph.AddDirectedEdge(3, 0);
        gph.AddDirectedEdge(2, 4);
        gph.AddDirectedEdge(4, 2);
        Console.WriteLine("IsStronglyConnected:: " + gph.IsStronglyConnected());
    }

    /*
    IsStronglyConnected:: True
    */

    public void stronglyConnectedComponent()
    {
        bool[] visited = new bool[count];

        Stack<int> stk = new Stack<int>();
        for (int i = 0; i < count; i++)
        {
            if (visited[i] == false)
            {
                DFSUtil2(i, visited, stk);
            }
        }

        Graph gReversed = TransposeGraph();
        Array.Fill(visited, false);

        Stack<int> stk2 = new Stack<int>();
        while (stk.Count > 0)
        {
            int index = stk.Pop();
            if (visited[index] == false)
            {
                stk2.Clear();
                gReversed.DFSUtil2(index, visited, stk2);
                foreach(var ele in stk2)
                    Console.Write(ele + " ");
                Console.WriteLine();
            }
        }
    }

    // Testing Code
    public static void Main13()
    {
        Graph gph = new Graph(7);
        gph.AddDirectedEdge(0, 1);
        gph.AddDirectedEdge(1, 2);
        gph.AddDirectedEdge(2, 0);
        gph.AddDirectedEdge(2, 3);
        gph.AddDirectedEdge(3, 4);
        gph.AddDirectedEdge(4, 5);
        gph.AddDirectedEdge(5, 3);
        gph.AddDirectedEdge(5, 6);
        gph.stronglyConnectedComponent();

    }

    /*
0 2 1 
3 5 4 
6 
    */

    public void PrimsMST()
    {
        int[] previous = new int[count];
        Array.Fill(previous, -1);
        int[] dist = new int[count];
        Array.Fill(dist, 99999); // infinite
        bool[] visited = new bool[count];

        int source = 0;
        dist[source] = 0;
        previous[source] = source;

        PriorityQueue<Edge> pq = new PriorityQueue<Edge>();
        Edge node = new Edge(source, source, 0);
        pq.Enqueue(node);

        while (pq.IsEmpty() != true)
        {
            node = pq.Peek();
            pq.Dequeue();
            visited[source] = true;
            source = node.dest;
            List<Edge> adl = Adj[source];
            foreach (Edge adn in adl)
            {
                int dest = adn.dest;
                int alt = adn.cost;
                if (dist[dest] > alt && visited[dest] == false)
                {
                    dist[dest] = alt;
                    previous[dest] = source;
                    node = new Edge(source, dest, alt);
                    pq.Enqueue(node);
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
            else
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

    public class Sets
    {
        internal int parent;
        internal int rank;
        internal Sets(int p, int r)
        {
            parent = p;
            rank = r;
        }
    }

    public int Find(Sets[] sets, int index)
    {
        int p = sets[index].parent;
        while (p != index)
        {
            index = p;
            p = sets[index].parent;
        }
        return index;
    }

    // consider x and y are roots of sets.
    public void union(Sets[] sets, int x, int y)
    {
        if (sets[x].rank < sets[y].rank)
        {
            sets[x].parent = y;
        }
        else if (sets[y].rank < sets[x].rank)
        {
            sets[y].parent = x;
        }
        else
        {
            sets[x].parent = y;
            sets[y].rank++;
        }
    }

    public void KruskalMST()
    {
        //Different subsets are created.
        Sets[] sets = new Sets[count];
        for (int i = 0; i < count; i++)
        {
            sets[i] = new Sets(i, 0);
        }

        // Edges are added to array and sorted.
        int E = 0;
        Edge[] edge = new Edge[100];
        for (int i = 0; i < count; i++)
        {
            List<Edge> ad = Adj[i];
            foreach (Edge adn in ad)
            {
                edge[E++] = adn;
            }
        }
        Array.Sort(edge, 0, E-1);

        int sum = 0;
        string output = "Edges are ";
        for (int i = 0; i < E; i++)
        {
            int x = Find(sets, edge[i].src);
            int y = Find(sets, edge[i].dest);
            if (x != y)
            {
                output += ("(" + edge[i].src + "->" + edge[i].dest + " @ " + edge[i].cost + ") ");
                sum += edge[i].cost;
                union(sets, x, y);
            }
        }
        Console.WriteLine(output);
        Console.WriteLine("Total MST cost: " + sum);
    }

    // Testing Code
    public static void Main14()
    {
        Graph gph = new Graph(9);
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
        Console.WriteLine();
        gph.KruskalMST();
        Console.WriteLine();
        gph.Dijkstra(0);
    }

    /*
Edges are (0->0 @ 0) (0->1 @ 4) (5->2 @ 4) (2->3 @ 7) (3->4 @ 9) (6->5 @ 2) (7->6 @ 1) (0->7 @ 8) (2->8 @ 2) 
Total MST cost: 37

Edges are (7->6 @ 1) (6->5 @ 2) (2->8 @ 2) (0->1 @ 4) (2->5 @ 4) (3->2 @ 7) (2->1 @ 8) (4->3 @ 9) 
Total MST cost: 37


Shortest Paths: (0->1 @ 4) (0->1->2 @ 12) (0->1->2->3 @ 19) (0->7->6->5->4 @ 21) (0->7->6->5 @ 11) (0->7->6 @ 9) (0->7 @ 8) (0->1->2->8 @ 14) 
    */


    public void ShortestPath(int source)
    {
        int curr;
        int[] distance = new int[count];
        int[] previous = new int[count];
        Array.Fill(distance, -1);
        Array.Fill(previous, -1);

        Queue<int> que = new Queue<int>();
        que.Enqueue(source);
        distance[source] = 0;
        previous[source] = source;

        while (que.Count > 0)
        {
            curr = que.Dequeue();
            List<Edge> adl = Adj[curr];
            foreach (Edge adn in adl)
            {
                if (distance[adn.dest] == -1)
                {
                    distance[adn.dest] = distance[curr] + 1;
                    previous[adn.dest] = curr;
                    que.Enqueue(adn.dest);
                }
            }
        }
        PrintPath(previous, distance, count, source);
    }

    public void Dijkstra(int source)
    {
        int[] previous = new int[count];
        Array.Fill(previous, -1);
        int[] dist = new int[count];
        Array.Fill(dist, int.MaxValue); // infinite
        bool[] visited = new bool[count];

        dist[source] = 0;
        previous[source] = source;

        PriorityQueue<Edge> pq = new PriorityQueue<Edge>();
        Edge node = new Edge(source, source, 0);
        pq.Enqueue(node);
        int curr;

        while (pq.IsEmpty() != true)
        {
            node = pq.Peek();
            pq.Dequeue();
            curr = node.dest;
            visited[curr] = true;
            List<Edge> adl = Adj[curr];
            foreach (Edge adn in adl)
            {
                int dest = adn.dest;
                int alt = adn.cost + dist[curr];
                if (dist[dest] > alt && visited[dest] == false)
                {

                    dist[dest] = alt;
                    previous[dest] = curr;
                    node = new Edge(curr, dest, alt);
                    pq.Enqueue(node);
                }
            }
        }
        PrintPath(previous, dist, count, source);
    }

    String PrintPathUtil(int[] previous, int source, int dest)
    {
        String path = "";
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

    public void BellmanFordShortestPath(int source)
    {
        int[] distance = new int[count];
        int[] path = new int[count];
        Array.Fill(distance, 99999); // infinite
        Array.Fill(path, -1);

        distance[source] = 0;
        path[source] = source;
        // Outer loop will run (V-1) number of times.
        // Inner for loop and while loop runs combined will
        // run for Edges number of times.
        // Which make the total complexity as O(V*E)

        for (int i = 0; i < count - 1; i++)
        {
            for (int j = 0; j < count; j++)
            {
                List<Edge> adl = Adj[j];
                foreach (Edge adn in adl)
                {
                    int newDistance = distance[j] + adn.cost;
                    if (distance[adn.dest] > newDistance)
                    {
                        distance[adn.dest] = newDistance;
                        path[adn.dest] = j;
                    }

                }
            }
        }
        PrintPath(path, distance, count, source);
    }

    // Testing Code
    public static void Main16()
    {
        Graph gph = new Graph(5);
        gph.AddDirectedEdge(0, 1, 3);
        gph.AddDirectedEdge(0, 4, 2);
        gph.AddDirectedEdge(1, 2, 1);
        gph.AddDirectedEdge(2, 3, 1);
        gph.AddDirectedEdge(4, 1, -2);
        gph.AddDirectedEdge(4, 3, 1);
        gph.BellmanFordShortestPath(0);
    }

    /*
Shortest Paths: (0->4->1 @ 0) (0->4->1->2 @ 1) (0->4->1->2->3 @ 2) (0->4 @ 2) 
    */

    public static int HeightTreeParentArr(int[] arr)
    {
        int count = arr.Length;
        int[] heightArr = new int[count];
        Graph gph = new Graph(count);
        int source = 0;
        for (int i = 0; i < count; i++)
        {
            if (arr[i] != -1)
            {
                gph.AddDirectedEdge(arr[i], i);
            }
            else
            {
                source = i;
            }
        }
        bool[] visited = new bool[count];
        visited[source] = true;
        Queue<int> que = new Queue<int>();
        que.Enqueue(source);
        heightArr[source] = 0;
        int maxHight = 0;
        while (que.Count > 0)
        {
            int curr = que.Dequeue();
            int height = heightArr[curr];
            if (height > maxHight)
            {
                maxHight = height;
            }
            List<Edge> adl = gph.Adj[curr];
            foreach (Edge adn in adl)
            {
                if (visited[adn.dest] == false)
                {
                    visited[adn.dest] = true;
                    que.Enqueue(adn.dest);
                    heightArr[adn.dest] = height + 1;
                }
            }
        }
        return maxHight;
    }

    public static int GetHeight(int[] arr, int[] height, int index)
    {
        if (arr[index] == -1)
        {
            return 0;
        }
        else
        {
            return GetHeight(arr, height, arr[index]) + 1;
        }
    }

    public static int HeightTreeParentArr2(int[] arr)
    {
        int count = arr.Length;
        int[] height = new int[count];
        int maxHeight = -1;
        for (int i = 0; i < count; i++)
        {
            height[i] = GetHeight(arr, height, i);
            maxHeight = Math.Max(maxHeight, height[i]);
        }
        return maxHeight;
    }

    // Testing Code
    public static void Main17()
    {
        int[] parentArray = new int[] {-1, 0, 1, 2, 3};
        Console.WriteLine(HeightTreeParentArr(parentArray));
        Console.WriteLine(HeightTreeParentArr2(parentArray));
    }

    /*
    4
    4
    */

    public int BestFirstSearchPQ(int source, int dest)
    {
        int[] previous = new int[count];
        int[] dist = new int[count];
        bool[] visited = new bool[count];
        for (int i = 0; i < count; i++)
        {
            previous[i] = -1;
            dist[i] = int.MaxValue; // infinite
        }
        PriorityQueue<Edge> pq = new PriorityQueue<Edge>();
        dist[source] = 0;
        previous[source] = -1;
        Edge node = new Edge(source, source, 0);
        pq.Enqueue(node);

        while (pq.IsEmpty() != true)
        {
            node = pq.Peek();
            pq.Dequeue();
            source = node.dest;
            if (source == dest)
            {
                return node.cost;
            }
            visited[source] = true;

            List<Edge> adl = Adj[source];
            foreach (Edge adn in adl)
            {
                int curr = adn.dest;
                int cost = adn.cost;
                int alt = cost + dist[source];
                if (dist[curr] > alt && visited[curr] == false)
                {
                    dist[curr] = alt;
                    previous[curr] = source;
                    node = new Edge(source, curr, alt);
                    pq.Enqueue(node);
                }
            }
        }
        return -1;
    }

    public bool IsConnected()
    {
        bool[] visited = new bool[count];

        // Find a vertex with non - zero degree
        // DFS traversal of graph from a vertex with non - zero degree
        List<Edge> adl;
        for (int i = 0; i < count; i++)
        {
            adl = Adj[i];
            if (adl.Count > 0)
            {
                DFSUtil(i, visited);
                break;
            }
        }
        // Check if all non - zero degree count are visited
        for (int i = 0; i < count; i++)
        {
            adl = Adj[i];
            if (adl.Count > 0)
            {
                if (visited[i] == false)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public int IsEulerian()
    {
        int odd;
        int[] inDegree;
        int[] outDegree;
        List<Edge> adl;
        // Check if all non - zero degree nodes are connected
        if (IsConnected() == false)
        {
            Console.WriteLine("graph is not Eulerian");
            return 0;
        }
        else
        {
            // Count odd degree
            odd = 0;
            inDegree = new int[count];
            outDegree = new int[count];

            for (int i = 0; i < count; i++)
            {
                adl = Adj[i];
                foreach (Edge adn in adl)
                {
                    outDegree[i] += 1;
                    inDegree[adn.dest] += 1;
                }
            }
            for (int i = 0; i < count; i++)
            {
                if ((inDegree[i] + outDegree[i]) % 2 != 0)
                {
                    odd += 1;
                }
            }
        }

        if (odd == 0)
        {
            Console.WriteLine("graph is Eulerian");
            return 2;
        }
        else if (odd == 2)
        {
            Console.WriteLine("graph is Semi-Eulerian");
            return 1;
        }
        else
        {
            Console.WriteLine("graph is not Eulerian");
            return 0;
        }
    }

    // Testing Code
    public static void Main18()
    {
        Graph gph = new Graph(5);
        gph.AddDirectedEdge(1, 0);
        gph.AddDirectedEdge(0, 2);
        gph.AddDirectedEdge(2, 1);
        gph.AddDirectedEdge(0, 3);
        gph.AddDirectedEdge(3, 4);
        gph.IsEulerian();
        gph.AddDirectedEdge(4, 0);
        gph.IsEulerian();
    }

    /*
graph is Semi-Eulerian
graph is Eulerian
    */

    public bool IsStronglyConnected2()
    {
        bool[] visited = new bool[count];
        Graph gReversed;
        int index;
        // Find a vertex with non - zero degree
        List<Edge> adl;
        for (index = 0; index < count; index++)
        {
            adl = Adj[index];
            if (adl.Count > 0)
            {
                break;
            }
        }
        // DFS traversal of graph from a vertex with non - zero degree
        DFSUtil(index, visited);
        for (int i = 0; i < count; i++)
        {
            adl = Adj[i];
            if (visited[i] == false && adl.Count > 0)
            {
                return false;
            }
        }

        gReversed = TransposeGraph();
        for (int i = 0; i < count; i++)
        {
            visited[i] = false;
        }
        gReversed.DFSUtil(index, visited);

        for (int i = 0; i < count; i++)
        {
            adl = Adj[i];
            if (visited[i] == false && adl.Count > 0)
            {
                return false;
            }
        }
        return true;
    }

    public bool IsEulerianCycle()
    {
        // Check if all non - zero degree count are connected
        int[] inDegree = new int[count];
        int[] outDegree = new int[count];
        if (!IsStronglyConnected2())
        {
            return false;
        }

        // Check if in degree and out degree of every vertex is same
        for (int i = 0; i < count; i++)
        {
            List<Edge> adl = Adj[i];
            foreach (Edge adn in adl)
            {
                outDegree[i] += 1;
                inDegree[adn.dest] += 1;
            }
        }
        for (int i = 0; i < count; i++)
        {
            if (inDegree[i] != outDegree[i])
            {
                return false;
            }
        }
        return true;
    }

    // Testing Code
    public static void Main19()
    {
        Graph gph = new Graph(5);
        gph.AddDirectedEdge(0, 1);
        gph.AddDirectedEdge(1, 2);
        gph.AddDirectedEdge(2, 0);
        gph.AddDirectedEdge(0, 4);
        gph.AddDirectedEdge(4, 3);
        gph.AddDirectedEdge(3, 0);
        Console.WriteLine(gph.IsEulerianCycle());
    }

    /*
    True
    */

    // Testing Code
    public static void Main20()
    {
        Graph gph = new Graph(9);
        gph.AddUndirectedEdge(0, 1);
        gph.AddUndirectedEdge(0, 7);
        gph.AddUndirectedEdge(1, 2);
        gph.AddUndirectedEdge(1, 7);
        gph.AddUndirectedEdge(2, 3);
        gph.AddUndirectedEdge(2, 8);
        gph.AddUndirectedEdge(2, 5);
        gph.AddUndirectedEdge(3, 4);
        gph.AddUndirectedEdge(3, 5);
        gph.AddUndirectedEdge(4, 5);
        gph.AddUndirectedEdge(5, 6);
        gph.AddUndirectedEdge(6, 7);
        gph.AddUndirectedEdge(6, 8);
        gph.AddUndirectedEdge(7, 8);
        gph.ShortestPath(0);
    }

    /*
Shortest Paths: (0->1 @ 1) (0->1->2 @ 2) (0->1->2->3 @ 3) (0->1->2->3->4 @ 4) (0->1->2->5 @ 3) (0->7->6 @ 2) (0->7 @ 1) (0->7->8 @ 2) 
    */
    
    internal void FloydWarshall()
    {
        int V = count;
        int[, ] dist = new int[V, V];
        int[, ] path = new int[V, V];

        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < V; j++)
            {
                dist[i, j] = 99999;
                if (i == j)
                {
                    path[i, j] = 0;
                }
                else
                {
                    path[i, j] = -1;
                }
            }
        }

        for (int i = 0; i < V; i++)
        {
            List<Edge> adl = Adj[i];
            foreach (Edge adn in adl)
            {
                path[adn.src, adn.dest] = adn.src;
                dist[adn.src, adn.dest] = adn.cost;
            }
        }

        // Pick intermediate vertices.
        for (int k = 0; k < V; k++)
        {
            // Pick source vertices one by one.
            for (int i = 0; i < V; i++)
            {
                // Pick destination vertices.
                for (int j = 0; j < V; j++)
                {
                    // If we have a shorter path from i to j via k.
                    // then update dist[i, j] and  and path[i, j]
                    if (dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                        path[i, j] = path[k, j];
                    }
                }
                // dist[i, i] is 0 in the start.
                // If there is a better path from i to i and is better path then we have -ve cycle.                //
                if (dist[i, i] < 0)
                {
                    Console.WriteLine("Negative-weight cycle found.");
                        return;
                }
            }
        }
        PrintSolution(dist, path, V);
    }

    private void PrintSolution(int[,] cost, int[,] path, int V)
    {
        Console.Write("Shortest Paths : ");
        for (int u = 0; u < V; u++)
        {
            for (int v = 0; v < V; v++)
            {
                if (u != v && path[u, v] != -1)
                {
                Console.Write("(");
                PrintPath(path, u, v);
                Console.Write(" @ " + cost[u, v] + ") ");
                }
            }
        }
        Console.WriteLine();
    }

    private void PrintPath(int[,] path, int u, int v)
    {
        if (path[u, v] == u)
        {
            Console.Write(u + "->" + v);
            return;
        }
        PrintPath(path, u, path[u, v]);
        Console.Write("->" + v);
    }

    // Testing code.
    public static void Main21()
    {
        Graph gph = new Graph(4);
        gph.AddDirectedEdge(0, 0, 0);
        gph.AddDirectedEdge(1, 1, 0);
        gph.AddDirectedEdge(2, 2, 0);
        gph.AddDirectedEdge(3, 3, 0);

        gph.AddDirectedEdge(0, 1, 5);
        gph.AddDirectedEdge(0, 3, 10);
        gph.AddDirectedEdge(1, 2, 3);
        gph.AddDirectedEdge(2, 3, 1);
        gph.FloydWarshall();
    }

    /*
Shortest Paths : (0->1 @ 5) (0->1->2 @ 8) (0->1->2->3 @ 9) (1->2 @ 3) (1->2->3 @ 4) (2->3 @ 1) 
    */

    internal void PrintSolution(int[,] dist, int V)
    {    
        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < V; j++)
            {
                if (dist[i, j] == int.MaxValue)
                {
                    Console.Write("INF ");
                }
                else
                {
                    Console.Write(dist[i, j] + "   ");
                }
            }
            Console.WriteLine();
        }
    }


    public static void Main(string[] args)
    {
        Main1();
        Main2(); 
        Main3(); 
        Main4(); 
        Main5();
        Main6();
        Main7();
        Main8();
        Main9();
        Main10();
        Main11();
        Main12();
        Main13();
        Main14();
        Main16();
        Main17();
        Main18();
        Main19();
        Main20();
        Main21();
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

    public void HeapSort(int[] array, bool inc)
    {
        // Create max heap for increasing order sorting.
        PriorityQueue<int> hp = new PriorityQueue<int>(array, !inc);
        for (int i = 0; i < array.Length; i++)
        {
            array[array.Length - i - 1] = hp.Dequeue();
        }
    }
}
