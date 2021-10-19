using System;

public class GraphAM
{
	private int count;
	private int[, ] adj;

	public GraphAM(int cnt)
	{
		count = cnt;
		adj = new int[count, count];
	}

	public void AddDirectedEdge(int src, int dst, int cost)
	{
		adj[src, dst] = cost;
	}

	public void AddUndirectedEdge(int src, int dst, int cost)
	{
		AddDirectedEdge(src, dst, cost);
		AddDirectedEdge(dst, src, cost);
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
					Console.Write("(" + j + ", " + adj[i, j] + ") ");
				}
			}
			Console.WriteLine("");
		}
	}

	public static void Main1()
	{
		GraphAM graph = new GraphAM(4);
		graph.AddUndirectedEdge(0, 1, 1);
		graph.AddUndirectedEdge(0, 2, 1);
		graph.AddUndirectedEdge(1, 2, 1);
		graph.AddUndirectedEdge(2, 3, 1);
		graph.Print();
	}

/*
Vertex 0 is connected to : (1, 1) (2, 1) 
Vertex 1 is connected to : (0, 1) (2, 1) 
Vertex 2 is connected to : (0, 1) (1, 1) (3, 1) 
Vertex 3 is connected to : (2, 1)
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

	public static void Dijkstra(GraphAM gph, int source)
	{
		int[] previous = new int[gph.count];
		int[] dist = new int[gph.count];
		bool[] visited = new bool[gph.count];
		Array.Fill(previous, -1);
		Array.Fill(dist, int.MaxValue); // infinite

		dist[source] = 0;
		previous[source] = -1;

		PriorityQueue<Edge> pq = new PriorityQueue<Edge>();
		Edge node = new Edge(source, source, 0);
		pq.Enqueue(node);

		while (pq.IsEmpty() != true)
		{
			node = pq.Dequeue();
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
						node = new Edge(source, dest, alt);
						pq.Enqueue(node);
					}
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

	public static void Prims(GraphAM gph)
	{
		int[] previous = new int[gph.count];
		int[] dist = new int[gph.count];
		int source = 0;
		bool[] visited = new bool[gph.count];
		Array.Fill(previous, -1);
		Array.Fill(dist, int.MaxValue); // infinite

		dist[source] = 0;
		previous[source] = -1;
		PriorityQueue<Edge> pq = new PriorityQueue<Edge>();
		Edge node = new Edge(source, source, 0);
		pq.Enqueue(node);

		while (pq.IsEmpty() != true)
		{
			node = pq.Dequeue();
			source = node.dest;
			visited[source] = true;
			for (int dest = 0; dest < gph.count; dest++)
			{
				int cost = gph.adj[source, dest];
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
		//gph.Print();
		Prims(gph);
		//Dijkstra(gph, 0);
	}
/*
Vertex 0 is connected to : (1, 4) (7, 8) 
Vertex 1 is connected to : (0, 4) (2, 8) (7, 11) 
Vertex 2 is connected to : (1, 8) (3, 7) (5, 4) (8, 2) 
Vertex 3 is connected to : (2, 7) (4, 9) (5, 14) 
Vertex 4 is connected to : (3, 9) (5, 10) 
Vertex 5 is connected to : (2, 4) (3, 14) (4, 10) (6, 2) 
Vertex 6 is connected to : (5, 2) (7, 1) (8, 6) 
Vertex 7 is connected to : (0, 8) (1, 11) (6, 1) (8, 7) 
Vertex 8 is connected to : (2, 2) (6, 6) (7, 7)  


node id 0  prev -1 distance : 0
node id 1  prev 0 distance : 4
node id 2  prev 5 distance : 4
node id 3  prev 2 distance : 7
node id 4  prev 3 distance : 9
node id 5  prev 6 distance : 2
node id 6  prev 7 distance : 1
node id 7  prev 0 distance : 8
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

	public static void Main3()
	{
		GraphAM gph = new GraphAM(9);
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
		gph.Print();
		Prims(gph);
		Dijkstra(gph, 1);
	}
/*
Vertex 0 is connected to : (2, 1) 
Vertex 1 is connected to : (2, 5) (3, 7) (4, 9) 
Vertex 2 is connected to : (0, 1) (1, 5) (3, 2) 
Vertex 3 is connected to : (1, 7) (2, 2) (5, 4) 
Vertex 4 is connected to : (1, 9) (5, 6) (6, 3) 
Vertex 5 is connected to : (3, 4) (4, 6) (7, 1) 
Vertex 6 is connected to : (4, 3) (7, 7) 
Vertex 7 is connected to : (5, 1) (6, 7) (8, 17) 
Vertex 8 is connected to : (7, 17)

node id 0  prev -1 distance : 0
node id 1  prev 2 distance : 5
node id 2  prev 0 distance : 1
node id 3  prev 2 distance : 2
node id 4  prev 5 distance : 6
node id 5  prev 3 distance : 4
node id 6  prev 4 distance : 3
node id 7  prev 5 distance : 1
node id 8  prev 7 distance : 17

node id 0  prev 2 distance : 6
node id 1  prev -1 distance : 0
node id 2  prev 1 distance : 5
node id 3  prev 1 distance : 7
node id 4  prev 1 distance : 9
node id 5  prev 3 distance : 11
node id 6  prev 4 distance : 12
node id 7  prev 5 distance : 12
node id 8  prev 7 distance : 29
*/
	public static bool HamiltonianPathUtil(GraphAM graph, int[] path, int pSize, int[] added)
	{
		// Base case full length path is found
		if (pSize == graph.count)
		{
			return true;
		}
		for (int vertex = 0; vertex < graph.count; vertex++)
		{
			// There is an edge from last element of path and next vertex
			// and the next vertex is not already included in the path.
			if (pSize == 0 || (graph.adj[path[pSize - 1], vertex] == 1 && added[vertex] == 0))
			{
				path[pSize++] = vertex;
				added[vertex] = 1;
				if (HamiltonianPathUtil(graph, path, pSize, added))
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

	public static bool HamiltonianPath(GraphAM graph)
	{
		int[] path = new int[graph.count];
		int[] added = new int[graph.count];

		if (HamiltonianPathUtil(graph, path, 0, added))
		{
			Console.Write("Hamiltonian Path found :: ");
			for (int i = 0; i < graph.count; i++)
			{
				Console.Write(" " + path[i]);
			}
			Console.WriteLine("");
			return true;
		}

		Console.WriteLine("Hamiltonian Path not found");
		return false;
	}

	public static bool HamiltonianCycleUtil(GraphAM graph, int[] path, int pSize, int[] added)
	{
		// Base case full length path is found
		// this last check can be modified to make it a path.
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
				if (HamiltonianCycleUtil(graph, path, pSize, added))
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

	public static bool HamiltonianCycle(GraphAM graph)
	{
		int[] path = new int[graph.count + 1];
		int[] added = new int[graph.count];
		if (HamiltonianCycleUtil(graph, path, 0, added))
		{
			Console.Write("Hamiltonian Cycle found :: ");
			for (int i = 0; i <= graph.count; i++)
			{
				Console.Write(" " + path[i]);
			}
			Console.WriteLine("");
			return true;
		}
		Console.WriteLine("Hamiltonian Cycle not found");
		return false;
	}

		public static void Main4()
	{
		int count = 5;
		GraphAM graph = new GraphAM(count);
		int[, ] adj = new int[, ]
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
		Console.WriteLine("HamiltonianPath : " + HamiltonianPath(graph));

		GraphAM graph2 = new GraphAM(count);
		int[, ] adj2 = new int[, ]
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

		Console.WriteLine("HamiltonianPath :  " + HamiltonianPath(graph2));
	}
/*
Hamiltonian Path found ::  0 1 2 4 3
HamiltonianPath : true

Hamiltonian Path found ::  0 3 1 2 4
HamiltonianPath :  true
 */
	public static void Main5()
	{
		int count = 5;
		GraphAM graph = new GraphAM(count);
		int[, ] adj = new int[, ]
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
		Console.WriteLine("HamiltonianCycle : " + HamiltonianCycle(graph));

		GraphAM graph2 = new GraphAM(count);
		int[, ] adj2 = new int[, ]
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

		Console.WriteLine("HamiltonianCycle :  " + HamiltonianCycle(graph2));
	}

/*
Hamiltonian Cycle found ::  0 1 2 4 3 0
HamiltonianCycle : true

Hamiltonian Cycle not found
HamiltonianCycle :  false
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
