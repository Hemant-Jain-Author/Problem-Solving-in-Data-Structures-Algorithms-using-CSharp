using System;
using System.Collections.Generic;

public class Introduction
{

	public static void PrintArray(int[] arr, int count)
	{
		Console.Write("[");
		for (int i = 0; i < count; i++)
		{
			Console.Write(" " + arr[i]);
		}
		Console.WriteLine(" ]");
	}

	public static void Swap(int[] arr, int x, int y)
	{
		int temp = arr[x];
		arr[x] = arr[y];
		arr[y] = temp;
		return;
	}

	public static int SumArray(int[] arr)
	{
		int size = arr.Length;
		int total = 0;
		for (int index = 0; index < size; index++)
		{
			total = total + arr[index];
		}
		return total;
	}

	/* Testing code */
	public static void Main1()
	{
		int[] arr = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
		Console.WriteLine("Sum of values in array:" + SumArray(arr));
	}
	/*
	Sum of values in array:45
	*/

	public void Function2()
	{
		Console.WriteLine("Fun2 line 1");
	}

	public void Function1()
	{
		Console.WriteLine("Fun1 line 1");
		Function2();
		Console.WriteLine("Fun1 line 2");
	}

	/* Testing code */
	public void Main2()
	{
		Console.WriteLine("Main line 1");
		Function1();
		Console.WriteLine("Main line 2");
	}
	/*
	Main line 1
	Fun1 line 1
	Fun2 line 1
	Fun1 line 2
	Main line 2
	*/
	public static int SequentialSearch(int[] arr, int size, int value)
	{
		for (int i = 0; i < size; i++)
		{
			if (value == arr[i])
			{
				{
					return i;
				}
			}
		}
		return -1;
	}

	public static int BinarySearch(int[] arr, int size, int value)
	{
		int mid;
		int low = 0;
		int high = size - 1;
		while (low <= high)
		{
			mid = (low + high) / 2;
			if (arr[mid] == value)
			{
				return mid;
			}
			else
			{
				if (arr[mid] < value)
				{
					low = mid + 1;
				}
				else
				{
					high = mid - 1;
				}
			}
		}
		return -1;
	}

	public static void Main3()
	{
		int[] arr = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
		Console.WriteLine("SequentialSearch:" + SequentialSearch(arr, arr.Length, 7));
		Console.WriteLine("BinarySearch:" + BinarySearch(arr, arr.Length, 7));
	}
	/*
	SequentialSearch:6
	BinarySearch:6
	*/
	public static void RotateArray(int[] a, int n, int k)
	{
		ReverseArray(a, 0, k - 1);
		ReverseArray(a, k, n - 1);
		ReverseArray(a, 0, n - 1);
	}

	public static void ReverseArray(int[] a, int start, int end)
	{
		for (int i = start, j = end; i < j; i++, j--)
		{
			int temp = a[i];
			a[i] = a[j];
			a[j] = temp;
		}
	}

	public static void ReverseArray2(int[] a)
	{
		int start = 0;
		int end = a.Length - 1;
		for (int i = start, j = end; i < j; i++, j--)
		{
			int temp = a[i];
			a[i] = a[j];
			a[j] = temp;
		}
	}

	/* Testing code */
	public static void Main4()
	{
		int[] arr = new int[] {1, 2, 3, 4, 5, 6};
		RotateArray(arr, arr.Length, 2);
		PrintArray(arr, arr.Length);
	}
	/*
	[ 3 4 5 6 1 2 ]
	*/
	public static int MaxSubArraySum(int[] a, int size)
	{
		int maxSoFar = 0, maxEndingHere = 0;

		for (int i = 0; i < size; i++)
		{
			maxEndingHere = maxEndingHere + a[i];
			if (maxEndingHere < 0)
			{
				maxEndingHere = 0;
			}
			if (maxSoFar < maxEndingHere)
			{
				maxSoFar = maxEndingHere;
			}
		}
		return maxSoFar;
	}

