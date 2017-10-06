using System;
using System.Collections;

public class ListStack
{
	private class Node
	{
		internal int value;
		internal Node next;

		public Node(int v, Node n)
		{
			value = v;
			next = n;
		}
		public int Value
		{
			get
			{
				return value;
			}
		}

		public Node Next
		{
			get
			{
				return next;
			}
		}

	}

	private Node head = null;
	private int count = 0;


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
			throw new System.InvalidOperationException("ListStackEmptyException");
		}
		return head.Value;
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
			throw new System.InvalidOperationException("ListStackEmptyException");
		}
		int value = head.Value;
		head = head.Next;
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


	public void print()
	{
		Node temp = head;
		while (temp != null)
		{
			Console.Write(temp.Value + " ");
			temp = temp.Next;
		}
	}

	public static void Main(string[] args)
	{
		ListStack s = new ListStack();
		for (int i = 1; i <= 100; i++)
		{
			s.Push(i);
		}
		for (int i = 1; i <= 50; i++)
		{
			s.Pop();
		}
		s.print();
	}
}