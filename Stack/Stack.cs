using System;
using System.Collections;

public class ArrayStack
{

	private const int CAPACITY = 1000;
	private int[] data;
	private int top = -1;

	public ArrayStack() : this(CAPACITY)
	{
	}

	public ArrayStack(int capacity)
	{
		data = new int[capacity];
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
		if (size() == data.Length)
		{
			throw new System.InvalidOperationException("ArrayStackOvarflowException");
		}
		top++;
		data[top] = value;
	}


	public int Peek()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("ArrayStackEmptyException");
		}
		return data[top];
	}

	public int Pop()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("ArrayStackEmptyException");
		}
		int topVal = data[top];
		top--;
		return topVal;
	}

	public void Print()
	{
		for (int i = top; i > -1; i--)
		{
			Console.Write(" " + data[i]);
		}
	}

	public static void Main(string[] args)
	{
		ArrayStack s = new ArrayStack(1000);
		for (int i = 1; i <= 100; i++)
		{
			s.Push(i);
		}
		for (int i = 1; i <= 50; i++)
		{
			s.Pop();
		}
		s.Print();
	}
}