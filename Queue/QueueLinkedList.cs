using System;
using System.Collections;

public class Queue
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
		public virtual int Value
		{
			get
			{
				return value;
			}
		}

		public virtual Node Next
		{
			get
			{
				return next;
			}
		}
	}

	private Node head = null;
	private Node tail = null;
	private int count = 0;


	public virtual int size()
	{
		return count;
	}

	public virtual bool Empty
	{
		get
		{
			return count == 0;
		}
	}


	public virtual int peek()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("QueueEmptyException");
		}
		return head.Value;
	}

	public virtual void add(int value)
	{
		Node temp = new Node(value, null);

		if (head == null)
		{
			head = tail = temp;
		}
		else
		{
			tail.next = temp;
			tail = temp;
		}
		count++;
	}


	public virtual int remove()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("QueueEmptyException");
		}
		int value = head.Value;
		head = head.Next;
		count--;
		return value;
	}

	public virtual void print()
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
		Queue q = new Queue();
		for (int i = 1; i <= 100; i++)
		{
			q.add(i);
		}
		for (int i = 1; i <= 50; i++)
		{
			q.remove();
		}
		q.print();
	}
}