using System;

public class CircularLinkedList
{

	private class Node
	{
		//Node class Fields and Methods
		internal int value;
		internal Node next;

		public Node(int v, Node n)
		{
			value = v;
			next = n;
		}
		public Node(int v)
		{
			value = v;
			next = null;
		}
	}
	private Node tail;
	private int count = 0;
	//Other Methods

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
			throw new System.InvalidOperationException("EmptyListException");
		}
		return tail.next.value;
	}

	public void addTail(int value)
	{
		Node temp = new Node(value, null);
		if (Empty)
		{
			tail = temp;
			temp.next = temp;
		}
		else
		{
			temp.next = tail.next;
			tail.next = temp;
			tail = temp;
		}
		count++;
	}

	public void addHead(int value)
	{
		Node temp = new Node(value, null);
		if (Empty)
		{
			tail = temp;
			temp.next = temp;
		}
		else
		{
			temp.next = tail.next;
			tail.next = temp;
		}
		count++;
	}

	public int removeHead()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("EmptyListException");
		}
		int value = tail.next.value;
		if (tail == tail.next)
		{
			tail = null;
		}
		else
		{
			tail.next = tail.next.next;
		}

		count--;
		return value;
	}

	public bool removeNode(int key)
	{
		if (Empty)
		{
			return false;
		}
		Node prev = tail;
		Node curr = tail.next;
		Node head = tail.next;

		if (curr.value == key) //head and single node case.
		{
			if (curr == curr.next) //single node case
			{
				tail = null;
			}
			else // head case
			{
				tail.next = tail.next.next;
			}
			return true;
		}

		prev = curr;
		curr = curr.next;

		while (curr != head)
		{
			if (curr.value == key)
			{
				if (curr == tail)
				{
					tail = prev;
				}
				prev.next = curr.next;
				return true;
			}
			prev = curr;
			curr = curr.next;
		}

		return false;
	}

	public void copyListReversed()
	{
		CircularLinkedList cl = new CircularLinkedList();
		Node curr = tail.next;
		Node head = curr;

		if (curr != null)
		{
			cl.addHead(curr.value);
			curr = curr.next;
		}
		while (curr != head)
		{
			cl.addHead(curr.value);
			curr = curr.next;
		}
	}

	public void copyList()
	{
		CircularLinkedList cl = new CircularLinkedList();
		Node curr = tail.next;
		Node head = curr;

		if (curr != null)
		{
			cl.addTail(curr.value);
			curr = curr.next;
		}
		while (curr != head)
		{
			cl.addTail(curr.value);
			curr = curr.next;
		}
	}

	public bool isPresent(int data)
	{
		Node temp = tail;
		for (int i = 0; i < count; i++)
		{
			if (temp.value == data)
			{
				return true;
			}
			temp = temp.next;
		}
		return false;
	}

	public void freeList()
	{
		tail = null;
		count = 0;
	}

	public void print()
	{
		if (Empty)
		{
			return;
		}
		Node temp = tail.next;
		while (temp != tail)
		{
			Console.Write(temp.value + " ");
			temp = temp.next;
		}
		Console.Write(temp.value);
	}
}
