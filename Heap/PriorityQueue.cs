using System;

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

public class HeapDemo
{
	public static void Main1(string[] args)
	{
		int[] a = new int[] { 1, 9, 6, 7, 8, 0, 2, 4, 5, 3 };
		PriorityQueue<int> hp = new PriorityQueue<int>(a, true);

		hp.add(100);
		hp.add(-1);
		hp.print();
		Console.WriteLine();
		while (hp.isEmpty() == false)
		{
			Console.Write(hp.remove() + " ");
		}
		Console.WriteLine();
		int[] a2 = new int[] { 1, 9, 6, 7, 8, 0, 2, 4, 5, 3 };
		PriorityQueue<int>.HeapSort(a2, true);
		for (int i = 0; i < a2.Length; i++)
		{
			Console.Write(a2[i] + " ");
		}
		Console.WriteLine();
		int[] a3 = new int[] { 1, 9, 6, 7, 8, 0, 2, 4, 5, 3 };
		PriorityQueue<int>.HeapSort(a3, false);
		for (int i = 0; i < a3.Length; i++)
		{
			Console.Write(a3[i] + " ");
		}
	}
}

public class MedianHeap
{
	internal PriorityQueue<int> minHeap;
	internal PriorityQueue<int> maxHeap;

	public MedianHeap()
	{
		minHeap = new PriorityQueue<int>();
		maxHeap = new PriorityQueue<int>(false);
	}

	//Other Methods.

	public void insert(int value)
	{
		if (maxHeap.size() == 0 || maxHeap.peek() >= value)
		{
			maxHeap.add(value);
		}
		else
		{
			minHeap.add(value);
		}

		//size balancing
		if (maxHeap.size() > minHeap.size() + 1)
		{
			value = maxHeap.remove();
			minHeap.add(value);
		}

		if (minHeap.size() > maxHeap.size() + 1)
		{
			value = minHeap.remove();
			maxHeap.add(value);
		}
	}

	public int median()
	{
		if (maxHeap.size() == 0 && minHeap.size() == 0)
		{
			throw new System.InvalidOperationException("EmptyException");
		}

		if (maxHeap.size() == minHeap.size())
		{
			return (maxHeap.peek() + minHeap.peek()) / 2;
		}
		else if (maxHeap.size() > minHeap.size())
		{
			return maxHeap.peek();
		}
		else
		{
			return minHeap.peek();
		}
	}

	public static void Main(string[] args)
	{
		int[] arr = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5, 1 };
		MedianHeap hp = new MedianHeap();

		for (int i = 0; i < 10; i++)
		{
			hp.insert(arr[i]);
			Console.WriteLine("Median after insertion of " + arr[i] + " is  " + hp.median());
		}
	}
}
