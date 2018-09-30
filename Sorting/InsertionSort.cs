using System;

public class InsertionSort
{
	private static bool more(int value1, int value2)
	{
		return value1 > value2;
	}

	public static void sort(int[] arr)
	{
		int size = arr.Length;
		int temp, j;
		for (int i = 1; i < size; i++)
		{
			temp = arr[i];
			for (j = i; j > 0 && more(arr[j - 1], temp); j--)
			{
				arr[j] = arr[j - 1];
			}
			arr[j] = temp;
		}
	}

	public static void Main(string[] args)
	{
		int[] array = new int[] { 9, 1, 8, 2, 7, 3, 6, 4, 5 };
		InsertionSort.sort(array);
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i] + " ");

		}
	}
}