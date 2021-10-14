
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
				Console.Write("(" + adn.dest + ", " + adn.cost + ") ");
			}
			Console.WriteLine();
		}
	}

	public static bool DFSStack(Graph gph, int source, int target)
	{
		int count = gph.count;
		bool[] visited = new bool[count];
		Stack<int> stk = new Stack<int>();
		stk.Push(source);
		visited[source] = true;

		while (stk.Count > 0)
		{
			int curr = stk.Pop();
			List<Edge> adl = gph.Adj[curr];
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

	public static bool DFS(Graph gph, int source, int target)
	{
		int count = gph.count;
		bool[] visited = new bool[count];
		DFSUtil(gph, source, visited);
		return visited[target];
	}

	private static void DFSUtil(Graph gph, int index, bool[] visited)
	{
		visited[index] = true;
		List<Edge> adl = gph.Adj[index];
		foreach (Edge adn in adl)
		{
			if (visited[adn.dest] == false)
			{
				DFSUtil(gph, adn.dest, visited);
			}
		}
	}

	public static void DFSUtil2(Graph gph, int index, bool[] visited, Stack<int> stk)
	{
		visited[index] = true;
		List<Edge> adl = gph.Adj[index];
		foreach (Edge adn in adl)
		{
			if (visited[adn.dest] == false)
			{
				DFSUtil2(gph, adn.dest, visited, stk);
			}
		}
		stk.Push(index);
	}

	public static bool BFS(Graph gph, int source, int target)
	{
		int count = gph.count;
		bool[] visited = new bool[count];
		Queue<int> que = new Queue<int>();
		que.Enqueue(source);
		visited[source] = true;

		while (que.Count > 0)
		{
			int curr = que.Dequeue();
			List<Edge> adl = gph.Adj[curr];
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
		Graph gph = new Graph(5);
		gph.AddDirectedEdge(0, 1, 3);
		gph.AddDirectedEdge(0, 4, 2);
		gph.AddDirectedEdge(1, 2, 1);
		gph.AddDirectedEdge(2, 3, 1);
		gph.AddDirectedEdge(4, 1, -2);
		gph.AddDirectedEdge(4, 3, 1);
		gph.Print();

		Console.WriteLine(Graph.DFS(gph, 0, 2));
		Console.WriteLine(Graph.BFS(gph, 0, 2));
		Console.WriteLine(Graph.DFSStack(gph, 0, 2));
	}

	/*
	Vertex 0 is connected to : (1, 3) (4, 2) 
	Vertex 1 is connected to : (2, 1) 
	Vertex 2 is connected to : (3, 1) 
	Vertex 3 is connected to : 
	Vertex 4 is connected to : (1, -2) (3, 1) 
True
True
True
	*/

	public static void TopologicalSort(Graph gph)
	{
		Stack<int> stk = new Stack<int>();
		int count = gph.count;
		bool[] visited = new bool[count];

		for (int i = 0; i < count; i++)
		{
			if (visited[i] == false)
			{
				DFSUtil2(gph, i, visited, stk);
			}
		}
		Console.Write("Topological Sort::");
		while (stk.Count == 0 != true)
		{
			Console.Write(" " + stk.Pop());
		}
	}

	// Testing Code
	public static void Main2()
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
		TopologicalSort(gph);
	}

	/*
	    TopologicalSort ::  1 4 6 3 5 7 8 0 2
	*/

	public static bool PathExist(Graph gph, int source, int dest)
	{
		int count = gph.count;
		bool[] visited = new bool[count];
		DFSUtil(gph, source, visited);
		return visited[dest];
	}

	public static int CountAllPathDFS(Graph gph, bool[] visited, int source, int dest)
	{
		if (source == dest)
		{
			return 1;
		}
		int count = 0;
		visited[source] = true;
		List<Edge> adl = gph.Adj[source];
		foreach (Edge adn in adl)
		{
			if (visited[adn.dest] == false)
			{
				count += CountAllPathDFS(gph, visited, adn.dest, dest);
			}
		}
		visited[source] = false;
		return count;
	}

	public static int CountAllPath(Graph gph, int src, int dest)
	{
		int count = gph.count;
		bool[] visited = new bool[count];
		return CountAllPathDFS(gph, visited, src, dest);
	}

	public static void PrintAllPathDFS(Graph gph, bool[] visited, int source, int dest, Stack<int> path)
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
		List<Edge> adl = gph.Adj[source];
		foreach (Edge adn in adl)
		{
			if (visited[adn.dest] == false)
			{
				PrintAllPathDFS(gph, visited, adn.dest, dest, path);
			}
		}
		visited[source] = false;
		path.Pop();
	}

	public static void PrintAllPath(Graph gph, int src, int dest)
	{
		bool[] visited = new bool[gph.count];
		Stack<int> path = new Stack<int>();
		PrintAllPathDFS(gph, visited, src, dest, path);
	}

		// Testing Code
	public static void Main3()
	{
		Graph gph = new Graph(5);
		gph.AddDirectedEdge(0, 1);
		gph.AddDirectedEdge(0, 2);
		gph.AddDirectedEdge(2, 3);
		gph.AddDirectedEdge(1, 3);
		gph.AddDirectedEdge(3, 4);
		gph.AddDirectedEdge(1, 4);
		gph.Print();
		Console.WriteLine("PathExist :: " + PathExist(gph, 0, 4));

		Console.WriteLine();
		Console.WriteLine(CountAllPath(gph, 0, 4));
		PrintAllPath(gph, 0, 4);
	}

	/*
	Vertex 0 is connected to : (1, 1) (2, 1) 
	Vertex 1 is connected to : (3, 1) (4, 1) 
	Vertex 2 is connected to : (3, 1) 
	Vertex 3 is connected to : (4, 1) 
	Vertex 4 is connected to : 
	PathExist :: True

	3
4 3 1 0
4 1 0
4 3 2 0 
	*/

	public static int RootVertex(Graph gph)
	{
		int count = gph.count;
		bool[] visited = new bool[count];
		int retVal = -1;
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == false)
			{
				DFSUtil(gph, i, visited);
				retVal = i;
			}
		}
		Console.Write("Root vertex is :: " + retVal);
		return retVal;
	}

		// Testing Code
	public static void Main4()
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
		gph.Print();
		RootVertex(gph);
	}

	/*
	Vertex 0 is connected to : (1, 1) (2, 1) 
	Vertex 1 is connected to : (3, 1) 
	Vertex 2 is connected to : 
	Vertex 3 is connected to : 
	Vertex 4 is connected to : (1, 1) 
	Vertex 5 is connected to : (6, 1) (2, 1) 
	Vertex 6 is connected to : (4, 1) (0, 1) 
	Root vertex is :: 5
	*/

	/*
	* Given a directed graph, Find transitive closure matrix or reach ability
	* matrix vertex v is reachable form vertex u if their is a path from u to v.
	*/

	public static void TransitiveClosureUtil(Graph gph, int source, int dest, int[, ] tc)
	{
		tc[source, dest] = 1;
		List<Edge> adl = gph.Adj[dest];
		foreach (Edge adn in adl)
		{
			if (tc[source, adn.dest] == 0)
			{
				TransitiveClosureUtil(gph, source, adn.dest, tc);
			}
		}
	}

	public static int[, ] TransitiveClosure(Graph gph)
	{
		int count = gph.count;
		int[, ] tc = new int[count, count];
		for (int i = 0; i < count; i++)
		{
			TransitiveClosureUtil(gph, i, i, tc);
		}
		return tc;
	}

	// Testing Code
	public static void Main5()
	{
		Graph gph = new Graph(4);
		gph.AddDirectedEdge(0, 1);
		gph.AddDirectedEdge(0, 2);
		gph.AddDirectedEdge(1, 2);
		gph.AddDirectedEdge(2, 0);
		gph.AddDirectedEdge(2, 3);
		gph.AddDirectedEdge(3, 3);
		int[, ] tc = TransitiveClosure(gph);
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

	public static void BFSLevelNode(Graph gph, int source)
	{
		int count = gph.count;
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
			List<Edge> adl = gph.Adj[curr];
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

	public static int BFSDistance(Graph gph, int source, int dest)
	{
		int count = gph.count;
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
			List<Edge> adl = gph.Adj[curr];
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
	public static void Main6()
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
		gph.Print();
		BFSLevelNode(gph, 1);
		Console.WriteLine(BFSDistance(gph, 1, 6));
	}
	/*
	Vertex 0 is connected to : (1, 1) (2, 1) (4, 1) 
	Vertex 1 is connected to : (0, 1) (2, 1) 
	Vertex 2 is connected to : (0, 1) (1, 1) (5, 1) 
	Vertex 3 is connected to : (4, 1) 
	Vertex 4 is connected to : (0, 1) (3, 1) (5, 1) (6, 1) 
	Vertex 5 is connected to : (2, 1) (4, 1) 
	Vertex 6 is connected to : (4, 1) 

	Node  - Level
	1 - 0
	0 - 1
	2 - 1
	4 - 2
	5 - 2
	3 - 3
	6 - 3
	3
	*/

	public static bool IsCyclePresentUndirectedDFS(Graph graph, int index, int parentIndex, bool[] visited)
	{
		visited[index] = true;
		int dest;
		List<Edge> adl = graph.Adj[index];
		foreach (Edge adn in adl)
		{
			dest = adn.dest;
			if (visited[dest] == false)
			{
				if (IsCyclePresentUndirectedDFS(graph, dest, index, visited))
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

	public static bool IsCyclePresentUndirected(Graph graph)
	{
		int count = graph.count;
		bool[] visited = new bool[count];
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == false && IsCyclePresentUndirectedDFS(graph, i, -1, visited))
			{
					return true;
			}
		}
		return false;
	}

	public static int Find(int[] parent, int index)
	{
		int p = parent[index];
		while (p != -1)
		{
			index = p;
			p = parent[index];
		}
		return index;
	}

	public static void union(int[] parent, int x, int y)
	{
		parent[y] = x;
	}

	public static bool IsCyclePresentUndirected2(Graph gph)
	{
		int count = gph.count;
		int[] parent = new int[count];
		Array.Fill(parent, -1);
		List<Edge> edge = new List<Edge>();
		bool[, ] flags = new bool[count, count];
		for (int i = 0; i < count; i++)
		{
			List<Edge> ad = gph.Adj[i];
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

	public static bool IsCyclePresentUndirected3(Graph gph)
	{
		int count = gph.count;
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
			List<Edge> ad = gph.Adj[i];
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
	public static void Main7()
	{
		Graph gph = new Graph(6);
		gph.AddUndirectedEdge(0, 1);
		gph.AddUndirectedEdge(1, 2);
		gph.AddUndirectedEdge(3, 4);
		gph.AddUndirectedEdge(4, 2);
		gph.AddUndirectedEdge(2, 5);
		gph.AddUndirectedEdge(4, 1);
		Console.WriteLine(IsCyclePresentUndirected(gph));
		Console.WriteLine(IsCyclePresentUndirected2(gph));
		Console.WriteLine(IsCyclePresentUndirected3(gph));
	}

	/*
	True
True
True
	*/

	/*
	* Given a directed graph Find if there is a cycle in it.
	*/
	public static bool IsCyclePresentDFS(Graph graph, int index, bool[] visited, int[] marked)
	{
		visited[index] = true;
		marked[index] = 1;
		List<Edge> adl = graph.Adj[index];
		foreach (Edge adn in adl)
		{
			int dest = adn.dest;
			if (marked[dest] == 1)
			{
				return true;
			}

			if (visited[dest] == false)
			{
				if (IsCyclePresentDFS(graph, dest, visited, marked))
				{
					return true;
				}
			}
		}
		marked[index] = 0;
		return false;
	}

	public static bool IsCyclePresent(Graph graph)
	{
		int count = graph.count;
		bool[] visited = new bool[count];
		int[] marked = new int[count];
		for (int index = 0; index < count; index++)
		{
			if (!visited[index])
			{
				if (IsCyclePresentDFS(graph, index, visited, marked))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool IsCyclePresentDFSColour(Graph graph, int index, int[] visited)
	{
		visited[index] = 1; // 1 = grey
		int dest;
		List<Edge> adl = graph.Adj[index];
		foreach (Edge adn in adl)
		{
			dest = adn.dest;
			if (visited[dest] == 1) // "Grey":
			{
				return true;
			}

			if (visited[dest] == 0) // "White":
			{
				if (IsCyclePresentDFSColour(graph, dest, visited))
				{
					return true;
				}
			}
		}
		visited[index] = 2; // "Black"
		return false;
	}

	public static bool IsCyclePresentColour(Graph graph)
	{
		int count = graph.count;
		int[] visited = new int[count];
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == 0) // "White"
			{
				if (IsCyclePresentDFSColour(graph, i, visited))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Testing Code
	public static void Main8()
	{
		Graph gph = new Graph(5);
		gph.AddDirectedEdge(0, 1);
		gph.AddDirectedEdge(0, 2);
		gph.AddDirectedEdge(2, 3);
		gph.AddDirectedEdge(1, 3);
		gph.AddDirectedEdge(3, 4);
		//gph.AddDirectedEdge(4, 1);
		Console.WriteLine(IsCyclePresent(gph));
		Console.WriteLine(IsCyclePresentColour(gph));
	}

	/*
	False
False
	*/

	public static Graph TransposeGraph(Graph gph)
	{
		int count = gph.count;
		Graph g = new Graph(count);
		for (int i = 0; i < count; i++)
		{
			List<Edge> adl = gph.Adj[i];
			foreach (Edge adn in adl)
			{
				int dest = adn.dest;
				g.AddDirectedEdge(dest, i);
			}
		}
		return g;
	}

	public static bool IsConnectedUndirected(Graph gph)
	{
		int count = gph.count;
		bool[] visited = new bool[count];

		DFSUtil(gph, 0, visited);
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == false)
			{
				return false;
			}
		}
		return true;
	}

		/*
	* Kosaraju Algorithm
	* 
	* Kosaraju's Algorithm to Find strongly connected directed graph based on DFS :
	* 1) Create a visited array of size V, and Initialize all count in visited array as 0. 
	* 2) Choose any vertex and perform a DFS traversal of graph. For 
	* all visited count mark them visited as 1. 
	* 3) If DFS traversal does not mark
	* all count as 1, then return 0. 
	* 4) Find transpose or reverse of graph 
	* 5) Repeat step 1, 2 and 3 for the reversed graph. 
	* 6) If DFS traversal mark all the count as 1, then return 1.
	*/

	public static bool IsStronglyConnected(Graph gph)
	{
		int count = gph.count;
		bool[] visited = new bool[count];

		DFSUtil(gph, 0, visited);
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == false)
			{
				return false;
			}
		}
		Graph gReversed = TransposeGraph(gph);
		for (int i = 0; i < count; i++)
		{
			visited[i] = false;
		}
		DFSUtil(gReversed, 0, visited);
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
	public static void Main9()
	{
		Graph gph = new Graph(5);
		gph.AddDirectedEdge(0, 1);
		gph.AddDirectedEdge(1, 2);
		gph.AddDirectedEdge(2, 3);
		gph.AddDirectedEdge(3, 0);
		gph.AddDirectedEdge(2, 4);
		gph.AddDirectedEdge(4, 2);
		Console.WriteLine("IsStronglyConnected:: " + IsStronglyConnected(gph));
	}

	/*
	IsStronglyConnected:: True
	*/

	public static void stronglyConnectedComponent(Graph gph)
	{
		int count = gph.count;
		bool[] visited = new bool[count];

		Stack<int> stk = new Stack<int>();
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == false)
			{
				DFSUtil2(gph, i, visited, stk);
			}
		}

		Graph gReversed = TransposeGraph(gph);
		Array.Fill(visited, false);

		Stack<int> stk2 = new Stack<int>();
		while (stk.Count > 0)
		{
			int index = stk.Pop();
			if (visited[index] == false)
			{
				stk2.Clear();
				DFSUtil2(gReversed, index, visited, stk2);
				foreach(var ele in stk2)
					Console.Write(ele + " ");
				Console.WriteLine();
			}
		}
	}

	// Testing Code
	public static void Main10()
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
		stronglyConnectedComponent(gph);

		Graph gReversed = TransposeGraph(gph);
		gReversed.Print();
	}

	/*
0 2 1 
3 5 4 
6 
	*/

		public static void primsMST(Graph gph)
	{
		int count = gph.count;
		int[] previous = new int[count];
		Array.Fill(previous, -1);

		int[] dist = new int[count];
		Array.Fill(dist, 9999); // infinite
		bool[] visited = new bool[count];
		int source = 1;

		dist[source] = 0;
		previous[source] = -1;
		PriorityQueue<Edge> queue = new PriorityQueue<Edge>();
		Edge node = new Edge(source, source, 0);
		queue.Add(node);

		while (queue.IsEmpty() != true)
		{
			node = queue.Peek();
			queue.Remove();
			visited[source] = true;
			source = node.dest;
			List<Edge> adl = gph.Adj[source];
			foreach (Edge adn in adl)
			{
				int dest = adn.dest;
				int alt = adn.cost;
				if (dist[dest] > alt && visited[dest] == false)
				{
					dist[dest] = alt;
					previous[dest] = source;
					node = new Edge(source, dest, alt);
					queue.Add(node);
				}
			}
		}
		// Printing result.
		int sum = 0;
		bool isMst = true;
		for (int i = 0; i < count; i++)
		{
			if (dist[i] == 99999)
			{
				Console.WriteLine("Node id " + i + "  prev " + previous[i] + " distance : Unreachable");
				isMst = false;
			}
			else
			{
				Console.WriteLine("Node id " + i + "  prev " + previous[i] + " distance : " + dist[i]);
				sum += dist[i];
			}
		}

		if (isMst)
		{
			Console.Write("Total MST cost: " + sum);
		}
		else
		{
			Console.Write("Not a mst");
		}

	}
	/*
	public static void kruskalMST((Graph gph) {
	    int count = gph.count;
	    int[] parent = new int[count];
	    Array.Fill(parent, -1);
	    Edge edge[] = new Edge[100];
	    List<Edge> output = new List<Edge>();
	    
	    int E = 0;
	    for (int i = 0; i < count; i++) {
	        List<Edge> ad = gph.Adj[i];
	        for (Edge adn : ad) {
	            edge[E++] = adn;
	        }
	    }

	    int sum=0;
	    Arrays.sort(edge, 0, E-1);
	    for (int i = 0; i < E; i++) {
	        int x = Find(parent, edge[i].src);
	        int y = Find(parent, edge[i].dest);            
	        if(x != y) {
	            System.out.Print("(" + edge[i].src + ", " + edge[i].dest + ", " + edge[i].cost + ") ");
	            sum += edge[i].cost;
	            output.Add(edge[i]);
	            union(parent, x, y);
	        }
	    }

	    System.out.Print("\nTotal MST cost: " + sum);
	}
	*/
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

	public static int Find(Sets[] sets, int index)
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
	public static void union(Sets[] sets, int x, int y)
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

	public static void kruskalMST(Graph gph)
	{
		int count = gph.count;

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
			List<Edge> ad = gph.Adj[i];
			foreach (Edge adn in ad)
			{
				edge[E++] = adn;
			}
		}
		Array.Sort(edge, 0, E-1);

		int sum = 0;
		List<Edge> output = new List<Edge>();
		for (int i = 0; i < E; i++)
		{
			int x = Find(sets, edge[i].src);
			int y = Find(sets, edge[i].dest);
			if (x != y)
			{
				Console.Write("(" + edge[i].src + ", " + edge[i].dest + ", " + edge[i].cost + ") ");
				sum += edge[i].cost;
				output.Add(edge[i]);
				union(sets, x, y);
			}
		}
		Console.Write("\nTotal MST cost: " + sum);
	}

	// Testing Code
	public static void Main11()
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
		//gph.Print();
		//gph.out.Println();
		//primsMST(gph);
		//System.out.Println();
		//kruskalMST(gph);
		Dijkstra(gph, 0);
		//FloydWarshall(gph);
	}

	/*
	Vertex 0 is connected to : (1, 4) (7, 8) 
	Vertex 1 is connected to : (0, 4) (2, 8) (7, 11) 
	Vertex 2 is connected to : (1, 8) (3, 7) (8, 2) (5, 4) 
	Vertex 3 is connected to : (2, 7) (4, 9) (5, 14) 
	Vertex 4 is connected to : (3, 9) (5, 10) 
	Vertex 5 is connected to : (2, 4) (3, 14) (4, 10) (6, 2) 
	Vertex 6 is connected to : (5, 2) (7, 1) (8, 6) 
	Vertex 7 is connected to : (0, 8) (1, 11) (6, 1) (8, 7) 
	Vertex 8 is connected to : (2, 2) (6, 6) (7, 7) 

	node id 0  prev 1 distance : 4
	node id 1  prev -1 distance : 0
	node id 2  prev 1 distance : 8
	node id 3  prev 2 distance : 7
	node id 4  prev 3 distance : 9
	node id 5  prev 2 distance : 4
	node id 6  prev 5 distance : 2
	node id 7  prev 6 distance : 1
	node id 8  prev 2 distance : 2

	node id 0  prev -1 distance : 0
	node id 1  prev 0 distance : 4
	node id 2  prev 1 distance : 12
	node id 3  prev 2 distance : 19
	node id 4  prev 5 distance : 21
	node id 5  prev 6 distance : 11
	node id 6  prev 7 distance : 9
	node id 7  prev 0 distance : 8
	node id 8  prev 2 distance : 14
	*/

	// Unweighed graph
	public static void shortestPath(Graph gph, int source)
	{
		int curr;
		int count = gph.count;
		int[] distance = new int[count];
		int[] path = new int[count];
		for (int i = 0; i < count; i++)
		{
			distance[i] = -1;
		}
		Queue<int> que = new Queue<int>();
		que.Enqueue(source);
		distance[source] = 0;
		while (que.Count > 0)
		{
			curr = que.Dequeue();
			List<Edge> adl = gph.Adj[curr];
			foreach (Edge adn in adl)
			{
				if (distance[adn.dest] == -1)
				{
					distance[adn.dest] = distance[curr] + 1;
					path[adn.dest] = curr;
					que.Enqueue(adn.dest);
				}
			}
		}
		for (int i = 0; i < count; i++)
		{
			Console.WriteLine(path[i] + " to " + i + " weight " + distance[i]);
		}
	}

	// Testing Code
	public static void Main12()
	{
		Graph gph = new Graph(9);
		gph.AddUndirectedEdge(0, 2, 1);
		gph.AddUndirectedEdge(1, 2, 5);
		gph.AddUndirectedEdge(1, 3, 7);
		gph.AddUndirectedEdge(1, 4, 9);
		gph.AddUndirectedEdge(3, 2, 2);
		gph.AddUndirectedEdge(3, 5, 4);
		gph.AddUndirectedEdge(4, 5, 6);
		gph.AddUndirectedEdge(4, 6, 3);
		gph.AddUndirectedEdge(5, 7, 1);
		gph.AddUndirectedEdge(6, 7, 7);
		gph.AddUndirectedEdge(7, 8, 17);
		BellmanFordShortestPath(gph, 1);
		// Dijkstra(gph, 1);
		primsMST(gph);
		//System.out.Println("IsConnectedUndirected :: " + IsConnectedUndirected(gph));
		Console.WriteLine();
		kruskalMST(gph);
	}

	/*
	2 to 0 weight 6
	-1 to 1 weight 0
	1 to 2 weight 5
	1 to 3 weight 7
	1 to 4 weight 9
	3 to 5 weight 11
	4 to 6 weight 12
	5 to 7 weight 12
	7 to 8 weight 29


ode id 0  prev 2 distance : 1
Node id 1  prev -1 distance : 0
Node id 2  prev 1 distance : 5
Node id 3  prev 2 distance : 2
Node id 4  prev 5 distance : 6
Node id 5  prev 3 distance : 4
Node id 6  prev 4 distance : 3
Node id 7  prev 5 distance : 1
Node id 8  prev 7 distance : 17
Total MST cost: 39


(0, 2, 1) (5, 7, 1) (2, 3, 2) (6, 4, 3) (3, 5, 4) (1, 2, 5) (4, 5, 6) (7, 8, 17) 
Total MST cost: 39	

*/

	public static void Dijkstra(Graph gph, int source)
	{
		int[] previous = new int[gph.count];
		Array.Fill(previous, -1);
		int[] dist = new int[gph.count];
		Array.Fill(dist, int.MaxValue); // infinite
		bool[] visited = new bool[gph.count];

		dist[source] = 0;
		previous[source] = -1;

		PriorityQueue<Edge> queue = new PriorityQueue<Edge>();
		Edge node = new Edge(source, source, 0);
		queue.Add(node);

		while (queue.IsEmpty() != true)
		{
			node = queue.Peek();
			queue.Remove();
			source = node.dest;
			visited[source] = true;
			List<Edge> adl = gph.Adj[source];
			foreach (Edge adn in adl)
			{
				int dest = adn.dest;
				int alt = adn.cost + dist[source];
				if (dist[dest] > alt && visited[dest] == false)
				{

					dist[dest] = alt;
					previous[dest] = source;
					node = new Edge(source, dest, alt);
					queue.Add(node);
				}
			}
		}

		int count = gph.count;
		for (int i = 0; i < count; i++)
		{
			if (dist[i] == int.MaxValue)
			{
				Console.WriteLine("node id " + i + "  prev " + previous[i] + " distance : Unreachable");
			}
			else
			{
				Console.WriteLine("node id " + i + "  prev " + previous[i] + " distance : " + dist[i]);

			}
		}
	}

		public static void BellmanFordShortestPath(Graph gph, int source)
	{
		int count = gph.count;
		int[] distance = new int[count];
		int[] path = new int[count];

		for (int i = 0; i < count; i++)
		{
			distance[i] = 99999; // infinite
			path[i] = -1;
		}
		distance[source] = 0;
		// Outer loop will run (V-1) number of times.
		// Inner for loop and while loop runs combined will
		// run for Edges number of times.
		// Which make the total complexity as O(V*E)

		for (int i = 0; i < count - 1; i++)
		{
			for (int j = 0; j < count; j++)
			{
				List<Edge> adl = gph.Adj[j];
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
		for (int i = 0; i < count; i++)
		{
			Console.WriteLine(path[i] + " to " + i + " weight " + distance[i]);
		}
	}

	// Testing Code
	public static void Main13()
	{
		Graph gph = new Graph(5);
		gph.AddDirectedEdge(0, 1, 3);
		gph.AddDirectedEdge(0, 4, 2);
		gph.AddDirectedEdge(1, 2, 1);
		gph.AddDirectedEdge(2, 3, 1);
		gph.AddDirectedEdge(4, 1, -2);
		gph.AddDirectedEdge(4, 3, 1);
		gph.Print();
		Console.WriteLine();
		BellmanFordShortestPath(gph, 0);
	}

	/*
	Vertex 0 is connected to : (1, 3) (4, 2) 
	Vertex 1 is connected to : (2, 1) 
	Vertex 2 is connected to : (3, 1) 
	Vertex 3 is connected to : 
	Vertex 4 is connected to : (1, -2) (3, 1) 

	-1 to 0 weight 0
	4 to 1 weight 0
	1 to 2 weight 1
	2 to 3 weight 2
	0 to 4 weight 2
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
	public static void Main14()
	{
		int[] parentArray = new int[] {-1, 0, 1, 2, 3};
		Console.WriteLine(HeightTreeParentArr(parentArray));
		Console.WriteLine(HeightTreeParentArr2(parentArray));
	}

	/*
	4
	4
	*/

		public static int BestFirstSearchPQ(Graph gph, int source, int dest)
	{
		int[] previous = new int[gph.count];
		int[] dist = new int[gph.count];
		bool[] visited = new bool[gph.count];
		for (int i = 0; i < gph.count; i++)
		{
			previous[i] = -1;
			dist[i] = int.MaxValue; // infinite
		}
		PriorityQueue<Edge> pq = new PriorityQueue<Edge>();
		dist[source] = 0;
		previous[source] = -1;
		Edge node = new Edge(source, source, 0);
		pq.Add(node);

		while (pq.IsEmpty() != true)
		{
			node = pq.Peek();
			pq.Remove();
			source = node.dest;
			if (source == dest)
			{
				return node.cost;
			}
			visited[source] = true;

			List<Edge> adl = gph.Adj[source];
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
					pq.Add(node);
				}
			}
		}
		return -1;
	}

	public static bool IsConnected(Graph graph)
	{
		int count = graph.count;
		bool[] visited = new bool[count];

		// Find a vertex with non - zero degree
		// DFS traversal of graph from a vertex with non - zero degree
		List<Edge> adl;
		for (int i = 0; i < count; i++)
		{
			adl = graph.Adj[i];
			if (adl.Count > 0)
			{
				DFSUtil(graph, i, visited);
				break;
			}
		}
		// Check if all non - zero degree count are visited
		for (int i = 0; i < count; i++)
		{
			adl = graph.Adj[i];
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

	/*
	* The function returns one of the following values Return 0 if graph is not
	* Eulerian Return 1 if graph has an Euler path (Semi-Eulerian) Return 2 if
	* graph has an Euler Circuit (Eulerian)
	*/
	public static int IsEulerian(Graph graph)
	{
		int count = graph.count;
		int odd;
		int[] inDegree;
		int[] outDegree;
		List<Edge> adl;
		// Check if all non - zero degree nodes are connected
		if (IsConnected(graph) == false)
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
				adl = graph.Adj[i];
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
	public static void Main15()
	{
		Graph gph = new Graph(5);
		gph.AddDirectedEdge(1, 0);
		gph.AddDirectedEdge(0, 2);
		gph.AddDirectedEdge(2, 1);
		gph.AddDirectedEdge(0, 3);
		gph.AddDirectedEdge(3, 4);
		Console.WriteLine(IsEulerian(gph));
	}

	/*
	graph is Semi-Eulerian
	1
	*/

		public static bool IsStronglyConnected2(Graph graph)
	{
		int count = graph.count;
		bool[] visited = new bool[count];
		Graph gReversed;
		int index;
		// Find a vertex with non - zero degree
		List<Edge> adl;
		for (index = 0; index < count; index++)
		{
			adl = graph.Adj[index];
			if (adl.Count > 0)
			{
				break;
			}
		}
		// DFS traversal of graph from a vertex with non - zero degree
		DFSUtil(graph, index, visited);
		for (int i = 0; i < count; i++)
		{
			adl = graph.Adj[i];
			if (visited[i] == false && adl.Count > 0)
			{
				return false;
			}
		}

		gReversed = TransposeGraph(graph);
		for (int i = 0; i < count; i++)
		{
			visited[i] = false;
		}
		DFSUtil(gReversed, index, visited);

		for (int i = 0; i < count; i++)
		{
			adl = graph.Adj[i];
			if (visited[i] == false && adl.Count > 0)
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsEulerianCycle(Graph graph)
	{
		// Check if all non - zero degree count are connected
		int count = graph.count;
		int[] inDegree = new int[count];
		int[] outDegree = new int[count];
		if (!IsStronglyConnected2(graph))
		{
			return false;
		}

		// Check if in degree and out degree of every vertex is same
		for (int i = 0; i < count; i++)
		{
			List<Edge> adl = graph.Adj[i];
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
	public static void Main16()
	{
		Graph gph = new Graph(5);
		gph.AddDirectedEdge(0, 1);
		gph.AddDirectedEdge(1, 2);
		gph.AddDirectedEdge(2, 0);
		gph.AddDirectedEdge(0, 4);
		gph.AddDirectedEdge(4, 3);
		gph.AddDirectedEdge(3, 0);
		Console.WriteLine(IsEulerianCycle(gph));
	}

	/*
	True
	*/

	// Testing Code
	public static void Main17()
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

		Graph gReversed = TransposeGraph(gph);
		gReversed.Print();
	}

	/*
	Vertex 0 is connected to : (2, 1) 
	Vertex 1 is connected to : (0, 1) 
	Vertex 2 is connected to : (1, 1) 
	Vertex 3 is connected to : (2, 1) (5, 1) 
	Vertex 4 is connected to : (3, 1) 
	Vertex 5 is connected to : (4, 1) 
	Vertex 6 is connected to : (5, 1) 
	*/

	// Testing Code
	public static void Main18()
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
		shortestPath(gph, 0);
	}

	/*
	0 to 0 weight 0
	0 to 1 weight 1
	1 to 2 weight 2
	2 to 3 weight 3
	3 to 4 weight 4
	2 to 5 weight 3
	7 to 6 weight 2
	0 to 7 weight 1
	7 to 8 weight 2
	*/
	internal static void FloydWarshall(Graph gph)
	{
		int V = gph.count;
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
			List<Edge> adl = gph.Adj[i];
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

		private static void PrintSolution(int[, ] cost, int[, ] path, int V)
		{
			for (int u = 0; u < V; u++)
			{
				for (int v = 0; v < V; v++)
				{
					if (u != v && path[u, v] != -1)
					{
						Console.Write("Shortest Path from {0:D} —> {1:D} ", u, v);
					Console.Write("Cost:" + cost[u, v] + " Path:");
					PrintPath(path, u, v);
					Console.WriteLine();
					}
				}
			}
		}

	private static void PrintPath(int[, ] path, int u, int v)
	{
		if (path[u, v] == u)
		{
			Console.Write(u + " " + v + " ");
			return;
		}
		PrintPath(path, u, path[u, v]);
		Console.Write(v + " ");
	}

	public static void Main19()
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
		FloydWarshall(gph);
	}

/*
Shortest Path from 0 —> 1 Cost:5 Path:0 1 
Shortest Path from 0 —> 2 Cost:8 Path:0 1 2 
Shortest Path from 0 —> 3 Cost:9 Path:0 1 2 3 
Shortest Path from 1 —> 2 Cost:3 Path:1 2 
Shortest Path from 1 —> 3 Cost:4 Path:1 2 3 
Shortest Path from 2 —> 3 Cost:1 Path:2 3
*/

	internal static void PrintSolution(int[, ] dist, int V)
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
		
		// Main7(); 
		// Main8();
		// Main9();

		// Main10(); 
		// Main11(); 
		// Main12();
		// Main13(); 
		//Main14();
		//Main15(); 
		//Main16();
		//Main17();
		//Main18();
		Main19();
		
	}
}

public class PriorityQueue<T> where T : IComparable<T>
{
	private const int CAPACITY = 32;
	private int Count; // Number of elements in Heap
	private T[] arr; // The Heap array
	private bool isMinHeap;

	public PriorityQueue(bool isMin = true)
	{
		arr = new T[CAPACITY];
		Count = 0;
		isMinHeap = isMin;
	}

	public PriorityQueue(T[] array, bool isMin = true)
	{
		Count = array.Length;
		arr = array;
		isMinHeap = isMin;
		// Build Heap operation over array
		for (int i = (Count / 2); i >= 0; i--)
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

		if (lChild < Count)
		{
			child = lChild;
		}

		if (rChild < Count && Compare(arr, lChild, rChild))
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

	public void Add(T value)
	{
		if (Count == arr.Length)
		{
			DoubleSize();
		}

		arr[Count++] = value;
		PercolateUp(Count - 1);
	}

	private void DoubleSize()
	{
		T[] old = arr;
		arr = new T[arr.Length * 2];
		Array.Copy(old, 0, arr, 0, Count);
	}

	public T Remove()
	{
		if (Count == 0)
		{
			throw new System.InvalidOperationException();
		}

		T value = arr[0];
		arr[0] = arr[Count - 1];
		Count--;
		PercolateDown(0);
		return value;
	}

	public void Print()
	{
		for (int i = 0; i < Count; i++)
		{
			Console.Write(arr[i] + " ");
		}
	}

	public bool IsEmpty()
	{
		return (Count == 0);
	}

	public int Size()
	{
		return Count;
	}

	public T Peek()
	{
		if (Count == 0)
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
			array[array.Length - i - 1] = hp.Remove();
		}
	}
}
