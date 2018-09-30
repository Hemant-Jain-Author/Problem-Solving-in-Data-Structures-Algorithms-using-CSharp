using System;
using System.Collections.Generic;

public class GraphAM
{

	internal int count;
	internal int[][] adj;

	internal GraphAM(int cnt)
	{
		count = cnt;
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces 
//the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: adj = new int[count][count];
		adj = RectangularArrays.ReturnRectangularIntArray(count, count);
	}

	public virtual void addDirectedEdge(int src, int dst, int cost)
	{
		adj[src][dst] = cost;
	}

	public virtual void addUndirectedEdge(int src, int dst, int cost)
	{
		addDirectedEdge(src, dst, cost);
		addDirectedEdge(dst, src, cost);
	}

	public virtual void print()
	{
		for (int i = 0; i < count; i++)
		{
			Console.Write("Node index [ " + i + " ] is connected with : ");
			for (int j = 0; j < count; j++)
			{
				if (adj[i][j] != 0)
				{
					Console.Write(j + " ");
				}
			}
			Console.WriteLine("");
		}
	}

	public static void Main(string[] args)
	{
		GraphAM graph = new GraphAM(4);
		graph.addUndirectedEdge(0, 1, 1);
		graph.addUndirectedEdge(0, 2, 1);
		graph.addUndirectedEdge(1, 2, 1);
		graph.addUndirectedEdge(2, 3, 1);
		graph.print();
	}

	private class Edge
	{
		internal int dest;
		internal int cost;

		public Edge(int dst, int cst)
		{
			dest = dst;
			cost = cst;
		}
	}

	internal class EdgeComparator : IComparer<Edge>
	{
		public virtual int Compare(Edge x, Edge y)
		{
			if (x.cost < y.cost)
			{
				return -1;
			}
			if (x.cost > y.cost)
			{
				return 1;
			}
			return 0;
		}
	}

