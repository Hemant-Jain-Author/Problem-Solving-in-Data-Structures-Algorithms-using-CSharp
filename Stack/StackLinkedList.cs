using System;

public class StackLL
{
	private Node head = null;
	private int count = 0;

	private class Node
	{
		internal int value;
		internal Node next;

		public Node(int v, Node n)
		{
			value = v;
			next = n;
		}
	}

	public int size()
	{
		return count;
	}

	public bool Empty
	{
		get
		{
			return count == 0;
		}
	}

	public int peek()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("StackEmptyException");
		}
		return head.value;
	}

	public void Push(int value)
	{
		head = new Node(value, head);
		count++;
	}

	public int Pop()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("StackEmptyException");
		}
		int value = head.value;
		head = head.next;
		count--;
		return value;
	}

	public void insertAtBottom(int value)
	{
		if (Empty)
		{
			Push(value);
		}
		else
		{
			int temp = Pop();
			insertAtBottom(value);
			Push(temp);
		}
	}

	public void Print()
	{
		Node temp = head;
		while (temp != null)
		{
			Console.Write(temp.value + " ");
			temp = temp.next;
		}
	}

	public static void Main(string[] args)
	{
		StackLL s = new StackLL();
		s.Push(1);
		s.Push(2);
		s.Push(3);
		s.Print();
		Console.WriteLine(s.Pop());
		Console.WriteLine(s.Pop());
		s.Print();
	}
}
