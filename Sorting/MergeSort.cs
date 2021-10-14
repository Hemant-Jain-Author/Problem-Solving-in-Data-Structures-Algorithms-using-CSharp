using System;

public class MergeSort
{
	private void Merge(int[] arr, int[] tempArray, int lowerIndex, int middleIndex, int upperIndex)
	{
		int lowerStart = lowerIndex;
		int lowerStop = middleIndex;
		int upperStart = middleIndex + 1;
		int upperStop = upperIndex;
		int count = lowerIndex;
		while (lowerStart <= lowerStop && upperStart <= upperStop)
		{
			if (arr[lowerStart] < arr[upperStart])
			{
				tempArray[count++] = arr[lowerStart++];
			}
			else
			{
				tempArray[count++] = arr[upperStart++];
			}
		}
		while (lowerStart <= lowerStop)
		{
			tempArray[count++] = arr[lowerStart++];
		}
		while (upperStart <= upperStop)
		{
			tempArray[count++] = arr[upperStart++];
		}
		for (int i = lowerIndex; i <= upperIndex; i++)
		{
			arr[i] = tempArray[i];
		}
	}

	private void MergeSrt(int[] arr, int[] tempArray, int lowerIndex, int upperIndex)
	{
		if (lowerIndex >= upperIndex)
		{
			return;
		}
		int middleIndex = (lowerIndex + upperIndex) / 2;
		MergeSrt(arr, tempArray, lowerIndex, middleIndex);
		MergeSrt(arr, tempArray, middleIndex + 1, upperIndex);
		Merge(arr, tempArray, lowerIndex, middleIndex, upperIndex);
	}

	public void Sort(int[] arr)
	{
		int size = arr.Length;
		int[] tempArray = new int[size];
		MergeSrt(arr, tempArray, 0, size - 1);
	}

	public static void Main(string[] args)
	{
		int[] array = new int[] {3, 4, 2, 1, 6, 5, 7, 8};
		MergeSort m = new MergeSort();
		m.Sort(array);
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i] + " ");
		}
	}
}
// 1 2 3 4 5 6 7 8