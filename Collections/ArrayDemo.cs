using System;

public class ArrayDemo
{
	private static void onedimension()
	{
		int[] arr = new int[10];
		for (int i = 0; i < 10; i++)
		{
			arr[i] = i;
		}
		for (int i = 0; i < 10; i++)
		{
			Console.WriteLine(arr[i]);
		}

	}


	private static void twodimension()
	{
		int[,] arr = new int[4, 4];

		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				arr[i, j] = i + j;
			}
		}

		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				Console.Write(arr[i, j]);
			}
			Console.WriteLine(" ");
		}
	}

	public static void Main(string[] args)
	{
		onedimension();
		twodimension();
	}
}