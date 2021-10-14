using System;

public class ChotaBhim
{
	public static int TotalQuantity(int[] cups, int size)
	{
		int time = 60;
		Array.Sort(cups);
		int total = 0;
		int index, temp;
		while (time > 0)
		{
			total += cups[0];
			cups[0] = (int) Math.Ceiling(cups[0] / 2.0);
			index = 0;
			temp = cups[0];
			while (index < size - 1 && temp < cups[index + 1])
			{
				cups[index] = cups[index + 1];
				index += 1;
			}
			cups[index] = temp;
			time -= 1;
		}
		Console.WriteLine("Total : " + total);
		return total;
	}

	public static int TotalQuantity2(int[] cups, int size)
	{
		int time = 60;
		PriorityQueue<int> pq = new PriorityQueue<int>(false);
		int i = 0;
		for (i = 0; i < size; i++)
		{
			pq.Add(cups[i]);
		}

		int total = 0;
		int value;
		while (time > 0)
		{
			value = pq.Remove();
			total += value;
			value = (int) Math.Ceiling(value / 2.0);
			pq.Add(value);
			time -= 1;
		}
		Console.WriteLine("Total : " + total);
		return total;
	}

	public static void Main(string[] args)
	{
		int[] cups = new int[] {2, 1, 7, 4, 2};
		ChotaBhim.TotalQuantity(cups, cups.Length);
		int[] cups2 = new int[] {2, 1, 7, 4, 2};
		ChotaBhim.TotalQuantity2(cups2, cups.Length);
	}

	/*
	 * Total : 76 
	 * Total : 76 
	 */
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