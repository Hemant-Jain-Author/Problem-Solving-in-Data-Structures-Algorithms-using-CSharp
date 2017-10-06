public class MergeSort
{
	private int[] arr;
	public MergeSort(int[] array)
	{
		arr = array;
	}
	public virtual void sort()
	{
		int size = arr.Length;
		int[] tempArray = new int[size];
		mergeSrt(arr, tempArray, 0, size - 1);
	}
	private void mergeSrt(int[] arr, int[] tempArray, int lowerIndex, int upperIndex)
	{
		if (lowerIndex >= upperIndex)
		{
			return;
		}
		int middleIndex = (lowerIndex + upperIndex) / 2;
		mergeSrt(arr, tempArray, lowerIndex, middleIndex);
		mergeSrt(arr, tempArray, middleIndex + 1, upperIndex);
		merge(arr, tempArray, lowerIndex, middleIndex, upperIndex);
	}

	private void merge(int[] arr, int[] tempArray, int lowerIndex, int middleIndex, int upperIndex)
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
}