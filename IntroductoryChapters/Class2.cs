using System;

public class Introduction
{
	//public static void Main(string[] args)
	//{
	//	twoDArrayExample();
	//}

	//public static void twoDArrayExample()
	//{
	//	//ORIGINAL LINE: int[][] arr = new int[4][2];
	//	int[][] arr = TwoDArrays.Init(4, 2);
	//	int count = 0;
	//	for (int i = 0; i < 4; i++)
	//	{
	//		for (int j = 0; j < 2; j++)
	//		{
	//			arr[i][j] = count++;
	//		}
	//	}

	//	print2DArray(arr, 4, 2);
	//}

	public static void print2DArray(int[][] arr, int row, int col)
	{
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				Console.WriteLine(" " + arr[i][j]);
			}
		}
	}
	public static int[][] TwoDArraysInit(int size1, int size2)
	{
		int[][] newArray = new int[size1][];
		for (int array1 = 0; array1 < size1; array1++)
		{
			newArray[array1] = new int[size2];
		}

		return newArray;
	}
}


internal static class TwoDArrays
{
	internal static int[][] TwoDArraysInit(int size1, int size2)
	{
		int[][] newArray = new int[size1][];
		for (int array1 = 0; array1 < size1; array1++)
		{
			newArray[array1] = new int[size2];
		}

		return newArray;
	}
}

