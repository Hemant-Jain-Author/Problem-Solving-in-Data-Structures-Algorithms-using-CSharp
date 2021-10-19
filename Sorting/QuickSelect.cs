using System;

public class QuickSelect
{
	public static void Select(int[] arr, int lower, int upper, int k)
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
			Select(arr, start, upper - 1, k); // pivot -1 is the upper for
		}
												   // left sub array.
		if (k > upper)
		{
			Select(arr, upper + 1, stop, k); // pivot + 1 is the lower for
		}
												  // right sub array.
	}

	public static void Swap(int[] arr, int first, int second)
	{
		int temp = arr[first];
		arr[first] = arr[second];
		arr[second] = temp;
	}

	public static int Select(int[] arr, int k)
	{
		Select(arr, 0, arr.Length - 1, k);
		return arr[k - 1];
	}

	public static void Main(string[] args)
	{
		int[] array = new int[] {3, 4, 2, 1, 6, 5, 7, 8};
		Console.Write("value at index 5 is : " + QuickSelect.Select(array, 5));
	}
}

// value at index 5 is : 5