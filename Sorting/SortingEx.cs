using System;
using System.Collections.Generic;

public class SortingEx
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

public static int Partition01(int[] arr, int size)
{
	int left = 0;
	int right = size - 1;
	int count = 0;
	while (left < right)
	{
		while (arr[left] == 0)
		{
			left += 1;
		}

		while (arr[right] == 1)
		{
			right -= 1;
		}

		if (left < right)
		{
			Swap(arr, left, right);
			count += 1;
		}
	}
	return count;
}

public static void Partition012_(int[] arr, int size)
{
	int zero = 0, one = 0, two = 0;

	for (int i = 0; i < size;i++)
	{
		if (arr[i] == 0)
		{
			zero += 1;
		}
		else if (arr[i] == 1)
		{
			one += 1;
		}
		else
		{
			two += 1;
		}
	}
	int index = 0;
	while (zero > 0)
	{
		arr[index++] = 0;
		zero -= 1;
	}
	while (one > 0)
	{
		arr[index++] = 1;
		one -= 1;
	}
	while (two > 0)
	{
		arr[index++] = 2;
		two -= 1;
	}
}

public static void Partition012(int[] arr, int size)
{
	int left = 0;
	int right = size - 1;
	int i = 0;
	while (i <= right)
	{
		if (arr[i] == 0)
		{
			Swap(arr, i, left);
			i += 1;
			left += 1;
		}
		else if (arr[i] == 2)
		{
			Swap(arr, i, right);
			right -= 1;
		}
		else
		{
			i += 1;
		}
	}
}

// Testing code
public static void Main1()
{
	int[] arr = new int[] {0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1};
	Partition01(arr, arr.Length);
	PrintArray(arr, arr.Length);

	int[] arr2 = new int[] {0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1};
	Partition012(arr2, arr2.Length);
	PrintArray(arr2, arr2.Length);

	int[] arr3 = new int[] {0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1};
	Partition012_(arr3, arr3.Length);
	PrintArray(arr3, arr3.Length);
}
/*
[ 0 0 0 0 0 0 1 1 1 1 1 1 ]
[ 0 0 0 0 0 1 1 1 1 1 2 2 ]
*/
public static void RangePartition(int[] arr, int size, int lower, int higher)
{
	int start = 0;
	int end = size - 1;
	int i = 0;
	while (i <= end)
	{
		if (arr[i] < lower)
		{
			Swap(arr, i, start);
			i += 1;
			start += 1;
		}
		else if (arr[i] > higher)
		{
			Swap(arr, i, end);
			end -= 1;
		}
		else
		{
			i += 1;
		}
	}
}

// Testing code
public static void Main2()
{
	int[] arr = new int[] {1, 2, 3, 4, 18, 5, 17, 6, 16, 7, 15, 8, 14, 9, 13, 10, 12, 11};
	RangePartition(arr, arr.Length, 9, 12);
	PrintArray(arr, arr.Length);
}
/*
[ 1 2 3 4 5 6 7 8 10 12 9 11 14 13 15 16 17 18 ]
*/


public static int MinSwaps(int[] arr, int size, int val)
{
	int SwapCount = 0;
	int first = 0;
	int second = size - 1;
	int temp;
	while (first < second)
	{
		if (arr[first] <= val)
		{
			first += 1;
		}
		else if (arr[second] > val)
		{
			second -= 1;
		}
		else
		{
			temp = arr[first];
			arr[first] = arr[second];
			arr[second] = temp;
			SwapCount += 1;
		}
	}
	return SwapCount;
}

//Testing code
public static void Main3()
{
 int[] array = new int[] {1, 2, 3, 4, 18, 5, 17, 6, 16, 7, 15, 8, 14, 9, 13, 10, 12, 11};
 Console.WriteLine("MinSwaps " + MinSwaps(array, array.Length, 10));

}
// MinSwaps 3

public static void SeparateEvenAndOdd(int[] data, int size)
{
	int left = 0, right = size - 1;
	int[] aux = new int[size];

	for (int i = 0;i < size;i++)
	{
		if (data[i] % 2 == 0)
		{
			aux[left] = data[i];
			left++;
		}
		else if (data[i] % 2 == 1)
		{
			aux[right] = data[i];
			right--;
		}
	}
	for (int i = 0;i < size;i++)
	{
		data[i] = aux[i];
	}
}

