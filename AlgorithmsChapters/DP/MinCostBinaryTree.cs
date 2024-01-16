using System;

public class MinCostBinaryTree
{
    private static int MaxVal(int[,] max, int i, int j)
    {
        if (max[i, j] != int.MinValue)
            return max[i, j];

        for (int k = i; k < j; k++)
            max[i, j] = Math.Max(max[i, j], Math.Max(MaxVal(max, i, k), MaxVal(max, k + 1, j)));

        return max[i, j];
    }

    private static int MinCostBstTD(int[,] dp, int[,] max, int i, int j, int[] arr)
    {
        if (j <= i)
            return 0;

        if (dp[i, j] != int.MaxValue)
            return dp[i, j];

        for (int k = i; k < j; k++)
            dp[i, j] = Math.Min(dp[i, j], MinCostBstTD(dp, max, i, k, arr) + MinCostBstTD(dp, max, k + 1, j, arr) + MaxVal(max, i, k) * MaxVal(max, k + 1, j));

        return dp[i, j];
    }

    public static int MinCostBstTD(int[] arr)
    {
        int n = arr.Length;
        int[,] dp = new int[n, n];
        int[,] max = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                dp[i, j] = int.MaxValue;

                if (i != j)
                    max[i, j] = int.MinValue;
                else
                    max[i, i] = arr[i];
            }
        }
        return MinCostBstTD(dp, max, 0, n - 1, arr);
    }

    public static int MinCostBstBU(int[] arr)
    {
        int n = arr.Length;
        int[,] dp = new int[n, n];
        int[,] max = new int[n, n];
        for (int i = 0; i < n; i++)
            max[i, i] = arr[i];

        for (int l = 1; l < n; l++) // l is length of range.
        {
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

    // Testing code.
    public static void Main(string[] args)
    {
        int[] arr = new int[] { 6, 2, 4 };
        Console.WriteLine("Total cost: " + MinCostBstTD(arr));
        Console.WriteLine("Total cost: " + MinCostBstBU(arr));
    }
}

/*
Total cost: 32
Total cost: 32
*/