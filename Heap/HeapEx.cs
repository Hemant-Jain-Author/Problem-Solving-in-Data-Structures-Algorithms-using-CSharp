using System;

public class HeapEx
{

	public static void demo(string[] args)
	{

		PriorityQueue<int> pq = new PriorityQueue<int>();
		// PriorityQueue<Integer> pq = new
		// PriorityQueue<Integer>(Collections.reverseOrder());
		int[] arr = new int[] { 1, 2, 10, 8, 7, 3, 4, 6, 5, 9 };

		foreach (int i in arr)
		{
			pq.add(i);
		}
		Console.WriteLine("Printing Priority Queue Heap : " + pq);

		Console.Write("Dequeue elements of Priority Queue ::");
		while (pq.isEmpty() == false)
		{
			Console.Write(" " + pq.remove());
		}
	}

	public static int KthSmallest(int[] arr, int size, int k)
	{
		Array.Sort(arr);
		return arr[k - 1];
	}

	public static int KthSmallest2(int[] arr, int size, int k)
	{
		int i = 0;
		int value = 0;
		PriorityQueue<int> pq = new PriorityQueue<int>();
		for (i = 0; i < size; i++)
		{
			pq.add(arr[i]);
		}

		while (i < size && i < k)
		{
			value = pq.remove();
			i += 1;
		}
		return value;
	}

	public static bool isMinHeap(int[] arr, int size)
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

	public static bool isMaxHeap(int[] arr, int size)
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

	public static void main2(string[] args)
	{
		int[] arr = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
		Console.WriteLine("Kth Smallest :: " + KthSmallest(arr, arr.Length, 3));
		int[] arr2 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
		Console.WriteLine("Kth Smallest :: " + KthSmallest2(arr2, arr2.Length, 3));
		int[] arr3 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
		Console.WriteLine("isMaxHeap :: " + isMaxHeap(arr3, arr3.Length));
		int[] arr4 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
		Array.Sort(arr4);
		Console.WriteLine("isMinHeap :: " + isMinHeap(arr4, arr4.Length));
	}

	public static int KSmallestProduct(int[] arr, int size, int k)
	{
		Array.Sort(arr); // , size, 1);
		int product = 1;
		for (int i = 0; i < k; i++)
		{
			product *= arr[i];
		}
		return product;
	}

