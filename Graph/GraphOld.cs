using System;
using System.Collections.Generic;

public class Graph
{

	public class AdjNode : IComparable<AdjNode>
	{
		internal int source;
		internal int destination;
		internal int cost;
		internal AdjNode next;

		public AdjNode(int src, int dst, int cst)
		{
			source = src;
			destination = dst;
			cost = cst;
			next = null;
		}

		public AdjNode(int src, int dst) : this(src, dst, 1)
		{
		}

		int IComparable<AdjNode>.CompareTo(AdjNode other)
		{
			return cost - other.cost;
		}
	}

	private class AdjList
	{
		internal AdjNode head;
	}

	private int count;
	private AdjList[] array;

	public Graph(int cnt)
	{
		count = cnt;
		array = new AdjList[cnt];
		for (int i = 0; i < cnt; i++)
		{
			array[i] = new AdjList();
			array[i].head = null;
		}
	}

	public virtual void AddEdge(int source, int destination, int cost)
	{
		AdjNode node = new AdjNode(source, destination, cost);
		node.next = array[source].head;
		array[source].head = node;
	}

	public virtual void AddEdge(int source, int destination)
	{
		AddEdge(source, destination, 1);
	}

	public virtual void AddBiEdge(int source, int destination, int cost) //bi directional edge
	{
		AddEdge(source, destination, cost);
		AddEdge(destination, source, cost);
	}

	public virtual void AddBiEdge(int source, int destination) //bi directional edge
	{
		AddBiEdge(source, destination, 1);
	}

	public virtual void Print()
	{
		AdjNode ad;
		for (int i = 0; i < count; i++)
		{
			ad = array[i].head;
			if (ad != null)
			{
				Console.Write("Vertex " + i + " is connected to : ");
				while (ad != null)
				{
					Console.Write(ad.destination + " ");
					ad = ad.next;
				}
				Console.WriteLine("");
			}
		}
	}

	public static void Dijkstra(Graph gph, int source)
	{

		int[] previous = new int[gph.count];
		int[] dist = new int[gph.count];

		for (int i = 0; i < gph.count; i++)
		{
			previous[i] = -1;
			dist[i] = int.MaxValue; //infinite
		}

		dist[source] = 0;
		previous[source] = -1;

		PriorityQueue<AdjNode> queue = new PriorityQueue<AdjNode>();

		AdjNode node = new AdjNode(source, source, 0);
		queue.Enqueue(node);

		while (queue.Count != 0)
		{
			node = queue.Peek();
			queue.Dequeue();

			AdjList adl = gph.array[node.destination];
			AdjNode adn = adl.head;
			while (adn != null)
			{
				int alt = adn.cost + dist[adn.source];
				if (alt < dist[adn.destination])
				{
					dist[adn.destination] = alt;
					previous[adn.destination] = adn.source;
					node = new AdjNode(adn.source, adn.destination, alt);
					queue.Enqueue(node);
				}
				adn = adn.next;
			}
		}

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

	public static void Prims(Graph gph)
	{
		int[] previous = new int[gph.count];
		int[] dist = new int[gph.count];
		int source = 1;

		for (int i = 0; i < gph.count; i++)
		{
			previous[i] = -1;
			dist[i] = int.MaxValue;
		}

		dist[source] = 0;
		previous[source] = -1;

		PriorityQueue<AdjNode> queue = new PriorityQueue<AdjNode>();
		AdjNode node = new AdjNode(source, source, 0);
		queue.Enqueue(node);

		while (queue.Count != 0)
		{
			node = queue.Peek();
			queue.Dequeue();

			if (dist[node.destination] < node.cost)
				continue;

			dist[node.destination] = node.cost;
			previous[node.destination] = node.source;

			AdjList adl = gph.array[node.destination];
			AdjNode adn = adl.head;

			while (adn != null)
			{
				if (previous[adn.destination] == -1)
				{
					node = new AdjNode(adn.source, adn.destination, adn.cost);
					queue.Enqueue(node);
				}
				adn = adn.next;
			}
		}

		// Printing result.
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

	private static void TopologicalSortDFS(Graph gph, int index, int[] visited, Stack<int> stk)
	{
		AdjNode head = gph.array[index].head;
		while (head != null)
		{
			if (visited[head.destination] == 0)
			{
				visited[head.destination] = 1;
				TopologicalSortDFS(gph, head.destination, visited, stk);
			}
			head = head.next;
		}
		stk.Push(index);
	}

	public static void TopologicalSort(Graph gph)
	{
		Stack<int> stk = new Stack<int>();
		int count = gph.count;
		int[] visited = new int[count];
		for (int i = 0; i < count; i++)
		{
			visited[i] = 0;
		}
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == 0)
			{
				visited[i] = 1;
				TopologicalSortDFS(gph, i, visited, stk);
			}
		}
		while (stk.Count == 0 != true)
		{
			Console.Write(" " + stk.Pop());
		}
	}

	public static int PathExist(Graph gph, int source, int destination)
	{
		int count = gph.count;
		int[] visited = new int[count];
		for (int i = 0; i < count; i++)
		{
			visited[i] = 0;
		}
		visited[source] = 1;
		DFSRec(gph, source, visited);
		return visited[destination];
	}

