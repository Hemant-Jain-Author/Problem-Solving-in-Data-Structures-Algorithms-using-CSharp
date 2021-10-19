using System;

public class Heap
{
	private const int CAPACITY = 32;
	private int size; // Number of elements in Heap
	private int[] arr; // The Heap array
	internal bool isMinHeap;

	public Heap(bool isMin)
	{
		arr = new int[CAPACITY];
		size = 0;
		isMinHeap = isMin;
	}

	public Heap(int[] array, bool isMin)
	{
		size = array.Length;
		arr = array;
		isMinHeap = isMin;
		// Build Heap operation over array
		for (int i = (size / 2); i >= 0; i--)
		{
			PercolateDown(i);
		}
	}

	// Other Methods.
	internal bool Compare(int[] arr, int first, int second)
	{
		if (isMinHeap)
		{
			return (arr[first] - arr[second]) > 0; // Min heap compare
		}
		else
		{
			return (arr[first] - arr[second]) < 0; // Max heap compare
		}
	}

	private void PercolateDown(int parent)
	{
		int lChild = 2 * parent + 1;
		int rChild = lChild + 1;
		int child = -1;
		int temp;

		if (lChild < size)
		{
			child = lChild;
		}
		if (rChild < size && Compare(arr, lChild, rChild))
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
		int temp;
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

	public void Enqueue(int value)
	{
		if (size == arr.Length)
		{
			DoubleSize();
		}
		arr[size++] = value;
		PercolateUp(size - 1);
	}

	private void DoubleSize()
	{
		int[] old = arr;
		arr = new int[arr.Length * 2];
		Array.Copy(old, 0, arr, 0, size);
	}

	public int Dequeue()
	{
		if (IsEmpty())
		{
			throw new System.InvalidOperationException();
		}

		int value = arr[0];
		arr[0] = arr[size - 1];
		size--;
		PercolateDown(0);
		return value;
	}

	public void Print()
	{
		for (int i = 0; i < size; i++)
		{
			Console.Write(arr[i] + " ");
		}
	}

	public bool Delete(int value)
	{
		for (int i = 0; i < size; i++)
		{
			if (arr[i] == value)
			{
				arr[i] = arr[size-1];
				size -= 1;
				PercolateDown(i);
				return true;
			}
		}
		return false;
	}


	public bool IsEmpty()
	{
		return (size == 0);
	}

	public int Length()
	{
		return size;
	}

	public int Peek()
	{
		if (IsEmpty())
		{
			throw new System.InvalidOperationException();
		}
		return arr[0];
	}

	public static void main1()
	{
		int[] a = new int[] {1, 9, 6, 7, 8, 2, 4, 5, 3};
		Heap hp = new Heap(a, true);
		hp.Print();
		Console.WriteLine();
		hp.Delete(5);
		hp.Print();
		Console.WriteLine();
		Console.WriteLine(hp.Dequeue());
		hp.Print();
		Console.WriteLine();


	}	
/*
1 3 2 5 8 6 4 9 7 
1 3 2 7 8 6 4 9 
1
2 3 4 7 8 6 9 
	*/

	public static void HeapSort(int[] array, bool inc)
	{
		// Create max heap for increasing order sorting.
		Heap hp = new Heap(array, !inc);
		for (int i = 0; i < array.Length; i++)
		{
			array[array.Length - i - 1] = hp.Dequeue();
		}
	}

	public static void main2()
	{
		int[] a2 = new int[] {1, 9, 6, 7, 8, 2, 4, 5, 3};
		Heap.HeapSort(a2, true);
		for (int i = 0; i < a2.Length; i++)
		{
			Console.Write(a2[i] + " ");
		}
		Console.WriteLine();

		int[] a3 = new int[] {1, 9, 6, 7, 8, 2, 4, 5, 3};
		Heap.HeapSort(a3, false);
		for (int i = 0; i < a3.Length; i++)
		{
			Console.Write(a3[i] + " ");
		}
	}

	/*
	1 2 3 4 5 6 7 8 9 
	9 8 7 6 5 4 3 2 1
	*/

	public static void Main(string[] args)
	{
		main1();
		main2();
	}
}
