using System;

public class PriorityQueueDemo
{
	public static void Main(string[] args)
	{

		PriorityQueue<int> pq = new PriorityQueue<int>();
		int[] arr = new int[] {1, 2, 10, 8, 7, 3, 4, 6, 5, 9};
		foreach (int i in arr)
		{
			pq.Enqueue(i);
		}

		Console.Write("Heap Array: ");
		pq.Print();
		while (pq.IsEmpty() == false)
		{
			Console.Write(pq.Dequeue() + " ");
		}
		Console.WriteLine();

		pq = new PriorityQueue<int>(false);
		foreach (int i in arr)
		{
			pq.Enqueue(i);
		}

		Console.Write("Heap Array: ");
		pq.Print();
		while (pq.IsEmpty() == false)
		{
			Console.Write(pq.Dequeue() + " ");
		}
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

