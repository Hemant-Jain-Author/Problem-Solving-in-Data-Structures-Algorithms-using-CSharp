using System;

public class TwoStack
{
	private readonly int MAX_SIZE = 50;
	internal int top1;
	internal int top2;
	internal int[] data;

	public TwoStack()
	{
		top1 = -1;
		top2 = MAX_SIZE;
		data = new int[MAX_SIZE];
	}

	public static void Main(string[] args)
	{
		TwoStack st = new TwoStack();
		for (int i = 0; i < 10; i++)
		{
			st.StackPush1(i);
		}
		for (int j = 0; j < 10; j++)
		{
			st.StackPush2(j + 10);
		}
		for (int i = 0; i < 10; i++)
		{
			Console.WriteLine("stack one pop value is : " + st.StackPop1());
			Console.WriteLine("stack two pop value is : " + st.StackPop2());
		}
	}

	public virtual void StackPush1(int value)
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

	public virtual void StackPush2(int value)
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

	public virtual int StackPop1()
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

	public virtual int StackPop2()
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
}
