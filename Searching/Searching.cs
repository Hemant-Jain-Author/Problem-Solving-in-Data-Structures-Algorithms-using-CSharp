using System;
using System.Collections.Generic;

public class Searching
{

public static bool linearSearchUnsorted(int[] arr, int size, int value)
{
	for (int i = 0; i < size; i++)
	{
		if (value == arr[i])
		{
			return true;
		}
	}
	return false;
}

public static bool linearSearchSorted(int[] arr, int size, int value)
{
	for (int i = 0; i < size; i++)
	{
		if (value == arr[i])
		{
			return true;
		}
		else if (value < arr[i])
		{
			return false;
		}
	}
	return false;
}

// Binary Search Algorithm - Iterative Way
public static bool Binarysearch(int[] arr, int size, int value)
{
	int low = 0;
	int high = size - 1;
	int mid;

	while (low <= high)
	{
		mid = (low + high) / 2;
		if (arr[mid] == value)
		{
			return true;
		}
		else if (arr[mid] < value)
		{
			low = mid + 1;
		}
		else
		{
			high = mid - 1;
		}
	}
	return false;
}

public static bool BinarySearchRec(int[] arr, int size, int value)
{
	int low = 0;
	int high = size - 1;
	return BinarySearchRecUtil(arr, low, high, value);
}

// Binary Search Algorithm - Recursive Way
public static bool BinarySearchRecUtil(int[] arr, int low, int high, int value)
{
	if (low > high)
	{
		return false;
	}
	int mid = (low + high) / 2;
	if (arr[mid] == value)
	{
		return true;
	}
	else if (arr[mid] < value)
	{
		return BinarySearchRecUtil(arr, mid + 1, high, value);
	}
	else
	{
		return BinarySearchRecUtil(arr, low, mid - 1, value);
	}
}

public static int BinarySearch(int[] arr, int start, int end, int key, bool isInc)
{
	int mid;
	if (end < start)
	{
		return -1;
	}
	mid = (start + end) / 2;
	if (key == arr[mid])
	{
		return mid;
	}
	if (isInc != false && key < arr[mid] || isInc == false && key > arr[mid])
	{
		return BinarySearch(arr, start, mid - 1, key, isInc);
	}
	else
	{
		return BinarySearch(arr, mid + 1, end, key, isInc);
	}
}

public static void Main1(string[] args)
{
	int[] first = new int[] { 1, 3, 5, 7, 9, 25, 30 };
	Console.WriteLine(linearSearchUnsorted(first, 7, 8));
	Console.WriteLine(linearSearchSorted(first, 7, 8));
	Console.WriteLine(Binarysearch(first, 7, 8));
	Console.WriteLine(BinarySearchRec(first, 7, 8));
	Console.WriteLine(linearSearchUnsorted(first, 7, 25));
	Console.WriteLine(linearSearchSorted(first, 7, 25));
	Console.WriteLine(Binarysearch(first, 7, 25));
	Console.WriteLine(BinarySearchRec(first, 7, 25));

}

public static void swap(int[] arr, int first, int second)
{
	int temp = arr[first];
	arr[first] = arr[second];
	arr[second] = temp;
}

public static int FirstRepeated(int[] arr, int size)
{
	for (int i = 0; i < size; i++)
	{
		for (int j = i + 1; j < size; j++)
		{
			if (arr[i] == arr[j])
			{
				return arr[i];
			}
		}
	}
	return 0;
}

public static void Main2(string[] args)
{
	int[] first = new int[] { 34, 56, 77, 1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 34, 20, 30 };
	Console.WriteLine(FirstRepeated(first, first.Length));
}

public static void printRepeating(int[] arr, int size)
{
	Console.Write(" \nRepeating elements are ");
	for (int i = 0; i < size; i++)
	{
		for (int j = i + 1; j < size; j++)
		{
			if (arr[i] == arr[j])
			{
				Console.Write(" " + arr[i]);
			}
		}
	}
}

public static void printRepeating2(int[] arr, int size)
{
	Array.Sort(arr);
	Console.Write(" \nRepeating elements are ");

	for (int i = 1; i < size; i++)
	{
		if (arr[i] == arr[i - 1])
		{
			Console.Write(" " + arr[i]);
		}
	}
}

public static void printRepeating3(int[] arr, int size)
{
	HashSet<int> hs = new HashSet<int>();
	Console.Write(" \nRepeating elements are ");
	for (int i = 0; i < size; i++)
	{
		if (hs.Contains(arr[i]))
		{
			Console.Write(" " + arr[i]);
		}
		else
		{
			hs.Add(arr[i]);
		}
	}
}

public static void printRepeating4(int[] arr, int size, int range)
{
	int[] count = new int[range];
	int i;
	for (i = 0; i < size; i++)
	{
		count[i] = 0;
	}
	Console.Write(" \nRepeating elements are ");
	for (i = 0; i < size; i++)
	{
		if (count[arr[i]] == 1)
		{
			Console.Write(" " + arr[i]);
		}
		else
		{
			count[arr[i]]++;
		}
	}
}

public static void Main3(string[] args)
{
	int[] first = new int[] { 1, 3, 5, 3, 9, 1, 30 };
	printRepeating(first, first.Length);
	printRepeating2(first, first.Length);
	printRepeating3(first, first.Length);
	printRepeating4(first, first.Length, 50);
}

public static int[] removeDuplicates(int[] array, int size)
{
	int j = 0;
	Array.Sort(array);
	for (int i = 1; i < size; i++)
	{
		if (array[i] != array[j])
		{
			j++;
			array[j] = array[i];
		}
	}
	int[] ret = new int[j + 1];
	Array.Copy(array, ret, j + 1);
	return ret;
}

public static void Main4(string[] args)
{
	int[] first = new int[] { 1, 3, 5, 3, 9, 1, 30 };
	int[] ret = removeDuplicates(first, first.Length);
	for (int i = 0; i < ret.Length; i++)
	{
		Console.Write(ret[i] + " ");
	}
}

public static int findMissingNumber(int[] arr, int size)
{
	int i, j, found = 0;
	for (i = 1; i <= size; i++)
	{
		found = 0;
		for (j = 0; j < size; j++)
		{
			if (arr[j] == i)
			{
				found = 1;
				break;
			}
		}
		if (found == 0)
		{
			return i;
		}
	}
	return int.MaxValue;
}

public static int findMissingNumber2(int[] arr, int size, int range)
{
	int i;
	int xorSum = 0;
	// get the XOR of all the numbers from 1 to range
	for (i = 1; i <= range; i++)
	{
		xorSum ^= i;
	}
	// loop through the array and get the XOR of elements
	for (i = 0; i < size; i++)
	{
		xorSum ^= arr[i];
	}
	return xorSum;
}

public static int findMissingNumber3(int[] arr, int size, int upperRange)
{
	HashSet<int> st = new HashSet<int>();

	int i = 0;
	while (i < size)
	{
		st.Add(arr[i]);
		i += 1;
	}
	i = 1;
	while (i <= upperRange)
	{
		if (st.Contains(i) == false)
		{
			return i;
		}
		i += 1;
	}
	Console.WriteLine("NoNumberMissing");
	return -1;
}

public static void Main5(string[] args)
{
	int[] first = new int[] { 1, 3, 5, 4, 6, 8, 7 };
	Console.WriteLine(findMissingNumber(first, first.Length));
	Console.WriteLine(findMissingNumber2(first, first.Length, 8));
	Console.WriteLine(findMissingNumber3(first, first.Length, 8));
}

public static void MissingValues(int[] arr, int size)
{
	Array.Sort(arr);
	int value = arr[0];
	int i = 0;
	while (i < size)
	{
		if (value == arr[i])
		{
			value += 1;
			i += 1;
		}
		else
		{
			Console.WriteLine(value);
			value += 1;
		}
	}
}

public static void MissingValues2(int[] arr, int size)
{
	HashSet<int> ht = new HashSet<int>();
	int minVal = 999999;
	int maxVal = -999999;

	for (int i = 0; i < size; i++)
	{
		ht.Add(arr[i]);
		if (minVal > arr[i])
		{
			minVal = arr[i];
		}
		if (maxVal < arr[i])
		{
			maxVal = arr[i];
		}
	}
	for (int i = minVal; i < maxVal + 1; i++)
	{
		if (ht.Contains(i) == false)
		{
			Console.WriteLine(i);
		}
	}
}

public static void Main6(string[] args)
{
	int[] arr = new int[] { 1, 9, 2, 8, 3, 7, 4, 6 };
	int size = arr.Length;
	MissingValues(arr, size);
	MissingValues2(arr, size);
}

public static void OddCount(int[] arr, int size)
{
	Dictionary<int, int> ctr = new Dictionary<int, int>();
	int count = 0;

	for (int i = 0; i < size; i++)
	{
		if (ctr.ContainsKey(arr[i]))
		{
			ctr[arr[i]] = ctr[arr[i]] + 1;
		}
		else
		{
			ctr[arr[i]] = 1;
		}
	}
	for (int i = 0; i < size; i++)
	{
		if (ctr.ContainsKey(arr[i]) && (ctr[arr[i]] % 2 == 1))
		{
			Console.WriteLine(arr[i]);
			count++;
			ctr.Remove(arr[i]);
		}
	}
	Console.WriteLine("Odd count is :: " + count);
}

public static void OddCount2(int[] arr, int size)
{
	int xorSum = 0;
	int first = 0;
	int second = 0;
	int setBit;
	/*
		* xor of all elements in arr[] even occurrence will cancel each other. sum will
		* contain sum of two odd elements.
		*/
	for (int i = 0; i < size; i++)
	{
		xorSum = xorSum ^ arr[i];
	}

	/* Rightmost set bit. */
	setBit = xorSum & ~(xorSum - 1);

	/*
		* Dividing elements in two group: Elements having setBit bit as 1. Elements
		* having setBit bit as 0. Even elements cancelled themselves if group and we
		* get our numbers.
		*/
	for (int i = 0; i < size; i++)
	{
		if ((arr[i] & setBit) != 0)
		{
			first ^= arr[i];
		}
		else
		{
			second ^= arr[i];
		}
	}
	Console.WriteLine(first + second);
}

public static void SumDistinct(int[] arr, int size)
{
	int sum = 0;
	Array.Sort(arr);
	for (int i = 0; i < (size - 1); i++)
	{
		if (arr[i] != arr[i + 1])
		{
			sum += arr[i];
		}
	}
	sum += arr[size - 1];
	Console.WriteLine(sum);
}

public static void minAbsSumPair(int[] arr, int size)
{
	int l, r, minSum, sum, minFirst, minSecond;
	// Array should have at least two elements
	if (size < 2)
	{
		Console.WriteLine("Invalid Input");
		return;
	}
	// Initialization of values
	minFirst = 0;
	minSecond = 1;
	minSum = Math.Abs(arr[0] + arr[1]);
	for (l = 0; l < size - 1; l++)
	{
		for (r = l + 1; r < size; r++)
		{
			sum = Math.Abs(arr[l] + arr[r]);
			if (sum < minSum)
			{
				minSum = sum;
				minFirst = l;
				minSecond = r;
			}
		}
	}
	Console.WriteLine(" Minimum sum elements are : " + arr[minFirst] + " , " + arr[minSecond]);
}

public static void minAbsSumPair2(int[] arr, int size)
{
	int l, r, minSum, sum, minFirst, minSecond;
	// Array should have at least two elements
	if (size < 2)
	{
		Console.WriteLine("Invalid Input");
		return;
	}
	Array.Sort(arr); // Array.Sort(arr);

	// Initialization of values
	minFirst = 0;
	minSecond = size - 1;
	minSum = Math.Abs(arr[minFirst] + arr[minSecond]);
	for (l = 0, r = size - 1; l < r;)
	{
		sum = (arr[l] + arr[r]);
		if (Math.Abs(sum) < minSum)
		{
			minSum = Math.Abs(sum); /// just corrected......hemant
			minFirst = l;
			minSecond = r;
		}
		if (sum < 0)
		{
			l++;
		}
		else if (sum > 0)
		{
			r--;
		}
		else
		{
			break;
		}
	}
	Console.WriteLine(" Minimum sum pair : " + arr[minFirst] + " , " + arr[minSecond]);
}

public static void Main7(string[] str)
{
	int[] first = new int[] { 1, 5, -10, 3, 2, -6, 8, 9, 6 };
	minAbsSumPair2(first, first.Length);
	minAbsSumPair(first, first.Length);

}

public static bool FindPair(int[] arr, int size, int value)
{
	for (int i = 0; i < size; i++)
	{
		for (int j = i + 1; j < size; j++)
		{
			if ((arr[i] + arr[j]) == value)
			{
				Console.WriteLine("The pair is : " + arr[i] + "," + arr[j]);
				return true;
			}
		}
	}
	return false;
}

public static bool FindPair2(int[] arr, int size, int value)
{
	int first = 0, second = size - 1;
	int curr;
	Array.Sort(arr); // Array.Sort(arr);
	while (first < second)
	{
		curr = arr[first] + arr[second];
		if (curr == value)
		{
			Console.WriteLine("The pair is " + arr[first] + "," + arr[second]);
			return true;
		}
		else if (curr < value)
		{
			first++;
		}
		else
		{
			second--;
		}
	}
	return false;
}

public static bool FindPair3(int[] arr, int size, int value)
{
	HashSet<int> hs = new HashSet<int>();
	for (int i = 0; i < size; i++)
	{
		if (hs.Contains(value - arr[i]))
		{
			Console.WriteLine("The pair is : " + arr[i] + " , " + (value - arr[i]));
			return true;
		}
		hs.Add(arr[i]);
	}
	return false;
}

public static void Main8(string[] args)
{
	int[] first = new int[] { 1, 5, 4, 3, 2, 7, 8, 9, 6 };
	Console.WriteLine(FindPair(first, first.Length, 8));
	Console.WriteLine(FindPair2(first, first.Length, 8));
	Console.WriteLine(FindPair3(first, first.Length, 8));

}

public static bool FindDifference(int[] arr, int size, int value)
{
	for (int i = 0; i < size; i++)
	{
		for (int j = i + 1; j < size; j++)
		{
			if (Math.Abs(arr[i] - arr[j]) == value)
			{
				Console.WriteLine("The pair is:: " + arr[i] + " & " + arr[j]);
				return true;
			}
		}
	}
	return false;
}

public static bool FindDifference2(int[] arr, int size, int value)
{
	int first = 0;
	int second = 0;
	int diff;
	Array.Sort(arr);
	while (first < size && second < size)
	{
		diff = Math.Abs(arr[first] - arr[second]);
		if (diff == value)
		{
			Console.WriteLine("The pair is::" + arr[first] + " & " + arr[second]);
			return true;
		}
		else if (diff > value)
		{
			first += 1;
		}
		else
		{
			second += 1;
		}
	}
	return false;
}

public static int findMinDiff(int[] arr, int size)
{
	Array.Sort(arr);
	int diff = 9999999;

	for (int i = 0; i < (size - 1); i++)
	{
		if ((arr[i + 1] - arr[i]) < diff)
		{
			diff = arr[i + 1] - arr[i];
		}
	}
	return diff;
}

public static int MinDiffPair(int[] arr1, int size1, int[] arr2, int size2)
{
	int minDiff = 9999999;
	int first = 0;
	int second = 0;
	int out1 = 0, out2 = 0, diff;
	Array.Sort(arr1);
	Array.Sort(arr2);
	while (first < size1 && second < size2)
	{
		diff = Math.Abs(arr1[first] - arr2[second]);
		if (minDiff > diff)
		{
			minDiff = diff;
			out1 = arr1[first];
			out2 = arr2[second];
		}
		if (arr1[first] < arr2[second])
		{
			first += 1;
		}
		else
		{
			second += 1;
		}
	}
	Console.WriteLine("The pair is :: " + out1 + out2);
	Console.WriteLine("Minimum difference is :: " + minDiff);
	return minDiff;
}

public static void Main9(string[] args)
{
	int[] first = new int[] { 1, 5, 4, 3, 2, 7, 8, 9, 6 };
	Console.WriteLine(FindDifference(first, first.Length, 6));
	Console.WriteLine(FindDifference2(first, first.Length, 6));
	Console.WriteLine(findMinDiff(first, first.Length));
	Console.WriteLine(MinDiffPair(first, first.Length, first, first.Length));
}

public static void ClosestPair(int[] arr, int size, int value)
{
	int diff = 999999;
	int first = -1;
	int second = -1;
	int curr;
	for (int i = 0; i < size; i++)
	{
		for (int j = i + 1; j < size; j++)
		{
			curr = Math.Abs(value - (arr[i] + arr[j]));
			if (curr < diff)
			{
				diff = curr;
				first = arr[i];
				second = arr[j];
			}
		}
	}
	Console.WriteLine("closest pair is ::" + first + second);
}

public static void ClosestPair2(int[] arr, int size, int value)
{
	int first = 0, second = 0;
	int start = 0;
	int stop = size - 1;
	int diff, curr;
	Array.Sort(arr);
	diff = 9999999;
	{
		while (start < stop)
		{
			curr = (value - (arr[start] + arr[stop]));
			if (Math.Abs(curr) < diff)
			{
				diff = Math.Abs(curr);
				first = arr[start];
				second = arr[stop];
			}
			if (curr == 0)
			{
				break;
			}
			else if (curr > 0)
			{
				start += 1;
			}
			else
			{
				stop -= 1;
			}
		}
	}
	Console.WriteLine("closest pair is :: " + first + second);
}

public static void Main10(string[] args)
{
	int[] first = new int[] { 1, 5, 4, 3, 2, 7, 8, 9, 6 };
	ClosestPair(first, first.Length, 6);
	ClosestPair2(first, first.Length, 6);
}

public static bool SumPairRestArray(int[] arr, int size)
{
	int total, low, high, curr, value;
	Array.Sort(arr);
	total = 0;
	for (int i = 0; i < size; i++)
	{
		total += arr[i];
	}
	value = total / 2;
	low = 0;
	high = size - 1;
	while (low < high)
	{
		curr = arr[low] + arr[high];
		if (curr == value)
		{
			Console.WriteLine("Pair is :: " + arr[low] + arr[high]);
			return true;
		}
		else if (curr < value)
		{
			low += 1;
		}
		else
		{
			high -= 1;
		}
	}
	return false;
}

public static void ZeroSumTriplets(int[] arr, int size)
{
	for (int i = 0; i < (size - 2); i++)
	{
		for (int j = i + 1; j < (size - 1); j++)
		{
			for (int k = j + 1; k < size; k++)
			{
				if (arr[i] + arr[j] + arr[k] == 0)
				{
					Console.WriteLine("Triplet :: " + arr[i] + arr[j] + arr[k]);
				}
			}
		}
	}
}

public static void ZeroSumTriplets2(int[] arr, int size)
{
	int start, stop;
	Array.Sort(arr);
	for (int i = 0; i < (size - 2); i++)
	{
		start = i + 1;
		stop = size - 1;

		while (start < stop)
		{
			if (arr[i] + arr[start] + arr[stop] == 0)
			{
				Console.WriteLine("Triplet :: " + arr[i] + arr[start] + arr[stop]);
				start += 1;
				stop -= 1;
			}
			else if (arr[i] + arr[start] + arr[stop] > 0)
			{
				stop -= 1;
			}
			else
			{
				start += 1;
			}
		}
	}
}

public static void findTriplet(int[] arr, int size, int value)
{
	for (int i = 0; i < (size - 2); i++)
	{
		for (int j = i + 1; j < (size - 1); j++)
		{
			for (int k = j + 1; k < size; k++)
			{
				if ((arr[i] + arr[j] + arr[k]) == value)
				{
					Console.WriteLine("Triplet :: " + arr[i] + arr[j] + arr[k]);
				}
			}
		}
	}
}

public static void findTriplet2(int[] arr, int size, int value)
{
	int start, stop;
	Array.Sort(arr);
	for (int i = 0; i < size - 2; i++)
	{
		start = i + 1;
		stop = size - 1;
		while (start < stop)
		{
			if (arr[i] + arr[start] + arr[stop] == value)
			{
				Console.WriteLine("Triplet ::" + arr[i] + arr[start] + arr[stop]);
				start += 1;
				stop -= 1;
			}
			else if (arr[i] + arr[start] + arr[stop] > value)
			{
				stop -= 1;
			}
			else
			{
				start += 1;
			}
		}
	}
}

public static void ABCTriplet(int[] arr, int size)
{
	int start, stop;
	Array.Sort(arr);
	for (int i = 0; i < (size - 1); i++)
	{
		start = 0;
		stop = size - 1;
		while (start < stop)
		{
			if (arr[i] == arr[start] + arr[stop])
			{
				Console.WriteLine("Triplet ::%d, %d, %d" + arr[i] + arr[start] + arr[stop]);
				start += 1;
				stop -= 1;
			}
			else if (arr[i] < arr[start] + arr[stop])
			{
				stop -= 1;
			}
			else
			{
				start += 1;
			}
		}
	}
}

public static void SmallerThenTripletCount(int[] arr, int size, int value)
{
	int start, stop;
	int count = 0;
	Array.Sort(arr);

	for (int i = 0; i < (size - 2); i++)
	{
		start = i + 1;
		stop = size - 1;
		while (start < stop)
		{
			if (arr[i] + arr[start] + arr[stop] >= value)
			{
				stop -= 1;
			}
			else
			{
				count += stop - start;
				start += 1;
			}
		}
	}
	Console.WriteLine(count);
}

public static void APTriplets(int[] arr, int size)
{
	int i, j, k;
	for (i = 1; i < size - 1; i++)
	{
		j = i - 1;
		k = i + 1;
		while (j >= 0 && k < size)
		{
			if (arr[j] + arr[k] == 2 * arr[i])
			{
				Console.WriteLine("Triplet ::" + arr[j] + arr[i] + arr[k]);
				k += 1;
				j -= 1;
			}
			else if (arr[j] + arr[k] < 2 * arr[i])
			{
				k += 1;
			}
			else
			{
				j -= 1;
			}
		}
	}
}

public static void GPTriplets(int[] arr, int size)
{
	int i, j, k;
	for (i = 1; i < size - 1; i++)
	{
		j = i - 1;
		k = i + 1;
		while (j >= 0 && k < size)
		{
			if (arr[j] * arr[k] == arr[i] * arr[i])
			{
				Console.WriteLine("Triplet is :: " + arr[j] + arr[i] + arr[k]);
				k += 1;
				j -= 1;
			}
			else if (arr[j] + arr[k] < 2 * arr[i])
			{
				k += 1;
			}
			else
			{
				j -= 1;
			}
		}
	}
}

public static int numberOfTriangles(int[] arr, int size)
{
	int i, j, k, count = 0;
	for (i = 0; i < (size - 2); i++)
	{
		for (j = i + 1; j < (size - 1); j++)
		{
			for (k = j + 1; k < size; k++)
			{
				if ((arr[i] + arr[j] > arr[k]) && (arr[k] + arr[j] > arr[i]) && (arr[i] + arr[k] > arr[j]))
				{
					count += 1;
				}
			}
		}
	}
	return count;
}

public static int numberOfTriangles2(int[] arr, int size)
{
	int i, j, k, count = 0;
	Array.Sort(arr);

	for (i = 0; i < (size - 2); i++)
	{
		k = i + 2;
		for (j = i + 1; j < (size - 1); j++)
		{
			/*
				* if sum of arr[i] & arr[j] is greater arr[k] then sum of arr[i] & arr[j + 1]
				* is also greater than arr[k] this improvement make algo O(n2)
				*/
			while (k < size && arr[i] + arr[j] > arr[k])
			{
				k += 1;
			}

			count += k - j - 1;
		}
	}
	return count;
}

public static int getMax(int[] arr, int size)
{
	int max = arr[0], count = 1, maxCount = 1;
	for (int i = 0; i < size; i++)
	{
		count = 1;
		for (int j = i + 1; j < size; j++)
		{
			if (arr[i] == arr[j])
			{
				count++;
			}
		}
		if (count > maxCount)
		{
			max = arr[i];
			maxCount = count;
		}
	}
	return max;
}

public static int getMax2(int[] arr, int size)
{
	int max = arr[0], maxCount = 1;
	int curr = arr[0], currCount = 1;
	Array.Sort(arr);
	for (int i = 1; i < size; i++)
	{
		if (arr[i] == arr[i - 1])
		{
			currCount++;
		}
		else
		{
			currCount = 1;
			curr = arr[i];
		}
		if (currCount > maxCount)
		{
			maxCount = currCount;
			max = curr;
		}
	}
	return max;
}

public static int getMax3(int[] arr, int size, int range)
{
	int max = arr[0], maxCount = 1;
	int[] count = new int[range];
	for (int i = 0; i < size; i++)
	{
		count[arr[i]]++;
		if (count[arr[i]] > maxCount)
		{
			maxCount = count[arr[i]];
			max = arr[i];
		}
	}
	return max;
}

public static void Main11(string[] args)
{
	int[] first = new int[] { 1, 30, 5, 13, 9, 31, 5 };
	Console.WriteLine(getMax(first, first.Length));
	Console.WriteLine(getMax2(first, first.Length));
	Console.WriteLine(getMax3(first, first.Length, 50));
}

public static int getMajority(int[] arr, int size)
{
	int max = 0, count = 0, maxCount = 0;
	for (int i = 0; i < size; i++)
	{
		for (int j = i + 1; j < size; j++)
		{
			if (arr[i] == arr[j])
			{
				count++;
			}
		}
		if (count > maxCount)
		{
			max = arr[i];
			maxCount = count;
		}
	}
	if (maxCount > size / 2)
	{
		return max;
	}
	else
	{
		return 0;
	}
}

public static int getMajority2(int[] arr, int size)
{
	int majIndex = size / 2, count = 1;
	int candidate;
	Array.Sort(arr);
	candidate = arr[majIndex];
	count = 0;
	for (int i = 0; i < size; i++)
	{
		if (arr[i] == candidate)
		{
			count++;
		}
	}
	if (count > size / 2)
	{
		return arr[majIndex];
	}
	else
	{
		return int.MinValue;
	}
}

public static int getMajority3(int[] arr, int size)
{
	int majIndex = 0, count = 1;
	int i;
	int candidate;
	for (i = 1; i < size; i++)
	{
		if (arr[majIndex] == arr[i])
		{
			count++;
		}
		else
		{
			count--;
		}
		if (count == 0)
		{
			majIndex = i;
			count = 1;
		}
	}
	candidate = arr[majIndex];
	count = 0;
	for (i = 0; i < size; i++)
	{
		if (arr[i] == candidate)
		{
			count++;
		}
	}
	if (count > size / 2)
	{
		return arr[majIndex];
	}
	else
	{
		return 0;
	}
}

public static void Main12(string[] args)
{
	int[] first = new int[] { 1, 5, 5, 13, 5, 31, 5 };
	Console.WriteLine(getMajority(first, first.Length));
	Console.WriteLine(getMajority2(first, first.Length));
	Console.WriteLine(getMajority3(first, first.Length));
}

public static int getMedian(int[] arr, int size)
{
	Array.Sort(arr);
	return arr[size / 2];
}

public static int SearchBotinicArrayMax(int[] arr, int size)
{
	int start = 0, end = size - 1;
	int mid = (start + end) / 2;
	int maximaFound = 0;
	if (size < 3)
	{
		Console.WriteLine("error");
		return 0;
	}
	while (start <= end)
	{
		mid = (start + end) / 2;
		if (arr[mid - 1] < arr[mid] && arr[mid + 1] < arr[mid]) // maxima
		{
			maximaFound = 1;
			break;
		}
		else if (arr[mid - 1] < arr[mid] && arr[mid] < arr[mid + 1]) // increasing
		{
			start = mid + 1;
		}
		else if (arr[mid - 1] > arr[mid] && arr[mid] > arr[mid + 1]) // decreasing
		{
			end = mid - 1;
		}
		else
		{
			break;
		}
	}
	if (maximaFound == 0)
	{
		Console.WriteLine("error");
		return 0;
	}
	return arr[mid];
}

public static int SearchBitonicArray(int[] arr, int size, int key)
{
	int max = FindMaxBitonicArray(arr, size);
	int k = BinarySearch(arr, 0, max, key, true);
	if (k != -1)
	{
		return k;
	}
	else
	{
		return BinarySearch(arr, max + 1, size - 1, key, false);
	}
}

public static int FindMaxBitonicArray(int[] arr, int size)
{
	int start = 0, end = size - 1, mid;
	if (size < 3)
	{
		Console.WriteLine("error");
		return -1;
	}
	while (start <= end)
	{
		mid = (start + end) / 2;
		if (arr[mid - 1] < arr[mid] && arr[mid + 1] < arr[mid]) // maxima
		{
			return mid;
		}
		else if (arr[mid - 1] < arr[mid] && arr[mid] < arr[mid + 1]) // increasing
		{
			start = mid + 1;
		}
		else if (arr[mid - 1] > arr[mid] && arr[mid] > arr[mid + 1]) // increasing
		{
			end = mid - 1;
		}
		else
		{
			break;
		}
	}
	Console.WriteLine("error");
	return -1;
}

public static void Main13(string[] args)
{
	int[] first = new int[] { 1, 5, 10, 13, 20, 30, 8, 7, 6 };

	Console.WriteLine(SearchBotinicArrayMax(first, first.Length));
	Console.WriteLine(SearchBitonicArray(first, first.Length, 7));
}

public static int findKeyCount(int[] arr, int size, int key)
{
	int count = 0;
	for (int i = 0; i < size; i++)
	{
		if (arr[i] == key)
		{
			count++;
		}
	}
	return count;
}

public static int findKeyCount2(int[] arr, int size, int key)
{
	int firstIndex, lastIndex;
	firstIndex = findFirstIndex(arr, 0, size - 1, key);
	lastIndex = findLastIndex(arr, 0, size - 1, key);
	return (lastIndex - firstIndex + 1);
}

/* Using binary search method. */
public static int FirstIndex(int[] arr, int size, int low, int high, int value)
{
	int mid = 0;
	if (high >= low)
	{
		mid = (low + high) / 2;
	}

	/*
		* Find first occurrence of value, either it should be the first element of the
		* array or the value before it is smaller than it.
		*/
	if ((mid == 0 || arr[mid - 1] < value) && (arr[mid] == value))
	{
		return mid;
	}
	else if (arr[mid] < value)
	{
		return FirstIndex(arr, size, mid + 1, high, value);
	}
	else
	{
		return FirstIndex(arr, size, low, mid - 1, value);
	}
}

public static bool isMajority(int[] arr, int size)
{
	int majority = arr[size / 2];
	int i = FirstIndex(arr, size, 0, size - 1, majority);
	/*
		* we are using majority element form array so we will get some valid index
		* always.
		*/
	if (((i + size / 2) <= (size - 1)) && arr[i + size / 2] == majority)
	{
		return true;
	}
	else
	{
		return false;
	}
}
public static int findFirstIndex(int[] arr, int start, int end, int key)
{
	int mid;
	if (end < start)
	{
		return -1;
	}
	mid = (start + end) / 2;
	if (key == arr[mid] && (mid == start || arr[mid - 1] != key))
	{
		return mid;
	}
	if (key <= arr[mid]) // <= is us the number.t in sorted array.
	{
		return findFirstIndex(arr, start, mid - 1, key);
	}
	else
	{
		return findFirstIndex(arr, mid + 1, end, key);
	}
}

public static int findLastIndex(int[] arr, int start, int end, int key)
{
	if (end < start)
	{
		return -1;
	}
	int mid = (start + end) / 2;
	if (key == arr[mid] && (mid == end || arr[mid + 1] != key))
	{
		return mid;
	}
	if (key < arr[mid]) // <
	{
		return findLastIndex(arr, start, mid - 1, key);
	}
	else
	{
		return findLastIndex(arr, mid + 1, end, key);
	}
}

public static void Main14(string[] args)
{
	int[] first = new int[] { 1, 5, 10, 13, 20, 30, 8, 7, 6 };
	Console.WriteLine(findKeyCount(first, first.Length, 6));
	Console.WriteLine(findKeyCount2(first, first.Length, 6));
}

public static int maxProfit(int[] stocks, int size)
{
	int buy = 0, sell = 0;
	int curMin = 0;
	int currProfit = 0;
	int maxProfit = 0;
	for (int i = 0; i < size; i++)
	{
		if (stocks[i] < stocks[curMin])
		{
			curMin = i;
		}
		currProfit = stocks[i] - stocks[curMin];
		if (currProfit > maxProfit)
		{
			buy = curMin;
			sell = i;
			maxProfit = currProfit;
		}
	}
	Console.WriteLine("Purchase day is- " + buy + " at price " + stocks[buy]);
	Console.WriteLine("Sell day is- " + sell + " at price " + stocks[sell]);
	return maxProfit;
}

public static void Main15(string[] args)
{
	int[] first = new int[] { 10, 150, 6, 67, 61, 16, 86, 6, 67, 78, 150, 3, 28, 143 };
	Console.WriteLine(maxProfit(first, first.Length));
}

public static int findMedian(int[] arrFirst, int sizeFirst, int[] arrSecond, int sizeSecond)
{
	int medianIndex = ((sizeFirst + sizeSecond) + (sizeFirst + sizeSecond) % 2) / 2; // cealing
																						// function.
	int i = 0, j = 0;
	int count = 0;
	while (count < medianIndex - 1)
	{
		if (i < sizeFirst - 1 && arrFirst[i] < arrSecond[j])
		{
			i++;
		}
		else
		{
			j++;
		}
		count++;
	}
	if (arrFirst[i] < arrSecond[j])
	{
		return arrFirst[i];
	}
	else
	{
		return arrSecond[j];
	}
}

public static void Main16(string[] args)
{
	int[] first = new int[] { 1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30 };
	int[] second = new int[] { 1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30 };
	Console.WriteLine(findMedian(first, first.Length, second, second.Length));
}

public static int BinarySearch01(int[] arr, int size)
{
	if (size == 1 && arr[0] == 1)
	{
		return 0;
	}
	return BinarySearch01Util(arr, 0, size - 1);
}

public static int BinarySearch01Util(int[] arr, int start, int end)
{
	if (end < start)
	{
		return -1;
	}
	int mid = (start + end) / 2;
	if (1 == arr[mid] && 0 == arr[mid - 1])
	{
		return mid;
	}
	if (0 == arr[mid])
	{
		return BinarySearch01Util(arr, mid + 1, end);
	}
	else
	{
		return BinarySearch01Util(arr, start, mid - 1);
	}
}

public static void Main17(string[] args)
{
	int[] first = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 };
	Console.WriteLine(BinarySearch01(first, first.Length));
}

