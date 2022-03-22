using System;
using System.Collections.Generic;

public class Searching
{
	public static bool LinearSearchUnsorted(int[] arr, int size, int value)
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

	public static bool LinearSearchSorted(int[] arr, int size, int value)
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
	public static bool BinarySearch(int[] arr, int size, int value)
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

	//Binary Search Algorithm - Recursive Way
	public static bool BinarySearchRec(int[] arr, int size, int value)
	{
		int low = 0;
		int high = size - 1;
		return BinarySearchRecUtil(arr, low, high, value);
	}

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

	public static bool FibonacciSearch(int[] arr, int size, int value)
	{
		/* Initialize Binary numbers */
		int fibNMn2 = 0;
		int fibNMn1 = 1;
		int fibN = fibNMn2 + fibNMn1;

		while (fibN < size)
		{
			fibNMn2 = fibNMn1;
			fibNMn1 = fibN;
			fibN = fibNMn2 + fibNMn1;
		}

		int low = 0;
		while (fibN > 1)
		{ // Fibonacci series start with 0, 1, 1, 2
			int i = Math.Min(low + fibNMn2, size-1);
			if (arr[i] == value)
			{
				return true;
			}
			else if (arr[i] < value)
			{
				fibN = fibNMn1;
				fibNMn1 = fibNMn2;
				fibNMn2 = fibN - fibNMn1;
				low = i;
			}
			else
			{ // for feb2 <= 1, these will be invalid.
				fibN = fibNMn2;
				fibNMn1 = fibNMn1 - fibNMn2;
				fibNMn2 = fibN - fibNMn1;
			}
		}
		if (arr[low + fibNMn2] == value) // above loop does not check when fibNMn2 = 0
		{
			return true;
		}
		return false;
	}

	public static void Main1()
	{
		int[] first = new int[] {1, 3, 5, 7, 9, 25, 30};
	/*    Console.WriteLine(LinearSearchUnsorted(first, 7, 8));
	    Console.WriteLine(LinearSearchSorted(first, 7, 8));
	    Console.WriteLine(BinarySearch(first, 7, 8));
	    Console.WriteLine(BinarySearchRec(first, 7, 8));
	
	    Console.WriteLine(LinearSearchUnsorted(first, 7, 25));
	    Console.WriteLine(LinearSearchSorted(first, 7, 25));
	    Console.WriteLine(BinarySearch(first, 7, 25));
	    Console.WriteLine(BinarySearchRec(first, 7, 25));
*/
	for (int i = 0;i < 32;i++)
	{
		Console.WriteLine(i + " : " + FibonacciSearch(first, 7, i));
	}
	}
	/*
	false
	false
	false
	false
	
	true
	true
	true
	true
	*/

	public static void Swap(int[] arr, int first, int second)
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

	public static int FirstRepeated2(int[] arr, int size)
	{
		Dictionary<int, int> hm = new Dictionary<int, int>();

		for (int i = 0; i < size; i++)
		{
			if (hm.ContainsKey(arr[i]))
			{
				hm[arr[i]] = 2;
			}
			else
			{
				hm[arr[i]] = 1;
			}
		}

		for (int i = 0; i < size; i++)
		{
			if (hm[arr[i]] == 2)
			{
				return arr[i];
			}
		}
		return 0;
	}


	public static void Main2()
	{
		int[] first = new int[] {1, 3, 5, 3, 9, 1, 30};
		Console.WriteLine(FirstRepeated(first, first.Length));
		Console.WriteLine(FirstRepeated2(first, first.Length));

	}
	/*
	1
	*/

	public static void PrintRepeating(int[] arr, int size)
	{
		Console.Write("Repeating elements are ");
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
		Console.WriteLine();
	}

	public static void PrintRepeating2(int[] arr, int size)
	{
		Array.Sort(arr);
		Console.Write("Repeating elements are ");

		for (int i = 1; i < size; i++)
		{
			if (arr[i] == arr[i - 1])
			{
				Console.Write(" " + arr[i]);
			}
		}
		Console.WriteLine();
	}

	public static void PrintRepeating3(int[] arr, int size)
	{
		HashSet<int> hs = new HashSet<int>();
		Console.Write("Repeating elements are ");
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
		Console.WriteLine();
	}

	public static void PrintRepeating4(int[] arr, int size, int range)
	{
		int[] count = new int[range];
		int i;
		for (i = 0; i < size; i++)
		{
			count[i] = 0;
		}
		Console.Write("Repeating elements are ");
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
		Console.WriteLine();
	}

	public static void Main3()
	{
		int[] first = new int[] {1, 3, 5, 3, 9, 1, 30};
		PrintRepeating(first, first.Length);
		PrintRepeating2(first, first.Length);
		PrintRepeating3(first, first.Length);
		PrintRepeating4(first, first.Length, 50);
	}
	/*
	Repeating elements are  1 3
	Repeating elements are  1 3
	Repeating elements are  1 3
	Repeating elements are  1 3
	*/

