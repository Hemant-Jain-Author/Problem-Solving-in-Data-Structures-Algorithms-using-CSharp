using System;

public class OptimalMergePattern
{
	public static int Merge(int[] lists, int size)
	{
		PriorityQueue<int> pq = new PriorityQueue<int>();
		int i = 0;
		for (i = 0; i < size; i++)
		{
			pq.add(lists[i]);
		}

		int total = 0;
		int value = 0;
		while (pq.size() > 1)
		{
			value = pq.remove();
			value += pq.remove();
			pq.add(value);
			total += value;
		}
		Console.WriteLine("Total : " + total);
		return total;
	}

	public static void Main(string[] args)
	{
		int[] lists = new int[] {4, 3, 2, 6};
		OptimalMergePattern.Merge(lists, lists.Length);
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

/*
Total : 29
*/