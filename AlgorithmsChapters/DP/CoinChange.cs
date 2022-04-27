using System;

public class CoinChange
{
    public static int MinCoins(int[] coins, int n, int val) // Greedy may be wrong.
    {
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
        return (val == 0) ? count : -1;
    }

    public static int MinCoins2(int[] coins, int n, int val) // Brute force.
    {
        if (val == 0)
        {
            return 0;
        }

        int count = int.MaxValue;
        for (int i = 0; i < n; i++)
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
        return (count != int.MaxValue) ? count : -1;
    }

    public static int MinCoinsTD(int[] coins, int n, int val)
    {
        int[] count = new int[val + 1];
        Array.Fill(count, int.MaxValue);
        count[0] = 0; // zero val need zero coins.
        return MinCoinsTD(count, coins, n, val);
    }

    private static int MinCoinsTD(int[] count, int[] coins, int n, int val) // DP top down approach.
    {
        // Base Case
        if (count[val] != int.MaxValue)
        {
            return count[val];
        }

        // Recursion
        for (int i = 0; i < n; i++)
        {
            if (coins[i] <= val)
            { // check validity of a sub-problem
                int subCount = MinCoinsTD(count, coins, n, val - coins[i]);
                if (subCount != int.MaxValue)
                {
                    count[val] = Math.Min(count[val], subCount + 1);
                }
            }
        }
        return count[val];
    }


    public static int MinCoinsBU(int[] coins, int n, int val) // DP bottom up approach.
    {
        int[] count = new int[val + 1];
        Array.Fill(count, int.MaxValue);
        count[0] = 0; // Base value.

        for (int i = 1; i <= val; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // For all coins smaller than or equal to i.
                if (coins[j] <= i && count[i - coins[j]] != int.MaxValue && count[i] > count[i - coins[j]] + 1)
                {
                    count[i] = count[i - coins[j]] + 1;
                }
            }
        }
        return (count[val] != int.MaxValue) ? count[val] : -1;
    }


    public static int MinCoinsBU2(int[] coins, int n, int val) // DP bottom up approach.
    {
        int[] count = new int[val + 1];
        int[] cvalue = new int[val + 1];

        Array.Fill(count, int.MaxValue);
        Array.Fill(cvalue, int.MaxValue);
        count[0] = 0; // Base value.

        for (int i = 1; i <= val; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // For all coins smaller than or equal to i.
                if (coins[j] <= i && count[i - coins[j]] != int.MaxValue && count[i] > count[i - coins[j]] + 1)
                {
                    count[i] = count[i - coins[j]] + 1;
                    cvalue[i] = coins[j];
                }
            }
        }
        if (count[val] == int.MaxValue)
            return -1;

        printCoins(cvalue, val);
        return count[val];
    }

    static void printCoinsUtil(int[] cvalue, int val)
    {
        if (val > 0)
        {
            printCoinsUtil(cvalue, val - cvalue[val]);
            Console.Write(cvalue[val] + " ");
        }
    }

    static void printCoins(int[] cvalue, int val)
    {
        Console.Write("Coins are : ");
        printCoinsUtil(cvalue, val);
        Console.WriteLine();
    }

    // Testing code.
    public static void Main1()
    {
        int[] coins = new int[] { 5, 6 };
        int value = 16;
        int n = coins.Length;
        Console.WriteLine("Count is:" + MinCoins(coins, n, value));
        Console.WriteLine("Count is:" + MinCoins2(coins, n, value));
        Console.WriteLine("Count is:" + MinCoinsBU(coins, n, value));
        Console.WriteLine("Count is:" + MinCoinsBU2(coins, n, value));
        Console.WriteLine("Count is:" + MinCoinsTD(coins, n, value));
    }

    // Testing code.
    public static void Main2()
    {
        int[] coins = new int[] { 1, 5, 6, 9, 12 };
        int value = 15;
        int n = coins.Length;
        Console.WriteLine("Count is:" + MinCoins(coins, n, value));
        Console.WriteLine("Count is:" + MinCoins2(coins, n, value));
        Console.WriteLine("Count is:" + MinCoinsBU(coins, n, value));
        Console.WriteLine("Count is:" + MinCoinsBU2(coins, n, value));
        Console.WriteLine("Count is:" + MinCoinsTD(coins, n, value));
    }

    // Testing code.
    public static void Main3()
    {
        int[] coins = new int[] { 1, 5, 6, 9, 11 };
        int value = 16;
        int n = coins.Length;
        Console.WriteLine("Count is:" + MinCoins(coins, n, value));
        Console.WriteLine("Count is:" + MinCoins2(coins, n, value));
        Console.WriteLine("Count is:" + MinCoinsBU(coins, n, value));
        Console.WriteLine("Count is:" + MinCoinsBU2(coins, n, value));
        Console.WriteLine("Count is:" + MinCoinsTD(coins, n, value));
    }

    public static void Main(string[] args)
    {
        //Main1();
        Main2();
        //Main3();
    }
}

/*
Count is:-1
Count is:3
Count is:3
Count is:3
*/