public static int RotationMaxUtil(int[] arr, int start, int end)
{
	if (end <= start)
	{
		return arr[start];
	}
	int mid = (start + end) / 2;
	if (arr[mid] > arr[mid + 1])
	{
		return arr[mid];
	}

	if (arr[start] <= arr[mid]) // increasing part.
	{
		return RotationMaxUtil(arr, mid + 1, end);
	}
	else
	{
		return RotationMaxUtil(arr, start, mid - 1);
	}
}

public static int RotationMax(int[] arr, int size)
{
	return RotationMaxUtil(arr, 0, size - 1);
}

public static int FindRotationMaxUtil(int[] arr, int start, int end)
{
	/* single element case. */
	if (end <= start)
	{
		return start;
	}

	int mid = (start + end) / 2;
	if (arr[mid] > arr[mid + 1])
	{
		return mid;
	}

	if (arr[start] <= arr[mid]) // increasing part.
	{
		return FindRotationMaxUtil(arr, mid + 1, end);
	}
	else
	{
		return FindRotationMaxUtil(arr, start, mid - 1);
	}
}

public static int FindRotationMax(int[] arr, int size)
{
	return FindRotationMaxUtil(arr, 0, size - 1);
}

public static int CountRotation(int[] arr, int size)
{
	int maxIndex = FindRotationMaxUtil(arr, 0, size - 1);
	return (maxIndex + 1) % size;
}

