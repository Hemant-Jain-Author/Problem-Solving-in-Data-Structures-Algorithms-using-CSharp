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

	public virtual void add(T value)
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

	public virtual T remove()
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

	public virtual void print()
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

	public virtual T peek()
	{
		if (isEmpty())
		{
			throw new System.InvalidOperationException("HeapEmptyException");
		}
		return arr[1];
	}

	public int length()
	{
		return size;
	}

	public static void Sort(T[] array)
	{
		PriorityQueue<T> hp = new PriorityQueue<T>(array);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = hp.remove();
		}
	}
}


class HeapDemo
{
	public static void Main(string[] args)
	{
		int[] a = new int[] { 9, 8, 10, 7, 6, 1, 4, 2, 5, 3 };
		PriorityQueue<int> pq = new PriorityQueue<int>(a, true);
		//pq.add(2);
		//pq.add(3);
		int count = pq.length();
		for (int i = 0; i < count; i++)
		{
			Console.WriteLine("value is :: " + pq.remove());
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
}
public virtual void insert(int value)
{
	if (maxHeap.length() == 0 || maxHeap.peek() >= value)
	{
		maxHeap.add(value);
	}
	else
	{
		minHeap.add(value);
	}

	//size balancing
	if (maxHeap.length() > minHeap.length() + 1)
	{
		value = maxHeap.remove();
		minHeap.add(value);
	}

	if (minHeap.length() > maxHeap.length() + 1)
	{
		value = minHeap.remove();
		maxHeap.add(value);
	}
}

public virtual int median()
{
	if (maxHeap.length() == 0 && minHeap.length() == 0)
	{
		throw new System.InvalidOperationException("EmptyException");
	}

	if (maxHeap.length() == minHeap.length())
	{
		return (maxHeap.peek() + minHeap.peek()) / 2;
	}
	else if (maxHeap.length() > minHeap.length())
	{
		return maxHeap.peek();
	}
	else
	{
		return minHeap.peek();
	}
}

public static void Main666(string[] args)
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