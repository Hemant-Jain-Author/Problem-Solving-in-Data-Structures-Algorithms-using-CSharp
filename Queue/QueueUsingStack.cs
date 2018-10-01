using System;
using System.Collections.Generic;

public class QueueUsingStack
{
	private Stack<int> stk1;
	private Stack<int> stk2;

	public QueueUsingStack()
	{
		stk1 = new Stack<int>();
		stk2 = new Stack<int>();
	}

	internal void add(int value)
	{
		stk1.Push(value);
	}

	internal int remove()
	{
		int value;
		if (stk2.Count > 0)
		{
			return stk2.Pop();
		}

		while (stk1.Count > 0)
		{
			value = stk1.Pop();
			stk2.Push(value);
		}
		return stk2.Pop();
	}

	public static void Main(string[] args)
	{
		QueueUsingStack que = new QueueUsingStack();
		que.add(1);
		que.add(2);
		que.add(3);
		for (int i = 0; i < 3; i++)
		{
			Console.WriteLine(q.remove());
		}
	}
}