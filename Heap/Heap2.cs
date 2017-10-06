using System;

public class Heap
{

	private const int CAPACITY = 16;
	private int size; // Number of elements in heap
	private int[] arr; // The heap array

	public Heap()
	{
		arr = new int[CAPACITY];
		size = 0;
	}

	public Heap(int[] array)
	{
		size = array.Length;
		arr = new int[array.Length + 1];
		Array.Copy(array, 0, arr, 1, array.Length); //we do not use 0 index

		//Build Heap operation over array
		for (int i = (size / 2); i > 0; i--)
		{
			proclateDown(i);
		}
	}
	//Other Methods.

	private void proclateDown(int position)
	{
		int lChild = 2 * position;
		int rChild = lChild + 1;
		int small = -1;
		int temp;

		if (lChild <= size)
		{
			small = lChild;
		}

		if (rChild <= size && (arr[rChild] - arr[lChild]) < 0)
		{
			small = rChild;
		}

		if (small != -1 && (arr[small] - arr[position]) < 0)
		{
			temp = arr[position];
			arr[position] = arr[small];
			arr[small] = temp;
			proclateDown(small);
		}
	}

	private void proclateUp(int position)
	{
		int parent = position / 2;
		int temp;
		if (parent == 0)
		{
			return;
		}

		if ((arr[parent] - arr[position]) < 0)
		{
			temp = arr[position];
			arr[position] = arr[parent];
			arr[parent] = temp;
			proclateUp(parent);
		}
	}

	public virtual void add(int value)
	{
		if (size == arr.Length - 1)
		{
			doubleSize();
		}

		arr[++size] = value;
		proclateUp(size);
	}

	private void doubleSize()
	{
		int[] old = arr;
		arr = new int[arr.Length * 2];
		Array.Copy(old, 1, arr, 1, size);
	}

	public virtual int remove()
	{
		if (isEmpty())
		{
			throw new System.InvalidOperationException("HeapEmptyException");
		}

		int value = arr[1];
		arr[1] = arr[size];
		size--;
		proclateDown(1);
		return value;
	}

	public virtual void print()
	{
		for (int i = 1; i <= size; i++)
		{
			Console.WriteLine("value is :: " + arr[i]);
		}

	}

	internal virtual bool IsMinHeap(int[] arr, int size)
	{
		for (int i = 0; i <= (size - 2) / 2; i++)
		{
			if (2 * i + 1 < size)
			{
				if (arr[i] > arr[2 * i + 1])
				{
					return false;
				}
			}
			if (2 * i + 2 < size)
			{
				if (arr[i] > arr[2 * i + 2])
				{
					return false;
				}
			}
		}
		return true;
	}

	internal virtual bool IsMaxHeap(int[] arr, int size)
	{
		for (int i = 0; i <= (size - 2) / 2; i++)
		{
			if (2 * i + 1 < size)
			{
				if (arr[i] < arr[2 * i + 1])
				{
					return false;
				}
			}
			if (2 * i + 2 < size)
			{
				if (arr[i] < arr[2 * i + 2])
				{
					return false;
				}
			}
		}
		return true;
	}

	public virtual bool isEmpty()
	{
		return (size == 0);
	}

	public virtual int peek()
	{
		if (isEmpty())
		{
			throw new System.InvalidOperationException("HeapEmptyException");
		}
		return arr[1];
	}

	public static void heapSort(int[] array)
	{
		Heap hp = new Heap(array);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = hp.remove();
		}
	}

	public static void Main(string[] args)
	{
		int[] a = new int[] { 4, 5, 3 };
		//Heap hp = new Heap(a);
		//hp.print();
		//for (int i = 0; i < a.Length; i++)
		//{
		//    Console.WriteLine("pop value :: " + hp.remove());
		//}

		Heap.heapSort(a);
		for (int i = 0; i < a.Length; i++)
		{
			Console.WriteLine("value is :: " + a[i]);
		}

		string[] b = new string[] { "banana", "mango", "apple", "grapes" };








	}
}