using System;

public class DoublyCircularLinkedList
{
	private Node head = null;
	private Node tail = null;
	private int count = 0;

	private class Node
	{
		internal int value;
		internal Node next;
		internal Node prev;

		public Node(int v, Node nxt, Node prv)
		{
			value = v;
			next = nxt;
			prev = prv;
		}

		public Node(int v)
		{
			value = v;
			next = this;
			prev = this;
		}
	}
	/* Other methods */

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

	public int peekHead()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("EmptyListException");
		}
		return head.value;
	}

	public void addHead(int value)
	{
		Node newNode = new Node(value, null, null);
		if (count == 0)
		{
			tail = head = newNode;
			newNode.next = newNode;
			newNode.prev = newNode;
		}
		else
		{
			newNode.next = head;
			newNode.prev = head.prev;
			head.prev = newNode;
			newNode.prev.next = newNode;
			head = newNode;
		}
		count++;
	}

	public void addTail(int value)
	{
		Node newNode = new Node(value, null, null);
		if (count == 0)
		{
			head = tail = newNode;
			newNode.next = newNode;
			newNode.prev = newNode;
		}
		else
		{
			newNode.next = tail.next;
			newNode.prev = tail;
			tail.next = newNode;
			newNode.next.prev = newNode;
			tail = newNode;
		}
		count++;
	}

	public int removeHead()
	{
		if (count == 0)
		{
			throw new System.InvalidOperationException("EmptyListException");
		}

		int value = head.value;
		count--;

		if (count == 0)
		{
			head = null;
			tail = null;
			return value;
		}

		Node next = head.next;
		next.prev = tail;
		tail.next = next;
		head = next;
		return value;
	}

	public int removeTail()
	{
		if (count == 0)
		{
			throw new System.InvalidOperationException("EmptyListException");
		}

		int value = tail.value;
		count--;

		if (count == 0)
		{
			head = null;
			tail = null;
			return value;
		}

		Node prev = tail.prev;
		prev.next = head;
		head.prev = prev;
		tail = prev;
		return value;
	}

	public bool isPresent(int key)
	{
		Node temp = head;
		if (head == null)
		{
			return false;
		}

		do
		{
			if (temp.value == key)
			{
				return true;
			}
			temp = temp.next;
		} while (temp != head);

		return false;
	}

	public void deleteList()
	{
		head = null;
		tail = null;
		count = 0;
	}

	public void print()
	{
		if (Empty)
		{
			return;
		}
		Node temp = head;
		while (temp != tail)
		{
			Console.Write(temp.value + " ");
			temp = temp.next;
		}
		Console.Write(temp.value);
	}

	public static void Main(string[] args)
	{
		DoublyCircularLinkedList ll = new DoublyCircularLinkedList();
		ll.addHead(1);
		ll.addHead(2);
		ll.addHead(3);
		ll.addHead(1);
		ll.addHead(2);
		ll.addHead(3);
		ll.print();
	}
}