	public static int[] RemoveDuplicates(int[] array, int size)
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
		Array.Copy(array, ret,  j + 1);
		return ret;
	}

	public static int[] RemoveDuplicates2(int[] arr, int size)
	{
		Dictionary<int, int> hm = new Dictionary<int, int>();
		int j = 0;
		for (int i = 0; i < size; i++)
		{
			if (!hm.ContainsKey(arr[i]))
			{
				arr[j] = arr[i];
				j++;
				hm[arr[i]] = 1;
			}
		}
		int[] ret = new int[j];
		Array.Copy(arr, ret, j);
		return ret;
	}

	public static void Main4()
	{
		int[] first = new int[] {1, 3, 5, 3, 9, 1, 30};
		int[] ret = RemoveDuplicates(first, first.Length);
		for (int i = 0; i < ret.Length; i++)
		{
			Console.Write(ret[i] + " ");
		}
		Console.WriteLine();

		int[] first2 = new int[] {1, 3, 5, 3, 9, 1, 30};
		int[] ret2 = RemoveDuplicates2(first2, first2.Length);
		for (int i = 0; i < ret2.Length; i++)
		{
			Console.Write(ret2[i] + " ");
		}
		Console.WriteLine();
	}
	/*
	1 3 5 9 30 
	*/

	public static int FindMissingNumber(int[] arr, int size)
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

	public static int FindMissingNumber2(int[] arr, int size)
	{
		Array.Sort(arr);
		for (int i = 0; i < size; i++)
		{
			if (arr[i] != i + 1)
			{
				return i + 1;
			}
		}
		return size;
	}

	public static int FindMissingNumber3(int[] arr, int size)
	{
		Dictionary<int, int> hm = new Dictionary<int, int>();
		for (int i = 0; i < size; i++)
		{
			hm[arr[i]] = 1;
		}

		for (int i = 1; i <= size; i++)
		{
			if (!hm.ContainsKey(i))
			{
				return i;
			}
		}

		return int.MaxValue;
	}

	public static int FindMissingNumber4(int[] arr, int size)
	{
		int[] count = new int[size+1];
		Array.Fill(count, -1);
		for (int i = 0; i < size; i++)
		{
			count[arr[i] - 1] = 1;
		}

		for (int i = 0; i <= size; i++)
		{
			if (count[i] == -1)
			{
				return i + 1;
			}
		}

		return int.MaxValue;
	}

	public static int FindMissingNumber5(int[] arr, int size)
	{
		int sum = 0;
		// Element value range is from 1 to size+1.
		for (int i = 1; i < (size+2); i++)
		{
			sum += i;
		}
		for (int i = 0; i < size; i++)
		{
			sum -= arr[i];
		}
		return sum;
	}

	public static int FindMissingNumber6(int[] arr, int size)
	{
		for (int i = 0; i < size; i++)
		{
			// len(arr)+1 value should be ignored.
			if(arr[i] != size+1 && arr[i] != size*3 +1)
			{
				// 1 should not become (len(arr)+1) so multiplied by 2
				arr[(arr[i]-1) % size] += (size*2);
			}
		}

		for (int i = 0; i < size; i++)
		{
			if (arr[i] < (size*2))
			{
				return i + 1;
			}
		}
		return int.MaxValue;
	}

	public static int FindMissingNumber7(int[] arr, int size)
	{
		int i;
		int xorSum = 0;
		// Element value range is from 1 to size+1.
		for (i = 1; i < (size+2); i++)
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

	public static int FindMissingNumber8(int[] arr, int size)
	{
		HashSet<int> st = new HashSet<int>();
		int i = 0;
		while (i < size)
		{
			st.Add(arr[i]);
			i += 1;
		}
		i = 1;
		while (i <= size)
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

	public static void Main5()
	{
		int[] first = new int[] {1, 5, 4, 3, 2, 7, 8, 9};
		Console.WriteLine(FindMissingNumber(first, first.Length));
		Console.WriteLine(FindMissingNumber2(first, first.Length));
		Console.WriteLine(FindMissingNumber3(first, first.Length));
		Console.WriteLine(FindMissingNumber4(first, first.Length));
		Console.WriteLine(FindMissingNumber5(first, first.Length));
		Console.WriteLine(FindMissingNumber7(first, first.Length));
		Console.WriteLine(FindMissingNumber8(first, first.Length));
		int[] second = new int[] {1, 5, 4, 3, 2, 7, 8, 9};
		Console.WriteLine(FindMissingNumber6(second, second.Length));

	}
	/*
	6
	6
	6
	*/


	public static void MissingValues(int[] arr, int size)
	{
		int max = arr[0];
		int min = arr[0];
		for (int i = 1; i < size; i++)
		{
			if (max < arr[i])
			{
				max = arr[i];
			}

			if (min > arr[i])
			{
				min = arr[i];
			}
		}
		bool found;
		for (int i = min + 1; i < max; i++)
		{
			found = false;
			for (int j = 0;j < size; j++)
			{
				if (arr[j] == i)
				{
					found = true;
					break;
				}
			}
			if (!found)
			{
				Console.Write(i + " ");
			}
		}
		Console.WriteLine();
	}

		public static void MissingValues2(int[] arr, int size)
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
				Console.Write(value + " ");
				value += 1;
			}
		}
		Console.WriteLine();
	}

	public static void MissingValues3(int[] arr, int size)
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
				Console.Write(i + " ");
			}
		}
		Console.WriteLine();
	}

	public static void Main6()
	{
		int[] arr = new int[] {11, 14, 13, 17, 21, 18, 19, 23, 24};
		int size = arr.Length;
		MissingValues(arr, size);
		MissingValues2(arr, size);
		MissingValues3(arr, size);

	}
	/*
	12 15 16 20 22 
	12 15 16 20 22 
	*/

	public static void OddCount(int[] arr, int size)
	{
		int xorSum = 0;
		for (int i = 0; i < size; i++)
		{
			xorSum ^= arr[i];
		}
		Console.WriteLine("Odd values: " + xorSum);
	}

	public static void OddCount2(int[] arr, int size)
	{
		Dictionary<int, int> hm = new Dictionary<int, int>();
		for (int i = 0; i < size; i++)
		{
			if (hm.ContainsKey(arr[i]))
			{
				hm.Remove(arr[i]);
			}
			else
			{
				hm[arr[i]] = 1;
			}
		}
		Console.Write("Odd values: ");
		foreach (int? key in hm.Keys)
		{
			Console.Write(key + " ");
		}
		Console.WriteLine();

		Console.WriteLine("Odd count is :: " + hm.Count);
	}

	public static void OddCount3(int[] arr, int size)
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
		Console.WriteLine("Odd values: " + first + " " + second);
	}

	public static void Main7()
	{
		int[] arr = new int[] {10, 25, 30, 10, 15, 25, 15};
		int size = arr.Length;
		OddCount(arr, size);
		OddCount2(arr, size);
		int[] arr2 = new int[] {10, 25, 30, 10, 15, 25, 15, 40};
		int size2 = arr2.Length;
		OddCount3(arr2, size2);
	}
	/*
	30 40 
	Odd count is :: 2
	30 40
	*/

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
		Console.WriteLine("sum : " + sum);
	}

	public static void Main8()
	{
		int[] arr = new int[] {1, 2, 3, 1, 1, 4, 5, 6};
		int size = arr.Length;
		SumDistinct(arr, size);
	}
	/*
	sum : 21
	*/

		public static void MinAbsSumPair(int[] arr, int size)
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
		Console.WriteLine("Minimum sum elements are : " + arr[minFirst] + " , " + arr[minSecond]);
	}

	public static void MinAbsSumPair2(int[] arr, int size)
	{
		int l, r, minSum, sum, minFirst, minSecond;
		// Array should have at least two elements
		if (size < 2)
		{
			Console.WriteLine("Invalid Input");
			return;
		}
		Array.Sort(arr);

		// Initialization of values
		minFirst = 0;
		minSecond = size - 1;
		minSum = Math.Abs(arr[minFirst] + arr[minSecond]);
		for (l = 0, r = size - 1; l < r;)
		{
			sum = (arr[l] + arr[r]);
			if (Math.Abs(sum) < minSum)
			{
				minSum = Math.Abs(sum);
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
		Console.WriteLine("Minimum sum elements are : " + arr[minFirst] + " , " + arr[minSecond]);
	}

	public static void Main9()
	{
		int[] first = new int[] {1, 5, -10, 3, 2, -6, 8, 9, 6};
		MinAbsSumPair2(first, first.Length);
		MinAbsSumPair(first, first.Length);

	}
	/*
	Minimum sum elements are : -6 , 6
	Minimum sum elements are : -6 , 6
	*/

	public static bool FindPair(int[] arr, int size, int value)
	{
		for (int i = 0; i < size; i++)
		{
			for (int j = i + 1; j < size; j++)
			{
				if ((arr[i] + arr[j]) == value)
				{
					Console.WriteLine("The pair is : " + arr[i] + ", " + arr[j]);
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
		Array.Sort(arr);
		while (first < second)
		{
			curr = arr[first] + arr[second];
			if (curr == value)
			{
				Console.WriteLine("The pair is " + arr[first] + ", " + arr[second]);
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
				Console.WriteLine("The pair is : " + arr[i] + ", " + (value - arr[i]));
				return true;
			}
			hs.Add(arr[i]);
		}
		return false;
	}

public static bool FindPair4(int[] arr, int size, int range, int value)
{
	int[] count = new int[range+1];
	Array.Fill(count, 0);
	for (int i = 0; i < size; i++)
	{
		if (count[value - arr[i]] > 0)
		{
			Console.WriteLine("The pair is : " + arr[i] + ", " + (value - arr[i]));
			return true;
		}
		count[arr[i]] += 1;
	}
	return false;
}

	public static void Main10()
	{
		int[] first = new int[] {1, 5, 4, 3, 2, 7, 8, 9, 6};
		Console.WriteLine(FindPair(first, first.Length, 8));
		Console.WriteLine(FindPair2(first, first.Length, 8));
		Console.WriteLine(FindPair3(first, first.Length, 8));
		Console.WriteLine(FindPair4(first, first.Length, 9, 8));
	}
	/*
	The pair is : 1, 7
	true
	The pair is 1, 7
	true
	The pair is : 5, 3
	true
	The pair is : 5, 3
	true
	*/


	public static bool FindPairTwoLists(int[] arr1, int size1, int[] arr2, int size2, int value)
	{
		for (int i = 0; i < size1; i++)
		{
			for (int j = 0; j < size2; j++)
			{
				if ((arr1[i] + arr2[j]) == value)
				{
					Console.WriteLine("The pair is : " + arr1[i] + ", " + arr2[j]);
					return true;
				}
			}
		}
		return false;
	}

		public static bool FindPairTwoLists2(int[] arr1, int size1, int[] arr2, int size2, int value)
	{
		Array.Sort(arr2);
		for (int i = 0; i < size1; i++)
		{
			if (BinarySearch(arr2, size2, value - arr1[i]))
			{
				Console.WriteLine("The pair is " + arr1[i] + ", " + (value - arr1[i]));
				return true;
			}
		}
		return false;
	}

	public static bool FindPairTwoLists3(int[] arr1, int size1, int[] arr2, int size2, int value)
	{
		int first = 0, second = size2 - 1, curr = 0;
		Array.Sort(arr1);
		Array.Sort(arr2);
		while (first < size1 && second >= 0)
		{
			curr = arr1[first] + arr2[second];
			if (curr == value)
			{
				Console.WriteLine("The pair is " + arr1[first] + ", " + arr2[second]);
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


	public static bool FindPairTwoLists4(int[] arr1, int size1, int[] arr2, int size2, int value)
	{
		HashSet<int> hs = new HashSet<int>();
		for (int i = 0; i < size2; i++)
		{
			hs.Add(arr2[i]);
		}

		for (int i = 0; i < size1; i++)
		{
			if (hs.Contains(value - arr1[i]))
			{
				Console.WriteLine("The pair is : " + arr1[i] + ", " + (value - arr1[i]));
				return true;
			}
		}
		return false;
	}

	public static bool FindPairTwoLists5(int[] arr1, int size1, int[] arr2, int size2, int range, int value)
	{
		int[] count = new int[range+1];
		Array.Fill(count, 0);

		for (int i = 0; i < size2; i++)
		{
			count[arr2[i]] = 1;
		}

		for (int i = 0; i < size1; i++)
		{
			if (count[value - arr1[i]] != 0)
			{
				Console.WriteLine("The pair is : " + arr1[i] + ", " + (value - arr1[i]));
				return true;
			}
		}
		return false;
	}

	public static void Main10A()
	{
		int[] first = new int[] {1, 5, 4, 3, 2, 7, 8, 9, 6};
		int[] second = new int[] {1, 5, 4, 3, 2, 7, 8, 9, 6};
		Console.WriteLine(FindPairTwoLists(first, first.Length, second, second.Length, 8));
		Console.WriteLine(FindPairTwoLists2(first, first.Length, second, second.Length, 8));
		Console.WriteLine(FindPairTwoLists3(first, first.Length, second, second.Length, 8));
		Console.WriteLine(FindPairTwoLists4(first, first.Length, second, second.Length, 8));
		Console.WriteLine(FindPairTwoLists5(first, first.Length, second, second.Length, 9, 8));
	}

/*
The pair is : 1, 7
true
The pair is 1, 7
true
The pair is 1, 7
true
The pair is : 1, 7
true
The pair is : 1, 7
true    */



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
	public static void Main11()
	{
		int[] first = new int[] {1, 5, 4, 3, 2, 7, 8, 9, 6};
		Console.WriteLine(FindDifference(first, first.Length, 6));
		Console.WriteLine(FindDifference2(first, first.Length, 6));
	}
	/*
	The pair is:: 1 & 7
	true
	The pair is::1 & 7
	true
	*/

	public static int FindMinDiff(int[] arr, int size)
	{
		int diff = int.MaxValue;
		for (int i = 0; i < size; i++)
		{
			for (int j = i + 1; j < size; j++)
			{
				int value = Math.Abs(arr[i] - arr[j]);
				if (diff > value)
				{
					diff = value;
				}
			}
		}
		return diff;
	}

	public static int FindMinDiff2(int[] arr, int size)
	{
		Array.Sort(arr);
		int diff = int.MaxValue;

		for (int i = 0; i < (size - 1); i++)
		{
			if ((arr[i + 1] - arr[i]) < diff)
			{
				diff = arr[i + 1] - arr[i];
			}
		}
		return diff;
	}

	public static void Main12()
	{
		int[] second = new int[] {1, 6, 4, 19, 17, 20};
		Console.WriteLine("FindMinDiff : " + FindMinDiff(second, second.Length));
		Console.WriteLine("FindMinDiff : " + FindMinDiff2(second, second.Length));
	}
	/*
	FindMinDiff : 1
	*/

	public static int MinDiffPair(int[] arr1, int size1, int[] arr2, int size2)
	{
		int diff = int.MaxValue;
		int first = 0;
		int second = 0;
		for (int i = 0; i < size1; i++)
		{
			for (int j = 0; j < size2; j++)
			{
				int value = Math.Abs(arr1[i] - arr2[j]);
				if (diff > value)
				{
					diff = value;
					first = arr1[i];
					second = arr2[j];
				}
			}
		}
		Console.WriteLine("The pair is :: " + first + " & " + second);
		Console.WriteLine("Minimum difference is :: " + diff);
		return diff;
	}


	public static int MinDiffPair2(int[] arr1, int size1, int[] arr2, int size2)
	{
		int minDiff = int.MaxValue;
		int i = 0;
		int j = 0;
		int first = 0, second = 0, diff;
		Array.Sort(arr1);
		Array.Sort(arr2);
		while (i < size1 && j < size2)
		{
			diff = Math.Abs(arr1[i] - arr2[j]);
			if (minDiff > diff)
			{
				minDiff = diff;
				first = arr1[i];
				second = arr2[j];
			}
			if (arr1[i] < arr2[j])
			{
				i += 1;
			}
			else
			{
				j += 1;
			}
		}
		Console.WriteLine("The pair is :: " + first + " & " + second);
		Console.WriteLine("Minimum difference is :: " + minDiff);
		return minDiff;
	}

	public static void Main13()
	{
		int[] first = new int[] {1, 5, 4, 3, 2, 7, 8, 9, 6};
		int[] second = new int[] {6, 4, 19, 17, 20};
		MinDiffPair(first, first.Length, second, second.Length);
		MinDiffPair(first, first.Length, second, second.Length);

	}
	/*
	The pair is :: 4 4
	Minimum difference is :: 0
	*/

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
		Console.WriteLine("closest pair is :: " + first + " " + second);
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
		Console.WriteLine("closest pair is :: " + first + " " + second);
	}

	public static void Main14()
	{
		int[] first = new int[] {10, 20, 3, 4, 50, 80};
		ClosestPair(first, first.Length, 47);
		ClosestPair2(first, first.Length, 47);
	}
	/*
	closest pair is :: 3 50
	closest pair is :: 3 50
	*/

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
				Console.WriteLine("Pair is :: " + arr[low] + " " + arr[high]);
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

		public static void Main15()
	{
		int[] first = new int[] {1, 2, 4, 8, 16, 15};
		Console.WriteLine(SumPairRestArray(first, first.Length));
	}
	/*
	Pair is :: 8 15
	true
	*/

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
						Console.WriteLine("Triplet:: " + arr[i] + " " + arr[j] + " " + arr[k]);
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
					Console.WriteLine("Triplet :: " + arr[i] + " " + arr[start] + " " + arr[stop]);
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

	public static void Main16()
	{
		int[] first = new int[] {0, -1, 2, -3, 1};
		ZeroSumTriplets(first, first.Length);
		ZeroSumTriplets2(first, first.Length);
	}
	/*
	Triplet:: 0 -1 1
	Triplet:: 2 -3 1
	Triplet :: -3 1 2
	Triplet :: -1 0 1
	*/

	public static void FindTriplet(int[] arr, int size, int value)
	{
		for (int i = 0; i < (size - 2); i++)
		{
			for (int j = i + 1; j < (size - 1); j++)
			{
				for (int k = j + 1; k < size; k++)
				{
					if ((arr[i] + arr[j] + arr[k]) == value)
					{
						Console.WriteLine("Triplet :: " + arr[i] + " " + arr[j] + " " + arr[k]);
					}
				}
			}
		}
	}

	public static void FindTriplet2(int[] arr, int size, int value)
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
					Console.WriteLine("Triplet ::" + arr[i] + " " + arr[start] + " " + arr[stop]);
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

	public static void Main17()
	{
		int[] first = new int[] {1, 5, 15, 6, 9, 8};
		FindTriplet(first, first.Length, 22);
		FindTriplet2(first, first.Length, 22);
	}
	/*
	Triplet :: 1 15 6
	Triplet :: 5 9 8
	Triplet ::1 6 15
	Triplet ::5 8 9
	*/


	public static void AbcTriplet(int[] arr, int size)
	{
		for (int i = 0; i < size-1; i++)
		{
		for (int j = i + 1; j < size; j++)
		{
			for (int k = 0; k < size; k++)
			{
				if (k != i && k != j && arr[i] + arr[j] == arr[k])
				{
					Console.WriteLine("AbcTriplet:: " + arr[i] + " " + arr[j] + " " + arr[k]);
				}
			}
		}
		}
	}

	public static void AbcTriplet2(int[] arr, int size)
	{
		int start, stop;
		Array.Sort(arr);
		for (int i = 0; i < size; i++)
		{
			start = 0;
			stop = size - 1;
			while (start < stop)
			{
				if (arr[i] == arr[start] + arr[stop])
				{
					Console.WriteLine("AbcTriplet:: " + arr[start] + " " + arr[stop] + " " + arr[i]);
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

	public static void Main18()
	{
		int[] first = new int[] {1, 5, 15, 6, 9, 8};
		AbcTriplet(first, first.Length);
		AbcTriplet2(first, first.Length);
	}

	/*
	AbcTriplet:: 1 5 6
	AbcTriplet:: 1 8 9
	AbcTriplet:: 6 9 15
	*/

	public static void SmallerThenTripletCount(int[] arr, int size, int value)
	{
		int count = 0;
		for (int i = 0; i < size-1; i++)
		{
		for (int j = i + 1; j < size; j++)
		{
		for (int k = j + 1; k < size; k++)
		{
			if (arr[i] + arr[j] + arr[k] < value)
			{
				count += 1;
			}
		}
		}
		}
		Console.WriteLine("SmallerThenTripletCount:: " + count);
	}

	public static void SmallerThenTripletCount2(int[] arr, int size, int value)
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
		Console.WriteLine("SmallerThenTripletCount:: " + count);
	}

	public static void Main19()
	{
		int[] first = new int[] {-2, -1, 0, 1};
		SmallerThenTripletCount(first, first.Length, 2);
		SmallerThenTripletCount(first, first.Length, 2);
	}
	/*
	4
	4
	*/

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
					Console.WriteLine("AP Triplet:: " + arr[j] + " " + arr[i] + " " + arr[k]);
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

	public static void Main20()
	{
		int[] arr = new int[] {2, 4, 10, 12, 14, 18, 36};
		APTriplets(arr, arr.Length);
	}
	/*
	AP Triplet:: 2 10 18
	AP Triplet:: 10 12 14
	AP Triplet:: 10 14 18
	*/

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
					Console.WriteLine("GP Triplet:: " + arr[j] + " " + arr[i] + " " + arr[k]);
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

	public static void Main21()
	{
		int[] arr = new int[] {1, 2, 4, 8, 16};
		GPTriplets(arr, arr.Length);
	}
	/*
	GP Triplet:: 1 2 4
	GP Triplet:: 2 4 8
	GP Triplet:: 1 4 16
	GP Triplet:: 4 8 16
	*/

	public static int NumberOfTriangles(int[] arr, int size)
	{
		int i, j, k, count = 0;
		for (i = 0; i < (size - 2); i++)
		{
			for (j = i + 1; j < (size - 1); j++)
			{
				for (k = j + 1; k < size; k++)
				{
					if (arr[i] + arr[j] > arr[k])
					{
						count += 1;
					}
				}
			}
		}
		return count;
	}

	public static int NumberOfTriangles2(int[] arr, int size)
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

	public static void Main22()
	{
		int[] arr = new int[] {1, 2, 3, 4, 5};
		Console.WriteLine(NumberOfTriangles(arr, arr.Length));
		Console.WriteLine(NumberOfTriangles2(arr, arr.Length));
	}
	/*
	3
	3
	*/

	public static int GetMax(int[] arr, int size)
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

	public static int GetMax2(int[] arr, int size)
	{
		int max = arr[0], maxCount = 1;
		int curr = arr[0], currCount = 1;
		Array.Sort(arr); // Sort(arr,size);
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

	public static int GetMax3(int[] arr, int size, int range)
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

	public static void Main23()
	{
		int[] first = new int[] {1, 30, 5, 13, 9, 31, 5};
		Console.WriteLine(GetMax(first, first.Length));
		Console.WriteLine(GetMax2(first, first.Length));
		Console.WriteLine(GetMax3(first, first.Length, 50));
	}
	/*
	5
	5
	5
	*/

	public static int GetMajority(int[] arr, int size)
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

	public static int GetMajority2(int[] arr, int size)
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

	public static int GetMajority3(int[] arr, int size)
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

	public static void Main24()
	{
		int[] first = new int[] {1, 5, 5, 13, 5, 31, 5};
		Console.WriteLine(GetMajority(first, first.Length));
		Console.WriteLine(GetMajority2(first, first.Length));
		Console.WriteLine(GetMajority3(first, first.Length));
	}
	/*
	5
	5
	5
	*/



	public static int GetMedian(int[] arr, int size)
	{
		Array.Sort(arr);
		return arr[size / 2];
	}

	public static int GetMedian2(int[] arr, int size)
	{
		QuickSelectUtil(arr, 0, size - 1, size / 2);
		return arr[size / 2];
	}

	public static void Main25()
	{
		int[] first = new int[] {1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30};
		Console.WriteLine(GetMedian(first, first.Length));
		Console.WriteLine(GetMedian(first, first.Length));
	}
	/*
	6
	*/


	public static int SearchBitonicArrayMax(int[] arr, int size)
	{
		for (int i = 0; i < size-2; i++)
		{
			if (arr[i] > arr[i + 1])
			{
				return arr[i];
			}
		}
		Console.WriteLine("error not a bitonic array");
		return 0;
	}


	public static int SearchBitonicArrayMax2(int[] arr, int size)
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
			Console.WriteLine("error not a bitonic array");
			return 0;
		}
		return arr[mid];
	}

	public static int SearchBitonicArray(int[] arr, int size, int key)
	{
		int max = findMaxBitonicArray(arr, size);
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

	public static int findMaxBitonicArray(int[] arr, int size)
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

	public static void Main26()
	{
		int[] first = new int[] {1, 5, 10, 13, 20, 30, 8, 7, 6};
		Console.WriteLine(SearchBitonicArrayMax(first, first.Length));
		Console.WriteLine(SearchBitonicArrayMax2(first, first.Length));
		Console.WriteLine(SearchBitonicArray(first, first.Length, 7));
	}
	/*
	30
	7
	*/

	public static int FindKeyCount(int[] arr, int size, int key)
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

	public static int FindFirstIndex(int[] arr, int start, int end, int key)
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
		if (key <= arr[mid])
		{
			return FindFirstIndex(arr, start, mid - 1, key);
		}
		else
		{
			return FindFirstIndex(arr, mid + 1, end, key);
		}
	}

	public static int FindLastIndex(int[] arr, int start, int end, int key)
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
		if (key < arr[mid])
		{
			return FindLastIndex(arr, start, mid - 1, key);
		}
		else
		{
			return FindLastIndex(arr, mid + 1, end, key);
		}
	}

	public static int FindKeyCount2(int[] arr, int size, int key)
	{
		int FirstIndex, lastIndex;
		FirstIndex = FindFirstIndex(arr, 0, size - 1, key);
		lastIndex = FindLastIndex(arr, 0, size - 1, key);
		return (lastIndex - FirstIndex + 1);
	}

	public static void Main27()
	{
		int[] first = new int[] {1, 5, 10, 13, 20, 30, 8, 7, 6};
		Console.WriteLine(FindKeyCount(first, first.Length, 6));
		Console.WriteLine(FindKeyCount2(first, first.Length, 6));
	}
	/*
	1
	1
	*/

	/* Using Binary search method. */
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


	public static bool IsMajority2(int[] arr, int size)
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


	public static bool IsMajority(int[] arr, int size)
	{
		int count = 0;
		int mid = arr[size / 2];
		for (int i = 0;i < size;i++)
		{
			if (arr[i] == mid)
			{
				count += 1;
			}
		}

		if (count > size / 2)
		{
			return true;
		}
		return false;
	}

	public static void Main28()
	{
		int[] arr = new int[] {3, 3, 3, 3, 4, 5, 10};
		Console.WriteLine(IsMajority(arr, arr.Length));
		Console.WriteLine(IsMajority2(arr, arr.Length));
	}
	/*
	true
	*/
	public static int MaxProfit(int[] stocks, int size)
	{
		int maxProfit = 0;
		int buy = 0, sell = 0;

		for (int i = 0;i < size-1;i++)
		{
			for (int j = i + 1;j < size ;j++)
			{
				if (maxProfit < stocks[j] - stocks[i])
				{
					maxProfit = stocks[j] - stocks[i];
					buy = i;
					sell = j;
				}
			}
		}
		Console.WriteLine("Purchase day is " + buy + " at price " + stocks[buy]);
		Console.WriteLine("Sell day is " + sell + " at price " + stocks[sell]);
		return maxProfit;
	}

	public static int MaxProfit2(int[] stocks, int size)
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
		Console.WriteLine("Purchase day is " + buy + " at price " + stocks[buy]);
		Console.WriteLine("Sell day is " + sell + " at price " + stocks[sell]);
		return maxProfit;
	}

	public static void Main29()
	{
		int[] first = new int[] {10, 150, 6, 67, 61, 16, 86, 6, 67, 78, 150, 3, 28, 143};
		Console.WriteLine(MaxProfit(first, first.Length));
		Console.WriteLine(MaxProfit2(first, first.Length));

	}
	/*
	Purchase day is- 2 at price 6
	Sell day is- 10 at price 150
	144
	*/

	public static int FindMedian(int[] arrFirst, int sizeFirst, int[] arrSecond, int sizeSecond)
	{
		int medianIndex = ((sizeFirst + sizeSecond) + (sizeFirst + sizeSecond) % 2) / 2; // ceiling
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

	public static void Main30()
	{
		int[] first = new int[] {1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30};
		int[] second = new int[] {1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30};
		Console.WriteLine(FindMedian(first, first.Length, second, second.Length));
	}
	/*
	6
	*/



	public static int Search01(int[] arr, int size)
	{
		for (int i = 0;i < size;i++)
		{
			if (arr[i] == 1)
			{
				return i;
			}
		}
		return -1;
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

	public static void Main31()
	{
		int[] first = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1};
		Console.WriteLine(Search01(first, first.Length));
		Console.WriteLine(BinarySearch01(first, first.Length));

	}
	/*
	8
	*/

	public static int RotationMax(int[] arr, int size)
	{
		for (int i = 0;i < size-1;i++)
		{
			if (arr[i] > arr[i + 1])
			{
				return arr[i];
			}
		}
		return -1;
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

	public static int RotationMax2(int[] arr, int size)
	{
		return RotationMaxUtil(arr, 0, size - 1);
	}

	public static void Main32()
	{
		int[] first = new int[] {34, 56, 77, 1, 5, 6, 6, 8, 10, 20, 30, 34};
		Console.WriteLine(RotationMax(first, first.Length));
		Console.WriteLine(RotationMax2(first, first.Length));
	}
	/*
	77
	*/   

	public static int FindRotationMax(int[] arr, int size)
	{
		for (int i = 0;i < size-1;i++)
		{
			if (arr[i] > arr[i + 1])
			{
				return i;
			}
		}
		return -1;
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

	public static int FindRotationMax2(int[] arr, int size)
	{
		return FindRotationMaxUtil(arr, 0, size - 1);
	}

	public static void Main33()
	{
		int[] first = new int[] {34, 56, 77, 1, 5, 6, 6, 8, 10, 20, 30, 34};
		Console.WriteLine(FindRotationMax(first, first.Length));
		Console.WriteLine(FindRotationMax2(first, first.Length));
	}
	/*
	2
	*/

	public static int CountRotation(int[] arr, int size)
	{
		int maxIndex = FindRotationMaxUtil(arr, 0, size - 1);
		return (maxIndex + 1) % size;
	}
	public static void Main34()
	{
		int[] first = new int[] {34, 56, 77, 1, 5, 6, 6, 8, 10, 20, 30, 34};
		Console.WriteLine(CountRotation(first, first.Length));
	}
	/*
	3
	*/

	public static int SearchRotateArray(int[] arr, int size, int key)
	{
		for (int i = 0;i < size-1;i++)
		{
			if (arr[i] == key)
			{
				return i;
			}
		}
		return -1;
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

	public static void Main35()
	{
		int[] first = new int[] {34, 56, 77, 1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30};
		Console.WriteLine(SearchRotateArray(first, first.Length, 20));
		Console.WriteLine(BinarySearchRotateArray(first, first.Length, 20));
		Console.WriteLine(CountRotation(first, first.Length));
		Console.WriteLine(first[FindRotationMax(first, first.Length)]);
	}
	/*
	15
	3
	77
	*/

	public static int MinAbsDiffAdjCircular(int[] arr, int size)
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

	// Testing Code
	public static void Main36()
	{
		int[] arr = new int[] {5, 29, 18, 51, 11};
		Console.WriteLine(MinAbsDiffAdjCircular(arr, arr.Length));
	}
	/*
	6
	*/

	public static void Swapch(char[] arr, int first, int second)
	{
		char temp = arr[first];
		arr[first] = arr[second];
		arr[second] = temp;
	}

	public static void TransformArrayAB1(char[] arr, int size)
	{
		int N = size / 2, i, j;
		for (i = 1; i < N; i++)
		{
			for (j = 0; j < i; j++)
			{
				Swapch(arr, N - i + 2 * j, N - i + 2 * j + 1);
			}
		}
	}
	public static void Main37()
	{
		char[] str = "aaaabbbb".ToCharArray();
		TransformArrayAB1(str, str.Length);
		Console.WriteLine(str);
	}
	/*
	abababab
	*/

	public static bool CheckPermutation(char[] array1, int size1, char[] array2, int size2)
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

	public static bool CheckPermutation2(char[] arr1, int size1, char[] arr2, int size2)
	{
		if (size1 != size2)
		{
			return false;
		}

		Dictionary<char, int> hm = new Dictionary<char, int>();
		for (int i = 0; i < size1; i++)
		{
			if (hm.ContainsKey(arr1[i]))
			{
				hm[arr1[i]] = hm[arr1[i]] + 1;
			}
			else
			{
				hm[arr1[i]] = 1;
			}
		}
		for (int i = 0; i < size2; i++)
		{
			if (hm.ContainsKey(arr2[i]) && hm[arr2[i]] != 0)
			{
				hm[arr2[i]] = hm[arr2[i]] - 1;
			}
			else
			{
				return false;
			}
		}
		return true;
	}


	public static bool CheckPermutation3(char[] array1, int size1, char[] array2, int size2)
	{
		if (size1 != size2)
		{
			return false;
		}
		int[] count = new int[256];
		for (int i = 0; i < size1; i++)
		{
			count[array1[i]]++;
			count[array2[i]]--;
		}

		for (int i = 0; i < size1; i++)
		{
			if (count[i] != 0)
			{
				Console.WriteLine("Not Permutation");
				return false;
			}
		}
		Console.WriteLine("Permutation.");
		return true;
	}

	public static void Main38()
	{
		char[] str1 = "aaaabbbb".ToCharArray();
		char[] str2 = "bbaaaabb".ToCharArray();
		Console.WriteLine(CheckPermutation(str1, str1.Length, str2, str2.Length));
		Console.WriteLine(CheckPermutation2(str1, str1.Length, str2, str2.Length));
		Console.WriteLine(CheckPermutation3(str1, str1.Length, str2, str2.Length));

	}
	/*
	true
	*/

	public static bool FindElementIn2DArray(int[, ] arr, int r, int c, int value)
	{
		int row = 0;
		int column = c - 1;
		while (row < r && column >= 0)
		{
			if (arr[row, column] == value)
			{
				return true;
			}
			else if (arr[row, column] > value)
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

	public static bool IsAP(int[] arr, int size)
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

	public static bool IsAP2(int[] arr, int size)
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



	public static bool IsAP3(int[] arr, int size)
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
			if (index > size - 1 || count[index] != 0)
			{
				return false;
			}
			count[index] = 1;
		}

		for (int i = 0; i < size; i++)
		{
			if (count[i] != 1)
			{
				return false;
			}
		}
		return true;
	}

	public static void Main39()
	{
		int[] arr = new int[] {20, 25, 15, 5, 0, 10, 35, 30};
		Console.WriteLine(IsAP(arr, arr.Length));
		Console.WriteLine(IsAP2(arr, arr.Length));
		Console.WriteLine(IsAP3(arr, arr.Length));

	}
	/*
	true
	true
	true
	*/

	public static int FindBalancedPoint(int[] arr, int size)
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

	// Testing Code
	public static void Main40()
	{
		int[] arr = new int[] {-7, 1, 5, 2, -4, 3, 0};
		Console.WriteLine(FindBalancedPoint(arr, arr.Length));

	}
	/*
	3
	*/

	public static int FindFloor(int[] arr, int size, int value)
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
				return arr[mid];
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

	public static int FindCeil(int[] arr, int size, int value)
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
				return arr[mid];
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

	public static void Main41()
	{
		int[] arr = new int[] {2, 4, 8, 16};
		Console.WriteLine(FindFloor(arr, arr.Length, 5));
		Console.WriteLine(FindCeil(arr, arr.Length, 5));
	}
	/*
	1
	2
	*/

	public static int ClosestNumber(int[] arr, int size, int num)
	{
		int start = 0;
		int stop = size - 1;
		int output = -1;
		int minDist = int.MaxValue;
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

	public static void Main42()
	{
		int[] arr = new int[] {2, 4, 8, 16};
		Console.WriteLine(ClosestNumber(arr, arr.Length, 9));
	}
	/*
	8
	*/

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

	// Testing Code
	public static void Main43()
	{
		int[] arr = new int[] {1, 2, 3, 1, 4, 5};
		DuplicateKDistance(arr, arr.Length, 3);
	}
	/*
	Value:1 Index: 0 & 3
	*/
	public static void FrequencyCounts(int[] arr, int size)
	{
		Dictionary<int, int> hm = new Dictionary<int, int>();
		for (int i = 0; i < size; i++)
		{
			if (hm.ContainsKey(arr[i]))
			{
				hm[arr[i]] = hm[arr[i]] + 1;
			}
			else
			{
				hm[arr[i]] = 1;
			}
		}
		foreach (int key in hm.Keys)
		{
			Console.Write("(" + key + " : " + hm[key] + ") ");
		}
		Console.WriteLine();
	}

	public static void FrequencyCounts2(int[] arr, int size)
	{
		Array.Sort(arr);
		int count = 1;
		for (int i = 1; i < size; i++)
		{
			if (arr[i] == arr[i - 1])
			{
				count++;
			}
			else
			{
				Console.Write("(" + arr[i - 1] + " : " + count + ") ");
				count = 1;
			}
		}
		Console.Write("(" + arr[size-1] + " : " + count + ") ");
		Console.WriteLine();
	}

	public static void FrequencyCounts3(int[] arr, int size)
	{
		int[] aux = new int[size+1];
		for (int i = 0; i < size; i++)
		{
			aux[arr[i]] += 1;
		}
		for (int i = 0; i < size+1; i++)
		{
			if (aux[i] > 0)
			{
				Console.Write("(" + i + " : " + aux[i] + ") ");
			}
		}
		Console.WriteLine();
	}

	public static void FrequencyCounts4(int[] arr, int size)
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
			if (arr[i] != 0)
			{
				Console.Write("(" + (i + 1) + " : " + Math.Abs(arr[i]) + ") ");
			}
		}
		Console.WriteLine();
	}

	public static void Main44()
	{
		int[] arr = new int[] {1, 2, 2, 2, 1};
		FrequencyCounts(arr, arr.Length);
		FrequencyCounts2(arr, arr.Length);
		FrequencyCounts3(arr, arr.Length);
		FrequencyCounts4(arr, arr.Length);
	}
/*
(1 : 2) (2 : 3) 
(1 : 2) (2 : 3) 
(1 : 2) (2 : 3) 
(1 : 2) (2 : 3)    
*/

	public static void KLargestElements(int[] arrIn, int size, int k)
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
				Console.Write(arrIn[i] + " ");
			}
		}
		Console.WriteLine();
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
			while (arr[lower] <= pivot && lower < upper)
			{
				lower++;
			}
			while (arr[upper] > pivot && lower <= upper)
			{
				upper--;
			}
			if (lower < upper)
			{
				Swap(arr, upper, lower);
			}
		}

		Swap(arr, upper, start); // upper is the pivot position
		if (k < upper)
		{
			QuickSelectUtil(arr, start, upper - 1, k); // pivot -1 is the upper for left sub array.
		}
		if (k > upper)
		{
			QuickSelectUtil(arr, upper + 1, stop, k); // pivot + 1 is the lower for right sub array.
		}
	}

	public static void KLargestElements2(int[] arrIn, int size, int k)
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
				Console.Write(arrIn[i] + " ");
			}
		}
		Console.WriteLine();
	}

	public static void Main45()
	{
		int[] arr = new int[] {10, 50, 30, 60, 15};
		KLargestElements(arr, arr.Length, 2);
		KLargestElements2(arr, arr.Length, 2);
	}

	/*
	50 60 
	50 60 
	*/

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

	public static void Main46()
	{
		int[] arr = new int[] {-10, -2, 0, 3, 11, 12, 35, 51, 200};
		Console.WriteLine(FixPoint(arr, arr.Length));
		Console.WriteLine(FixPoint2(arr, arr.Length));
	}
	/*
	3
	3
	*/

	public static void SubArraySums(int[] arr, int size, int value)
	{
		int start = 0, end = 0, sum = 0;
		while (start < size && end < size)
		{
			if (sum < value)
			{
				sum += arr[end];
				end += 1;
			}
			else
			{
				sum -= arr[start];
				start += 1;
			}

			if (sum == value)
			{
				Console.WriteLine(start + " " + (end - 1));
			}
		}
	}

	public static void Main47()
	{
		int[] arr = new int[] {15, 5, 5, 20, 10, 5, 5, 20, 10, 10};
		SubArraySums(arr, arr.Length, 20);
	}
	/*
	0 1
	3 3
	4 6
	7 7
	8 9
	*/

	public static int MaxConSub(int[] arr, int size)
	{
		int currMax = 0, maximum = 0;
		for (int i = 0; i < size; i++)
		{
			currMax += arr[i];
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
				currMax = currMax + A[i];
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

	public static int MaxConSubArr2(int[] A, int sizeA, int[] B, int sizeB)
	{
		Array.Sort(B);
		int currMax = 0;
		int maximum = 0;

		for (int i = 0; i < sizeA; i++)
		{
			if (BinarySearch(B, sizeB, A[i]))
			{
				currMax = 0;
			}
			else
			{
				currMax = currMax + A[i];
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

	public static void Main48()
	{
		int[] arr = new int[] {1, 2, -3, 4, 5, -10, 6, 7};
		MaxConSub(arr, arr.Length);
		int[] arr2 = new int[] {1, 2, 3, 4, 5, -10, 6, 7, 3};
		int[] arr3 = new int[] {1, 3};
		MaxConSubArr(arr2, arr2.Length, arr3, arr3.Length);
		MaxConSubArr2(arr2, arr2.Length, arr3, arr3.Length);
	}
	/*
	13
	13
	13
	*/

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

	public static void Main49()
	{
		int[] arr = new int[] {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1};
		RainWater(arr, arr.Length);
		RainWater2(arr, arr.Length);
	}
	/*
	Water : 6
	Water : 6
	*/

	public static void SeparateEvenAndOdd(int[] arr, int size)
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
				Swap(arr, left, right);
				left++;
				right--;
			}
		}
	}

	public static void Main50()
	{
		int[] first = new int[] {1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30};
		SeparateEvenAndOdd(first, first.Length);
		foreach (int val in first)
		{
			Console.Write(val + " ");
		}
	}

	/*
	30 20 6 6 6 6 6 6 10 8 7 13 5 1
	*/

	public static void Main(string[] args)
	{
		/*Main1();
		Main2();
		Main3();
		Main4();*/
		Main5();
		/*Main6();
		Main7();
		Main8();
		Main9();
		Main10();
		Main10A();
		Main11();
		Main12();
		Main13();
		Main14();
		Main15();
		Main16();
		Main17();
		Main18();
		Main19();
		Main20();
		Main21();
		Main22();
		Main23();
		Main24();
		Main25();
		Main26();
		Main27();
		Main28();
		Main29();
		Main30();
		Main31();
		Main32();
		Main33();
		Main34();
		Main35();
		Main36();
		Main37();
		Main38();
		Main39();
		Main40();
		Main41();
		Main42();
		Main43();
		Main44();
		Main45();
		Main46();
		Main47();
		Main48();
		Main49();
		Main50();*/
	}
}