	/* Testing code */
	public static void Main5()
	{
		int[] arr = new int[] {1, -2, 3, 4, -4, 6, -4, 3, 2};
		Console.WriteLine("Max sub array sum :" + MaxSubArraySum(arr, 9));
	}
	/*
	Max sub array sum :10
	*/
	public static void WaveArray2(int[] arr)
	{
		int size = arr.Length;
		/* Odd elements are lesser then even elements. */
		for (int i = 1; i < size; i += 2)
		{
			if ((i - 1) >= 0 && arr[i] > arr[i - 1])
			{
				Swap(arr, i, i - 1);
			}
			if ((i + 1) < size && arr[i] > arr[i + 1])
			{
				Swap(arr, i, i + 1);
			}
		}
	}

	public static void WaveArray(int[] arr)
	{
		int size = arr.Length;
		Array.Sort(arr);
		for (int i = 0 ; i < size -1 ; i += 2)
		{
			Swap(arr, i, i + 1);
		}
	}


	/* Testing code */
	public static void Main6()
	{
		int[] arr = new int[] {8, 1, 2, 3, 4, 5, 6, 4, 2};
		WaveArray(arr);
		PrintArray(arr, arr.Length);
		int[] arr2 = new int[] {8, 1, 2, 3, 4, 5, 6, 4, 2};
		WaveArray2(arr2);
		PrintArray(arr2, arr2.Length);
	}
	/*
	[ 2 1 3 2 4 4 6 5 8 ]
	[ 8 1 3 2 5 4 6 2 4 ]
	*/
	public static void IndexArray(int[] arr, int size)
	{
		for (int i = 0; i < size; i++)
		{
			int curr = i;
			int value = -1;

			/* Swaps to move elements in proper position. */
			while (arr[curr] != -1 && arr[curr] != curr)
			{
				int temp = arr[curr];
				arr[curr] = value;
				value = curr = temp;
			}

			/* check if some Swaps happened. */
			if (value != -1)
			{
				arr[curr] = value;
			}
		}
	}

	public static void IndexArray2(int[] arr, int size)
	{
		int temp;
		for (int i = 0; i < size; i++)
		{
			while (arr[i] != -1 && arr[i] != i)
			{
				/* Swap arr[i] and arr[arr[i]] */
				temp = arr[i];
				arr[i] = arr[temp];
				arr[temp] = temp;
			}
		}
	}

	/* Testing code */
	public static void Main7()
	{
		int[] arr = new int[] {8, -1, 6, 1, 9, 3, 2, 7, 4, -1};
		int size = arr.Length;
		IndexArray2(arr, size);
		PrintArray(arr, size);
		int[] arr2 = new int[] {8, -1, 6, 1, 9, 3, 2, 7, 4, -1};
		size = arr2.Length;
		IndexArray(arr2, size);
		PrintArray(arr2, size);
	}
	/*
	[ -1 1 2 3 4 -1 6 7 8 9 ]
	[ -1 1 2 3 4 -1 6 7 8 9 ]
	*/

	public static void Sort1toN(int[] arr, int size)
	{
		int curr, value, next;
		for (int i = 0; i < size; i++)
		{
			curr = i;
			value = -1;
			/* Swaps to move elements in proper position. */
			while (curr >= 0 && curr < size && arr[curr] != curr + 1)
			{
				next = arr[curr];
				arr[curr] = value;
				value = next;
				curr = next - 1;
			}
		}
	}

	public static void Sort1toN2(int[] arr, int size)
	{
		int temp;
		for (int i = 0; i < size; i++)
		{
			while (arr[i] != i + 1 && arr[i] > 1)
			{
				temp = arr[i];
				arr[i] = arr[temp - 1];
				arr[temp - 1] = temp;
			}
		}
	}

