using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class QueueDemo
{
	public static void Main99(string[] args)
	{
		Queue<int> que = new Queue<int>();
		que.Enqueue(1);
		que.Enqueue(2);
		que.Enqueue(3);
		que.Enqueue(4);
		que.Enqueue(5);

		int size = que.Count;
		for (int i = 0; i < size; i++)
		{
			Console.WriteLine("Dequeue from queue: " + que.Dequeue());
		}
	}
}
