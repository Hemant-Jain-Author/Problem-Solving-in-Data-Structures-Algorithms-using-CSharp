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

	int[] arr = new int[] {1, 2, 3, 5, 6, 7, 8, 9, 10};
	Console.WriteLine(findMissing(arr, 1, 10));

	int[] arr1 = new int[] {1, 2, 3, 4, 4, 5, 6, 7, 8, 9, 1};
	printRepeating(arr1);
	printFirstRepeating(arr1);
}

public static bool isAnagram(char[] str1, char[] str2)
{
	int size1 = str1.Length;
	int size2 = str2.Length;

	if (size1 != size2)
		return false;

	Dictionary<char, int> hm = new Dictionary<char, int>();

	foreach (char ch in str1)
	{
		if (hm.ContainsKey(ch))
			hm[ch] = hm[ch] + 1;
		else
			hm[ch] = 1;
	}

	foreach (char ch in str2)
	{
		if (hm.ContainsKey(ch) == false || hm[ch] == 0)
			return false;
		else
			hm[ch] = hm[ch] - 1;
	}
	return true;
}

public static string removeDuplicate(char[] str)
{
	HashSet<char> hs = new HashSet<char>();
	string outValue = "";

	foreach (char ch in str)
	{
		if (hs.Contains(ch) == false)
		{
			outValue += ch;
			hs.Add(ch);
		}
	}
	return outValue;
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
			Console.Write(" " + val);
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
	HashSet<int> hs = new HashSet<int>();
	int firstRepeating = int.MaxValue;

	for (i = size - 1; i >= 0; i--)
	{
		if (hs.Contains(arr[i]))
		{
			firstRepeating = arr[i];
		}
		hs.Add(arr[i]);
	}
	Console.WriteLine("First Repeating number is : " + firstRepeating);
}

public static int hornerHash(char[] key, int tableSize)
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
