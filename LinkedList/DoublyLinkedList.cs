using System;

public class DoublyLinkedList
{
	private class Node
	{
		public int value;
		public Node next;
		public Node prev;

		public Node(int v, Node nxt, Node prv)
		{
			value = v;
			next = nxt;
			prev = prv;
		}
		public Node(int v)
		{
			value = v;
			next = null;
			prev = null;
		}
	}

	private Node head;
	private Node tail;

	private int count = 0;

	public DoublyLinkedList()
	{
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
		}
		else
		{
			head.prev = newNode;
			newNode.next = head;
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
		}
		else
		{
			newNode.prev = tail;
			tail.next = newNode;
			tail = newNode;
		}
		count++;
	}

	public int removeHead()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("EmptyListException");
		}
		int value = head.value;
		head = head.next;

		if (head == null)
		{
			tail = null;
		}
		else
		{
			head.prev = null;
		}

		count--;
		return value;
	}

	public bool removeNode(int key)
	{
		Node curr = head;

		if (curr == null) //empty list
		{
			return false;
		}

		if (curr.value == key) //head is the node with value key.
		{
			head = head.next;
			count--;
			if (head != null)
			{
				head = null;
			}
			else
			{
				tail = null; // only one element in list.
			}

			return true;
		}

		while (curr.next != null)
		{
			if (curr.next.value == key)
			{
				curr.next = curr.next.next;
				if (curr.next == null) //last element case.
				{
					tail = curr;
				}
				else
				{
					curr.next = curr;
				}
				count--;
				return true;
			}
			curr = curr.next;
		}
		return false;
	}


	public bool isPresent(int key)
	{
		Node temp = head;
		while (temp != null)
		{
			if (temp.value == key)
			{
				return true;
			}
			temp = temp.next;
		}
		return false;
	}


	public void freeList()
	{
		head = null;
		tail = null;
		count = 0;
	}

	public void print()
	{
		Node temp = head;
		while (temp != null)
		{
			Console.Write(temp.value + " ");
			temp = temp.next;
		}
		Console.WriteLine("");
	}

	//SORTED INSERT DECREASING
	public void sortedInsert(int value)
	{
		Node temp = new Node(value);

		Node curr = head;
		if (curr == null) //first element
		{
			head = temp;
			tail = temp;
		}

		if (head.value <= value) //at the begining
		{
			temp.next = head;
			head.prev = temp;
			head = temp;
		}

		while (curr.next != null && curr.next.value > value) //treversal
		{
			curr = curr.next;
		}

		if (curr.next == null) //at the end
		{
			tail = temp;
			temp.prev = curr;
			curr.next = temp;
		}
		else ///all other
		{
			temp.next = curr.next;
			temp.prev = curr;
			curr.next = temp;
			temp.next.prev = temp;
		}
	}

	/*
        Reverse a doubly linked List iteratively
     */

	public void reverseList()
	{
		Node curr = head;
		Node tempNode;
		while (curr != null)
		{
			tempNode = curr.next;
			curr.next = curr.prev;
			curr.prev = tempNode;

			if (curr.prev == null)
			{
				tail = head;
				head = curr;
				return;
			}

			curr = curr.prev;
		}
		return;
	}

	/*  Remove Duplicate */
	public void removeDuplicate()
	{
		Node curr = head;
		Node deleteMe;
		while (curr != null)
		{
			if ((curr.next != null) && curr.value == curr.next.value)
			{
				deleteMe = curr.next;
				curr.next = deleteMe.next;
				curr.next.prev = curr;
				if (deleteMe == tail)
				{
					tail = curr;
				}
			}
			else
			{
				curr = curr.next;
			}
		}
	}

	public DoublyLinkedList copyListReversed()
	{
		DoublyLinkedList dll = new DoublyLinkedList();
		Node curr = head;

		while (curr != null)
		{
			dll.addHead(curr.value);
			curr = curr.next;
		}
		return dll;
	}

	public DoublyLinkedList copyList()
	{
		DoublyLinkedList dll = new DoublyLinkedList();
		Node curr = head;

		while (curr != null)
		{
			dll.addTail(curr.value);
			curr = curr.next;
		}
		return dll;
	}

	public static void Main(string[] args)
	{
		DoublyLinkedList ll = new DoublyLinkedList();
		ll.addHead(1);
		ll.addHead(2);
		ll.addHead(3);
		ll.addHead(4);
		ll.addHead(5);
		ll.addHead(6);
		ll.print();
		ll.removeHead();
		ll.print();
		ll.freeList();
		ll.print();
		ll.addHead(11);
		ll.addHead(21);
		ll.addHead(31);
		ll.addHead(41);
		ll.addHead(51);
		ll.addHead(61);
		ll.print();
	}
}