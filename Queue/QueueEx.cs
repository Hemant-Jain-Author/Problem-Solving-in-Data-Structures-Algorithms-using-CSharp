using System;
using System.Collections.Generic;

public class QueueEx
{

	public static int CircularTour(int[,] arr, int n)
	{
		Queue<int> que = new Queue<int>();
		int nextPump = 0, prevPump;
		int count = 0;
		int petrol = 0;

		while (que.Count != n)
		{
			while (petrol >= 0 && que.Count != n)
			{
				que.Enqueue(nextPump);
				petrol += (arr[nextPump, 0] - arr[nextPump, 1]);
				nextPump = (nextPump + 1) % n;
			}
			while (petrol < 0 && que.Count > 0)
			{
				prevPump = que.Dequeue();
				petrol -= (arr[prevPump, 0] - arr[prevPump, 1]);
			}
			count += 1;
			if (count == n)
			{
				return -1;
			}
		}
		if (petrol >= 0)
		{
			return que.Dequeue();
		}
		else
		{
			return -1;
		}
	}

	public static void Main1(string[] args)
	{
		// Testing code
		int[,] tour = new int[,] { { 8, 6 }, { 1, 4 }, { 7, 6 } };
		Console.WriteLine(" Circular Tour : " + CircularTour(tour, 3));
	}

	public static int convertXY(int src, int dst)
	{
		Queue<int> que = new Queue<int>();
		int[] arr = new int[100];
		int steps = 0;
		int index = 0;
		int value;

		que.Enqueue(src);
		while (que.Count != 0)
		{
			value = que.Dequeue();
			arr[index++] = value;

			if (value == dst)
			{
				for (int i = 0; i < index; i++)
				{
					Console.Write(arr[i]);
				}
				Console.Write("Steps countr :: " + steps);
				return steps;
			}
			steps++;
			if (value < dst)
			{
				que.Enqueue(value * 2);
			}
			else
			{
				que.Enqueue(value - 1);
			}
		}
		return -1;
	}

	public static void Main2(string[] args)
	{
		convertXY(2, 7);
	}

	public static void maxSlidingWindows(int[] arr, int size, int k)
	{
		LinkedList<int> que = new LinkedList<int>();
		for (int i = 0; i < size; i++)
		{
			// Remove out of range elements
			if (que.Count > 0 && que.First.Value <= i - k)
			{
				que.RemoveFirst();
			}
			// Remove smaller values at left.
			while (que.Count > 0 && arr[que.Last.Value] <= arr[i])
			{
				que.RemoveLast();
			}

			que.AddLast(i);
			// Largest value in window of size k is at index que[0]
			// It is displayed to the screen.
			if (i >= (k - 1))
			{
				Console.WriteLine(arr[que.First.Value]);
			}
		}
	}

	public static void Main3(string[] args)
	{
		int[] arr = new int[] { 11, 2, 75, 92, 59, 90, 55 };
		int k = 3;
		maxSlidingWindows(arr, 7, 3);
		// Output 75, 92, 92, 92, 90
	}

	public static int minOfMaxSlidingWindows(int[] arr, int size, int k)
	{
		LinkedList<int> que = new LinkedList<int>();
		int minVal = 999999;
		for (int i = 0; i < size; i++)
		{
			// Remove out of range elements
			if (que.Count > 0 && que.First.Value <= i - k)
			{
				que.RemoveFirst();
			}
			// Remove smaller values at left.
			while (que.Count > 0 && arr[que.Last.Value] <= arr[i])
			{
				que.RemoveLast();
			}
			que.AddLast(i);
			// window of size k
			if (i >= (k - 1) && minVal > arr[que.First.Value])
			{
				minVal = arr[que.First.Value];
			}
		}
		Console.WriteLine("Min of max is :: " + minVal);
		return minVal;
	}

	public static void Main4(string[] args)
	{
		int[] arr = new int[] { 11, 2, 75, 92, 59, 90, 55 };
		minOfMaxSlidingWindows(arr, 7, 3);
		// Output 75
	}

	public static void maxOfMinSlidingWindows(int[] arr, int size, int k)
	{
		LinkedList<int> que = new LinkedList<int>();
		int maxVal = -999999;
		for (int i = 0; i < size; i++)
		{
			// Remove out of range elements
			if (que.Count > 0 && que.First.Value <= i - k)
			{
				que.RemoveFirst();
			}
			// Remove smaller values at left.
			while (que.Count > 0 && arr[que.Last.Value] >= arr[i])
			{
				que.RemoveLast();
			}
			que.AddLast(i);
			// window of size k
			if (i >= (k - 1) && maxVal < arr[que.First.Value])
			{
				maxVal = arr[que.First.Value];
			}
		}
		Console.WriteLine("Max of min is :: " + maxVal);
	}

	public static void Main5(string[] args)
	{
		int[] arr = new int[] { 11, 2, 75, 92, 59, 90, 55 };
		int k = 3;
		maxOfMinSlidingWindows(arr, 7, 3);
		// Output 59, as minimum values in sliding windows are [2, 2, 59, 59, 55]
	}

	public static void firstNegSlidingWindows(int[] arr, int size, int k)
	{
		Queue<int> que = new Queue<int>();

		for (int i = 0; i < size; i++)
		{
			// Remove out of range elements
			if (que.Count > 0 && que.Peek() <= i - k)
			{
				que.Dequeue();
			}
			if (arr[i] < 0)
			{
				que.Enqueue(i);
			}
			// window of size k
			if (i >= (k - 1))
			{
				if (que.Count > 0)
				{
					Console.Write(arr[que.Peek()]);
				}
				else
				{
					Console.Write("NAN");
				}
			}
		}
	}

	public static void Main6(string[] args)
	{
		int[] arr = new int[] { 3, -2, -6, 10, -14, 50, 14, 21 };
		int k = 3;
		firstNegSlidingWindows(arr, 8, 3);
		// Output [-2, -2, -6, -14, -14, NAN]
	}

	public static void Main(string[] args)
	{
		Main1(args);
		Main2(args);
		Main3(args);
		Main4(args);
		Main5(args);
		Main6(args);
	}
}