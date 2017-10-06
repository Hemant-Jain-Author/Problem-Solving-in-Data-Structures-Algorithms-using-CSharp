using System;

public class QuickSortDemo
{
	public static void Main5(string[] args)
	{
		int[] array = new int[] { 3, 4, 2, 1, 6, 5, 7, 8, 1, 1 };
		QuickSort m = new QuickSort(array);
		m.sort();
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i] + " ");
		}
	}
}