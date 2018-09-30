using System;

public class HashTableSC
{

	private int tableSize;
	internal Node[] listArray;

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

	public HashTableSC()
	{
		tableSize = 512;
		listArray = new Node[tableSize];
		for (int i = 0; i < tableSize; i++)
		{
			listArray[i] = null;
		}
	}

	private int computeHash(int key) // division method
	{
		int hashValue = key;
		return hashValue % tableSize;
	}

	public void add(int value)
	{
		int index = computeHash(value);
		listArray[index] = new Node(this, value, listArray[index]);
	}

	public bool remove(int value)
	{
		int index = computeHash(value);
		Node nextNode , head = listArray[index];
		if (head != null && head.value == value)
		{
			listArray[index] = head.next;
			return true;
		}
		while (head != null)
		{
			nextNode = head.next;
			if (nextNode != null && nextNode.value == value)
			{
				head.next = nextNode.next;
				return true;
			}
			else
			{
				head = nextNode;
			}
		}
		return false;
	}

	public void print()
	{
		for (int i = 0; i < tableSize; i++)
		{
			Console.WriteLine("printing for index value :: " + i + "List of value printing :: ");
			Node head = listArray[i];
			while (head != null)
			{
				Console.WriteLine(head.value);
				head = head.next;
			}
		}
	}

	public bool find(int value)
	{
		int index = computeHash(value);
		Node head = listArray[index];
		while (head != null)
		{
			if (head.value == value)
			{
				return true;
			}
			head = head.next;
		}
		return false;
	}

	public static void Main(string[] args)
	{
		HashTableSC ht = new HashTableSC();

		for (int i = 100; i < 110; i++)
		{
			ht.add(i);
		}
		Console.WriteLine("search 100 :: " + ht.find(100));
		Console.WriteLine("remove 100 :: " + ht.remove(100));
		Console.WriteLine("search 100 :: " + ht.find(100));
		Console.WriteLine("remove 100 :: " + ht.remove(100));
	}
}
