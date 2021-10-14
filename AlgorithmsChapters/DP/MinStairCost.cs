using System;

public class MinStairCost
{
	public static int MinCost(int[] cost, int n)
	{
		// base case
		if (n == 1)
		{
			return cost[0];
		}

		int[] dp = new int[n];
		dp[0] = cost[0];
		dp[1] = cost[1];

		for (int i = 2; i < n; i++)
		{
			dp[i] = Math.Min(dp[i - 1], dp[i - 2]) + cost[i];
		}

		return Math.Min(dp[n - 2], dp[n - 1]);
	}

	public static void Main(string[] args)
	{
		int[] a = new int[] {1, 5, 6, 3, 4, 7, 9, 1, 2, 11};
		int n = a.Length;
		Console.Write(MinCost(a, n));
	}
}

/*
18
*/