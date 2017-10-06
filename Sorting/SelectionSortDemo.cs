using System;

public class SelectionSortDemo
{
	public static void Main7(string[] args)
	{
		int[] array = new int[] { 9, 1, 8, 2, 7, 3, 6, 4, 5 };
		SelectionSort bs = new SelectionSort(array);
		bs.sort2();
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i] + " ");
		}
	}
}