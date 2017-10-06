using System;
using System.Collections.Generic;

public class Searching
{

	public Searching()
	{
	}

	public static void Main(string[] args)
	{
		int[] first = new int[] { 1, 3, 5, 7, 9, 25, 30 };
		int[] second = new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 21, 23, 24 };

		for (int i = 1; i < 16; i++)
		{
			Console.Write("Index : " + i + " Value : ");
			Console.WriteLine(findkth(first, second, i));
		}

	}

	//buggy implimentation.
	internal static int findkth(int[] first, int[] second, int k)
	{
		int sizeFirst = first.Length;
		int sizeSecond = second.Length;

		if (sizeFirst + sizeSecond < k)
		{
			return int.MaxValue;
		}

		if (k == 1)
		{
			return min(first[0], second[0]);
		}

		int i = min(sizeFirst, k / 2);
		int j = min(sizeSecond, k - i);

		int step = max(1, min(i, j) / 2);

		while (step > 0)
		{
			if (first[i - 1] > second[j - 1] && first[i - 1] > second[min(second.Length, j + step) - 1])
			{
				j = min(second.Length, j + step);
				i = k - j;

			}
			else if (first[i - 1] < second[j - 1] && first[min(first.Length, i + step) - 1] < second[j - 1])
			{
				i = min(first.Length, i + step);
				j = k - i;
			}
			step = step / 2;
		}
		return max(first[i - 1], second[j - 1]);
	}


	public bool linearSearchUnsorted(int[] arr, int size, int value)
	{
		int i = 0;
		for (i = 0; i < size; i++)
		{
			if (value == arr[i])
			{
				return true;
			}
		}
		return false;
	}

	public bool linearSearchSorted(int[] arr, int size, int value)
	{
		int i = 0;
		for (i = 0; i < size; i++)
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

	// Binary Search Algorithm � Iterative Way 
	public bool Binarysearch(int[] arr, int size, int value)
	{
		int low = 0;
		int high = size - 1;
		int mid;

		while (low <= high)
		{
			mid = low + (high - low) / 2; // To avoid the overflow
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


	// Binary Search Algorithm � Recursive Way 
	public bool BinarySearchRecursive(int[] arr, int low, int high, int value)
	{
		if (low > high)
		{
			return false;
		}
		int mid = low + (high - low) / 2; // To avoid the overflow
		if (arr[mid] == value)
		{
			return true;
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

	public void printRepeating(int[] arr, int size)
	{
		int i, j;
		Console.WriteLine(" Repeating elements are ");
		for (i = 0; i < size; i++)
		{
			for (j = i + 1; j < size; j++)
			{
				if (arr[i] == arr[j])
				{
					Console.WriteLine(" " + arr[i]);
				}
			}
		}
	}

	public void printRepeating2(int[] arr, int size)
	{
		int i;
		Array.Sort(arr); // Sort(arr,size);
		Console.WriteLine(" Repeating elements are ");

		for (i = 1; i < size; i++)
		{
			if (arr[i] == arr[i - 1])
			{
				Console.WriteLine(" " + arr[i]);
			}
		}
	}



	public void printRepeating3(int[] arr, int size)
	{
		HashSet<int> hs = new HashSet<int>();
		int i;
		Console.WriteLine(" Repeating elements are ");
		for (i = 0; i < size; i++)
		{
			if (hs.Contains(arr[i]))
			{
				Console.WriteLine(" " + arr[i]);
			}
			else
			{
				hs.Add(arr[i]);
			}
		}
	}


	public void printRepeating4(int[] arr, int size)
	{
		int[] count = new int[size];
		int i;
		for (i = 0; i < size; i++)
		{
			count[i] = 0;
		}
		Console.WriteLine(" Repeating elements are ");
		for (i = 0; i < size; i++)
		{
			if (count[arr[i]] == 1)
			{
				Console.WriteLine(" " + arr[i]);
			}
			else
			{
				count[arr[i]]++;
			}
		}
	}


	public int getMax(int[] arr, int size)
	{
		int i, j;
		int max = 0, count = 0, maxCount = 0;
		for (i = 0; i < size; i++)
		{
			for (j = i + 1; j < size; j++)
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

	public int getMax2(int[] arr, int size)
	{
		int max = arr[0], maxCount = 1;
		int curr = arr[0], currCount = 1;
		int i;
		Array.Sort(arr); // Sort(arr,size);
		for (i = 1; i < size; i++)
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

	public int getMax(int[] arr, int size, int range)
	{
		int max = arr[0], maxCount = 1;
		int[] count = new int[range];
		int i;
		for (i = 0; i < size; i++)
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

	public int getMajority(int[] arr, int size)
	{
		int i, j;
		int max = 0, count = 0, maxCount = 0;
		for (i = 0; i < size; i++)
		{
			for (j = i + 1; j < size; j++)
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

	public int getMajority2(int[] arr, int size)
	{
		int majIndex = size / 2, count = 1;
		int i;
		int candidate;
		Array.Sort(arr); // Sort(arr,size);
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
			return int.MinValue;
		}
	}

	public int getMajority3(int[] arr, int size)
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

	public int findMissingNumber(int[] arr, int size)
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

	public int findMissingNumber(int[] arr, int size, int range)
	{
		int i;
		int xorSum = 0;
		//get the XOR of all the numbers from 1 to range
		for (i = 1; i <= range; i++)
		{
			xorSum ^= i;
		}
		//loop through the array and get the XOR of elements
		for (i = 0; i < size; i++)
		{
			xorSum ^= arr[i];
		}
		return xorSum;
	}

	public int FindPair(int[] arr, int size, int value)
	{
		int i, j;
		for (i = 0; i < size; i++)
		{
			for (j = i + 1; j < size; j++)
			{
				if ((arr[i] + arr[j]) == value)
				{
					Console.WriteLine("The pair is : " + arr[i] + "," + arr[j]);
					return 1;
				}
			}
		}
		return 0;
	}

	public int FindPair2(int[] arr, int size, int value)
	{
		int first = 0, second = size - 1;
		int curr;
		Array.Sort(arr); //Sort(arr, size);
		while (first < second)
		{
			curr = arr[first] + arr[second];
			if (curr == value)
			{
				Console.WriteLine("The pair is " + arr[first] + "," + arr[second]);
				return 1;
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
		return 0;
	}

	public int FindPair3(int[] arr, int size, int value)
	{
		HashSet<int?> hs = new HashSet<int?>();
		int i;
		for (i = 0; i < size; i++)
		{
			if (hs.Contains(value - arr[i]))
			{
				Console.WriteLine("The pair is : " + arr[i] + " , " + (value - arr[i]));
				return 1;
			}
			hs.Add(arr[i]);
		}
		return 0;
	}



	public void minAbsSumPair(int[] arr, int size)
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
		Console.WriteLine(" The two elements with minimum sum are : " + arr[minFirst] + " , " + arr[minSecond]);
	}


	public void minabsSumPair2(int[] arr, int size)
	{
		int l, r, minSum, sum, minFirst, minSecond;
		// Array should have at least two elements
		if (size < 2)
		{
			Console.WriteLine("Invalid Input");
			return;
		}
		Array.Sort(arr); //Sort(arr, size);

		// Initialization of values
		minFirst = 0;
		minSecond = size - 1;
		minSum = Math.Abs(arr[minFirst] + arr[minSecond]);
		for (l = 0, r = size - 1; l < r;)
		{
			sum = (arr[l] + arr[r]);
			if (Math.Abs(sum) < minSum)
			{
				minSum = sum;
				minFirst = l;
				minSecond = r;
			}
			if (sum < 0)
			{
				l++;
			}
			else if (sum > 0)
			{
				r++;
			}
			else
			{
				break;
			}
		}
		Console.WriteLine(" The two elements with minimum sum are : " + arr[minFirst] + " , " + arr[minSecond]);
	}


	public int SearchBotinicArrayMax(int[] arr, int size)
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
			if (arr[mid - 1] < arr[mid] && arr[mid + 1] < arr[mid]) //maxima
			{
				maximaFound = 1;
				break;
			}
			else if (arr[mid - 1] < arr[mid] && arr[mid] < arr[mid + 1]) //increasing
			{
				start = mid + 1;
			}
			else if (arr[mid - 1] > arr[mid] && arr[mid] > arr[mid + 1]) //decreasing
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

	public int SearchBitonicArray(int[] arr, int size, int key)
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

	public int FindMaxBitonicArray(int[] arr, int size)
	{
		int start = 0, end = size - 1, mid;
		if (size < 3)
		{
			Console.WriteLine("error");
			return 0;
		}
		while (start <= end)
		{
			mid = (start + end) / 2;
			if (arr[mid - 1] < arr[mid] && arr[mid + 1] < arr[mid]) //maxima
			{
				return mid;
			}
			else if (arr[mid - 1] < arr[mid] && arr[mid] < arr[mid + 1]) //increasing
			{
				start = mid + 1;
			}
			else if (arr[mid - 1] > arr[mid] && arr[mid] > arr[mid + 1]) //increasing
			{
				end = mid - 1;
			}
			else
			{
				break;
			}
		}
		Console.WriteLine("error");
		return 0;
	}

	public int BinarySearch(int[] arr, int start, int end, int key, bool isInc)
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


	public int findKeyCount(int[] arr, int size, int key)
	{
		int i, count = 0;
		for (i = 0; i < size - 1; i++)
		{
			if (arr[i] == key)
			{
				count++;
			}
		}
		return count;
	}


	public int findKeyCount2(int[] arr, int size, int key)
	{
		int firstIndex, lastIndex;
		firstIndex = findFirstIndex(arr, 0, size - 1, key);
		lastIndex = findLastIndex(arr, 0, size - 1, key);
		return (lastIndex - firstIndex + 1);
	}

	public int findFirstIndex(int[] arr, int start, int end, int key)
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


	public int findLastIndex(int[] arr, int start, int end, int key)
	{
		int mid;
		if (end < start)
		{
			return -1;
		}
		mid = (start + end) / 2;
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

	public void swap(int[] arr, int first, int second)
	{
		int temp = arr[first];
		arr[first] = arr[second];
		arr[second] = temp;
	}

	public void seperateEvenAndOdd(int[] arr, int size)
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

	public void maxProfit(int[] stocks, int size)
	{
		int buy = 0, sell = 0;
		int curMin = 0;
		int currProfit = 0;
		int maxProfit = 0;
		int i;
		for (i = 0; i < size; i++)
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
	}

	public int getMedian(int[] arr, int size)
	{
		Array.Sort(arr); //Sort(arr, size);
		return arr[size / 2];
	}


	public int findMedian(int[] arrFirst, int sizeFirst, int[] arrSecond, int sizeSecond)
	{
		int medianIndex = ((sizeFirst + sizeSecond) + (sizeFirst + sizeSecond) % 2) / 2; //cealing function.
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

	internal static int min(int a, int b)
	{
		return a > b ? b : a;
	}

	internal static int max(int a, int b)
	{
		return a < b ? b : a;
	}


	public int BinarySearch01Wrapper(int[] arr, int size)
	{
		if (size == 1 && arr[0] == 1)
		{
			return 0;
		}
		return BinarySearch01(arr, 0, size - 1);
	}

	public int BinarySearch01(int[] arr, int start, int end)
	{
		int mid;
		if (end < start)
		{
			return -1;
		}
		mid = (start + end) / 2;
		if (1 == arr[mid] && 0 == arr[mid - 1])
		{
			return mid;
		}
		if (0 == arr[mid])
		{
			return BinarySearch01(arr, mid + 1, end);
		}
		else
		{
			return BinarySearch01(arr, start, mid - 1);
		}
	}

	public int BinarySearchRotateArray(int[] arr, int start, int end, int key)
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
		if (arr[mid] > arr[start])
		{
			if (arr[start] <= key && key < arr[mid])
			{
				return BinarySearchRotateArray(arr, start, mid - 1, key);
			}
			else
			{
				return BinarySearchRotateArray(arr, mid + 1, end, key);
			}
		}
		else
		{
			if (arr[mid] < key && key <= arr[end])
			{
				return BinarySearchRotateArray(arr, mid + 1, end, key);
			}
			else
			{
				return BinarySearchRotateArray(arr, start, mid - 1, key);
			}
		}
	}
	public int BinarySearchRotateArrayWrapper(int[] arr, int size, int key)
	{
		return BinarySearchRotateArray(arr, 0, size - 1, key);
	}

	public int FirstRepeated(int[] arr, int size)
	{
		int i, j;
		for (i = 0; i < size; i++)
		{
			for (j = i + 1; j < size; j++)
			{
				if (arr[i] == arr[j])
				{
					return arr[i];
				}
			}
		}
		return 0;
	}

	public void transformArrayAB1(int[] arr, int size)
	{
		int N = size / 2, i, j;
		for (i = 1; i < N; i++)
		{
			for (j = 0; j < i; j++)
			{
				swap(arr, N - i + 2 * j, N - i + 2 * j + 1);
			}
		}
	}
	public bool checkPermutation(int[] array1, int size1, int[] array2, int size2)
	{
		if (size1 != size2)
		{
			return false;
		}
		Array.Sort(array1); // Sort(array1, size1);
		Array.Sort(array2); // Sort(array2, size2);
		for (int i = 0; i < size1; i++)
		{
			if (array1[i] != array2[i])
			{
				return false;
			}
		}
		return true;
	}


	public bool checkPermutation2(int[] array1, int size1, int[] array2, int size2)
	{
		int i;
		if (size1 != size2)
		{
			return false;
		}

		List<int?> al = new List<int?>();

		for (i = 0; i < size1; i++)
		{
			al.Add(array1[i]);
		}

		for (i = 0; i < size2; i++)
		{
			if (al.Contains(array2[i]) == false)
			{
				return false;
			}
			al.RemoveAt(array2[i]);
		}
		return true;
	}


	public int removeDuplicates(int[] array, int size)
	{
		int j = 0;
		int i;
		if (size == 0)
		{
			return 0;
		}
		Array.Sort(array); // Sort(array,size);
		for (i = 1; i < size; i++)
		{
			if (array[i] != array[j])
			{
				j++;
				array[j] = array[i];
			}
		}
		return j + 1;
	}

	public int FindElementIn2DArray(int[][] arr, int r, int c, int value)
	{
		int row = 0;
		int column = c - 1;
		while (row < r && column >= 0)
		{
			if (arr[row][column] == value)
			{
				return 1;
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
		return 0;
	}
}