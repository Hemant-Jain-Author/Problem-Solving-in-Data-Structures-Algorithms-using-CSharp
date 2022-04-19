using System;

public class OptimalBST
{
    private static int OptCost(int[] freq, int i, int j)
    {
        if (i > j)
        {
            return 0;
        }

        if (j == i) // one element in this subarray
        {
            return freq[i];
        }

    int min = int.MaxValue;
    for (int r = i; r <= j; r++)
    {
            min = Math.Min(min, OptCost(freq, i, r - 1) + OptCost(freq, r + 1, j));
    }
    return min + sum(freq, i, j);
    }

    public static int OptCost(int[] keys, int[] freq)
    {
        int n = freq.Length;
        return OptCost(freq, 0, n - 1);
    }

    public static int OptCostTD(int[] keys, int[] freq)
    {
        int n = freq.Length;
        int[, ] cost = new int[n, n];
        for(int i=0; i<n; i++)
            for(int j=0;j<n;j++)
                cost[i, j] = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            cost[i, i] = freq[i];
        }

        return OptCostTD(freq, cost, 0, n - 1);
    }

    private static int OptCostTD(int[] freq, int[, ] cost, int i, int j)
    {
        if (i > j)
        {
            return 0;
        }

        if (cost[i, j] != int.MaxValue)
        {
            return cost[i, j];
        }

        int s = sum(freq, i, j);
        for (int r = i; r <= j; r++)
        {
            cost[i, j] = Math.Min(cost[i, j], OptCostTD(freq,cost, i, r - 1) + OptCostTD(freq,cost, r + 1, j) + s);
        }
        return cost[i, j];
    }

    private static int sum(int[] freq, int i, int j)
    {
        int s = 0;
        for (int k = i; k <= j; k++)
        {
            s += freq[k];
        }
        return s;
    }

    private static int[] SumInit(int[] freq, int n)
    {
        int[] sum = new int[n];
        sum[0] = freq[0];
        for (int i = 1; i < n; i++)
        {
            sum[i] = sum[i - 1] + freq[i];
        }
        return sum;
    }

    private static int SumRange(int[] sum, int i, int j)
    {
        if (i == 0)
        {
            return sum[j];
        }
        return sum[j] - sum[i - 1];
    }

    public static int OptCostBU(int[] keys, int[] freq)
    {
        int n = freq.Length;
        int[, ] cost = new int[n, n];

        for(int i=0; i<n; i++)
            for(int j=0;j<n;j++)
                cost[i, j] = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            cost[i, i] = freq[i];
        }

        int sm = 0;
        for (int l = 1; l < n; l++)
        { // l is length of range.
            for (int i = 0, j = i + l; j < n; i++, j++)
            {
                sm = sum(freq, i, j);
                for (int r = i; r <= j; r++)
                {
                    cost[i, j] = Math.Min(cost[i, j], sm + ((r - 1 >= i)? cost[i, r - 1] : 0) + ((r + 1 <= j)? cost[r + 1, j] : 0));
                }
            }
        }
        return cost[0, n - 1];
    }



    public static int OptCostBU2(int[] keys, int[] freq)
    {
        int n = freq.Length;
        int[, ] cost = new int[n, n];
        for(int i=0; i<n; i++)
            for(int j=0;j<n;j++)
                cost[i, j] = int.MaxValue;

        int[] sumArr = SumInit(freq, n);
        for (int i = 0; i < n; i++)
        {
            cost[i, i] = freq[i];
        }

        int sm = 0;
        for (int l = 1; l < n; l++)
        { // l is length of range.
            for (int i = 0, j = i + l; j < n; i++, j++)
            {
                sm = SumRange(sumArr, i, j);
                for (int r = i; r <= j; r++)
                {
                    cost[i, j] = Math.Min(cost[i, j], sm + ((r - 1 >= i)? cost[i, r - 1] : 0) + ((r + 1 <= j)? cost[r + 1, j] : 0));
                }
            }
        }
        return cost[0, n - 1];
    }

    public static void Main(string[] args)
    {
        int[] keys = new int[] {9, 15, 25};
        int[] freq = new int[] {30, 10, 40};
        Console.WriteLine("OBST cost:" + OptCost(keys, freq));
        Console.WriteLine("OBST cost:" + OptCostTD(keys, freq));
        Console.WriteLine("OBST cost:" + OptCostBU(keys, freq));
        Console.WriteLine("OBST cost:" + OptCostBU2(keys, freq));
    }
}

/*
OBST cost:130
OBST cost:130
OBST cost:130
OBST cost:130
*/