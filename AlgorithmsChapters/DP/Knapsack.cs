using System;

public class Knapsack
{
    public static int MaxCost01Knapsack(int[] wt, int[] cost, int capacity)
    {
        return MaxCost01KnapsackUtil(wt, cost, wt.Length, capacity);
    }

    private static int MaxCost01KnapsackUtil(int[] wt, int[] cost, int n, int capacity)
    {
        // Base Case
        if (n == 0 || capacity == 0)
            return 0;

        // Return the maximum of two cases:
        // (1) nth item is included
        // (2) nth item is not included
        int first = 0;
        if (wt[n - 1] <= capacity)
            first = cost[n - 1] + MaxCost01KnapsackUtil(wt, cost, n - 1, capacity - wt[n - 1]);

        int second = MaxCost01KnapsackUtil(wt, cost, n - 1, capacity);
        return Math.Max(first, second);
    }

    public static int MaxCost01KnapsackTD(int[] wt, int[] cost, int capacity)
    {
        int n = wt.Length;
        int[,] dp = new int[capacity + 1, n + 1];
        return MaxCost01KnapsackTD(dp, wt, cost, n, capacity);
    }

    private static int MaxCost01KnapsackTD(int[,] dp, int[] wt, int[] cost, int i, int w)
    {
        if (w == 0 || i == 0)
            return 0;

        if (dp[w, i] != 0)
            return dp[w, i];

        // Their are two cases:
        // (1) ith item is included
        // (2) ith item is not included
        int first = 0;
        if (wt[i - 1] <= w)
            first = MaxCost01KnapsackTD(dp, wt, cost, i - 1, w - wt[i - 1]) + cost[i - 1];

        int second = MaxCost01KnapsackTD(dp, wt, cost, i - 1, w);
        return dp[w, i] = Math.Max(first, second);
    }

    public static int MaxCost01KnapsackBU(int[] wt, int[] cost, int capacity)
    {
        int n = wt.Length;
        int[,] dp = new int[capacity + 1, n + 1];

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
                    first = dp[w - wt[i - 1], i - 1] + cost[i - 1];

                int second = dp[w, i - 1];
                dp[w, i] = Math.Max(first, second);
            }
        }
        PrintItems(dp, wt, cost, n, capacity);
        return dp[capacity, n]; // Number of weights considered and final capacity.
    }

    private static void PrintItems(int[,] dp, int[] wt, int[] cost, int n, int capacity)
    {
        int totalCost = dp[capacity, n];
        Console.Write("Selected items are:");
        for (int i = n - 1; i > 0; i--)
        {
            if (totalCost != dp[capacity, i - 1])
            {
                Console.Write(" (wt:" + wt[i] + ", cost:" + cost[i] + ")");
                capacity -= wt[i];
                totalCost -= cost[i];
            }
        }
        Console.WriteLine();
    }

    public static int KS01UnboundBU(int[] wt, int[] cost, int capacity)
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

    // Testing code.
    public static void Main(string[] args)
    {
        int[] wt = new int[] { 10, 40, 20, 30 };
        int[] cost = new int[] { 60, 40, 90, 120 };
        int capacity = 50;

        double maxCost = MaxCost01Knapsack(wt, cost, capacity);
        Console.WriteLine("Maximum cost obtained = " + maxCost);
        maxCost = MaxCost01KnapsackBU(wt, cost, capacity);
        Console.WriteLine("Maximum cost obtained = " + maxCost);
        maxCost = MaxCost01KnapsackTD(wt, cost, capacity);
        Console.WriteLine("Maximum cost obtained = " + maxCost);
    }
}

/*
Maximum cost obtained = 210
Selected items are: (wt:30, cost:120) (wt:20, cost:90)
Maximum cost obtained = 210
Maximum cost obtained = 210
*/