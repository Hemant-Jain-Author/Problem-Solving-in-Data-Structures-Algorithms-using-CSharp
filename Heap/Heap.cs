using System;

public class Heap
{
	private const int CAPACITY = 32;
	private int Count; // Number of elements in Heap
	private int[] arr; // The Heap array
	private bool isMinHeap;

	public Heap(bool isMin = true)
	{
		arr = new int[CAPACITY];
		Count = 0;
		isMinHeap = isMin;
	}

	public Heap(int[] array, bool isMin = true)
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

	private bool compare(int[] arr, int first, int second)
	{
		if (isMinHeap)
			return (arr[first] - arr[second]) > 0; // Min heap compare
		else
			return (arr[first] - arr[second]) < 0; // Max heap compare
	}

	private void proclateDown(int parent)
	{
		int lChild = 2 * parent + 1;
		int rChild = lChild + 1;
		int child = -1;
		int temp;

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
		int temp;
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

	public void add(int value)
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
		int[] old = arr;
		arr = new int[arr.Length * 2];
		Array.Copy(old, 0, arr, 0, Count);
	}

	public int remove()
	{
		if (Count == 0)
		{
			throw new System.InvalidOperationException();
		}

		int value = arr[0];
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

	public int peek()
	{
		if (Count == 0)
		{
			throw new System.InvalidOperationException();
		}
		return arr[0];
	}

	public static void heapSort(int[] array, bool inc)
	{
		Heap hp = new Heap(array, !inc);
		for (int i = 0; i < array.Length; i++)
		{
			array[array.Length - i - 1] = hp.remove();
		}
	}

	public static void Main(string[] args)
	{
		int[] a = new int[] { 1, 9, 6, 7, 8, 0, 2, 4, 5, 3 };
		Heap hp = new Heap(a, false);
		hp.add(100);
		hp.add(-1);
		hp.print();
		Console.WriteLine();

		while (hp.isEmpty() == false)
		{
			Console.Write(hp.remove() + " ");
		}

		Console.WriteLine();
		int[] a1 = new int[] { 1, 9, 6, 7, 8, 0, 2, 4, 5, 3 };
		Heap.heapSort(a1, true);
		for (int i = 0; i < a1.Length; i++)
		{
			Console.Write(a1[i] + " ");
		}
		Console.WriteLine();
		int[] a2 = new int[] { 1, 9, 6, 7, 8, 0, 2, 4, 5, 3 };
		Heap.heapSort(a2, false);
		for (int i = 0; i < a2.Length; i++)
		{
			Console.Write(a2[i] + " ");
		}
	}
}
