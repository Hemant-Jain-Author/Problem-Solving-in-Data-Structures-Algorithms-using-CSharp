using System;
using System.Collections;

public class Queue
{
	private int count;
	private int Capacity = 100;
	private int[] data;
	internal int front = 0;
	internal int back = 0;

	public Queue()
	{
		count = 0;
		data = new int[100];
	}

	public virtual void add(int value)
	{
		if (count >= Capacity)
		{
			throw new System.InvalidOperationException("QueueFullException");
		}
		else
		{
			count++;
			data[back] = value;
			back = (++back) % (Capacity - 1);
		}
	}

	public virtual int remove()
	{
		int value;
		if (count <= 0)
		{
			throw new System.InvalidOperationException("QueueEmptyException");
		}
		else
		{
			count--;
			value = data[front];
			front = (++front) % (Capacity - 1);
		}
		return value;
	}

	internal virtual bool Empty
	{
		get
		{
			return count == 0;
		}
	}

	internal virtual int size()
	{
		return count;
	}

	public static void Main(string[] args)
	{
		Queue que = new Queue();

		for (int i = 0; i < 20; i++)
		{
			que.add(i);
		}
		for (int i = 0; i < 22; i++)
		{
			Console.WriteLine(que.remove());
		}
	}
}