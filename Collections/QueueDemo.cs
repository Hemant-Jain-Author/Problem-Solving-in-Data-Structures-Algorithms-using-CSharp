using System;
using System.Collections.Generic;

class QueueDemo
{
	public static void Main5(string[] args)
	{
		Queue<int> que = new Queue<int>();
		que.Enqueue(1);
		que.Enqueue(2);
		que.Enqueue(3);
		que.Enqueue(4);

		int size = que.Count;
		for (int i = 0; i < size; i++)
			Console.WriteLine("Dequeue from queue: " + que.Dequeue());
	}
}