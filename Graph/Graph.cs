using System;
using System.Collections.Generic;

public class Graph
{
	internal int count;
	private List<List<Edge>> Adj;

	private class Edge : IComparable<Edge>
	{
		internal int dest;
		internal int cost;

		public Edge(int dst, int cst)
		{
			dest = dst;
			cost = cst;
		}

		int IComparable<Edge>.CompareTo(Edge other)
		{
			return cost - other.cost;
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

	private void addDirectedEdge(int source, int dest, int cost)
	{
		Edge edge = new Edge(dest, cost);
		Adj[source].Add(edge);
	}

	public virtual void addDirectedEdge(int source, int dest)
	{
		addDirectedEdge(source, dest, 1);
	}

	public virtual void addUndirectedEdge(int source, int dest, int cost)
	{
		addDirectedEdge(source, dest, cost);
		addDirectedEdge(dest, source, cost);
	}

	public virtual void addUndirectedEdge(int source, int dest)
	{
		addUndirectedEdge(source, dest, 1);
	}

	public virtual void print()
	{
		for (int i = 0; i < count; i++)
		{
			List<Edge> ad = Adj[i];
			Console.Write("\n Vertex " + i + " is connected to : ");
			foreach (Edge adn in ad)
			{
				Console.Write("(" + adn.dest + ", " + adn.cost + ") ");
			}
		}
	}

	public static bool dfsStack(Graph gph, int source, int target)
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

	public static bool dfs(Graph gph, int source, int target)
	{
		int count = gph.count;
		bool[] visited = new bool[count];
		dfsUtil(gph, source, visited);
		return visited[target];
	}

	public static void dfsUtil(Graph gph, int index, bool[] visited)
	{
		visited[index] = true;
		List<Edge> adl = gph.Adj[index];
		foreach (Edge adn in adl)
		{
			if (visited[adn.dest] == false)
			{
				dfsUtil(gph, adn.dest, visited);
			}
		}
	}

	public static void dfsUtil2(Graph gph, int index, bool[] visited, Stack<int> stk)
	{
		visited[index] = true;
		List<Edge> adl = gph.Adj[index];
		foreach (Edge adn in adl)
		{
			if (visited[adn.dest] == false)
			{
				dfsUtil2(gph, adn.dest, visited, stk);
			}
		}
		stk.Push(index);
	}

	public static bool bfs(Graph gph, int source, int target)
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

	public static void Main444()
	{
		Graph gph = new Graph(5);
		gph.addDirectedEdge(0, 1, 3);
		gph.addDirectedEdge(0, 4, 2);
		gph.addDirectedEdge(1, 2, 1);
		gph.addDirectedEdge(2, 3, 1);
		gph.addDirectedEdge(4, 1, -2);
		gph.addDirectedEdge(4, 3, 1);
		gph.print();
		Console.WriteLine(Graph.dfs(gph, 0, 2));
		Console.WriteLine(Graph.bfs(gph, 0, 2));
		Console.WriteLine(Graph.dfsStack(gph, 0, 2));
	}

	public static void topologicalSort(Graph gph)
	{
		Stack<int> stk = new Stack<int>();
		int count = gph.count;
		bool[] visited = new bool[count];

		for (int i = 0; i < count; i++)
		{
			if (visited[i] == false)
			{
				dfsUtil2(gph, i, visited, stk);
			}
		}
		Console.Write("topologicalSort :: ");
		while (stk.Count == 0 != true)
		{
			Console.Write(" " + stk.Pop());
		}
	}

	public static void main5()
	{
		Graph gph = new Graph(6);
		gph.addDirectedEdge(5, 2, 1);
		gph.addDirectedEdge(5, 0, 1);
		gph.addDirectedEdge(4, 0, 1);
		gph.addDirectedEdge(4, 1, 1);
		gph.addDirectedEdge(2, 3, 1);
		gph.addDirectedEdge(3, 1, 1);
		gph.print();
		topologicalSort(gph);
	}

	public static bool pathExist(Graph gph, int source, int dest)
	{
		int count = gph.count;
		bool[] visited = new bool[count];

		dfsUtil(gph, source, visited);
		return visited[dest];
	}

	public static int countAllPathDFS(Graph gph, bool[] visited, int source, int dest)
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
				count += countAllPathDFS(gph, visited, adn.dest, dest);
			}
			visited[source] = false;
		}
		return count;
	}

	public static int countAllPath(Graph gph, int src, int dest)
	{
		int count = gph.count;
		bool[] visited = new bool[count];
		return countAllPathDFS(gph, visited, src, dest);
	}

	public static void printAllPathDFS(Graph gph, bool[] visited, int source, int dest, Stack<int> path)
	{
		path.Push(source);

		if (source == dest)
		{
			Console.WriteLine(path);
			path.Pop();
			return;
		}
		visited[source] = true;
		List<Edge> adl = gph.Adj[source];
		foreach (Edge adn in adl)
		{
			if (visited[adn.dest] == false)
			{
				printAllPathDFS(gph, visited, adn.dest, dest, path);
			}
		}
		visited[source] = false;
		path.Pop();
	}

	public static void printAllPath(Graph gph, int src, int dest)
	{
		bool[] visited = new bool[gph.count];
		Stack<int> path = new Stack<int>();
		printAllPathDFS(gph, visited, src, dest, path);
	}

	public static void main11()
	{
		Graph gph = new Graph(5);
		gph.addDirectedEdge(0, 1, 1);
		gph.addDirectedEdge(0, 2, 1);
		gph.addDirectedEdge(2, 3, 1);
		gph.addDirectedEdge(1, 3, 1);
		gph.addDirectedEdge(3, 4, 1);
		gph.addDirectedEdge(1, 4, 1);
		gph.print();
		Console.WriteLine("PathExist :: " + pathExist(gph, 0, 4));

		Console.WriteLine();
		Console.WriteLine(countAllPath(gph, 0, 4));
		printAllPath(gph, 0, 4);
	}

	public static int rootVertex(Graph gph)
	{
		int count = gph.count;
		bool[] visited = new bool[count];
		int retVal = -1;
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == false)
			{
				dfsUtil(gph, i, visited);
				retVal = i;
			}
		}
		Console.Write("Root vertex is :: " + retVal);
		return retVal;
	}

	public static void main4()
	{
		Graph gph = new Graph(7);
		gph.addDirectedEdge(0, 1, 1);
		gph.addDirectedEdge(0, 2, 1);
		gph.addDirectedEdge(1, 3, 1);
		gph.addDirectedEdge(4, 1, 1);
		gph.addDirectedEdge(6, 4, 1);
		gph.addDirectedEdge(5, 6, 1);
		gph.addDirectedEdge(5, 2, 1);
		gph.addDirectedEdge(6, 0, 1);
		gph.print();
		rootVertex(gph);
	}

	/*
		* Given a directed graph, find transitive closure matrix or reach ability
		* matrix vertex v is reachable form vertex u if their is a path from u to v.
		*/

	public static void transitiveClosureUtil(Graph gph, int source, int dest, int[,] tc)
	{
		tc[source, dest] = 1;
		List<Edge> adl = gph.Adj[dest];
		foreach (Edge adn in adl)
		{
			if (tc[source, adn.dest] == 0)
			{
				transitiveClosureUtil(gph, source, adn.dest, tc);
			}
		}
	}

	public static int[,] transitiveClosure(Graph gph)
	{
		int count = gph.count;
		int[,] tc = new int[count, count]; ;
		for (int i = 0; i < count; i++)
		{
			transitiveClosureUtil(gph, i, i, tc);
		}
		return tc;
	}

	public static void main10()
	{
		Graph gph = new Graph(4);
		gph.addDirectedEdge(0, 1, 1);
		gph.addDirectedEdge(0, 2, 1);
		gph.addDirectedEdge(1, 2, 1);
		gph.addDirectedEdge(2, 0, 1);
		gph.addDirectedEdge(2, 3, 1);
		gph.addDirectedEdge(3, 3, 1);
		int[,] tc = transitiveClosure(gph);
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				Console.Write(tc[i, j] + " ");
			}
			Console.WriteLine();
		}
	}

	public static void bfsLevelNode(Graph gph, int source)
	{
		int count = gph.count;
		bool[] visited = new bool[count];
		int[] level = new int[count];
		visited[source] = true;

		Queue<int> que = new Queue<int>();
		que.Enqueue(source);
		level[source] = 0;
		Console.WriteLine("\nNode  - Level");

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

	public static int bfsDistance(Graph gph, int source, int dest)
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
					return depth+1;
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

	public static void main1()
	{
		Graph gph = new Graph(7);
		gph.addUndirectedEdge(0, 1, 1);
		gph.addUndirectedEdge(0, 2, 1);
		gph.addUndirectedEdge(0, 4, 1);
		gph.addUndirectedEdge(1, 2, 1);
		gph.addUndirectedEdge(2, 5, 1);
		gph.addUndirectedEdge(3, 4, 1);
		gph.addUndirectedEdge(4, 5, 1);
		gph.addUndirectedEdge(4, 6, 1);
		gph.print();
		bfsLevelNode(gph, 1);
		Console.WriteLine(bfsDistance(gph, 1, 6));
	}

	public static bool isCyclePresentUndirectedDFS(Graph graph, int index, int parentIndex, bool[] visited)
	{
		visited[index] = true;
		int dest;
		List<Edge> adl = graph.Adj[index];
		foreach (Edge adn in adl)
		{
			dest = adn.dest;
			if (visited[dest] == false)
			{
				if (isCyclePresentUndirectedDFS(graph, dest, index, visited))
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

	public static bool isCyclePresentUndirected(Graph graph)
	{
		int count = graph.count;
		bool[] visited = new bool[count];
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == false)
			{
				if (isCyclePresentUndirectedDFS(graph, i, -1, visited))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static void main14()
	{
		Graph gph = new Graph(6);
		gph.addUndirectedEdge(0, 1, 1);
		gph.addUndirectedEdge(1, 2, 1);
		gph.addUndirectedEdge(3, 4, 1);
		gph.addUndirectedEdge(4, 2, 1);
		gph.addUndirectedEdge(2, 5, 1);
		// gph.addUndirectedEdge(4, 1, 1);
		Console.WriteLine(isCyclePresentUndirected(gph));
	}

	/*
		* Given a directed graph find if there is a cycle in it.
		*/
	public static bool isCyclePresentDFS(Graph graph, int index, bool[] visited, int[] marked)
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
				if (isCyclePresentDFS(graph, dest, visited, marked))
				{
					return true;
				}
			}
		}
		marked[index] = 0;
		return false;
	}

	public static bool isCyclePresent(Graph graph)
	{
		int count = graph.count;
		bool[] visited = new bool[count];
		int[] marked = new int[count];
		for (int index = 0; index < count; index++)
		{
			if (visited[index] == false)
			{
				if (isCyclePresentDFS(graph, index, visited, marked))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool isCyclePresentDFSColor(Graph graph, int index, int[] visited)
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
				if (isCyclePresentDFSColor(graph, dest, visited))
				{
					return true;
				}
			}
		}
		visited[index] = 2; // "Black"
		return false;
	}

	public static bool isCyclePresentColor(Graph graph)
	{
		int count = graph.count;
		int[] visited = new int[count];
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == 0) // "White"
			{
				if (isCyclePresentDFSColor(graph, i, visited))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static void main13()
	{
		Graph gph = new Graph(5);
		gph.addDirectedEdge(0, 1, 1);
		gph.addDirectedEdge(0, 2, 1);
		gph.addDirectedEdge(2, 3, 1);
		gph.addDirectedEdge(1, 3, 1);
		gph.addDirectedEdge(3, 4, 1);
		gph.addDirectedEdge(4, 1, 1);
		Console.WriteLine(isCyclePresentColor(gph));
	}

	public static Graph transposeGraph(Graph gph)
	{
		int count = gph.count;
		Graph g = new Graph(count);
		for (int i = 0; i < count; i++)
		{
			List<Edge> adl = gph.Adj[i];
			foreach (Edge adn in adl)
			{
				int dest = adn.dest;
				g.addDirectedEdge(dest, i);
			}
		}
		return g;
	}

	public static bool isConnectedUndirected(Graph gph)
	{
		int count = gph.count;
		bool[] visited = new bool[count];

		dfsUtil(gph, 0, visited);
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
		* Kosaraju’s Algorithm to find strongly connected directed graph based on DFS :
		* 1) Create a visited array of size V, and Initialize all count in visited array as 0. 
		* 2) Choose any vertex and perform a DFS traversal of graph. For all visited count mark them visited as 1. 
		* 3) If DFS traversal does not mark all count as 1, then return 0. 
		* 4) Find transpose or reverse of graph 
		* 5) Repeat step 1, 2 and 3 for the reversed graph. 
		* 6) If DFS traversal mark all the count as 1, then return 1.
		*/
	public static bool isStronglyConnected(Graph gph)
	{
		int count = gph.count;
		bool[] visited = new bool[count];

		dfsUtil(gph, 0, visited);
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == false)
			{
				return false;
			}
		}
		Graph gReversed = transposeGraph(gph);
		for (int i = 0; i < count; i++)
		{
			visited[i] = false;
		}
		dfsUtil(gReversed, 0, visited);
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == false)
			{
				return false;
			}
		}
		return true;
	}

	public static void main6()
	{
		Graph gph = new Graph(5);
		gph.addDirectedEdge(0, 1, 1);
		gph.addDirectedEdge(1, 2, 1);
		gph.addDirectedEdge(2, 3, 1);
		gph.addDirectedEdge(3, 0, 1);
		gph.addDirectedEdge(2, 4, 1);
		gph.addDirectedEdge(4, 2, 1);
		Console.WriteLine(" IsStronglyConnected:: " + isStronglyConnected(gph));
	}

	public static void stronglyConnectedComponent(Graph gph)
	{
		int count = gph.count;
		bool[] visited = new bool[count];

		Stack<int> stk = new Stack<int>();
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == false)
			{
				dfsUtil2(gph, i, visited, stk);
			}
		}
		Graph gReversed = transposeGraph(gph);
		for (int i = 0; i < count; i++)
		{
			visited[i] = false;
		}

		Stack<int> stk2 = new Stack<int>();
		while (stk.Count > 0)
		{
			int index = stk.Pop();
			if (visited[index] == false)
			{
				stk2.Clear();
				dfsUtil2(gReversed, index, visited, stk2);
				Console.WriteLine(stk2);
			}
		}
	}

	public static void main7()
	{
		Graph gph = new Graph(7);
		gph.addDirectedEdge(0, 1, 1);
		gph.addDirectedEdge(1, 2, 1);
		gph.addDirectedEdge(2, 0, 1);
		gph.addDirectedEdge(2, 3, 1);
		gph.addDirectedEdge(3, 4, 1);
		gph.addDirectedEdge(4, 5, 1);
		gph.addDirectedEdge(5, 3, 1);
		gph.addDirectedEdge(5, 6, 1);
		stronglyConnectedComponent(gph);
	}

	public static void prims(Graph gph)
	{
		int[] previous = new int[gph.count];
		int[] dist = new int[gph.count];
		bool[] visited = new bool[gph.count];
		int source = 1;

		for (int i = 0; i < gph.count; i++)
		{
			previous[i] = -1;
			dist[i] = 999999; // infinite
		}

		dist[source] = 0;
		previous[source] = -1;
		PriorityQueue<Edge> queue = new PriorityQueue<Edge>();
		Edge node = new Edge(source, 0);
		queue.add(node);

		while (queue.isEmpty() != true)
		{
			node = queue.peek();
			queue.remove();
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
					node = new Edge(dest, alt);
					queue.add(node);
				}
			}
		}
		// printing result.
		int count = gph.count;
		for (int i = 0; i < count; i++)
		{
			if (dist[i] == int.MaxValue)
			{
				Console.WriteLine(" node id " + i + "  prev " + previous[i] + " distance : Unreachable");
			}
			else
			{
				Console.WriteLine(" node id " + i + "  prev " + previous[i] + " distance : " + dist[i]);
			}
		}
	}

	public static void main3()
	{
		Graph gph = new Graph(9);
		gph.addUndirectedEdge(0, 1, 4);
		gph.addUndirectedEdge(0, 7, 8);
		gph.addUndirectedEdge(1, 2, 8);
		gph.addUndirectedEdge(1, 7, 11);
		gph.addUndirectedEdge(2, 3, 7);
		gph.addUndirectedEdge(2, 8, 2);
		gph.addUndirectedEdge(2, 5, 4);
		gph.addUndirectedEdge(3, 4, 9);
		gph.addUndirectedEdge(3, 5, 14);
		gph.addUndirectedEdge(4, 5, 10);
		gph.addUndirectedEdge(5, 6, 2);
		gph.addUndirectedEdge(6, 7, 1);
		gph.addUndirectedEdge(6, 8, 6);
		gph.addUndirectedEdge(7, 8, 7);
		gph.print();
		Console.WriteLine();
		prims(gph);
		Console.WriteLine();
		dijkstra(gph, 0);
	}

	public static void shortestPath(Graph gph, int source) // unweighted graph
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

	public static void main9()
	{
		Graph gph = new Graph(9);
		gph.addUndirectedEdge(0, 2, 1);
		gph.addUndirectedEdge(1, 2, 5);
		gph.addUndirectedEdge(1, 3, 7);
		gph.addUndirectedEdge(1, 4, 9);
		gph.addUndirectedEdge(3, 2, 2);
		gph.addUndirectedEdge(3, 5, 4);
		gph.addUndirectedEdge(4, 5, 6);
		gph.addUndirectedEdge(4, 6, 3);
		gph.addUndirectedEdge(5, 7, 1);
		gph.addUndirectedEdge(6, 7, 7);
		gph.addUndirectedEdge(7, 8, 17);
		bellmanFordshortestPath(gph, 1);
		dijkstra(gph, 1);
		prims(gph);
		Console.WriteLine("isConnectedUndirected :: " + isConnectedUndirected(gph));
	}

	public static void dijkstra(Graph gph, int source)
	{
		int[] previous = new int[gph.count];
		int[] dist = new int[gph.count];
		bool[] visited = new bool[gph.count];

		for (int i = 0; i < gph.count; i++)
		{
			previous[i] = -1;
			dist[i] = 999999; // infinite
		}

		dist[source] = 0;
		previous[source] = -1;
		PriorityQueue<Edge> queue = new PriorityQueue<Edge>();
		Edge node = new Edge(source, 0);
		queue.add(node);

		while (queue.isEmpty() != true)
		{
			node = queue.peek();
			queue.remove();
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
					node = new Edge(dest, alt);
					queue.add(node);
				}
			}
		}

		int count = gph.count;
		for (int i = 0; i < count; i++)
		{
			if (dist[i] == int.MaxValue)
			{
				Console.WriteLine(" \n node id " + i + "  prev " + previous[i] + " distance : Unreachable");
			}
			else
			{
				Console.WriteLine(" node id " + i + "  prev " + previous[i] + " distance : " + dist[i]);
			}
		}
	}

	public static void bellmanFordshortestPath(Graph gph, int source)
	{
		int count = gph.count;
		int[] distance = new int[count];
		int[] path = new int[count];

		for (int i = 0; i < count; i++)
		{
			distance[i] = 999999; // infinite
			path[i] = -1;
		}
		distance[source] = 0;
		// Outer loop will run (V-1) number of times.
		// Inner for loop and while loop runs combined will run for Edges number of times.
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
			Console.WriteLine(path[i] + " to " + i + " weight " + distance[i]);
	}

	public static void main2()
	{
		Graph gph = new Graph(5);
		gph.addDirectedEdge(0, 1, 3);
		gph.addDirectedEdge(0, 4, 2);
		gph.addDirectedEdge(1, 2, 1);
		gph.addDirectedEdge(2, 3, 1);
		gph.addDirectedEdge(4, 1, -2);
		gph.addDirectedEdge(4, 3, 1);
		gph.print();
		Console.WriteLine();
		bellmanFordshortestPath(gph, 0);
	}

	public static int heightTreeParentArr(int[] arr)
	{
		int count = arr.Length;
		int[] heightArr = new int[count];
		Graph gph = new Graph(count);
		int source = 0;
		for (int i = 0; i < count; i++)
		{
			if (arr[i] != -1)
			{
				gph.addDirectedEdge(arr[i], i);
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

	public static int getHeight(int[] arr, int[] height, int index)
	{
		if (arr[index] == -1)
		{
			return 0;
		}
		else
		{
			return getHeight(arr, height, arr[index]) + 1;
		}
	}

	public static int heightTreeParentArr2(int[] arr)
	{
		int count = arr.Length;
		int[] height = new int[count];
		int maxHeight = -1;
		for (int i = 0; i < count; i++)
		{
			height[i] = getHeight(arr, height, i);
			maxHeight = Math.Max(maxHeight, height[i]);
		}
		return maxHeight;
	}

	public static void main12()
	{
		int[] parentArray = new int[] { -1, 0, 1, 2, 3 };
		Console.WriteLine(heightTreeParentArr(parentArray));
		Console.WriteLine(heightTreeParentArr2(parentArray));
	}
	/*
	public static int bestFirstSearchPQ(Graph gph, int source, int dest)
	{
		int[] previous = new int[gph.count];
		int[] dist = new int[gph.count];
		bool[] visited = new bool[gph.count];
		for (int i = 0; i < gph.count; i++)
		{
			previous[i] = -1;
			dist[i] = 999999; // infinite
		}
		EdgeComparator comp = new EdgeComparator();
		PriorityQueue<Edge> pq = new PriorityQueue<Edge>(100, comp);
		dist[source] = 0;
		previous[source] = -1;
		Edge node = new Edge(source, 0);
		pq.add(node);

		while (pq.Empty != true)
		{
			node = pq.peek();
			pq.remove();
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
					node = new Edge(curr, alt);
					pq.add(node);
				}
			}
		}
		return -1;
	}
	*/
	public static bool isConnected(Graph graph)
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
				dfsUtil(graph, i, visited);
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
	public static int isEulerian(Graph graph)
	{
		int count = graph.count;
		int odd;
		int[] inDegree;
		int[] outDegree;
		List<Edge> adl;
		// Check if all non - zero degree nodes are connected
		if (isConnected(graph) == false)
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

	public static void main15()
	{
		Graph gph = new Graph(5);
		gph.addDirectedEdge(1, 0, 1);
		gph.addDirectedEdge(0, 2, 1);
		gph.addDirectedEdge(2, 1, 1);
		gph.addDirectedEdge(0, 3, 1);
		gph.addDirectedEdge(3, 4, 1);
		Console.WriteLine(isEulerian(gph));
	}

	public static bool isStronglyConnected2(Graph graph)
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
		dfsUtil(graph, index, visited);
		for (int i = 0; i < count; i++)
		{
			adl = graph.Adj[i];
			if (visited[i] == false && adl.Count > 0)
			{
				return false;
			}
		}

		gReversed = transposeGraph(graph);
		for (int i = 0; i < count; i++)
		{
			visited[i] = false;
		}
		dfsUtil(gReversed, index, visited);

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

	public static bool isEulerianCycle(Graph graph)
	{
		// Check if all non - zero degree count are connected
		int count = graph.count;
		int[] inDegree = new int[count];
		int[] outDegree = new int[count];
		if (!isStronglyConnected2(graph))
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

	public static void main16()
	{
		Graph gph = new Graph(5);
		gph.addDirectedEdge(0, 1, 1);
		gph.addDirectedEdge(1, 2, 1);
		gph.addDirectedEdge(2, 0, 1);
		gph.addDirectedEdge(0, 4, 1);
		gph.addDirectedEdge(4, 3, 1);
		gph.addDirectedEdge(3, 0, 1);
		Console.WriteLine(isEulerianCycle(gph));
	}

	public static void Main(string[] args)
	{
		main10();
		main3();
		/*
			* main2(); main3(); main4(); main5(); main6(); main7(); main8(); main9();
			* main10(); main11(); main12(); main13(); main14(); main15(); main16();
			*/
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
			proclateDown(i);
		}
	}

	// Other Methods.
	private bool compare(T[] arr, int first, int second)
	{
		if (isMinHeap)
			return arr[first].CompareTo(arr[second]) > 0;
		else
			return arr[first].CompareTo(arr[second]) < 0;
	}

	private void proclateDown(int parent)
	{
		int lChild = 2 * parent + 1;
		int rChild = lChild + 1;
		int child = -1;
		T temp;

		if (lChild < Count)
		{
			child = lChild;
		}

		if (rChild < Count && compare(arr, lChild, rChild))
		{
			child = rChild;
		}

		if (child != -1 && compare(arr, parent, child))
		{
			temp = arr[parent];
			arr[parent] = arr[child];
			arr[child] = temp;
			proclateDown(child);
		}
	}

	private void proclateUp(int child)
	{
		int parent = (child - 1) / 2;
		T temp;
		if (parent < 0)
		{
			return;
		}

		if (compare(arr, parent, child))
		{
			temp = arr[child];
			arr[child] = arr[parent];
			arr[parent] = temp;
			proclateUp(parent);
		}
	}

	public void add(T value)
	{
		if (Count == arr.Length)
		{
			doubleSize();
		}

		arr[Count++] = value;
		proclateUp(Count - 1);
	}

	private void doubleSize()
	{
		T[] old = arr;
		arr = new T[arr.Length * 2];
		Array.Copy(old, 0, arr, 0, Count);
	}

	public T remove()
	{
		if (Count == 0)
		{
			throw new System.InvalidOperationException();
		}

		T value = arr[0];
		arr[0] = arr[Count - 1];
		Count--;
		proclateDown(0);
		return value;
	}

	public void print()
	{
		for (int i = 0; i < Count; i++)
		{
			Console.Write(arr[i] + " ");
		}
	}

	public bool isEmpty()
	{
		return (Count == 0);
	}

	public int size()
	{
		return Count;
	}

	public T peek()
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
			array[array.Length - i - 1] = hp.remove();
		}
	}
}