public static int BinarySearchRotateArrayUtil(int[] arr, int start, int end, int key)
{
	if (end < start)
	{
		return -1;
	}
	int mid = (start + end) / 2;
	if (key == arr[mid])
	{
		return mid;
	}
	if (arr[mid] > arr[start])
	{
		if (arr[start] <= key && key < arr[mid])
		{
			return BinarySearchRotateArrayUtil(arr, start, mid - 1, key);
		}
		else
		{
			return BinarySearchRotateArrayUtil(arr, mid + 1, end, key);
		}
	}
	else
	{
		if (arr[mid] < key && key <= arr[end])
		{
			return BinarySearchRotateArrayUtil(arr, mid + 1, end, key);
		}
		else
		{
			return BinarySearchRotateArrayUtil(arr, start, mid - 1, key);
		}
	}
}

public static int BinarySearchRotateArray(int[] arr, int size, int key)
{
	return BinarySearchRotateArrayUtil(arr, 0, size - 1, key);
}

public static void Main18(string[] args)
{
	int[] first = new int[] { 34, 56, 77, 1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30 };
	Console.WriteLine(BinarySearchRotateArray(first, first.Length, 20));
	Console.WriteLine(CountRotation(first, first.Length));
	Console.WriteLine(first[FindRotationMax(first, first.Length)]);
}