public static void SeparateEvenAndOdd2(int[] data, int size)
{
	int left = 0, right = size - 1;
	while (left < right)
	{
		if (data[left] % 2 == 0)
		{
			left++;
		}
		else if (data[right] % 2 == 1)
		{
			right--;
		}
		else
		{
			Swap(data, left, right);
			left++;
			right--;
		}
	}
}

// Testing code
public static void Main4()
{
	int[] array = new int[] {9, 1, 8, 2, 7, 3, 6, 4, 5};
	SeparateEvenAndOdd(array, array.Length);
	PrintArray(array, array.Length);
	int[] array2 = new int[] {9, 1, 8, 2, 7, 3, 6, 4, 5};
	SeparateEvenAndOdd2(array2, array2.Length);
	PrintArray(array2, array2.Length);
}
// [ 8 2 6 4 5 3 7 1 9 ]
// [ 4 6 8 2 7 3 1 9 5 ]

public static bool AbsMore(int value1, int value2, int reference)
{
	return (Math.Abs(value1 - reference) > Math.Abs(value2 - reference));
}

public static void AbsBubbleSort(int[] arr, int size, int reference)
{
	for (int i = 0; i < (size - 1); i++)
	{
		for (int j = 0; j < (size - i - 1); j++)
		{
			if (AbsMore(arr[j], arr[j + 1], reference))
			{
				Swap(arr, j, j + 1);
			}
		}
	}
}

// Testing code
public static void Main5()
{
	int[] array = new int[] {9, 1, 8, 2, 7, 3, 6, 4, 5};
	int reference = 5;
	AbsBubbleSort(array, array.Length, reference);
	PrintArray(array, array.Length);
}
/*
[ 5 6 4 7 3 8 2 9 1 ]
*/
public static bool EqMore(int value1, int value2, int A)
{
	value1 = A * value1 * value1;
	value2 = A * value2 * value2;
	return value1 > value2;
}

public static void ArrayReduction(int[] arr, int size)
{
	Array.Sort(arr);
	int count = 1;
	int reduction = arr[0];

	for (int i = 0; i < size; i++)
	{
		if (arr[i] - reduction > 0)
		{
			reduction = arr[i];
			count += 1;
			Console.WriteLine(size - i);
		}
	}
	Console.WriteLine(0); // after all the reduction the array will be empty.

	Console.WriteLine("Total number of reductions: " + count);
}

// Testing code
public static void Main6()
{
	int[] arr = new int[] {5, 1, 1, 1, 2, 3, 5};
	ArrayReduction(arr, arr.Length);
}
/*
4
3
2
0
Total number of reductions: 4
*/

	public static void SortByOrder(int[] arr, int size, int[] arr2, int size2)
{
	Dictionary<int, int> ht = new Dictionary<int, int>();
	int value;
	for (int i = 0; i < size; i++)
	{
		if (ht.ContainsKey(arr[i]))
		{
			value = ht[arr[i]];
			ht[arr[i]] = value + 1;
		}
		else
		{
			ht[arr[i]] = 1;
		}
	}

	for (int j = 0; j < size2; j++)
	{
		if (ht.ContainsKey(arr2[j]))
		{
			value = ht[arr2[j]];
			for (int k = 0; k < value; k++)
			{
				Console.Write(arr2[j] + " ");
			}
			ht.Remove(arr2[j]);
		}
	}

	for (int i = 0; i < size; i++)
	{
		if (ht.ContainsKey(arr[i]))
		{
			value = ht[arr[i]];
			for (int k = 0; k < value; k++)
			{
				Console.Write(arr[i] + " ");
			}
			ht.Remove(arr[i]);
		}
	}
}

