using System;

public class HeapEx
{

	public static void Demo(string[] args)
	{
		PriorityQueue<int> pq = new PriorityQueue<int>();
		int[] arr = new int[] {1, 2, 10, 8, 7, 3, 4, 6, 5, 9};

		foreach (int i in arr)
		{
			pq.Enqueue(i);
		}
		Console.WriteLine("Printing Priority Queue Heap : " + pq);

		Console.Write("Dequeue elements of Priority Queue ::");
		while (pq.IsEmpty() == false)
		{
			Console.Write(" " + pq.Dequeue());
		}
	}

	public static int KthSmallest(int[] arr, int size, int k)
	{
		Array.Sort(arr);
		return arr[k - 1];
	}

	public static int KthSmallest2(int[] arr, int size, int k)
	{
		PriorityQueue<int> pq = new PriorityQueue<int>();
		for (int i = 0; i < size; i++)
		{
			pq.Enqueue(arr[i]);
		}
		for (int i = 0; i < k - 1; i++)
		{
			pq.Dequeue();
		}
		return pq.Peek();
	}

	public static int KthSmallest3(int[] arr, int size, int k)
	{
		PriorityQueue<int> pq = new PriorityQueue<int>(false);
		for (int i = 0; i < size; i++)
		{
			if (i < k)
			{
				pq.Enqueue(arr[i]);
			}
			else
			{
				if (pq.Peek() > arr[i])
				{
					pq.Enqueue(arr[i]);
					pq.Dequeue();
				}
			}
		}
		return pq.Peek();
	}

	public static int KthLargest(int[] arr, int size, int k)
	{
		int value = 0;
		PriorityQueue<int> pq = new PriorityQueue<int>(false);
		for (int i = 0; i < size; i++)
		{
			pq.Enqueue(arr[i]);
		}
		for (int i = 0; i < k; i++)
		{
			value = pq.Dequeue();
		}
		return value;
	}