public static int minAbsDiffAdjCircular(int[] arr, int size)
{
	int diff = 9999999;
	if (size < 2)
	{
		return -1;
	}

	for (int i = 0; i < size; i++)
	{
		diff = Math.Min(diff, Math.Abs(arr[i] - arr[(i + 1) % size]));
	}

	return diff;
}

/*
	* Testing code
	*/
public static void Main19(string[] str)
{
	int[] arr = new int[] { 5, 29, 18, 51, 11 };
	Console.WriteLine(minAbsDiffAdjCircular(arr, arr.Length));
}

public static void swapch(char[] arr, int first, int second)
{
	char temp = arr[first];
	arr[first] = arr[second];
	arr[second] = temp;
}

public static void transformArrayAB1(char[] arr, int size)
{
	int N = size / 2, i, j;
	for (i = 1; i < N; i++)
	{
		for (j = 0; j < i; j++)
		{
			swapch(arr, N - i + 2 * j, N - i + 2 * j + 1);
		}
	}
}

public static void Main20(string[] args)
{
	char[] str = "aaaabbbb".ToCharArray();
	transformArrayAB1(str, str.Length);
	Console.WriteLine(str);
}

public static bool checkPermutation(char[] array1, int size1, char[] array2, int size2)
{
	if (size1 != size2)
	{
		return false;
	}
	Array.Sort(array1);
	Array.Sort(array2);
	for (int i = 0; i < size1; i++)
	{
		if (array1[i] != array2[i])
		{
			return false;
		}
	}
	return true;
}