// Testing code
public static void Main7()
{
	int[] arr = new int[] {2, 1, 2, 5, 7, 1, 9, 3, 6, 8, 8};
	int[] arr2 = new int[] {2, 1, 8, 3};
	SortByOrder(arr, arr.Length, arr2, arr2.Length);
	Console.WriteLine();
}
/*
2 2 1 1 8 8 3 5 7 9 6 
*/
public static void Merge(int[] arr1, int size1, int[] arr2, int size2)
{
	int index = 0;
	int temp;
	while (index < size1)
	{
		if (arr1[index] <= arr2[0])
		{
			index += 1;
		}
		else
		{
			// always first element of arr2 is compared.
			temp = arr1[index];
			arr1[index] = arr2[0];
			arr2[0] = temp;
			index += 1;
			// After Swap arr2 may be unsorted.
			// Insertion of the element in proper sorted position.
			for (int i = 0; i < (size2 - 1); i++)
			{
				if (arr2[i] < arr2[i + 1])
				{
					break;
				}
				temp = arr2[i];
				arr2[i] = arr2[i + 1];
				arr2[i + 1] = temp;
			}
		}
	}
}

// Testing code.
public static void Main8()
{
	int[] arr1 = new int[] {1, 5, 9, 10, 15, 20};
	int[] arr2 = new int[] {2, 3, 8, 13};
	Merge(arr1, arr1.Length, arr2, arr2.Length);
	PrintArray(arr1, arr1.Length);
	PrintArray(arr2, arr2.Length);
}
/*
[ 1 2 3 5 8 9 ]
[ 10 13 15 20 ]
*/

public static bool CheckReverse(int[] arr, int size)
{
	int start = -1;
	int stop = -1;
	for (int i = 0; i < (size - 1); i++)
	{
		if (arr[i] > arr[i + 1])
		{
			start = i;
			break;
		}
	}

	if (start == -1)
	{
		return true;
	}

	for (int i = start; i < (size - 1); i++)
	{
		if (arr[i] < arr[i + 1])
		{
			stop = i;
			break;
		}
	}

	if (stop == -1)
	{
		return true;
	}

	// increasing property
	// after reversal the sub array should fit in the array.
	if (arr[start - 1] > arr[stop] || arr[stop + 1] < arr[start])
	{
		return false;
	}

	for (int i = stop + 1; i < size - 1; i++)
	{
		if (arr[i] > arr[i + 1])
		{
			return false;
		}
	}
	return true;
}
public static void Main9()
{
	int[] arr1 = new int[] {1, 2, 6, 5, 4, 7};
	Console.WriteLine(CheckReverse(arr1, arr1.Length));
}
// True

public static void UnionIntersectionSorted(int[] arr1, int size1, int[] arr2, int size2)
{
	int first = 0, second = 0;
	int[] unionArr = new int[size1 + size2];
	int[] interArr = new int[Math.Min(size1, size2)];
	int uIndex = 0;
	int iIndex = 0;

	while (first < size1 && second < size2)
	{
		if (arr1[first] == arr2[second])
		{
			unionArr[uIndex++] = arr1[first];
			interArr[iIndex++] = arr1[first];
			first += 1;
			second += 1;
		}
		else if (arr1[first] < arr2[second])
		{
			unionArr[uIndex++] = arr1[first];
			first += 1;
		}
		else
		{
			unionArr[uIndex++] = arr2[second];
			second += 1;
		}
	}
	while (first < size1)
	{
		unionArr[uIndex++] = arr1[first];
		first += 1;
	}
	while (second < size2)
	{
		unionArr[uIndex++] = arr2[second];
		second += 1;
	}
	PrintArray(unionArr, uIndex);
	PrintArray(interArr, iIndex);
}

public static void UnionIntersectionUnsorted(int[] arr1, int size1, int[] arr2, int size2)
{
	Array.Sort(arr1);
	Array.Sort(arr2);
	UnionIntersectionSorted(arr1, size1, arr2, size2);
}

public static void Main10()
{
	int[] arr1 = new int[] {1, 11, 2, 3, 14, 5, 6, 8, 9};
	int[] arr2 = new int[] {2, 4, 5, 12, 7, 8, 13, 10};
	UnionIntersectionUnsorted(arr1, arr1.Length, arr2, arr2.Length);
}
/*
[ 1 2 3 4 5 6 7 8 9 10 11 12 13 14 ]
[ 2 5 8 ]
*/
	public static void Main(string[] args)
	{
		Main1();
		Main2();
		Main3();
		Main4();
		Main5();
		Main6();
		Main7();
		Main8();
		Main9();
		Main10();
	}
}