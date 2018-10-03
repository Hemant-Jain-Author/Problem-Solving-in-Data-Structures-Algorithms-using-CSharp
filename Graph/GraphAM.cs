using System;
using System.Collections.Generic;

public class GraphAM
{
	internal int count;
	internal int[,] adj;

	internal GraphAM(int cnt)
	{
		count = cnt;
		adj = new int[count, count];
	}

	public virtual void addDirectedEdge(int src, int dst, int cost)
	{
		adj[src, dst] = cost;
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
				if (adj[i, j] != 0)
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

		PriorityQueue<Edge> queue = new PriorityQueue<Edge>();

		Edge node = new Edge(source, 0);
		queue.add(node);

		while (queue.isEmpty() != true)
		{
			node = queue.peek();
			queue.remove();
			source = node.dest;
			visited[source] = true;
			for (int dest = 0; dest < gph.count; dest++)
			{
				int cost = gph.adj[source, dest];
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
		PriorityQueue<Edge> queue = new PriorityQueue<Edge>();
		Edge node = new Edge(source, 0);
		queue.add(node);

		while (queue.isEmpty() != true)
		{
			node = queue.peek();
			queue.remove();
			source = node.dest;
			visited[source] = true;
			for (int dest = 0; dest < gph.count; dest++)
			{
				int cost = gph.adj[source, dest];
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
			if (pSize == 0 || (graph.adj[path[pSize - 1], vertex] == 1 && added[vertex] == 0))
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
		// Base case full length path is found this last check can be modified to make it a path.
		if (pSize == graph.count)
		{
			if (graph.adj[path[pSize - 1], path[0]] == 1)
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
			if (pSize == 0 || (graph.adj[path[pSize - 1], vertex] == 1 && added[vertex] == 0))
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
					graph.addDirectedEdge(i, j, 1);
				}
			}
		}
		Console.WriteLine("hamiltonianPath : " + hamiltonianPath(graph));
		Console.WriteLine("hamiltonianCycle : " + hamiltonianCycle(graph));

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
					graph2.addDirectedEdge(i, j, 1);
				}
			}
		}

		Console.WriteLine("hamiltonianPath :  " + hamiltonianPath(graph2));
		Console.WriteLine("hamiltonianCycle :  " + hamiltonianCycle(graph2));
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
