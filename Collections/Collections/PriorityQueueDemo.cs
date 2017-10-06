using System;
using System.Collections;
using System.Collections.Generic;

public class PriorityQueueDemo
{
	public static void Main77(string[] args)
	{
		int[] arr = new int[] { 1, 2, 10, 8, 7, 3, 4, 6, 5, 9 };
		PriorityQueue<int> pq = new PriorityQueue<int>(arr, false);
		foreach (int i in arr)
		{
			pq.Enqueue(i);
		}

		Console.WriteLine("Priority Queue ::");
		foreach (int o in pq)
		{
			Console.WriteLine(o);
		}

		int size = pq.Count;
		Console.WriteLine("Dequeue elements of priority queue ::");
		while (pq.isEmpty() == false)
		{
			Console.WriteLine(pq.Dequeue());
		}
	}
}
