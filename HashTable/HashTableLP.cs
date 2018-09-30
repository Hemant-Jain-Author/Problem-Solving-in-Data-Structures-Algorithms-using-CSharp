using System;

public class HashTableLP
{

	private static int EMPTY_VALUE = -1;
	private static int DELETED_VALUE = -2;
	private static int FILLED_VALUE = 0;

	private int tableSize;
	internal int[] Arr;
	internal int[] Flag;

	public HashTableLP(int tSize)
	{
		tableSize = tSize;
		Arr = new int[tSize + 1];
		Flag = new int[tSize + 1];
		for (int i = 0; i <= tSize; i++)
		{
			Flag[i] = EMPTY_VALUE;
		}
	}

	/* Other Methods */

	internal virtual int computeHash(int key)
	{
		return key % tableSize;
	}

	internal virtual int resolverFun(int index)
	{
		return index;
	}

	internal virtual int resolverFun2(int index)
	{
		return index * index;
	}

	internal virtual bool add(int value)
	{
		int hashValue = computeHash(value);
		for (int i = 0; i < tableSize; i++)
		{
			if (Flag[hashValue] == EMPTY_VALUE || Flag[hashValue] == DELETED_VALUE)
			{
				Arr[hashValue] = value;
				Flag[hashValue] = FILLED_VALUE;
				return true;
			}
			hashValue += resolverFun(i);
			hashValue %= tableSize;
		}
		return false;
	}

	internal virtual bool find(int value)
	{
		int hashValue = computeHash(value);
		for (int i = 0; i < tableSize; i++)
		{
			if (Flag[hashValue] == EMPTY_VALUE)
			{
				return false;
			}

			if (Flag[hashValue] == FILLED_VALUE && Arr[hashValue] == value)
			{
				return true;
			}

			hashValue += resolverFun(i);
			hashValue %= tableSize;
		}
		return false;
	}

	internal virtual bool remove(int value)
	{
		int hashValue = computeHash(value);
		for (int i = 0; i < tableSize; i++)
		{
			if (Flag[hashValue] == EMPTY_VALUE)
			{
				return false;
			}

			if (Flag[hashValue] == FILLED_VALUE && Arr[hashValue] == value)
			{
				Flag[hashValue] = DELETED_VALUE;
				return true;
			}
			hashValue += resolverFun(i);
			hashValue %= tableSize;
		}
		return false;
	}

	internal virtual void print()
	{
		for (int i = 0; i < tableSize; i++)
		{
			if (Flag[i] == FILLED_VALUE)
			{
				Console.WriteLine("Node at index [" + i + " ] :: " + Arr[i]);
			}
		}
	}

	public static void Main(string[] args)
	{
		HashTableLP ht = new HashTableLP(1000);
		ht.add(1);
		ht.add(2);
		ht.add(3);
		ht.print();
		Console.WriteLine(ht.remove(1));
		Console.WriteLine(ht.remove(4));
		ht.print();
	}
}