	public static void DFSRec(Graph gph, int index, int[] visited)
	{
		AdjNode head = gph.array[index].head;
		while (head != null)
		{
			if (visited[head.destination] == 0)
			{
				visited[head.destination] = 1;
				DFSRec(gph, head.destination, visited);
			}
			head = head.next;
		}
	}

	public virtual void DFSStack(Graph gph)
	{
		int count = gph.count;
		int[] visited = new int[count];
		int curr;
		Stack<int> stk = new Stack<int>();
		for (int i = 0; i < count; i++)
		{
			visited[i] = 0;
		}

		visited[0] = 1;
		stk.Push(0);

		while (stk.Count > 0)
		{
			curr = stk.Pop();
			AdjNode head = gph.array[curr].head;
			while (head != null)
			{
				if (visited[head.destination] == 0)
				{
					visited[head.destination] = 1;
					stk.Push(head.destination);
				}
				head = head.next;
			}
		}
	}

	internal virtual void DFS(Graph gph)
	{
		int count = gph.count;
		int[] visited = new int[count];
		for (int i = 0; i < count; i++)
		{
			visited[i] = 0;
		}
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == 0)
			{
				visited[i] = 1;
				DFSRec(gph, i, visited);
			}
		}
	}

	public virtual void BFSQueue(Graph gph, int index, int[] visited)
	{
		int curr;
		Queue<int> que = new Queue<int>();

		visited[index] = 1;
		que.Enqueue(index);

		while (que.Count > 0)
		{
			curr = que.Dequeue();
			AdjNode head = gph.array[curr].head;
			while (head != null)
			{
				if (visited[head.destination] == 0)
				{
					visited[head.destination] = 1;
					que.Enqueue(head.destination);
				}
				head = head.next;
			}
		}
	}

	public virtual void BFS(Graph gph)
	{
		int count = gph.count;
		int[] visited = new int[count];
		for (int i = 0; i < count; i++)
		{
			visited[i] = 0;
		}
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == 0)
			{
				BFSQueue(gph, i, visited);
			}
		}
	}

	public virtual bool isConnected(Graph gph)
	{
		int count = gph.count;
		int[] visited = new int[count];
		for (int i = 0; i < count; i++)
		{
			visited[i] = 0;
		}
		visited[0] = 1;
		DFSRec(gph, 0, visited);
		for (int i = 0; i < count; i++)
		{
			if (visited[i] == 0)
			{
				return false;
			}
		}
		return true;
	}

	internal virtual void ShortestPath(Graph gph, int source) // unweighted graph
	{
		int curr;
		int count = gph.count;
		int[] distance = new int[count];
		int[] path = new int[count];

		Queue<int> que = new Queue<int>();

		for (int i = 0; i < count; i++)
		{
			distance[i] = -1;
		}
		que.Enqueue(source);
		distance[source] = 0;
		while (que.Count > 0)
		{
			curr = que.Dequeue();
			AdjNode head = gph.array[curr].head;
			while (head != null)
			{
				if (distance[head.destination] == -1)
				{
					distance[head.destination] = distance[curr] + 1;
					path[head.destination] = curr;
					que.Enqueue(head.destination);
				}
				head = head.next;
			}
		}
		for (int i = 0; i < count; i++)
		{
			Console.WriteLine(path[i] + " to " + i + " weight " + distance[i]);
		}
	}

	internal virtual void BellmanFordShortestPath(Graph gph, int source)
	{
		int count = gph.count;
		int[] distance = new int[count];
		int[] path = new int[count];

		for (int i = 0; i < count; i++)
		{
			distance[i] = int.MaxValue;
		}
		distance[source] = 0;
		for (int i = 0; i < count - 1; i++)
		{
			for (int j = 0; j < count; j++)
			{
				AdjNode head = gph.array[j].head;
				while (head != null)
				{
					int newDistance = distance[j] + head.cost;
					if (distance[head.destination] > newDistance)
					{
						distance[head.destination] = newDistance;
						path[head.destination] = j;
					}
					head = head.next;
				}
			}
		}
		for (int i = 0; i < count; i++)
		{
			Console.WriteLine(path[i] + " to " + i + " weight " + distance[i]);
		}
	}

	public static void Main3(string[] args)
	{
		Graph gph = new Graph(9);
		gph.AddBiEdge(0, 2, 1);
		gph.AddBiEdge(1, 2, 5);
		gph.AddBiEdge(1, 3, 7);
		gph.AddBiEdge(1, 4, 9);
		gph.AddBiEdge(3, 2, 2);
		gph.AddBiEdge(3, 5, 4);
		gph.AddBiEdge(4, 5, 6);
		gph.AddBiEdge(4, 6, 3);
		gph.AddBiEdge(5, 7, 5);
		gph.AddBiEdge(6, 7, 7);
		gph.AddBiEdge(7, 8, 17);

		Prims(gph);
		//Dijkstra(gph,1);
	}

	public static void Main(string[] args)
	{
		Graph g = new Graph(6);
		g.AddEdge(5, 2);
		g.AddEdge(5, 0);
		g.AddEdge(4, 0);
		g.AddEdge(4, 1);
		g.AddEdge(2, 3);
		g.AddEdge(3, 1);

		Console.WriteLine("Following is a Topological Sort of the given graph.");
		Graph.TopologicalSort(g);
	}
}