public static void Main21(string[] args)
{
	char[] str1 = "aaaabbbb".ToCharArray();
	char[] str2 = "bbaaaabb".ToCharArray();

	Console.WriteLine(checkPermutation(str1, str1.Length, str2, str2.Length));
}

public static bool FindElementIn2DArray(int[][] arr, int r, int c, int value)
{
	int row = 0;
	int column = c - 1;
	while (row < r && column >= 0)
	{
		if (arr[row][column] == value)
		{
			return true;
		}
		else if (arr[row][column] > value)
		{
			column--;
		}
		else
		{
			row++;
		}
	}
	return false;
}

public static bool isAP(int[] arr, int size)
{
	if (size <= 1)
	{
		return true;
	}

	Array.Sort(arr);
	int diff = arr[1] - arr[0];
	for (int i = 2; i < size; i++)
	{
		if (arr[i] - arr[i - 1] != diff)
		{
			return false;
		}
	}
	return true;
}

public static bool isAP2(int[] arr, int size)
{
	int first = 9999999;
	int second = 9999999;
	int value;
	HashSet<int> hs = new HashSet<int>();
	for (int i = 0; i < size; i++)
	{
		if (arr[i] < first)
		{
			second = first;
			first = arr[i];
		}
		else if (arr[i] < second)
		{
			second = arr[i];
		}
	}
	int diff = second - first;

	for (int i = 0; i < size; i++)
	{
		if (hs.Contains(arr[i]))
		{
			return false;
		}
		hs.Add(arr[i]);
	}
	for (int i = 0; i < size; i++)
	{
		value = first + i * diff;
		if (!hs.Contains(value))
		{
			return false;
		}
	}
	return true;
}

