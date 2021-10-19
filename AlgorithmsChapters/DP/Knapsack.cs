using System;

public class Knapsack
{
	public int GetMaxCost01(int[] wt, int[] cost, int capacity)
	{
		int n = wt.Length;
		return GetMaxCost01Util(wt, cost, n, capacity);
	}

	private int GetMaxCost01Util(int[] wt, int[] cost, int n, int capacity)
	{
		// Base Case
		if (n == 0 || capacity == 0)
		{
			return 0;
		}

		// Return the maximum of two cases:
		// (1) nth item is included
		// (2) nth item is not included
		int first = 0;
		if (wt[n - 1] <= capacity)
		{
			first = cost[n - 1] + GetMaxCost01Util(wt, cost, n - 1, capacity - wt[n - 1]);
		}

		int second = GetMaxCost01Util(wt, cost, n - 1, capacity);
		return Math.Max(first, second);
	}

	public int GetMaxCost01TD(int[] wt, int[] cost, int capacity)
	{
		int n = wt.Length;
		int[, ] dp = new int[capacity + 1, n + 1];
		return GetMaxCost01TD(dp, wt, cost, n, capacity);
	}

	private int GetMaxCost01TD(int[, ] dp, int[] wt, int[] cost, int i, int w)
	{
		if (w == 0 || i == 0)
		{
			return 0;
		}

		if (dp[w, i] != 0)
		{
			return dp[w, i];
		}

		// Their are two cases:
		// (1) ith item is included
		// (2) ith item is not included
		int first = 0;
		if (wt[i - 1] <= w)
		{
			first = GetMaxCost01TD(dp, wt, cost, i - 1, w - wt[i - 1]) + cost[i - 1];
		}

		int second = GetMaxCost01TD(dp, wt, cost, i - 1, w);
		return dp[w, i] = Math.Max(first,second);
	}

	public int GetMaxCost01BU(int[] wt, int[] cost, int capacity)
	{
		int n = wt.Length;
		int[, ] dp = new int[capacity + 1, n + 1];

		// Build table dp[, ] in bottom up approach.
		// Weights considered against capacity.
		for (int w = 1; w <= capacity; w++)
		{
			for (int i = 1; i <= n; i++)
			{
				// Their are two cases:
				// (1) ith item is included
				// (2) ith item is not included
				int first = 0;
				if (wt[i - 1] <= w)
				{
					first = dp[w - wt[i - 1], i - 1] + cost[i - 1];
				}

				int second = dp[w, i - 1];
				dp[w, i] = Math.Max(first,second);
			}
		}
		//PrintItems(dp, wt, cost, n, capacity);
		return dp[capacity, n]; // Number of weights considered and final capacity.
	}

	private void PrintItems(int[, ] dp, int[] wt, int[] cost, int n, int capacity)
	{
		int totalCost = dp[capacity, n];
		Console.Write("Selected items are:");
		for (int i = n - 1; i > 0 ; i--)
		{
			if (totalCost != dp[capacity, i - 1])
			{
				Console.Write(" (" + wt[i] + "," + cost[i] + ")");
				capacity -= wt[i];
				totalCost -= cost[i];
			}
		}
	}

	public int KS01UnboundBU(int[] wt, int[] cost, int capacity)
	{
		int n = wt.Length;
		int[] dp = new int[capacity + 1];

		// Build table dp[] in bottom up approach.
		// Weights considered against capacity.
		for (int w = 1; w <= capacity; w++)
		{
			for (int i = 1; i <= n; i++)
			{
				// Their are two cases:
				// (1) ith item is included 
				// (2) ith item is not included
				if (wt[i - 1] <= w)
				{
					dp[w] = Math.Max(dp[w], dp[w - wt[i - 1]] + cost[i - 1]);
				}
			}
		}
		//PrintItems(dp, wt, cost, n, capacity);
		return dp[capacity]; // Number of weights considered and final capacity.
	}

	public static void Main1(string[] args)
	{
		int[] wt = new int[] {5, 10, 15};
		int[] cost = new int[] {10, 30, 20};
		int capacity = 20;

		Knapsack kp = new Knapsack();

		double maxCost = kp.GetMaxCost01(wt, cost, capacity);
		Console.WriteLine("Maximum cost obtained = " + maxCost);
		maxCost = kp.GetMaxCost01BU(wt, cost, capacity);
		Console.WriteLine("Maximum cost obtained = " + maxCost);
		maxCost = kp.GetMaxCost01TD(wt, cost, capacity);
		Console.WriteLine("Maximum cost obtained = " + maxCost);
	}

	public static void Main(string[] args)
	{
		int[] wt = new int[] {10, 40, 20, 30};
		int[] cost = new int[] {60, 40, 90, 120};
		int capacity = 50;

		Knapsack kp = new Knapsack();

		double maxCost = kp.GetMaxCost01(wt, cost, capacity);
		Console.WriteLine("Maximum cost obtained = " + maxCost);
		maxCost = kp.GetMaxCost01BU(wt, cost, capacity);
		Console.WriteLine("Maximum cost obtained = " + maxCost);
		maxCost = kp.GetMaxCost01TD(wt, cost, capacity);
		Console.WriteLine("Maximum cost obtained = " + maxCost);
	}
}

/*
Maximum cost obtained = 210.0
Maximum cost obtained = 210.0
Maximum cost obtained = 210.0
*/