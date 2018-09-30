using System;

public class Stack2
{
	private int[] data;
	private int top = -1;
	private int minCapacity;
	private int capacity;

	public Stack2() : this(1000)
	{
	}

	public Stack2(int size)
	{
		data = new int[size];
		capacity = minCapacity = size;
	}

	/* Other methods */
	public int size()
	{
		return (top + 1);
	}

	public bool Empty
	{
		get
		{
			return (top == -1);
		}
	}

	public void Push(int value)
	{
		if (size() == capacity)
		{
			Console.WriteLine("size dubbelled");
			int[] newData = new int[capacity * 2];
			Array.Copy(data, 0, newData, 0, capacity);
			data = newData;
			capacity = capacity * 2;
		}
		top++;
		data[top] = value;
	}

	public int Peek()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("StackEmptyException");
		}
		return data[top];
	}

	public int Pop()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("StackEmptyException");
		}

		int topVal = data[top];
		top--;
		if (size() == capacity / 2 && capacity > minCapacity)
		{
			Console.WriteLine("size halfed");
			capacity = capacity / 2;
			int[] newData = new int[capacity];
			Array.Copy(data, 0, newData, 0, capacity);
			data = newData;
		}
		return topVal;
	}

	public void print()
	{
		for (int i = top; i > -1; i--)
		{
			Console.Write(" " + data[i]);
		}
	}

	public static void Main(string[] args)
	{
		Stack2 s = new Stack2(10);
		for (int i = 1; i <= 100; i++)
		{
			s.Push(i);
		}
		for (int i = 1; i <= 100; i++)
		{
			s.Pop();
		}
		s.print();
	}
}
