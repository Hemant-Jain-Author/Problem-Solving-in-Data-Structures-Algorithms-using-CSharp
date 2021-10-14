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

	public int Size()
	{
		return (top + 1);
	}

	public bool IsEmpty()
	{
		return (top == -1);
	}

	public void Push(int value)
	{
		if (Size() == capacity)
		{
			Console.WriteLine("size doubled");
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
		if (IsEmpty())
		{
			throw new System.InvalidOperationException("StackEmptyException");
		}
		return data[top];
	}

	public int Pop()
	{
		if (IsEmpty())
		{
			throw new System.InvalidOperationException("StackEmptyException");
		}

		int topVal = data[top];
		top--;
		if (Size() == capacity / 2 && capacity > minCapacity)
		{
			Console.WriteLine("size halved");
			capacity = capacity / 2;
			int[] newData = new int[capacity];
			Array.Copy(data, 0, newData, 0, capacity);
			data = newData;
		}
		return topVal;
	}

	public void Print()
	{
		for (int i = top; i > -1; i--)
		{
			Console.Write(data[i] + " ");
		}
		Console.WriteLine();
	}

	public static void Main(string[] args)
	{
		Stack2 s = new Stack2(5);
		for (int i = 1; i <= 11; i++)
		{
			s.Push(i);
		}
		s.Print();
		for (int i = 1; i <= 11; i++)
		{
			s.Pop();
		}
	}
}
/*
size doubled
size doubled
11 10 9 8 7 6 5 4 3 2 1 
size halved
size halved
*/