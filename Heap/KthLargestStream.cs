using System;

public class KthLargestStream
{
	internal PriorityQueue<int> pq = new PriorityQueue<int>();
	internal int size = 0;
	internal int k = 10;

	internal KthLargestStream(int a)
	{
		k = a;
	}

	public void Add(int value)
	{
		if (size < k)
		{
			pq.Add(value);
		}
		else if (pq.Peek() < value)
		{
				pq.Add(value);
				pq.Remove();
		}
		size += 1;
	}

	public void Print()
	{
		Console.WriteLine(pq);
	}

	public void Add2(int value)
	{
		if (size < k)
		{
			pq.Add(value);
			Console.Write("- ");
		}
		else
		{
			if (pq.Peek() < value)
			{
				pq.Add(value);
				pq.Remove();
			}
			Console.Write(pq.Peek() + " ");
		}
		size += 1;
	}

	public static void Main(string[] args)
	{
		KthLargestStream kt = new KthLargestStream(10);
		int value;
		Random rand = new Random();
		for (int i = 0;i < 100;i++)
		{
			value = rand.Next(1000);
			kt.Add2(value);
		}
		kt.Print();
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
			ProclateDown(i);
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

	private void ProclateDown(int parent)
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
			ProclateDown(child);
		}
	}

	private void ProclateUp(int child)
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
			ProclateUp(parent);
		}
	}

	public void Add(T value)
	{
		if (Count == arr.Length)
		{
			DoubleSize();
		}

		arr[Count++] = value;
		ProclateUp(Count - 1);
	}

	private void DoubleSize()
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
		ProclateDown(0);
		return value;
	}

	public void Print()
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
			array[array.Length - i - 1] = hp.remove();
		}
	}
}