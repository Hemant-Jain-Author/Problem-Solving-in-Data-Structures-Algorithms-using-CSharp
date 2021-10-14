using System;

public class LargestIncreasingSubseq
{
	public static int LIS(int[] arr)
	{
		int n = arr.Length;
		int[] lis = new int[n];
		int max = 0;

		// Populating LIS values in bottom up manner.
		for (int i = 0; i < n; i++)
		{
			lis[i] = 1; // Initialize LIS values for all indexes as 1.
			for (int j = 0; j < i; j++)
			{
				if (arr[j] < arr[i] && lis[i] < lis[j] + 1)
				{
					lis[i] = lis[j] + 1;
				}
			}
			if (max < lis[i]) // Max LIS values.
			{
				max = lis[i];
			}
		}
		return max;
	}

	public static void Main(string[] args)
	{
		int[] arr = new int[] {10, 12, 9, 23, 25, 55, 49, 70};
		Console.WriteLine("Length of LIS is " + LIS(arr));
	}
}

// Length of lis is 6
