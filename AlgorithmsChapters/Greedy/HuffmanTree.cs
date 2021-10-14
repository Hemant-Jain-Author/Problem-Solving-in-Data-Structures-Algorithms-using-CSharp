using System;

public class HuffmanTree
{
	private Node root = null;

	internal class Node : IComparable<Node>
	{
		internal char c;
		internal int freq;
		internal Node left;
		internal Node right;

		internal Node(char ch, int fr, Node l, Node r)
		{
			c = ch;
			freq = fr;
			left = l;
			right = r;
		}

		public int CompareTo(Node n2)
		{
			return this.freq - n2.freq;
		}
	}

	public HuffmanTree(char[] arr, int[] freq)
	{
		int n = arr.Length;
		PriorityQueue<Node> que = new PriorityQueue<Node>();

		for (int i = 0; i < n; i++)
		{
			Node node = new Node(arr[i], freq[i], null, null);
			que.Add(node);
		}

		while (que.Size() > 1)
		{
			Node lt = que.Peek();
			que.Remove();
			Node rt = que.Peek();
			que.Remove();

			Node nd = new Node('+', lt.freq + rt.freq, lt, rt);
			que.Add(nd);
		}
		root = que.Peek();
	}

	private void Print(Node root, string s)
	{
		if (root.left == null && root.right == null && root.c != '+')
		{
			Console.WriteLine(root.c + " = " + s);
			return;
		}
		Print(root.left, s + "0");
		Print(root.right, s + "1");
	}

	public void Print()
	{
		Console.WriteLine("Char = Huffman code");
		Print(root, "");
	}

	public static void Main(string[] args)
	{
		char[] ar = new char[] {'A', 'B', 'C', 'D', 'E'};
		int[] fr = new int[] {30, 25, 21, 14, 10};
		HuffmanTree hf = new HuffmanTree(ar, fr);
		hf.Print();
	}
}

/*
Char = Huffman code
C = 00
E = 010
D = 011
B = 10
A = 11
*/
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