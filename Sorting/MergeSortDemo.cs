using System;

public class MergeSortDemo
{

	public static void Main(string[] args)
	{
		int[] array = new int[] { 3, 4, 2, 1, 6, 5, 7, 8, 1, 1 };
		MergeSort m = new MergeSort(array);
		m.sort();
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i] + " ");
		}
	}
}
