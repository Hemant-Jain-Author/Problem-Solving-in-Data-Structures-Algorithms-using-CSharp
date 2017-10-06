using System;
using System.Collections.Generic;

public class QueueUsingStack
{
	public QueueUsingStack()
	{
		stk1 = new Stack<int>();
		stk2 = new Stack<int>();
	}
	private Stack<int> stk1;
	private Stack<int> stk2;


	public void add(int value)
	{
		stk1.Push(value);
	}

	public int remove()
	{
		int value;
		if (stk2.Count != 0)
		{
			return stk2.Pop();
		}

		while (stk1.Count != 0)
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
		que.add(11);
		que.add(111);
		Console.WriteLine(que.remove());
		que.add(2);
		que.add(21);
		que.add(211);
		Console.WriteLine(que.remove());
		Console.WriteLine(que.remove());
		Console.WriteLine(que.remove());
		Console.WriteLine(que.remove());
		Console.WriteLine(que.remove());
	}
}