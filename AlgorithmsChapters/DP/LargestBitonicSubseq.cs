using System;

public class LargestBitonicSubseq
{
	public static int LBS(int[] arr)
	{
		int n = arr.Length;
		int[] lis = new int[n];
		Array.Fill(lis, 1); // Initialize LIS values for all indexes as 1.
		int[] lds = new int[n];
		Array.Fill(lds, 1); // Initialize LDS values for all indexes as 1.
		int max = 0;

		// Populating LIS values in bottom up manner.
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < i; j++)
			{
				if (arr[j] < arr[i] && lis[i] < lis[j] + 1)
				{
					lis[i] = lis[j] + 1;
				}
			}
		}

		// Populating LDS values in bottom up manner.
		for (int i = n - 1; i > 0; i--)
		{
			for (int j = n - 1; j > i; j--)
			{
				if (arr[j] < arr[i] && lds[i] < lds[j] + 1)
				{
					lds[i] = lds[j] + 1;
				}
			}
		}
		for (int i = 0; i < n; i++)
		{
			max = Math.Max(max, lis[i] + lds[i] - 1);
		}

		return max;
	}

	public static void Main(string[] args)
	{
		int[] arr = new int[] {1, 6, 3, 11, 1, 9, 5, 12, 3, 14, 6, 17, 3, 19, 2, 19};
		Console.WriteLine("Length of LBS is " + LBS(arr));
	}
}
/*
Length of LBS is 8
*/