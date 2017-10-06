using System;

public class HashTable
{

	private static int EMPTY_NODE = -1;
	private static int LAZY_DELETED = -2;
	private static int FILLED_NODE = 0;


	private int tableSize;
	internal int[] Arr;
	internal int[] Flag;

	public HashTable(int tSize)
	{
		tableSize = tSize;
		Arr = new int[tSize + 1];
		Flag = new int[tSize + 1];
		for (int i = 0; i <= tSize; i++)
		{
			Flag[i] = EMPTY_NODE;
		}
	}

	internal virtual int ComputeHash(int key)
	{
		return key % tableSize;
	}

	internal virtual int resolverFun(int index)
	{
		return index;
	}

	internal virtual bool InsertNode(int value)
	{
		int hashValue = ComputeHash(value);
		for (int i = 0; i < tableSize; i++)
		{
			if (Flag[hashValue] == EMPTY_NODE || Flag[hashValue] == LAZY_DELETED)
			{
				Arr[hashValue] = value;
				Flag[hashValue] = FILLED_NODE;
				return true;
			}
			hashValue += resolverFun(i);
			hashValue %= tableSize;
		}
		return false;
	}

	internal virtual bool FindNode(int value)
	{
		int hashValue = ComputeHash(value);
		for (int i = 0; i < tableSize; i++)
		{
			if (Flag[hashValue] == EMPTY_NODE)
			{
				return false;
			}

			if (Flag[hashValue] == FILLED_NODE && Arr[hashValue] == value)
			{
				return true;
			}

			hashValue += resolverFun(i);
			hashValue %= tableSize;
		}
		return false;
	}

	internal virtual bool DeleteNode(int value)
	{
		int hashValue = ComputeHash(value);
		for (int i = 0; i < tableSize; i++)
		{
			if (Flag[hashValue] == EMPTY_NODE)
			{
				return false;
			}

			if (Flag[hashValue] == FILLED_NODE && Arr[hashValue] == value)
			{
				Flag[hashValue] = LAZY_DELETED;
				return true;
			}
			hashValue += resolverFun(i);
			hashValue %= tableSize;
		}
		return false;

	}

	internal virtual void Print()
	{
		for (int i = 0; i < tableSize; i++)
		{
			if (Flag[i] == FILLED_NODE)
			{
				Console.WriteLine("Node at index [" + i + " ] :: " + Arr[i]);
			}
		}
	}

	public static void Main(string[] args)
	{
		HashTable ht = new HashTable(1000);
		ht.InsertNode(89);
		ht.InsertNode(18);
		ht.InsertNode(49);
		ht.InsertNode(58);
		ht.InsertNode(69);
		ht.InsertNode(89);
		ht.InsertNode(18);
		ht.InsertNode(49);
		ht.InsertNode(58);
		ht.InsertNode(69);

		ht.Print();
		Console.WriteLine("");

		ht.DeleteNode(89);
		ht.DeleteNode(18);
		ht.DeleteNode(49);
		ht.DeleteNode(58);
		ht.DeleteNode(100);

		ht.Print();
	}
}