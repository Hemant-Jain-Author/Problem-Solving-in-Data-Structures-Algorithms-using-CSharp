using System;

public class EditDist
{
    private static int Min(int x, int y, int z)
    {
        x = Math.Min(x, y);
        return Math.Min(x, z);
    }

    public static int FindEditDist(string str1, string str2)
    {
        int m = str1.Length;
        int n = str2.Length;
        return FindEditDist(str1, str2, m, n);
    }

    private static int FindEditDist(string str1, string str2, int m, int n)
    {
        if (m == 0 || n == 0) // If any one string is empty, then empty the other string.
        {
            return m + n;
        }

        // If last characters of both strings are same, ignore last characters.
        if (str1[m - 1] == str2[n - 1])
        {
            return FindEditDist(str1, str2, m - 1, n - 1);
        }

        // If last characters are not same, 
        // consider all three operations:
        // Insert last char of second into first.
        // Remove last char of first.
        // Replace last char of first with second.
        return 1 + Min(FindEditDist(str1, str2, m, n - 1), FindEditDist(str1, str2, m - 1, n), FindEditDist(str1, str2, m - 1, n - 1)); // Replace
    }

    public static int FindEditDistDP(string str1, string str2)
    {
        int m = str1.Length;
        int n = str2.Length;
        int[, ] dp = new int[m + 1, n + 1];

        // Fill dp[, ] in bottom up manner.
        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                // If any one string is empty, then empty the other string.
                if (i == 0 || j == 0)
                {
                    dp[i, j] = (i + j);
                }
                // If last characters of both strings are same, ignore last characters.
                else if (str1[i - 1] == str2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                // If last characters are not same, consider all three operations:
                // Insert last char of second into first.
                // Remove last char of first.
                // Replace last char of first with second.
                else
                {
                    dp[i, j] = 1 + Min(dp[i, j - 1], dp[i - 1, j], dp[i - 1, j - 1]); // Replace
                }
            }
        }
        return dp[m, n];
    }

    // Testing code.
    public static void Main(string[] args)
    {
        string str1 = "sunday";
        string str2 = "saturday";
        Console.WriteLine(FindEditDist(str1, str2));
        Console.WriteLine(FindEditDistDP(str1, str2));
    }
}

/*
3
3
*/