public static bool isAP3(int[] arr, int size)
{
	int first = 9999999;
	int second = 9999999;
	int[] count = new int[size];
	int index = -1;
	for (int i = 0; i < size; i++)
	{
		if (arr[i] < first)
		{
			second = first;
			first = arr[i];
		}
		else if (arr[i] < second)
		{
			second = arr[i];
		}
	}
	int diff = second - first;

	for (int i = 0; i < size; i++)
	{
		index = (arr[i] - first) / diff;
	}
	if (index > size - 1 || count[index] != 0)
	{
		return false;
	}
	count[index] = 1;

	for (int i = 0; i < size; i++)
	{
		if (count[i] != 1)
		{
			return false;
		}
	}
	return true;
}

public static int findBalancedPoint(int[] arr, int size)
{
	int first = 0;
	int second = 0;
	for (int i = 1; i < size; i++)
	{
		second += arr[i];
	}

	for (int i = 0; i < size; i++)
	{
		if (first == second)
		{
			Console.WriteLine(i);
			return i;
		}
		if (i < size - 1)
		{
			first += arr[i];
		}
		second -= arr[i + 1];
	}
	return -1;
}

/*
	* Testing code
	*/
public static void Main22(string[] args)
{
	int[] arr = new int[] { -7, 1, 5, 2, -4, 3, 0 };
	Console.WriteLine(findBalancedPoint(arr, arr.Length));

}

