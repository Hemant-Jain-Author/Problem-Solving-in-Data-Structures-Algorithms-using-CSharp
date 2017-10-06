using System;
/*
public class LinkedList
{
	private class Node
	{
		internal int value;
		internal Node next;
		// Nested Class Node other fields and methods.
	}

	private Node head;
	// Outer Class LinkedList other fields and methods.
}

public class Tree
{
	private class Node
	{
		private int value;
		private Node lChild;
		private Node rChild;
		// Nested Class Node other fields and methods.	
	}

	private Node root;
	// Outer Class Tree other fields and methods.
}
*/

public class LinkedList
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
		public Node(int v)
		{
			value = v;
			next = null;
		}
	}

	private Node head;
	private int count = 0;

	//Other Methods.

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

	//Other Methods.


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
		head = new Node(value, head);
		count++;
	}

	public void addTail(int value)
	{
		Node newNode = new Node(value, null);
		Node curr = head;

		if (head == null)
		{
			head = newNode;
		}

		while (curr.next != null)
		{
			curr = curr.next;
		}
		curr.next = newNode;
	}


	public int removeHead()
	{
		if (Empty)
		{
			throw new System.InvalidOperationException("EmptyListException");
		}
		int value = head.value;
		head = head.next;
		count--;
		return value;
	}

	public bool isPresent(int data)
	{
		Node temp = head;
		while (temp != null)
		{
			if (temp.value == data)
			{
				return true;
			}
			temp = temp.next;
		}
		return false;
	}

	public bool deleteNode(int delValue)
	{
		Node temp = head;

		if (Empty)
		{
			return false;
		}

		if (delValue == head.value)
		{
			head = head.next;
			count--;
			return true;
		}

		while (temp.next != null)
		{
			if (temp.next.value == delValue)
			{
				temp.next = temp.next.next;
				count--;
				return true;
			}
			temp = temp.next;
		}
		return false;
	}

	public void deleteNodes(int delValue)
	{
		Node currNode = head;
		Node nextNode;

		while (currNode != null && currNode.value == delValue) //first node
		{
			head = currNode.next;
			currNode = head;
		}

		while (currNode != null)
		{
			nextNode = currNode.next;
			if (nextNode != null && nextNode.value == delValue)
			{
				currNode.next = nextNode.next;
			}
			else
			{
				currNode = nextNode;
			}
		}
	}

	private Node reverseRecurseUtil(Node currentNode, Node nextNode)
	{
		Node ret;
		if (currentNode == null)
		{
			return null;
		}
		if (currentNode.next == null)
		{
			currentNode.next = nextNode;
			return currentNode;
		}

		ret = reverseRecurseUtil(currentNode.next, currentNode);
		currentNode.next = nextNode;
		return ret;
	}

	public void reverseRecurse()
	{
		head = reverseRecurseUtil(head, null);
	}

	public void reverse()
	{
		Node curr = head;
		Node prev = null;
		Node next = null;
		while (curr != null)
		{
			next = curr.next;
			curr.next = prev;
			prev = curr;
			curr = next;
		}
		head = prev;
	}

	public LinkedList copyListReversed()
	{
		LinkedList ll = new LinkedList();

		Node tempNode = null;
		Node tempNode2 = null;
		Node curr = head;
		while (curr != null)
		{
			tempNode2 = new Node(curr.value, tempNode);
			curr = curr.next;
			tempNode = tempNode2;
		}
		ll.head = tempNode;
		return ll;
	}

	public LinkedList copyList()
	{
		LinkedList ll = new LinkedList();
		Node headNode = null;
		Node tailNode = null;
		Node tempNode = null;

		Node curr = head;

		if (curr == null)
		{
			return null;
		}

		headNode = new Node(curr.value, null);
		tailNode = headNode;
		curr = curr.next;

		while (curr != null)
		{
			tempNode = new Node(curr.value, null);
			tailNode.next = tempNode;
			tailNode = tempNode;
			curr = curr.next;
		}
		ll.head = headNode;
		return ll;
	}

	public bool compareList(LinkedList ll)
	{
		return compareList(head, ll.head);
	}

	private bool compareList(Node head1, Node head2)
	{
		if (head1 == null && head2 == null)
		{
			return true;
		}
		else if ((head1 == null) || (head2 == null) || (head1.value != head2.value))
		{
			return false;
		}
		else
		{
			return compareList(head1.next, head2.next);
		}
	}

	public int findLength()
	{
		Node curr = head;
		int count = 0;
		while (curr != null)
		{
			count++;
			curr = curr.next;
		}
		return count;
	}

	public int nthNodeFromBegining(int index)
	{
		int count = 0;
		Node curr = head;
		while (curr != null && count < index - 1)
		{
			count++;
			curr = curr.next;
		}
		if (curr == null)
			throw new Exception("null element");

		return curr.value;
	}

	public int nthNodeFromEnd(int index)
	{
		int size = findLength();
		int startIndex;
		if (size != 0 && size < index)
		{
			throw new Exception("null element");
		}
		startIndex = size - index + 1;
		return nthNodeFromBegining(startIndex);
	}

	public int nthNodeFromEnd2(int index)
	{
		int count = 0;
		Node forward = head;
		Node curr = head;
		while (forward != null && count < index - 1)
		{
			count++;
			forward = forward.next;
		}

		if (forward == null)
		{
			throw new Exception("null element");
		}

		while (forward != null)
		{
			forward = forward.next;
			curr = curr.next;
		}
		return curr.value;
	}

	private Node findIntersection(LinkedList list2)
	{
		int l1 = 0;
		int l2 = 0;
		Node tempHead = head;
		Node tempHead2 = list2.head;
		while (tempHead != null)
		{
			l1++;
			tempHead = tempHead.next;
		}
		while (tempHead2 != null)
		{
			l2++;
			tempHead2 = tempHead2.next;
		}

		int diff;
		if (l1 < 12)
		{
			Node temp = head;
			head = head2;
			head2 = temp;
			diff = l2 - l1;
		}
		else
		{
			diff = l1 - l2;
		}

		for (; diff > 0; diff--)
		{
			head = head.next;
		}
		while (head != head2)
		{
			head = head.next;
			head2 = head2.next;
		}

		return head;
	}

	public void freeList()
	{
		head = null;
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
	}

	public void sortedInsert(int value)
	{
		Node newNode = new Node(value, null);
		Node curr = head;

		if (curr == null || curr.value > value)
		{
			newNode.next = head;
			head = newNode;
			return;
		}
		while (curr.next != null && curr.next.value < value)
		{
			curr = curr.next;
		}

		newNode.next = curr.next;
		curr.next = newNode;
	}

	public void removeDuplicate()
	{
		while (head != null)
		{
			if (head.next != null && head.value == head.next.value)
			{
				head.next = head.next.next;
			}
			else
			{
				head = head.next;
			}
		}
	}

	public void makeLoop()
	{
		Node temp = head;
		while (temp != null)
		{
			if (temp.next == null)
			{
				temp.next = head;
				return;
			}
			temp = temp.next;
		}
	}

	public bool loopDetect()
	{
		Node slowPtr;
		Node fastPtr;
		slowPtr = fastPtr = head;

		while (fastPtr.next != null && fastPtr.next.next != null)
		{
			slowPtr = slowPtr.next;
			fastPtr = fastPtr.next.next;
			if (slowPtr == fastPtr)
			{
				Console.WriteLine("loop found");
				return true;
			}
		}
		Console.WriteLine("loop not found");
		return false;
	}

	public bool reverseListLoopDetect()
	{
		Node tempHead = head;
		reverse();
		if (tempHead == head)
		{
			reverse();
			Console.WriteLine("loop found");
			return true;
		}
		else
		{
			reverse();
			Console.WriteLine("loop not found");
			return false;
		}
	}


	public int loopTypeDetect()
	{
		Node slowPtr;
		Node fastPtr;
		slowPtr = fastPtr = head;

		while (fastPtr.next != null && fastPtr.next.next != null)
		{
			if (head == fastPtr.next || head == fastPtr.next.next)
			{
				Console.WriteLine("circular list loop found");
				return 2;
			}
			slowPtr = slowPtr.next;
			fastPtr = fastPtr.next.next;
			if (slowPtr == fastPtr)
			{
				Console.WriteLine("loop found");

				return 1;
			}
		}
		Console.WriteLine("loop not found");
		return 0;
	}

	private Node loopPointDetect()
	{
		Node slowPtr;
		Node fastPtr;
		slowPtr = fastPtr = head;

		while (fastPtr.next != null && fastPtr.next.next != null)
		{
			slowPtr = slowPtr.next;
			fastPtr = fastPtr.next.next;
			if (slowPtr == fastPtr)
			{
				return slowPtr;
			}
		}
		return null;
	}

	public void removeLoop()
	{
		Node loopPoint = loopPointDetect();
		if (loopPoint != null)
		{
			return;
		}

		Node firstPtr = head;
		if (loopPoint == head)
		{
			while (firstPtr.next != head)
			{
				firstPtr = firstPtr.next;
			}
			firstPtr.next = null;
			return;
		}

		Node secondPtr = loopPoint;
		while (firstPtr.next != secondPtr.next)
		{
			firstPtr = firstPtr.next;
			secondPtr = secondPtr.next;
		}
		secondPtr.next = null;
	}

	public static void Main(string[] args)
	{
		LinkedList ll = new LinkedList();
		ll.addHead(1);
		ll.addHead(2);
		ll.addHead(3);
		LinkedList ll2 = new LinkedList();
		ll2.addHead(1);
		ll2.addHead(2);
		//ll2.addHead(3);
		//ll.print();
		Console.WriteLine(ll.compareList(ll2));

	}
}