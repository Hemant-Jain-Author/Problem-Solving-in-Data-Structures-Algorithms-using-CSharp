using System;

public class CoinChange
{
    public static int MinCoins(int[] coins, int n, int val)
    { // Greedy may be wrong.
        if (val <= 0)
        {
            return 0;
        }

        int count = 0;
        Array.Sort(coins);

        for (int i = n - 1; i >= 0 && val > 0;)
        {
            if (coins[i] <= val)
            {
                count++;
                val -= coins[i];
            }
            else
            {
                i--;
            }
        }
        return (val == 0)? count : -1;
    }

    public static int MinCoins2(int[] coins, int n, int val)
    { // Brute force.
        if (val == 0)
        {
            return 0;
        }

        int count = int.MaxValue;
        for (int i = 0; i < n ; i++)
        {
            if (coins[i] <= val)
            {
                int subCount = MinCoins2(coins, n, val - coins[i]);
                if (subCount >= 0)
                {
                    count = Math.Min(count, subCount + 1);
                }
            }
        }
        return (count != int.MaxValue)? count : -1;
    }

    public static int MinCoinsTD(int[] coins, int n, int val)
    {
        int[] dp = new int[val + 1];
        Array.Fill(dp, int.MaxValue);
        return MinCoinsTD(dp, coins, n, val);
    }

    private static int MinCoinsTD(int[] dp, int[] coins, int n, int val)
    {
        // Base Case
        if (val == 0)
        {
            return 0;
        }

        if (dp[val] != int.MaxValue)
        {
            return dp[val];
        }

        // Recursion
        for (int i = 0; i < n; i++)
        {
            if (coins[i] <= val)
            { // check validity of a sub-problem
                int subCount = MinCoinsTD(dp, coins, n, val - coins[i]);
                if (subCount != int.MaxValue)
                {
                    dp[val] = Math.Min(dp[val], subCount + 1);
                }
            }
        }
        return dp[val];
    }


    public static int MinCoinsBU(int[] coins, int n, int val)
    { // DP bottom up approach.
        int[] dp = new int[val + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0; // Base value.

        for (int i = 1; i <= val; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // For all coins smaller than or equal to i.
                if (coins[j] <= i)
                {
                    if (dp[i - coins[j]] != int.MaxValue)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }
        }
        return (dp[val] != int.MaxValue)? dp[val] : -1;
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int[] coins = new int[] {5, 6};
        int value = 16;
        int n = coins.Length;
        Console.WriteLine("Count is:" + MinCoins(coins, n, value));
        Console.WriteLine("Count is:" + MinCoins2(coins, n, value));
        Console.WriteLine("Count is:" + MinCoinsBU(coins, n, value));
        Console.WriteLine("Count is:" + MinCoinsTD(coins, n, value));
    }

    // Testing code.
    public static void main1(string[] args)
    {
        int[] coins = new int[] {1, 5, 6, 9, 12};
        int value = 15;
        int n = coins.Length;
        Console.WriteLine("Count is:" + MinCoins(coins, n, value));
        Console.WriteLine("Count is:" + MinCoins2(coins, n, value));
        Console.WriteLine("Count is:" + MinCoinsBU(coins, n, value));
        Console.WriteLine("Count is:" + MinCoinsTD(coins, n, value));
    }

    // Testing code.
    public static void main2(string[] args)
    {
        int[] coins = new int[] {1, 5, 6, 9, 11};
        int v = 15;
        int n = coins.Length;
        MinCoins(coins, n, v);
        MinCoins2(coins, n, v);
        MinCoinsBU(coins, n, v);
    }
}

/*
Count is:-1
Count is:3
Count is:3
Count is:3
*/