using System;

public class GridMinCost
{
    private static int Min(int x, int y, int z)
    {
        x = Math.Min(x, y);
        return Math.Min(x, z);
    }

    public static int MinCost(int[, ] cost, int m, int n)
    {
        if (m == 0 || n == 0)
        {
            return 99999;
        }

        if(m == 1 && n == 1) {
            return cost[0, 0];
        }

        return cost[m - 1, n - 1] + Min(MinCost(cost, m - 1, n - 1), MinCost(cost, m - 1, n), MinCost(cost, m, n - 1));
    }

    public static int MinCostBU(int[, ] cost, int m, int n)
    {
        int[, ] tc  = new int[m, n];
        tc[0, 0] = cost[0, 0];

        // Initialize first column.
        for (int i = 1; i < m; i++)
        {
            tc[i, 0] = tc[i - 1, 0] + cost[i, 0];
        }
        // Initialize first row.
        for (int j = 1; j < n; j++)
        {
            tc[0, j] = tc[0, j - 1] + cost[0, j];
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                tc[i, j] = cost[i, j] + Min(tc[i - 1, j - 1], tc[i - 1, j], tc[i, j - 1]);
            }
        }
        return tc[m - 1, n - 1];
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int[, ] cost = new int[, ]
        {
            {1, 3, 4},
            {4, 7, 5},
            {1, 5, 3}
        };

        Console.WriteLine(MinCost(cost, 3, 3));
        Console.WriteLine(MinCostBU(cost, 3, 3));

    }
}

/*
11
11
*/