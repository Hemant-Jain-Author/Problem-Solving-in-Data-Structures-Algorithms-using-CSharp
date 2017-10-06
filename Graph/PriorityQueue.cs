using System;


public class PriorityQueue<T> where T : IComparable<T>
{
	private const int CAPACITY = 16;
	private int size; // Number of elements in PriorityQueue
	private T[] arr; // The PriorityQueue array
	bool isMinHeap;

	public PriorityQueue(bool minHeap = true)
	{
		arr = new T[CAPACITY];
		size = 0;
		isMinHeap = minHeap;
	}

	public PriorityQueue(T[] array, bool minHeap = true)
	{
		size = array.Length;
		arr = new T[array.Length + 1];
		size = array.Length;
		isMinHeap = minHeap;
		Array.Copy(array, 0, arr, 1, array.Length); //we do not use 0 index

		//Build PriorityQueue operation over array
		for (int i = (size / 2); i > 0; i--)
		{
			proclateDown(i);
		}
	}
	//Other Methods.

	private int comp(int first, int second)
	{
		if (isMinHeap)
			return arr[first].CompareTo(arr[second]);
		else
			return arr[second].CompareTo(arr[first]);
	}

	private void proclateDown(int position)
	{
		int lChild = 2 * position;
		int rChild = lChild + 1;
		int small = -1;
		T temp;

		if (lChild <= size)
		{
			small = lChild;
		}

		if (rChild <= size && comp(rChild, lChild) < 0)
		{
			small = rChild;
		}

		if (small != -1 && comp(small, position) < 0)
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
		T temp;
		if (parent == 0)
		{
			return;
		}

		if (comp(parent, position) > 0) //parent grater then child.
		{
			temp = arr[position];
			arr[position] = arr[parent];
			arr[parent] = temp;
			proclateUp(parent);
		}
	}

	public virtual void Enqueue(T value)
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
		T[] old = arr;
		arr = new T[arr.Length * 2];
		Array.Copy(old, 1, arr, 1, size);
	}

	public virtual T Dequeue()
	{
		if (isEmpty())
		{
			throw new System.InvalidOperationException("HeapEmptyException");
		}

		T value = arr[1];
		arr[1] = arr[size];
		size--;
		proclateDown(1);
		return value;
	}

	public virtual void Print()
	{
		for (int i = 1; i <= size + 1; i++)
		{
			Console.WriteLine("value is :: " + arr[i]);
		}
	}

	public virtual bool isEmpty()
	{
		return (size == 0);
	}

	public virtual T Peek()
	{
		if (isEmpty())
		{
			throw new System.InvalidOperationException("HeapEmptyException");
		}
		return arr[1];
	}

	public int Count
	{
		get
		{
			return size;
		}

	}

	public static void Sort(T[] array)
	{
		PriorityQueue<T> hp = new PriorityQueue<T>(array);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = hp.Dequeue();
		}
	}
}
