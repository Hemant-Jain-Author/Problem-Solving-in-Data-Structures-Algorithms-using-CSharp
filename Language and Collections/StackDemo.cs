using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StackDemo
{
	public static void Main44(string[] args)
	{
		Stack<int> stk = new Stack<int>();
		stk.Push(10);
		stk.Push(20);
		stk.Push(9);
		stk.Push(21);
		stk.Push(8);
		stk.Push(22);

		Console.WriteLine("Element at top of stack ::" + stk.Peek());
		int size = stk.Count;
		for (int i = 0; i < size; i++)
		{
			Console.WriteLine("Pop from stack: " + stk.Pop());
		}
	}
}
