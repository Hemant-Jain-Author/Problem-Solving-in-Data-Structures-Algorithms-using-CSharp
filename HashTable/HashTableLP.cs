using System;

public class HashTableLP
{
	private static int EMPTY_VALUE = -1;
	private static int DELETED_VALUE = -2;
	private static int FILLED_VALUE = 0;

	private int tableSize;
	internal int[] array;
	internal int[] flag;

	public HashTableLP(int tSize)
	{
		tableSize = tSize;
		array = new int[tSize + 1];
		flag = new int[tSize + 1];
		for (int i = 0; i <= tSize; i++)
		{
			flag[i] = EMPTY_VALUE;
		}
	}

	/* Other Methods */

	internal int ComputeHash(int key)
	{
		return key % tableSize;
	}

	internal int ResolverFun(int index)
	{
		return index;
	}

	internal int ResolverFun2(int index)
	{
		return index * index;
	}

	internal bool Add(int value)
	{
		int hashValue = ComputeHash(value);
		for (int i = 0; i < tableSize; i++)
		{
			if (flag[hashValue] == EMPTY_VALUE || flag[hashValue] == DELETED_VALUE)
			{
				array[hashValue] = value;
				flag[hashValue] = FILLED_VALUE;
				return true;
			}
			hashValue += ResolverFun(i);
			hashValue %= tableSize;
		}
		return false;
	}

	internal bool Find(int value)
	{
		int hashValue = ComputeHash(value);
		for (int i = 0; i < tableSize; i++)
		{
			if (flag[hashValue] == EMPTY_VALUE)
			{
				return false;
			}

			if (flag[hashValue] == FILLED_VALUE && array[hashValue] == value)
			{
				return true;
			}

			hashValue += ResolverFun(i);
			hashValue %= tableSize;
		}
		return false;
	}

	internal bool Remove(int value)
	{
		int hashValue = ComputeHash(value);
		for (int i = 0; i < tableSize; i++)
		{
			if (flag[hashValue] == EMPTY_VALUE)
			{
				return false;
			}

			if (flag[hashValue] == FILLED_VALUE && array[hashValue] == value)
			{
				flag[hashValue] = DELETED_VALUE;
				return true;
			}
			hashValue += ResolverFun(i);
			hashValue %= tableSize;
		}
		return false;
	}

	internal void Print()
	{
		Console.Write("Hash Table contains ::");
		for (int i = 0; i < tableSize; i++)
		{
			if (flag[i] == FILLED_VALUE)
			{
				Console.Write(array[i] + " ");
			}
		}
		Console.WriteLine();
	}

	public static void Main(string[] args)
	{
		HashTableLP ht = new HashTableLP(1000);
		ht.Add(1);
		ht.Add(2);
		ht.Add(3);
		ht.Print();
		Console.WriteLine("Find key 2 : " + ht.Find(2));
		ht.Remove(2);
		Console.WriteLine("Find key 2 : " + ht.Find(2));
	}
}

/*
Hash Table contains ::1 2 3 
Find key 2 : true
Find key 2 : false
*/