	public static void dijkstra(GraphAM gph, int source)
	{
		int[] previous = new int[gph.count];
		int[] dist = new int[gph.count];
		bool[] visited = new bool[gph.count];

		for (int i = 0; i < gph.count; i++)
		{
			previous[i] = -1;
			dist[i] = int.MaxValue; // infinite
			visited[i] = false;
		}

		dist[source] = 0;
		previous[source] = -1;

		EdgeComparator comp = new EdgeComparator();
		PriorityQueue<Edge> queue = new PriorityQueue<Edge>(100, comp);

		Edge node = new Edge(source, 0);
		queue.add(node);

		while (queue.Empty != true)
		{
			node = queue.peek();
			queue.remove();
			source = node.dest;
			visited[source] = true;
			for (int dest = 0; dest < gph.count; dest++)
			{
				int cost = gph.adj[source][dest];
				if (cost != 0)
				{
					int alt = cost + dist[source];
					if (dist[dest] > alt && visited[dest] == false)
					{

						dist[dest] = alt;
						previous[dest] = source;
						node = new Edge(dest, alt);
						queue.add(node);
					}
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

	public static void prims(GraphAM gph)
	{
		int[] previous = new int[gph.count];
		int[] dist = new int[gph.count];
		int source = 0;
		bool[] visited = new bool[gph.count];

		for (int i = 0; i < gph.count; i++)
		{
			previous[i] = -1;
			dist[i] = int.MaxValue; // infinite
			visited[i] = false;
		}

		dist[source] = 0;
		previous[source] = -1;

		EdgeComparator comp = new EdgeComparator();
		PriorityQueue<Edge> queue = new PriorityQueue<Edge>(100, comp);

		Edge node = new Edge(source, 0);
		queue.add(node);

		while (queue.Empty != true)
		{
			node = queue.peek();
			queue.remove();
			source = node.dest;
			visited[source] = true;
			for (int dest = 0; dest < gph.count; dest++)
			{
				int cost = gph.adj[source][dest];
				if (cost != 0)
				{
					int alt = cost;
					if (dist[dest] > alt && visited[dest] == false)
					{

						dist[dest] = alt;
						previous[dest] = source;
						node = new Edge(dest, alt);
						queue.add(node);
					}
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

	public static void main40(string[] args)
	{
		GraphAM gph = new GraphAM(9);
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
		prims(gph);
		dijkstra(gph, 0);
	}

	public static void main41(string[] args)
	{
		GraphAM gph = new GraphAM(9);
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
		gph.print();
		prims(gph);
		dijkstra(gph, 1);
	}

	public static bool hamiltonianPathUtil(GraphAM graph, int[] path, int pSize, int[] added)
	{
		// Base case full length path is found
		if (pSize == graph.count)
		{
			return true;
		}
		for (int vertex = 0; vertex < graph.count; vertex++)
		{
			// there is a path from last element and next vertex
			// and next vertex is not already included in path.
			if (pSize == 0 || (graph.adj[path[pSize - 1]][vertex] == 1 && added[vertex] == 0))
			{
				path[pSize++] = vertex;
				added[vertex] = 1;
				if (hamiltonianPathUtil(graph, path, pSize, added))
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

	public static bool hamiltonianPath(GraphAM graph)
	{
		int[] path = new int[graph.count];
		int[] added = new int[graph.count];

		if (hamiltonianPathUtil(graph, path, 0, added))
		{
			Console.WriteLine("Hamiltonian Path found :: ");
			for (int i = 0; i < graph.count; i++)
			{
				Console.WriteLine(" " + path[i]);
			}

			return true;
		}

		Console.WriteLine("Hamiltonian Path not found");
		return false;
	}

	public static bool hamiltonianCycleUtil(GraphAM graph, int[] path, int pSize, int[] added)
	{
		// Base case full length path is found
		// this last check can be modified to make it a path.
		if (pSize == graph.count)
		{
			if (graph.adj[path[pSize - 1]][path[0]] == 1)
			{
				path[pSize] = path[0];
				return true;
			}
			else
			{
				return false;
			}
		}
		for (int vertex = 0; vertex < graph.count; vertex++)
		{
			// there is a path from last element and next vertex
			if (pSize == 0 || (graph.adj[path[pSize - 1]][vertex] == 1 && added[vertex] == 0))
			{
				path[pSize++] = vertex;
				added[vertex] = 1;
				if (hamiltonianCycleUtil(graph, path, pSize, added))
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

	public static bool hamiltonianCycle(GraphAM graph)
	{
		int[] path = new int[graph.count + 1];
		int[] added = new int[graph.count];
		if (hamiltonianCycleUtil(graph, path, 0, added))
		{
			Console.WriteLine("Hamiltonian Cycle found :: ");
			for (int i = 0; i <= graph.count; i++)
			{
				Console.Write(" " + path[i]);
			}
			return true;
		}
		Console.WriteLine("Hamiltonian Cycle not found");
		return false;
	}

	public static void main2(string[] args)
	{
		int count = 5;
		GraphAM graph = new GraphAM(count);
		int[][] adj = new int[][]
		{
			new int[] {0, 1, 0, 1, 0},
			new int[] {1, 0, 1, 1, 0},
			new int[] {0, 1, 0, 0, 1},
			new int[] {1, 1, 0, 0, 1},
			new int[] {0, 1, 1, 1, 0}
		};

		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < count; j++)
			{
				if (adj[i][j] == 1)
				{
					graph.addDirectedEdge(i, j, 1);
				}
			}
		}
		Console.WriteLine("hamiltonianPath : " + hamiltonianPath(graph));
		Console.WriteLine("hamiltonianCycle : " + hamiltonianCycle(graph));

		GraphAM graph2 = new GraphAM(count);
		int[][] adj2 = new int[][]
		{
			new int[] {0, 1, 0, 1, 0},
			new int[] {1, 0, 1, 1, 0},
			new int[] {0, 1, 0, 0, 1},
			new int[] {1, 1, 0, 0, 0},
			new int[] {0, 1, 1, 0, 0}
		};
		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < count; j++)
			{
				if (adj2[i][j] == 1)
				{
					graph2.addDirectedEdge(i, j, 1);
				}
			}
		}

		Console.WriteLine("hamiltonianPath :  " + hamiltonianPath(graph2));
		Console.WriteLine("hamiltonianCycle :  " + hamiltonianCycle(graph2));
	}

}