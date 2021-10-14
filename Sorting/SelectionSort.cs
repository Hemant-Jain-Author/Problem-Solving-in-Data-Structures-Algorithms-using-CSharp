using System;

public class SelectionSort
{
	 private bool more(int value1, int value2)
	 {
		return value1 > value2;
	 }

	public void Sort(int[] arr) // Sorted array created in reverse order.
	{
		int size = arr.Length;
		int i, j, max, temp;
		for (i = 0; i < size - 1; i++)
		{
			max = 0;
			for (j = 1; j < size - i; j++)
			{
				if (arr[j] > arr[max])
				{
					max = j;
				}
			}
			temp = arr[size - 1 - i];
			arr[size - 1 - i] = arr[max];
			arr[max] = temp;
		}
	}

	public void Sort2(int[] arr) // Sorted array created in forward direction
	{
		int size = arr.Length;
		int i, j, min, temp;
		for (i = 0; i < size - 1; i++)
		{
			min = i;
			for (j = i + 1; j < size; j++)
			{
				if (arr[j] < arr[min])
				{
					min = j;
				}
			}
			temp = arr[i];
			arr[i] = arr[min];
			arr[min] = temp;
		}
	}

	public static void Main(string[] args)
	{
		int[] array = new int[] {9, 1, 8, 2, 7, 3, 6, 4, 5};
		SelectionSort srt = new SelectionSort();
		srt.Sort(array);
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i] + " ");
		}
		Console.WriteLine();

		int[] array2 = new int[] {9, 1, 8, 2, 7, 3, 6, 4, 5};
		srt = new SelectionSort();
		srt.Sort2(array2);
		for (int i = 0; i < array2.Length; i++)
		{
			Console.Write(array2[i] + " ");
		}
	}
}

/*
1 2 3 4 5 6 7 8 9 
1 2 3 4 5 6 7 8 9
*/