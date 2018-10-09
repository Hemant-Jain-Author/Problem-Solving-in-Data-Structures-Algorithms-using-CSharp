using System;
using System.Collections.Generic;

class StackDemo
{
	public static void Main(string[] args)
	{
		Stack<int> stk = new Stack<int>();
		stk.Push(1);
		stk.Push(2);
		stk.Push(3);
		stk.Push(4);

		Console.WriteLine("Element at top of stack ::" + stk.Peek());
		int size = stk.Count;
		for (int i = 0; i < size; i++)
			Console.WriteLine("Pop from stack: " + stk.Pop());
	}
}
