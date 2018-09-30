internal static class RectangularArrays
{
	internal static int[][] ReturnRectangularIntArray(int size1, int size2)
	{
		int[][] newArray = new int[size1][];
		for (int array1 = 0; array1 < size1; array1++)
		{
			newArray[array1] = new int[size2];
		}

		return newArray;
	}
}