	public static bool IsMinHeap(int[] arr, int size)
	{
		int lchild, rchild;
		// last element index size - 1
		for (int parent = 0; parent < (size / 2 + 1); parent++)
		{
			lchild = parent * 2 + 1;
			rchild = parent * 2 + 2;
			// heap property check.
			if (((lchild < size) && (arr[parent] > arr[lchild])) || ((rchild < size) && (arr[parent] > arr[rchild])))
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsMaxHeap(int[] arr, int size)
	{
		int lchild, rchild;
		// last element index size - 1
		for (int parent = 0; parent < (size / 2 + 1); parent++)
		{
			lchild = parent * 2 + 1;
			rchild = lchild + 1;
			// heap property check.
			if (((lchild < size) && (arr[parent] < arr[lchild])) || ((rchild < size) && (arr[parent] < arr[rchild])))
			{
				return false;
			}
		}
		return true;
	}

	public static void Main0(string[] args)
	{
		int[] arr = new int[] {8, 7, 6, 5, 7, 5, 2, 1};
		Console.WriteLine("Kth Smallest :: " + KthSmallest(arr, arr.Length, 3));
		int[] arr2 = new int[] {8, 7, 6, 5, 7, 5, 2, 1};
		Console.WriteLine("Kth Smallest :: " + KthSmallest2(arr2, arr2.Length, 3));
	}
	/*
	Kth Smallest :: 5
	Kth Smallest :: 5
	*/

	public static void Main1()
	{
		int[] arr3 = new int[] {8, 7, 6, 5, 7, 5, 2, 1};
		Console.WriteLine("IsMaxHeap :: " + IsMaxHeap(arr3, arr3.Length));
		int[] arr4 = new int[] {1, 2, 3, 4, 5, 6, 7, 8};
		Console.WriteLine("IsMinHeap :: " + IsMinHeap(arr4, arr4.Length));
	}

	/*
	IsMaxHeap :: true
	IsMinHeap :: true     
	*/
	public static int KSmallestProduct(int[] arr, int size, int k)
	{
		Array.Sort(arr);
		int product = 1;
		for (int i = 0; i < k; i++)
		{
			product *= arr[i];
		}
		return product;
	}

	public static void Swap(int[] arr, int i, int j)
	{
		int temp = arr[i];
		arr[i] = arr[j];
		arr[j] = temp;
	}

	public static void QuickSelectUtil(int[] arr, int lower, int upper, int k)
	{
		if (upper <= lower)
		{
			return;
		}

		int pivot = arr[lower];
		int start = lower;
		int stop = upper;

		while (lower < upper)
		{
			while (lower < upper && arr[lower] <= pivot)
			{
				lower++;
			}
			while (lower <= upper && arr[upper] > pivot)
			{
				upper--;
			}
			if (lower < upper)
			{
				Swap(arr, upper, lower);
			}
		}

		Swap(arr, upper, start); // upper is the pivot position
		if (k < upper)
		{
			QuickSelectUtil(arr, start, upper - 1, k); // pivot -1 is the upper for left sub array.
		}
		if (k > upper)
		{
			QuickSelectUtil(arr, upper + 1, stop, k); // pivot + 1 is the lower for right sub array.
		}
	}

	public static int KSmallestProduct3(int[] arr, int size, int k)
	{
		QuickSelectUtil(arr, 0, size - 1, k);
		int product = 1;
		for (int i = 0; i < k; i++)
		{
			product *= arr[i];
		}
		return product;
	}

	public static int KSmallestProduct2(int[] arr, int size, int k)
	{
		PriorityQueue<int> pq = new PriorityQueue<int>();
		int i = 0;
		int product = 1;
		for (i = 0; i < size; i++)
		{
			pq.Enqueue(arr[i]);
		}
		i = 0;
		while (i < size && i < k)
		{
			product *= pq.Dequeue();
			i += 1;
		}
		return product;
	}

	public static int KSmallestProduct4(int[] arr, int size, int k)
	{
		PriorityQueue<int> pq = new PriorityQueue<int>(false);
		for (int i = 0; i < size; i++)
		{
			if (i < k)
			{
				pq.Enqueue(arr[i]);
			}
			else
			{
				if (pq.Peek() > arr[i])
				{
					pq.Enqueue(arr[i]);
					pq.Dequeue();
				}
			}
		}
		int product = 1;
		for (int i = 0; i < k; i++)
		{
			product *= pq.Dequeue();
		}
		return product;
	}

	public static void Main2()
	{
		int[] arr = new int[] {8, 7, 6, 5, 7, 5, 2, 1};
		Console.WriteLine("Kth Smallest product:: " + KSmallestProduct(arr, 8, 3));
		int[] arr2 = new int[] {8, 7, 6, 5, 7, 5, 2, 1};
		Console.WriteLine("Kth Smallest product:: " + KSmallestProduct2(arr2, 8, 3));
		int[] arr3 = new int[] {8, 7, 6, 5, 7, 5, 2, 1};
		Console.WriteLine("Kth Smallest product:: " + KSmallestProduct3(arr3, 8, 3));
		int[] arr4 = new int[] {8, 7, 6, 5, 7, 5, 2, 1};
		Console.WriteLine("Kth Smallest product:: " + KSmallestProduct4(arr4, 8, 3));
	}

	/*
	 * Kth Smallest product:: 10 
	 * Kth Smallest product:: 10 
	 * Kth Smallest product:: 10
	 * Kth Smallest product:: 10
	 */

	public static void PrintLargerHalf(int[] arr, int size)
	{
		Array.Sort(arr);
		for (int i = size / 2; i < size; i++)
		{
			Console.Write(arr[i] + " ");
		}
		Console.WriteLine();
	}

	public static void PrintLargerHalf2(int[] arr, int size)
	{
		PriorityQueue<int> pq = new PriorityQueue<int>();
		for (int i = 0; i < size; i++)
		{
			pq.Enqueue(arr[i]);
		}

		for (int i = 0; i < size / 2; i++)
		{
			pq.Dequeue();
		}
		pq.Print();
	}

	public static void PrintLargerHalf3(int[] arr, int size)
	{
		QuickSelectUtil(arr, 0, size - 1, size / 2);
		for (int i = size / 2; i < size; i++)
		{
			Console.Write(arr[i] + " ");
		}
		Console.WriteLine();
	}

	public static void Main3()
	{
		int[] arr = new int[] {8, 7, 6, 5, 7, 5, 2, 1};
		PrintLargerHalf(arr, 8);
		int[] arr2 = new int[] {8, 7, 6, 5, 7, 5, 2, 1};
		PrintLargerHalf2(arr2, 8);
		int[] arr3 = new int[] {8, 7, 6, 5, 7, 5, 2, 1};
		PrintLargerHalf3(arr3, 8);
	}

	/*
	 * 6 7 7 8 
	 * 6 7 7 8 
	 * 6 7 7 8
	 */

	public static void SortK(int[] arr, int size, int k)
	{
		PriorityQueue<int> pq = new PriorityQueue<int>();
		int i = 0;
		for (i = 0; i < k; i++)
		{
			pq.Enqueue(arr[i]);
		}

		int[] output = new int[size];
		int index = 0;

		for (i = k; i < size; i++)
		{
			output[index++] = pq.Dequeue();
			pq.Enqueue(arr[i]);
		}
		while (pq.Size() > 0)
		{
			output[index++] = pq.Dequeue();
		}

		for (i = k; i < size; i++)
		{
			arr[i] = output[i];
		}
	}

	// Testing Code
	public static void Main4()
	{
		int k = 3;
		int[] arr = new int[] {1, 5, 4, 10, 50, 9};
		int size = arr.Length;
		SortK(arr, size, k);
		for (int i = 0; i < size; i++)
		{
			Console.Write(arr[i] + " ");
		}
	}
	/*
	 * 1 5 4 9 10 50
	 */
	public static void Main(string[] args)
	{
		Main1();
		Main2();
		Main3();
		Main4();
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
