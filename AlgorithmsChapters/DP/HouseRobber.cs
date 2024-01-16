using System;

public class HouseRobber
{
    public static int MaxRobbery(int[] house)
    {
        int n = house.Length;
        int[] dp = new int[n];
        dp[0] = house[0];
        dp[1] = house[1];
        dp[2] = dp[0] + house[2];
        for (int i = 3; i < n; i++)
        {
            dp[i] = Math.Max(dp[i - 2], dp[i - 3]) + house[i];
        }
        return Math.Max(dp[n - 1], dp[n - 2]);
    }

    public static int MaxRobbery2(int[] house)
    {
        int n = house.Length;
        int[,] dp = new int[n, 2];

        dp[0, 1] = house[0];
        dp[0, 0] = 0;

        for (int i = 1; i < n; ++i)
        {
            dp[i, 1] = Math.Max(dp[i - 1, 0] + house[i], dp[i - 1, 1]);
            dp[i, 0] = dp[i - 1, 1];
        }
        return Math.Max(dp[n - 1, 1], dp[n - 1, 0]);
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int[] arr = new int[] { 10, 12, 9, 23, 25, 55, 49, 70 };
        Console.WriteLine("Total cash: " + MaxRobbery(arr));
        Console.WriteLine("Total cash: " + MaxRobbery2(arr));
    }
}

/*
Total cash: 160
Total cash: 160
*/