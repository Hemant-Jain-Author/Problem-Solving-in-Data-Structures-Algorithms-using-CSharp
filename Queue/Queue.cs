using System;
using System.Collections;

public class Queue
{
	private int count;
	private int capacity = 100;
	private int[] data;
	internal int front = 0;
	internal int back = 0;

	public Queue()
	{
		count = 0;
		data = new int[100];
	}

	public virtual bool add(int value)
	{
		if (count >= capacity)
		{
			Console.WriteLine("Queue is full.");
			return false;
		}
		else
		{
			count++;
			data[back] = value;
			back = (++back) % (capacity - 1);
		}
		return true;
	}

	public virtual int remove()
	{
		int value;
		if (count <= 0)
		{
			Console.WriteLine("Queue is empty.");
			return -999;
		}
		else
		{
			count--;
			value = data[front];
			front = (++front) % (capacity - 1);
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
