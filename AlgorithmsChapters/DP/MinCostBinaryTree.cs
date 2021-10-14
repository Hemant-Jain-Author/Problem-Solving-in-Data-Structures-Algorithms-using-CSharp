using System;

public class MinCostBinaryTree
{
	private static int MaxVal(int[, ] max, int i, int j)
	{
		if (max[i, j] != int.MinValue)
		{
			return max[i, j];
		}

		for (int k = i;k < j;k++)
		{
			max[i, j] = Math.Max(max[i, j], Math.Max(MaxVal(max, i, k), MaxVal(max, k + 1, j)));
		}
		return max[i, j];
	}

	private static int FindSumTD(int[, ] dp, int[, ] max, int i, int j, int[] arr)
	{
	if (j <= i)
	{
		return 0;
	}

	if (dp[i, j] != int.MaxValue)
	{
		return dp[i, j];
	}

	for (int k = i;k < j;k++)
	{
		dp[i, j] = Math.Min(dp[i, j], FindSumTD(dp, max, i, k, arr) + FindSumTD(dp, max, k + 1, j, arr) + MaxVal(max, i, k) * MaxVal(max, k + 1,j));
	}
	return dp[i, j];
	}

	public static int FindSumTD(int[] arr)
	{
		int n = arr.Length;
		int[, ] dp = new int[n, n];

		for(int i=0; i<n; i++)
			for(int j=0;j<n;j++)
				dp[i, j] = int.MaxValue;

		int[, ] max = new int[n, n];
		for(int i=0; i<n; i++)
			for(int j=0;j<n;j++)
				max[i, j] = int.MinValue;

		for (int i = 0;i < n;i++)
		{
			max[i, i] = arr[i];
		}

		return FindSumTD(dp, max, 0, n - 1, arr);
	}

	public static int FindSumBU(int[] arr)
	{
		int n = arr.Length;
		int[, ] dp = new int[n, n];

		int[, ] max = new int[n, n];
		for (int i = 0;i < n;i++)
		{
			max[i, i] = arr[i];
		}

		for (int l = 1; l < n; l++)
		{ // l is length of range.
			for (int i = 0, j = i + l; j < n; i++, j++)
			{
				dp[i, j] = int.MaxValue;
				for (int k = i; k < j; k++)
				{
					dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k + 1, j] + max[i, k] * max[k + 1, j]);
					max[i, j] = Math.Max(max[i, k], max[k + 1, j]);
				}
			}
		}
		return dp[0, n - 1];
	}

	public static void Main(string[] args)
	{
		int[] arr = new int[] {6, 2, 4};
		Console.WriteLine("Total cost: " + FindSumTD(arr));
		Console.WriteLine("Total cost: " + FindSumBU(arr));
	}
}

/*
Total cost: 32
Total cost: 32
*/