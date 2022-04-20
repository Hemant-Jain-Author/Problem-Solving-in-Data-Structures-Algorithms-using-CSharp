using System;

public class GridUniqueWays
{
    public static int UniqueWays(int m, int n)
    {
        int[, ] dp = new int[m, n];
        dp[0, 0] = 1;

        // Initialize first column.
        for (int i = 1; i < m; i++)
        {
            dp[i, 0] = dp[i - 1, 0];
        }
        // Initialize first row.
        for (int j = 1; j < n; j++)
        {
            dp[0, j] = dp[0, j - 1];
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }
        return dp[m - 1, n - 1];
    }

    // Diagonal movement allowed.
    public static int Unique3Ways(int m, int n)
    {
        int[, ] dp = new int[m, n];
        dp[0, 0] = 1;

        // Initialize first column.
        for (int i = 1; i < m; i++)
        {
            dp[i, 0] = dp[i - 1, 0];
        }
        // Initialize first row.
        for (int j = 1; j < n; j++)
        {
            dp[0, j] = dp[0, j - 1];
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j] + dp[i, j - 1];
            }
        }
        return dp[m - 1, n - 1];
    }

    // Testing code.
    public static void Main(string[] args)
    {
        Console.WriteLine(UniqueWays(3, 3));
        Console.WriteLine(Unique3Ways(3, 3));

    }
}

/*
6
13
*/