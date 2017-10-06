using System;
using System.Collections.Generic;

public class HashTableExercise
{

	public static void Main(string[] args)
	{
		char[] first = "hello".ToCharArray();
		char[] second = "elloh".ToCharArray();
		char[] third = "world".ToCharArray();

		Console.WriteLine("isAnagram : " + isAnagram(first, second));
		Console.WriteLine("isAnagram : " + isAnagram(first, third));

		removeDuplicate(first);
		Console.WriteLine(first);

		int[] arr = new int[] { 1, 2, 3, 5, 6, 7, 8, 9, 10 };
		Console.WriteLine(findMissing(arr, 1, 10));

		int[] arr1 = new int[] { 1, 2, 3, 4, 4, 5, 6, 7, 8, 9, 1 };
		printRepeating(arr1);
		printFirstRepeating(arr1);
	}

	public static bool isAnagram(char[] str1, char[] str2)
	{
		int size1 = str1.Length;
		int size2 = str2.Length;

		if (size1 != size2)
		{
			return false;
		}

		CountMap<char> cm = new CountMap<char>();

		foreach (char ch in str1)
		{
			cm.add(ch);
		}

		foreach (char ch in str2)
		{
			if (cm.containsKey(ch))
				cm.remove(ch);
			else
				return false;
		}

		return (cm.size() == 0);
	}

	public static void removeDuplicate(char[] str)
	{
		int index = 0;
		HashSet<char> hs = new HashSet<char>();


		foreach (char ch in str)
		{
			if (hs.Contains(ch) == false)
			{
				str[index++] = ch;
				hs.Add(ch);
			}
		}
		str[index] = '\0';
	}

	public static int findMissing(int[] arr, int start, int end)
	{
		HashSet<int> hs = new HashSet<int>();
		foreach (int i in arr)
		{
			hs.Add(i);
		}

		for (int curr = start; curr <= end; curr++)
		{
			if (hs.Contains(curr) == false)
			{
				return curr;
			}
		}

		return int.MaxValue;
	}

	public static void printRepeating(int[] arr)
	{
		HashSet<int> hs = new HashSet<int>();

		Console.Write("Repeating elements are:");
		foreach (int val in arr)
		{
			if (hs.Contains(val))
			{
				Console.Write("  " + val);
			}
			else
			{
				hs.Add(val);
			}
		}
	}

	public static void printFirstRepeating(int[] arr)
	{
		int i;
		int size = arr.Length;
		CountMap<int> hs = new CountMap<int>();

		for (i = 0; i < size; i++)
		{
			hs.add(arr[i]);
		}
		for (i = 0; i < size; i++)
		{
			hs.remove(arr[i]);
			if (hs.containsKey(arr[i]))
			{
				Console.WriteLine("First Repeating number is : " + arr[i]);
				return;
			}
		}
	}

	internal virtual int hornerHash(char[] key, int tableSize)
	{
		int size = key.Length;
		int h = 0;
		int i;
		for (i = 0; i < size; i++)
		{
			h = (32 * h + key[i]) % tableSize;
		}
		return h;
	}
}