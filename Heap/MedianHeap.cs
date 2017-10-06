using System;

public class MedianHeap
{
	internal PriorityQueue<int> minHeap;
	internal PriorityQueue<int> maxHeap;

	public MedianHeap()
	{
		minHeap = new PriorityQueue<int>();
		maxHeap = new PriorityQueue<int>(Collections.reverseOrder());
	}

	//Other Methods.

	public void insert(int value)
	{
		if (maxHeap.size() == 0 || maxHeap.peek() >= value)
		{
			maxHeap.add(value);
		}
		else
		{
			minHeap.add(value);
		}

		//size balancing
		if (maxHeap.size() > minHeap.size() + 1)
		{
			value = maxHeap.remove();
			minHeap.add(value);
		}

		if (minHeap.size() > maxHeap.size() + 1)
		{
			value = minHeap.remove();
			maxHeap.add(value);
		}
	}

	public int median()
	{
		if (maxHeap.size() == 0 && minHeap.size() == 0)
		{
			throw new System.InvalidOperationException("EmptyException");
		}

		if (maxHeap.size() == minHeap.size())
		{
			return (maxHeap.peek() + minHeap.peek()) / 2;
		}
		else if (maxHeap.size() > minHeap.size())
		{
			return maxHeap.peek();
		}
		else
		{
			return minHeap.peek();
		}
	}

	public static void Main(string[] args)
	{
		int[] arr = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5, 1, 9, 2, 8, 3, 7, 4, 6, 5, 10, 10 };
		MedianHeap hp = new MedianHeap();

		for (int i = 0; i < 20; i++)
		{
			hp.insert(arr[i]);
			Console.WriteLine("Median after insertion of " + arr[i] + " is  " + hp.median());
		}
	}
}