public static int findFloor(int[] arr, int size, int value)
{
	int start = 0;
	int stop = size - 1;
	int mid;
	while (start <= stop)
	{
		mid = (start + stop) / 2;
		/*
			* search value is equal to arr[mid] value.. search value is greater than mid
			* index value and less than mid+1 index value. value is greater than
			* arr[size-1] then floor is arr[size-1]
			*/
		if (arr[mid] == value || (arr[mid] < value && (mid == size - 1 || arr[mid + 1] > value)))
		{
			return mid;
		}
		else if (arr[mid] < value)
		{
			start = mid + 1;
		}
		else
		{
			stop = mid - 1;
		}
	}
	return -1;
}

public static int findCeil(int[] arr, int size, int value)
{
	int start = 0;
	int stop = size - 1;
	int mid;

	while (start <= stop)
	{
		mid = (start + stop) / 2;
		/*
			* search value is equal to arr[mid] value.. search value is less than mid index
			* value and greater than mid-1 index value. value is less than arr[0] then ceil
			* is arr[0]
			*/
		if (arr[mid] == value || (arr[mid] > value && (mid == 0 || arr[mid - 1] < value)))
		{
			return mid;
		}
		else if (arr[mid] < value)
		{
			start = mid + 1;
		}
		else
		{
			stop = mid - 1;
		}
	}
	return -1;
}

public static int ClosestNumber(int[] arr, int size, int num)
{
	int start = 0;
	int stop = size - 1;
	int output = -1;
	int minDist = 9999;
	int mid;

	while (start <= stop)
	{
		mid = (start + stop) / 2;
		if (minDist > Math.Abs(arr[mid] - num))
		{
			minDist = Math.Abs(arr[mid] - num);
			output = arr[mid];
		}
		if (arr[mid] == num)
		{
			break;
		}
		else if (arr[mid] > num)
		{
			stop = mid - 1;
		}
		else
		{
			start = mid + 1;
		}
	}
	return output;
}

public static bool DuplicateKDistance(int[] arr, int size, int k)
{
	Dictionary<int, int> hm = new Dictionary<int, int>();

	for (int i = 0; i < size; i++)
	{
		if (hm.ContainsKey(arr[i]) && i - hm[arr[i]] <= k)
		{
			Console.WriteLine("Value:" + arr[i] + " Index: " + hm[arr[i]] + " & " + i);
			return true;
		}
		else
		{
			hm[arr[i]] = i;
		}
	}
	return false;
}

/*
	* Testing code
	*/
public static void Main23(string[] args)
{
	int[] arr = new int[] { 1, 2, 3, 1, 4, 5 };
	DuplicateKDistance(arr, arr.Length, 3);
}

public static void frequencyCounts(int[] arr, int size)
{
	int index;
	for (int i = 0; i < size; i++)
	{
		while (arr[i] > 0)
		{
			index = arr[i] - 1;
			if (arr[index] > 0)
			{
				arr[i] = arr[index];
				arr[index] = -1;
			}
			else
			{
				arr[index] -= 1;
				arr[i] = 0;
			}
		}
	}
	for (int i = 0; i < size; i++)
	{
		Console.WriteLine((i + 1) + Math.Abs(arr[i]));
	}
}

public static int KLargestElements(int[] arrIn, int size, int k)
{
	int[] arr = new int[size];
	for (int i = 0; i < size; i++)
	{
		arr[i] = arrIn[i];
	}

	Array.Sort(arr);
	for (int i = 0; i < size; i++)
	{
		if (arrIn[i] >= arr[size - k])
		{
			Console.WriteLine(arrIn[i]);
			return arrIn[i];
		}
	}
	return -1;
}

