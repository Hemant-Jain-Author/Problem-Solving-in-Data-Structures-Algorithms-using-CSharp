using System;
using System.Collections;

public class MinMaxStack
{
	private const int MIN_CAPACITY = 1000;
	private int[] data;
	private int top = -1;
	private int minCapacity;
	private int maxCapacity;

	public MinMaxStack() : this(MIN_CAPACITY)
	{
		maxCapacity = minCapacity = MIN_CAPACITY;
	}

	public MinMaxStack(int capacity)
	{
		data = new int[capacity];
		maxCapacity = minCapacity = capacity;
	}

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
		if (size() == maxCapacity)
		{
			Console.WriteLine("size dubbelled");
			int[] newData = new int[maxCapacity * 2];
			Array.Copy(data, 0, newData, 0, maxCapacity);
			data = newData;
			maxCapacity = maxCapacity * 2;
		}
		top++;
		data[top] = value;
	}

	public int Peek()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("MinMaxStackEmptyException");
		}
		return data[top];
	}

	public int Pop()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("MinMaxStackEmptyException");
		}

		int topVal = data[top];
		top--;

		if (size() == maxCapacity / 2 && maxCapacity > minCapacity)
		{
			Console.WriteLine("size halfed");
			maxCapacity = maxCapacity / 2;
			int[] newData = new int[maxCapacity];
			Array.Copy(data, 0, newData, 0, maxCapacity);
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
		MinMaxStack s = new MinMaxStack(10);
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