	public static void swap(int[] arr, int i, int j)
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
				swap(arr, upper, lower);
			}
		}

		swap(arr, upper, start); // upper is the pivot position
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
			pq.add(arr[i]);
		}

		while (i < size && i < k)
		{
			product *= pq.remove();
			i += 1;
		}
		return product;
	}

	public static void main3(string[] args)
	{
		int[] arr = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
		Console.WriteLine("Kth Smallest product:: " + KSmallestProduct(arr, 8, 3));
		int[] arr2 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
		Console.WriteLine("Kth Smallest product:: " + KSmallestProduct2(arr2, 8, 3));
		int[] arr3 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
		Console.WriteLine("Kth Smallest product:: " + KSmallestProduct3(arr3, 8, 3));
	}

	public static void PrintLargerHalf(int[] arr, int size)
	{
		Array.Sort(arr); // , size, 1);
		for (int i = size / 2; i < size; i++)
		{
			Console.Write(arr[i]);
		}
		Console.WriteLine();
	}

	public static void PrintLargerHalf2(int[] arr, int size)
	{
		PriorityQueue<int> pq = new PriorityQueue<int>();
		for (int i = 0; i < size; i++)
		{
			pq.add(arr[i]);
		}

		for (int i = 0; i < size / 2; i++)
		{
			pq.remove();
		}
		Console.WriteLine(pq);
	}

	public static void PrintLargerHalf3(int[] arr, int size)
	{
		QuickSelectUtil(arr, 0, size - 1, size / 2);
		for (int i = size / 2; i < size; i++)
		{
			Console.Write(arr[i]);
		}
		Console.WriteLine();
	}

	public static void main4(string[] args)
	{
		int[] arr = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
		PrintLargerHalf(arr, 8);
		int[] arr2 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
		PrintLargerHalf2(arr2, 8);
		int[] arr3 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
		PrintLargerHalf3(arr3, 8);
	}

	public static void sortK(int[] arr, int size, int k)
	{
		PriorityQueue<int> pq = new PriorityQueue<int>();
		int i = 0;
		for (i = 0; i < size; i++)
		{
			pq.add(arr[i]);
		}

		int[] output = new int[size];
		int index = 0;

		for (i = k; i < size; i++)
		{
			output[index++] = pq.remove();
			pq.add(arr[i]);
		}
		while (pq.size() > 0)
		{
			output[index++] = pq.remove();
		}

		for (i = k; i < size; i++)
		{
			arr[i] = output[i];
		}
		Console.WriteLine(output);
	}

	// Testing Code
	public static void main5(string[] args)
	{
		int k = 3;
		int[] arr = new int[] { 1, 5, 4, 10, 50, 9 };
		int size = arr.Length;
		sortK(arr, size, k);
	}

	public static int ChotaBhim(int[] cups, int size)
	{
		int time = 60;
		Array.Sort(cups);
		int total = 0;
		int index, temp;
		while (time > 0)
		{
			total += cups[0];
			cups[0] = (int)Math.Ceiling(cups[0] / 2.0);
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
		Console.WriteLine("Total " + total);
		return total;
	}

	public static int ChotaBhim2(int[] cups, int size)
	{
		int time = 60;
		Array.Sort(cups);
		int total = 0;
		int i, temp;
		while (time > 0)
		{
			total += cups[0];
			cups[0] = (int)Math.Ceiling(cups[0] / 2.0);
			i = 0;
			// Insert into proper location.
			while (i < size - 1)
			{
				if (cups[i] > cups[i + 1])
				{
					break;
				}
				temp = cups[i];
				cups[i] = cups[i + 1];
				cups[i + 1] = temp;
				i += 1;
			}
			time -= 1;
		}
		Console.WriteLine("Total : " + total);
		return total;
	}

	public static int ChotaBhim3(int[] cups, int size)
	{
		int time = 60;
		PriorityQueue<int> pq = new PriorityQueue<int>();
		int i = 0;
		for (i = 0; i < size; i++)
		{
			pq.add(cups[i]);
		}

		int total = 0;
		int value;
		while (time > 0)
		{
			value = pq.remove();
			total += value;
			value = (int)Math.Ceiling(value / 2.0);
			pq.add(value);
			time -= 1;
		}
		Console.WriteLine("Total : " + total);
		return total;
	}

	public static int JoinRopes(int[] ropes, int size)
	{
		Array.Sort(ropes);
		Console.WriteLine(ropes);
		int total = 0;
		int value = 0;
		int index;
		int length = size;

		while (length >= 2)
		{
			value = ropes[length - 1] + ropes[length - 2];
			total += value;
			index = length - 2;

			while (index > 0 && ropes[index - 1] < value)
			{
				ropes[index] = ropes[index - 1];
				index -= 1;
			}
			ropes[index] = value;
			length--;
		}
		Console.WriteLine("Total : " + total);
		return total;
	}

	public static int JoinRopes2(int[] ropes, int size)
	{
		PriorityQueue<int> pq = new PriorityQueue<int>();
		int i = 0;
		for (i = 0; i < size; i++)
		{
			pq.add(ropes[i]);
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
		int[] cups = new int[] { 2, 1, 7, 4, 2 };
		ChotaBhim(cups, cups.Length);
		int[] cups2 = new int[] { 2, 1, 7, 4, 2 };
		ChotaBhim2(cups2, cups.Length);
		int[] cups3 = new int[] { 2, 1, 7, 4, 2 };
		ChotaBhim3(cups3, cups.Length);

		int[] ropes = new int[] { 2, 1, 7, 4, 2 };
		JoinRopes(ropes, ropes.Length);
		int[] rope2 = new int[] { 2, 1, 7, 4, 2 };
		JoinRopes2(rope2, rope2.Length);
	}

	/*
		* public static int kthAbsDiff(int[] arr, int size, int k) { Sort(arr, size,1);
		* int diff[1000]; int index = 0; for (int i = 0; i < size - 1; i++) { for (int
		* j = i + 1; j < size; j++) diff[index++] = abs(arr[i] - arr[j]); } Sort(diff,
		* index); return diff[k - 1]; }
		* 
		* int kthAbsDiff(int[] arr, int size, int k) { Sort(arr, size, 1); Heap hp; int
		* value = 0;
		* 
		* for (int i = k + 1; i < size - 1; i++) HeapAdd(&hp,(abs(arr[i] - arr[i + 1]),
		* i, i + 1)); heapify(hp);
		* 
		* for (int i = 0; i < k; i++) { tp = heapq.heappop(hp); value = tp[0]; src =
		* tp[1]; dst = tp[2]; if (dst + 1 < size) heapq.heappush(hp, (abs(arr[src] -
		* arr[dst + 1]), src, dst + 1)); } return value; }
		* 
		* public static void main7(String[] args) { int arr[] = { 1, 2, 3, 4 };
		* System.out.println("", kthAbsDiff(arr, 4, 5)); return 0; }
		*/
	public static int kthLargestStream(int k)
	{
		PriorityQueue<int> pq = new PriorityQueue<int>();
		int size = 0;
		int data = 0;
		while (true)
		{
			Console.WriteLine("Enter data: ");
			//data = System.in.read();

			if (size < k - 1)
			{
				pq.add(data);
			}
			else
			{
				if (size == k - 1)
				{
					pq.add(data);
				}
				else if (pq.peek() < data)
				{
					pq.add(data);
					pq.remove();
				}
				Console.WriteLine("Kth larges element is :: " + pq.peek());
			}
			size += 1;
		}
	}

	public static void Main888(string[] args)
	{
		kthLargestStream(3);
	}
	/*
		* public static int minJumps(int[] arr, int size) { int *jumps = (int
		* *)malloc(sizeof(int) * size); //all jumps to maxint. int steps, j; jumps[0] =
		* 0;
		* 
		* for (int i = 0; i < size; i++) { steps = arr[i]; // error checks can be added
		* hear. j = i + 1; while (j <= i + steps && j < size) { jumps[j] =
		* min(jumps[j], jumps[i] + 1); j += 1; } System.out.println("%s", jumps); }
		* return jumps[size - 1]; } public static void main2(String[] args) { int arr[]
		* = {1, 4, 3, 7, 6, 1, 0, 3, 5, 1, 10}; System.out.println("%d", minJumps(arr,
		* sizeof(arr) / sizeof(int))); return 0; }
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