using System;

public class DoublyLinkedList
{
	private Node head;
	private Node tail;
	private int size = 0;

	private class Node
	{
		internal int value;
		internal Node next;
		internal Node prev;

		internal Node(int v, Node nxt, Node prv)
		{
			value = v;
			next = nxt;
			prev = prv;
		}
	}

	/* Other methods */

	public int Size()
	{
		return size;
	}

	public bool IsEmpty()
	{
		return size == 0;
	}

	public int Peek()
	{
		if (IsEmpty())
		{
			throw new System.InvalidOperationException("EmptyListException");
		}
		return head.value;
	}

	public void AddHead(int value)
	{
		Node newNode = new Node(value, null, null);
		if (size == 0)
		{
			tail = head = newNode;
		}
		else
		{
			head.prev = newNode;
			newNode.next = head;
			head = newNode;
		}
		size++;
	}

	public void AddTail(int value)
	{
		Node newNode = new Node(value, null, null);
		if (size == 0)
		{
			head = tail = newNode;
		}
		else
		{
			newNode.prev = tail;
			tail.next = newNode;
			tail = newNode;
		}
		size++;
	}

	public int RemoveHead()
	{
		if (IsEmpty())
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

		size--;
		return value;
	}

	public bool DeleteNode(int key)
	{
		Node curr = head;
		if (curr == null) // empty list
		{
			return false;
		}

		if (curr.value == key) // head is the node with value key.
		{
			head = head.next;
			size--;
			if (head != null)
			{
				head.prev = null;
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
				if (curr.next == null) // last element case.
				{
					tail = curr;
				}
				else
				{
					curr.next.prev = curr;
				}
				size--;
				return true;
			}
			curr = curr.next;
		}
		return false;
	}

	public bool Search(int key)
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

	public void DeleteList()
	{
		head = null;
		tail = null;
		size = 0;
	}

	public void Print()
	{
		Node temp = head;
		while (temp != null)
		{
			Console.Write(temp.value + " ");
			temp = temp.next;
		}
		Console.WriteLine("");
	}

	// Sorted insert increasing
	public void SortedInsert(int value)
	{
		Node temp = new Node(value, null, null);

		Node curr = head;
		if (curr == null) // first element
		{
			head = temp;
			tail = temp;
			return;
		}

		if (head.value > value) // at the beginning
		{
			temp.next = head;
			head.prev = temp;
			head = temp;
			return;
		}

		while (curr.next != null && curr.next.value < value) // traversal
		{
			curr = curr.next;
		}

		if (curr.next == null) // at the end
		{
			tail = temp;
			temp.prev = curr;
			curr.next = temp;
		}
		else /// all other
		{
			temp.next = curr.next;
			temp.prev = curr;
			curr.next = temp;
			temp.next.prev = temp;
		}
	}

	/*
	 * Reverse a doubly linked List iteratively
	 */

	public void ReverseList()
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

	/* Remove Duplicate */
	public void RemoveDuplicate()
	{
		Node curr = head;
		while (curr != null)
		{
			if ((curr.next != null) && curr.value == curr.next.value)
			{
				curr.next = curr.next.next;
				if (curr.next != null)
				{
					curr.next.prev = curr;
				}
				if (curr.next == null)
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

	public DoublyLinkedList CopyListReversed()
	{
		DoublyLinkedList dll = new DoublyLinkedList();
		Node curr = head;

		while (curr != null)
		{
			dll.AddHead(curr.value);
			curr = curr.next;
		}
		return dll;
	}

	public DoublyLinkedList CopyList()
	{
		DoublyLinkedList dll = new DoublyLinkedList();
		Node curr = head;

		while (curr != null)
		{
			dll.AddTail(curr.value);
			curr = curr.next;
		}
		return dll;
	}

	public static void Main1()
	{
		DoublyLinkedList ll = new DoublyLinkedList();
		ll.AddHead(1);
		ll.AddHead(2);
		ll.AddHead(3);
		ll.Print();
		ll.RemoveHead();
		ll.Print();
		Console.WriteLine(ll.Search(2));
	}
	/*
	3 2 1 
	2 1 
	True
	*/

	public static void Main2()
	{
		DoublyLinkedList ll = new DoublyLinkedList();
		ll.SortedInsert(1);
		ll.SortedInsert(2);
		ll.SortedInsert(3);
		ll.Print();
		ll.SortedInsert(1);
		ll.SortedInsert(2);
		ll.SortedInsert(3);
		ll.Print();
		ll.RemoveDuplicate();
		ll.Print();
	}
	/*
	1 2 3 
	1 1 2 2 3 3 
	1 2 3 
	*/

	public static void Main3()
	{
		DoublyLinkedList ll = new DoublyLinkedList();
		ll.AddHead(1);
		ll.AddHead(2);
		ll.AddHead(3);
		ll.Print();

		DoublyLinkedList l2 = ll.CopyList();
		l2.Print();
		DoublyLinkedList l3 = ll.CopyListReversed();
		l3.Print();
	}
	/*
	3 2 1 
	3 2 1 
	1 2 3
	*/

	public static void Main4()
	{
		DoublyLinkedList ll = new DoublyLinkedList();
		ll.AddHead(1);
		ll.AddHead(2);
		ll.AddHead(3);
		ll.Print();
		ll.DeleteNode(2);
		ll.Print();
	}

	/*
	3 2 1 
	3 1 
	*/

	public static void Main5()
	{
		DoublyLinkedList ll = new DoublyLinkedList();
		ll.AddHead(1);
		ll.AddHead(2);
		ll.AddHead(3);
		ll.Print();
		ll.ReverseList();
		ll.Print();
	}

	/*
	3 2 1
	1 2 3
	*/

	public static void Main(string[] args)
	{
		Main1();
		Main2();
		Main3();
		Main4();
		Main5();
	}
}