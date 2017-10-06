using System;

public class HashTableSC
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
	}

	private int tableSize;
	private Node[] listArray; //double pointer

	public HashTableSC()
	{
		tableSize = 512;
		listArray = new Node[tableSize];
		for (int i = 0; i < tableSize; i++)
		{
			listArray[i] = null;
		}
	}

	private int ComputeHash(int key) //division method
	{
		int hashValue = 0;
		hashValue = key;
		return hashValue % tableSize;
	}

	internal virtual int resolverFun(int i)
	{
		return i;
	}

	internal virtual int resolverFun2(int i)
	{
		return i * i;
	}


	public virtual void insert(int value)
	{
		int index = ComputeHash(value);
		listArray[index] = new Node(value, listArray[index]);
	}

	public virtual bool delete(int value)
	{
		int index = ComputeHash(value);
		Node nextNode, head = listArray[index];
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

	public virtual void print()
	{
		for (int i = 0; i < tableSize; i++)
		{
			Console.WriteLine("Printing for index value :: " + i + "List of value printing :: ");
			Node head = listArray[i];
			while (head != null)
			{
				Console.WriteLine(head.value);
				head = head.next;
			}
		}
	}

	public virtual bool find(int value)
	{
		int index = ComputeHash(value);
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
			ht.insert(i);
		}
		Console.WriteLine("search 100 :: " + ht.find(100));
		Console.WriteLine("remove 100 :: " + ht.delete(100));
		Console.WriteLine("search 100 :: " + ht.find(100));
		Console.WriteLine("remove 100 :: " + ht.delete(100));
	}
}