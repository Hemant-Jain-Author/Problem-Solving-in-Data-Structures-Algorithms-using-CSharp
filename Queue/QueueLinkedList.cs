using System;

public class QueueLL
{
	private Node tail = null;
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
			throw new System.InvalidOperationException("StackEmptyException");
		}
		int value;
		if (tail == tail.next)
		{
			value = tail.value;
		}
		else
		{
			value = tail.next.value;
		}

		return value;
	}

	public virtual void add(int value)
	{
		Node temp = new Node(value, null);

		if (tail == null)
		{
			tail = temp;
			tail.next = tail;
		}
		else
		{
			temp.next = tail.next;
			tail.next = temp;
			tail = temp;
		}
		count++;
	}

	public virtual int remove()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("StackEmptyException");
		}

		int value = 0;
		if (tail == tail.next)
		{
			value = tail.value;
			tail = null;
		}
		else
		{
			value = tail.next.value;
			tail.next = tail.next.next;
		}
		count--;
		return value;
	}

	public static void Main(string[] args)
	{
		QueueLL q = new QueueLL();
		q.add(1);
		q.add(2);
		q.add(3);
		for (int i = 0; i < 3; i++)
		{
			Console.WriteLine(q.remove());
		}
	}
}
