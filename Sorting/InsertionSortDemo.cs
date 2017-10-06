using System;

public class InsertionSortDemo
{
	public static void Main2(string[] args)
	{
		int[] array = new int[] { 9, 1, 8, 2, 7, 3, 6, 4, 5 };
		InsertionSort bs = new InsertionSort(array);
		bs.sort();
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i] + " ");

		}
	}
}
