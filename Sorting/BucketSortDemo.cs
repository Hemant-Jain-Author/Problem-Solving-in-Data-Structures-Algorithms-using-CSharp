using System;

public class BucketSortDemo
{
	public static void Main4(string[] args)
	{
		int[] array = new int[] { 23, 24, 22, 21, 26, 25, 27, 28, 21, 21 };

		BucketSort m = new BucketSort(array, 20, 30);
		m.sort();
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i] + " ");
		}
	}
}