public static void QuickSelectUtil(int[] arr, int lower, int upper, int k)
{
	if (upper <= lower)
	{
		return;
	}

	int pivot = arr[lower];
	int start = lower;
	int stop = upper;

	while (lower < upper)
	{
		while (arr[lower] <= pivot)
		{
			lower++;
		}
		while (arr[upper] > pivot)
		{
			upper--;
		}
		if (lower < upper)
		{
			swap(arr, upper, lower);
		}
	}

	swap(arr, upper, start); // upper is the pivot position
	if (k < upper)
	{
		QuickSelectUtil(arr, start, upper - 1, k); // pivot -1 is the upper for left sub array.
	}
	if (k > upper)
	{
		QuickSelectUtil(arr, upper + 1, stop, k); // pivot + 1 is the lower for right sub array.
	}
}

public static int KLargestElements2(int[] arrIn, int size, int k)
{
	int[] arr = new int[size];
	for (int i = 0; i < size; i++)
	{
		arr[i] = arrIn[i];
	}

	QuickSelectUtil(arr, 0, size - 1, size - k);
	for (int i = 0; i < size; i++)
	{
		if (arrIn[i] >= arr[size - k])
		{
			Console.WriteLine(arrIn[i]);
			return arrIn[i];
		}
	}
	return -1;
}

/* linear search method */
public static int FixPoint(int[] arr, int size)
{
	for (int i = 0; i < size; i++)
	{
		if (arr[i] == i)
		{
			return i;
		}
	} // fix point not found so return invalid index
	return -1;
}

/* Binary search method */
public static int FixPoint2(int[] arr, int size)
{
	int low = 0;
	int high = size - 1;
	int mid;
	while (low <= high)
	{
		mid = (low + high) / 2;
		if (arr[mid] == mid)
		{
			return mid;
		}
		else if (arr[mid] < mid)
		{
			low = mid + 1;
		}
		else
		{
			high = mid - 1;
		}
	}
	/* fix point not found so return invalid index */
	return -1;
}

public static int subArraySums(int[] arr, int size, int value)
{
	int first = 0;
	int second = 0;
	int sum = arr[first];
	while (second < size && first < size)
	{
		if (sum == value)
		{
			Console.WriteLine(first + second);
		}

		if (sum < value)
		{
			second += 1;
			if (second < size)
			{
				sum += arr[second];
			}
		}
		else
		{
			sum -= arr[first];
			first += 1;
		}
	}
	return sum;
}

public static int MaxConSub(int[] arr, int size)
{
	int currMax = 0;
	int maximum = 0;
	for (int i = 0; i < size; i++)
	{
		currMax = Math.Max(arr[i], currMax + arr[i]);
		if (currMax < 0)
		{
			currMax = 0;
		}
		if (maximum < currMax)
		{
			maximum = currMax;
		}
	}
	Console.WriteLine(maximum);
	return maximum;
}

public static int MaxConSubArr(int[] A, int sizeA, int[] B, int sizeB)
{
	int currMax = 0;
	int maximum = 0;
	HashSet<int> hs = new HashSet<int>();

	for (int i = 0; i < sizeB; i++)
	{
		hs.Add(B[i]);
	}

	for (int i = 0; i < sizeA; i++)
	{
		if (hs.Contains(A[i]))
		{
			currMax = 0;
		}
		else
		{
			currMax = Math.Max(A[i], currMax + A[i]);
		}
	}
	if (currMax < 0)
	{
		currMax = 0;
	}
	if (maximum < currMax)
	{
		maximum = currMax;
	}
	Console.WriteLine(maximum);
	return maximum;
}

public static int MaxConSubArr2(int[] A, int sizeA, int[] B, int sizeB)
{
	Array.Sort(B);
	int currMax = 0;
	int maximum = 0;

	for (int i = 0; i < sizeA; i++)
	{
		if (Binarysearch(B, sizeB, A[i]))
		{
			currMax = 0;
		}
		else
		{
			currMax = Math.Max(A[i], currMax + A[i]);
			if (currMax < 0)
			{
				currMax = 0;
			}
			if (maximum < currMax)
			{
				maximum = currMax;
			}
		}
	}
	Console.WriteLine(maximum);
	return maximum;
}

public static int RainWater(int[] arr, int size)
{
	int[] leftHigh = new int[size];
	int[] rightHigh = new int[size];

	int max = arr[0];
	leftHigh[0] = arr[0];
	for (int i = 1; i < size; i++)
	{
		if (max < arr[i])
		{
			max = arr[i];
		}
		leftHigh[i] = max;
	}
	max = arr[size - 1];
	rightHigh[size - 1] = arr[size - 1];
	for (int i = (size - 2); i >= 0; i--)
	{
		if (max < arr[i])
		{
			max = arr[i];
		}
		rightHigh[i] = max;
	}

	int water = 0;
	for (int i = 0; i < size; i++)
	{
		water += Math.Min(leftHigh[i], rightHigh[i]) - arr[i];
	}
	Console.WriteLine("Water : " + water);
	return water;
}

public static int RainWater2(int[] arr, int size)
{
	int water = 0;
	int leftMax = 0, rightMax = 0;
	int left = 0;
	int right = size - 1;

	while (left <= right)
	{
		if (arr[left] < arr[right])
		{
			if (arr[left] > leftMax)
			{
				leftMax = arr[left];
			}
			else
			{
				water += leftMax - arr[left];
			}
			left += 1;
		}
		else
		{
			if (arr[right] > rightMax)
			{
				rightMax = arr[right];
			}
			else
			{
				water += rightMax - arr[right];
			}
			right -= 1;
		}
	}
	Console.WriteLine("Water : " + water);
	return water;
}

public static void seperateEvenAndOdd(int[] arr, int size)
{
	int left = 0, right = size - 1;
	while (left < right)
	{
		if (arr[left] % 2 == 0)
		{
			left++;
		}
		else if (arr[right] % 2 == 1)
		{
			right--;
		}
		else
		{
			swap(arr, left, right);
			left++;
			right--;
		}
	}
}

public static void Main24(string[] args)
{
	int[] first = new int[] { 1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30 };
	seperateEvenAndOdd(first, first.Length);
	foreach (int val in first)
	{
		Console.Write(val + " ");
	}
}

public static void Main(string[] args)
{
	Main1(args);
	Main2(args);
	Main3(args);
	Main4(args);
	Main5(args);
	Main6(args);
	Main7(args);
	Main8(args);
	Main9(args);
	Main10(args);
	Main11(args);
	Main12(args);
	Main13(args);
	Main14(args);
	Main15(args);
	Main16(args);
	Main17(args);
	Main18(args);
	Main19(args);
	Main20(args);
	Main21(args);
	Main22(args);
	Main23(args);
	Main24(args);
}
}