using System;

public class TwoStack
{
	private readonly int MAX_SIZE = 50;
	private int top1;
	private int top2;
	private int[] data;

	public TwoStack()
	{
		top1 = -1;
		top2 = MAX_SIZE;
		data = new int[MAX_SIZE];
	}

	public void Push1(int value)
	{
		if (top1 < top2 - 1)
		{
			data[++top1] = value;
		}
		else
		{
			Console.Write("Stack is Full!");
		}
	}

	public void Push2(int value)
	{
		if (top1 < top2 - 1)
		{
			data[--top2] = value;
		}
		else
		{
			Console.Write("Stack is Full!");
		}
	}

	public int Pop1()
	{
		if (top1 >= 0)
		{
			int value = data[top1--];
			return value;
		}
		else
		{
			Console.Write("Stack Empty!");
		}
		return -999;
	}

	public int Pop2()
	{
		if (top2 < MAX_SIZE)
		{
			int value = data[top2++];
			return value;
		}
		else
		{
			Console.Write("Stack Empty!");
		}
		return -999;
	}
	public static void Main(string[] args)
	{
		TwoStack st = new TwoStack();
		st.Push1(1);
		st.Push1(2);
		st.Push1(3);
		st.Push2(4);
		st.Push2(5);
		st.Push2(6);
		Console.WriteLine("stk1 pop: " + st.Pop1());
		Console.WriteLine("stk1 pop: " + st.Pop1());
		Console.WriteLine("stk2 pop: " + st.Pop2());
		Console.WriteLine("stk2 pop: " + st.Pop2());
	}
}

/*
stk1 pop: 3
stk1 pop: 2
stk2 pop: 6
stk2 pop: 5
*/