	/* Testing code */
	public static void Main8()
	{
		int[] arr = new int[] {8, 5, 6, 1, 9, 3, 2, 7, 4, 10};
		int size = arr.Length;
		Sort1toN2(arr, size);
		PrintArray(arr, size);
		int[] arr2 = new int[] {8, 5, 6, 1, 9, 3, 2, 7, 4, 10};
		size = arr2.Length;
		Sort1toN(arr2, size);
		PrintArray(arr2, size);

	}
	/*
	[ 1 2 3 4 5 6 7 8 9 10 ]
	[ 1 2 3 4 5 6 7 8 9 10 ]
	*/
	public static int SmallestPositiveMissingNumber(int[] arr, int size)
	{
		int found;
		for (int i = 1; i < size + 1; i++)
		{
			found = 0;
			for (int j = 0; j < size; j++)
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
		return -1;
	}

	public static int SmallestPositiveMissingNumber2(int[] arr, int size)
	{
		Dictionary<int, int> hs = new Dictionary<int, int>();
		for (int i = 0; i < size; i++)
		{
			hs[arr[i]] = 1;
		}
		for (int i = 1; i < size + 1; i++)
		{
			if (hs.ContainsKey(i) == false)
			{
				return i;
			}
		}
		return -1;
	}

	public static int SmallestPositiveMissingNumber3(int[] arr, int size)
	{
		int[] aux = new int[size];
		Array.Fill(aux, -1);

		for (int i = 0; i < size; i++)
		{
			if (arr[i] > 0 && arr[i] <= size)
			{
				aux[arr[i] - 1] = arr[i];
			}
		}
		for (int i = 0; i < size; i++)
		{
			if (aux[i] != i + 1)
			{
				return i + 1;
			}
		}
		return -1;
	}

	public static int SmallestPositiveMissingNumber4(int[] arr, int size)
	{
		int temp;
		for (int i = 0; i < size; i++)
		{
			while (arr[i] != i + 1 && arr[i] > 0 && arr[i] <= size)
			{
				temp = arr[i];
				arr[i] = arr[temp - 1];
				arr[temp - 1] = temp;
			}
		}
		for (int i = 0; i < size; i++)
		{
			if (arr[i] != i + 1)
			{
				return i + 1;
			}
		}
		return -1;
	}

	/* Testing code */
	public static void Main9()
	{
		int[] arr = new int[] {8, 5, 6, 1, 9, 11, 2, 7, 4, 10};
		int size = arr.Length;

		Console.WriteLine("SmallestPositiveMissingNumber :" + SmallestPositiveMissingNumber(arr, size));
		Console.WriteLine("SmallestPositiveMissingNumber :" + SmallestPositiveMissingNumber2(arr, size));
		Console.WriteLine("SmallestPositiveMissingNumber :" + SmallestPositiveMissingNumber3(arr, size));
		Console.WriteLine("SmallestPositiveMissingNumber :" + SmallestPositiveMissingNumber4(arr, size));
	}

	/*
	SmallestPositiveMissingNumber :3
	SmallestPositiveMissingNumber :3
	SmallestPositiveMissingNumber :3
	SmallestPositiveMissingNumber :3
	*/
	public static void MaxMinArr(int[] arr, int size)
	{
		int[] aux = new int[size];
		Array.Copy(arr, aux, size);
		int start = 0;
		int stop = size - 1;
		for (int i = 0; i < size; i++)
		{
			if (i % 2 == 0)
			{
				arr[i] = aux[stop];
				stop -= 1;
			}
			else
			{
				arr[i] = aux[start];
				start += 1;
			}
		}
	}

	public static void ReverseArr(int[] arr, int start, int stop)
	{
		while (start < stop)
		{
			Swap(arr, start, stop);
			start += 1;
			stop -= 1;
		}
	}

	public static void MaxMinArr2(int[] arr, int size)
	{
		for (int i = 0; i < (size - 1); i++)
		{
			ReverseArr(arr, i, size - 1);
		}
	}

	/* Testing code */
	public static void Main10()
	{
		int[] arr = new int[] {1, 2, 3, 4, 5, 6, 7};
		int size = arr.Length;
		MaxMinArr(arr, size);
		PrintArray(arr, size);
		int[] arr2 = new int[] {1, 2, 3, 4, 5, 6, 7};
		int size2 = arr.Length;
		MaxMinArr2(arr2, size2);
		PrintArray(arr2, size2);
	}
	/*
	[ 7 1 6 2 5 3 4 ]
	[ 7 1 6 2 5 3 4 ]
	*/
	public static int MaxCircularSum(int[] arr, int size)
	{
		int sumAll = 0;
		int currVal = 0;
		int maxVal;

		for (int i = 0; i < size; i++)
		{
			sumAll += arr[i];
			currVal += (i * arr[i]);
		}
		maxVal = currVal;
		for (int i = 1; i < size; i++)
		{
			currVal = (currVal + sumAll) - (size * arr[size - i]);
			if (currVal > maxVal)
			{
				maxVal = currVal;
			}
		}
		return maxVal;
	}

	/* Testing code */
	public static void Main11()
	{
		int[] arr = new int[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
		Console.WriteLine("MaxCircularSum: " + MaxCircularSum(arr, arr.Length));
	}
	/*
	MaxCircularSum: 290
	*/
	public static int ArrayIndexMaxDiff(int[] arr, int size)
	{
		int maxDiff = -1;
		int j;
		for (int i = 0; i < size; i++)
		{
			j = size - 1;
			while (i < j)
			{
				if (arr[i] <= arr[j])
				{
					maxDiff = Math.Max(maxDiff, j - i);
					break;
				}
				j -= 1;
			}
		}
		return maxDiff;
	}

	public static int ArrayIndexMaxDiff2(int[] arr, int size)
	{
		int[] rightMax = new int[size];
		rightMax[size - 1] = arr[size - 1];
		for (int i = size - 2; i >= 0; i--)
		{
			rightMax[i] = Math.Max(rightMax[i + 1], arr[i]);
		}

		int maxDiff = -1;
		for (int i = 0, j = 1; i < size && j < size;)
		{
			if (arr[i] <= rightMax[j])
			{
				if (i < j)
				{
					maxDiff = Math.Max(maxDiff, j - i);
				}
				j = j + 1;
			}
			else
			{
				i = i + 1;
			}
		}
		return maxDiff;
	}

	/* Testing code */
	public static void Main12()
	{
		int[] arr = new int[]{ 33, 9, 10, 3, 2, 60, 30, 33, 1 };// {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
		Console.WriteLine("ArrayIndexMaxDiff : " + ArrayIndexMaxDiff(arr, arr.Length));
		Console.WriteLine("ArrayIndexMaxDiff : " + ArrayIndexMaxDiff2(arr, arr.Length));
	}
	/*
	ArrayIndexMaxDiff : 7
	ArrayIndexMaxDiff : 7
	*/

	public static int MaxPathSum(int[] arr1, int size1, int[] arr2, int size2)
	{
		int i = 0, j = 0, result = 0, sum1 = 0, sum2 = 0;

		while (i < size1 && j < size2)
		{
			if (arr1[i] < arr2[j])
			{
				sum1 += arr1[i];
				i += 1;
			}
			else if (arr1[i] > arr2[j])
			{
				sum2 += arr2[j];
				j += 1;
			}
			else
			{
				result += Math.Max(sum1, sum2);
				result = result + arr1[i];
				sum1 = 0;
				sum2 = 0;
				i += 1;
				j += 1;
			}
		}
		while (i < size1)
		{
			sum1 += arr1[i];
			i += 1;
		}

		while (j < size2)
		{
			sum2 += arr2[j];
			j += 1;
		}

		result += Math.Max(sum1, sum2);
		return result;
	}

	/* Testing code */
	public static void Main13()
	{
		int[] arr1 = new int[] {12, 13, 18, 20, 22, 26, 70};
		int[] arr2 = new int[] {11, 15, 18, 19, 20, 26, 30, 31};
		Console.WriteLine("Max Path Sum :: " + MaxPathSum(arr1, arr1.Length, arr2, arr2.Length));
	}
	/*
	Max Path Sum :: 201
	*/
	public static int Factorial(int i)
	{
		// Termination Condition
		if (i <= 1)
		{
			return 1;
		}
		// Body, Recursive Expansion
		return i * Factorial(i - 1);
	}

	/* Testing code */
	public static void Main14()
	{
		Console.WriteLine("Factorial:" + Factorial(5));
	}
	// Factorial:120

	public static void PrintInt10(int number)
	{
		char digit = (char)(number % 10 + '0');
		number = number / 10;
		if (number != 0)
		{
			PrintInt10(number);
		}
		Console.Write(digit);
	}

	public static void PrintInt(int number, int outputbase)
	{
		string conversion = "0123456789ABCDEF";
		char digit = (char)(number % outputbase);
		number = number / outputbase;
		if (number != 0)
		{
			PrintInt(number, outputbase);
		}
		Console.Write(conversion[digit]);
	}

	/* Testing code */
	public static void Main15()
	{
		PrintInt10(50);
		Console.WriteLine();
		PrintInt(500, 16);
		Console.WriteLine();
	}
	/*
	50
	1F4
	*/


	public static void TowerOfHanoi(int num, char src, char dst, char temp)
	{
		if (num < 1)
		{
			return;
		}

		TowerOfHanoi(num - 1, src, temp, dst);
		Console.WriteLine("Move " + num + " disk  from peg " + src + " to peg " + dst);
		TowerOfHanoi(num - 1, temp, dst, src);
	}

	/* Testing code */
	public static void Main16()
	{
		int num = 3;
		Console.WriteLine("Moves involved in the Tower of Hanoi are:");
		TowerOfHanoi(num, 'A', 'C', 'B');
	}
	/*
	Moves involved in the Tower of Hanoi are:
	Move 1 disk  from peg A to peg C
	Move 2 disk  from peg A to peg B
	Move 1 disk  from peg C to peg B
	Move 3 disk  from peg A to peg C
	Move 1 disk  from peg B to peg A
	Move 2 disk  from peg B to peg C
	Move 1 disk  from peg A to peg C
	*/
	public static int Gcd(int m, int n)
	{
        if (n == 0)
            return m;

        if (m == 0)
            return n;

        return (Gcd(n, m % n));
	}

	/* Testing code */
	public static void Main17()
	{
		Console.WriteLine("Gcd is:: " + Gcd(5, 2));
	}

	/*
	Gcd is:: 1
	*/

	public static int Fibonacci(int n)
	{
		if (n <= 1)
		{
			return n;
		}
		return Fibonacci(n - 1) + Fibonacci(n - 2);
	}

	/* Testing code */
	public static void Main18()
	{
		for (int i = 0; i < 10; i++)
		{
			Console.Write(Fibonacci(i) + " ");
		}
		Console.WriteLine();
	}

	/*
	0 1 1 2 3 5 8 13 21 34 
	*/

	public static void Permutation(int[] arr, int i, int length)
	{
		if (length == i)
		{
			PrintArray(arr, length);
			return;
		}
		int j = i;
		for (j = i; j < length; j++)
		{
			Swap(arr, i, j);
			Permutation(arr, i + 1, length);
			Swap(arr, i, j);
		}
		return;
	}

	/* Testing code */
	public static void Main19()
	{
		int[] arr = new int[3];
		for (int i = 0; i < 3; i++)
		{
			arr[i] = i;
		}
		Permutation(arr, 0, 3);
	}
	/*
	[ 0 1 2 ]
	[ 0 2 1 ]
	[ 1 0 2 ]
	[ 1 2 0 ]
	[ 2 1 0 ]
	[ 2 0 1 ]
	*/
	// Binary Search Algorithm - Recursive
	public static int BinarySearchRecursive(int[] arr, int low, int high, int value)
	{
		if (low > high)
		{
			return -1;
		}
		int mid = (low + high) / 2;
		if (arr[mid] == value)
		{
			return mid;
		}
		else if (arr[mid] < value)
		{
			return BinarySearchRecursive(arr, mid + 1, high, value);
		}
		else
		{
			return BinarySearchRecursive(arr, low, mid - 1, value);
		}
	}

	/* Testing code */
	public static void Main20()
	{
		int[] arr = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
		Console.WriteLine(BinarySearchRecursive(arr, 0, arr.Length - 1, 6));
		Console.WriteLine(BinarySearchRecursive(arr, 0, arr.Length - 1, 16));
	}
	/*
	5
	-1
	*/
	public static void Main(string[] args)
	{
		Main1();
		Introduction i = new Introduction();
		i.Main2();
		Main3();
		Main4();
		Main5();
		Main6();
		Main7();
		Main8();
		Main9();
		Main10();
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
	}
}

