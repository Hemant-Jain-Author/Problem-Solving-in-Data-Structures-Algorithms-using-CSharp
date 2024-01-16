using System;

public class StockBuySell
{
    public static int maxProfit(int[] arr)
    {
        int buyProfit = -arr[0]; // Buy stock profit
        int sellProfit = 0; // Sell stock profit
        int n = arr.Length;
        for (int i = 1;i < n;i++)
        {
            int newBuyProfit = (sellProfit - arr[i] > buyProfit)? sellProfit - arr[i] : buyProfit;
            int newSellProfit = (buyProfit + arr[i] > sellProfit)? buyProfit + arr[i] : sellProfit;
            buyProfit = newBuyProfit;
            sellProfit = newSellProfit;
        }
        return sellProfit;
    }

    public static int maxProfitTC(int[] arr, int t)
    {
        int buyProfit = -arr[0];
        int sellProfit = 0;
        int n = arr.Length;
        for (int i = 1;i < n;i++)
        {
            int newBuyProfit = ((sellProfit - arr[i]) > buyProfit) ? (sellProfit - arr[i]) : buyProfit;
            int newSellProfit = ((buyProfit + arr[i] - t) > sellProfit) ? (buyProfit + arr[i] - t) : sellProfit;
            buyProfit = newBuyProfit;
            sellProfit = newSellProfit;
        }
        return sellProfit;
    }

    public static int maxProfit2(int[] arr)
    {
        int n = arr.Length;
        int[, ] dp = new int[n, 2];
        dp[0, 0] = -arr[0]; // Buy stock profit
        dp[0, 1] = 0; // Sell stock profit

        for (int i = 1;i < n;i++)
        {
            dp[i, 0] = (dp[i - 1, 1] - arr[i] > dp[i - 1, 0]) ? dp[i - 1, 1] - arr[i] : dp[i - 1, 0];
            dp[i, 1] = (dp[i - 1, 0] + arr[i] > dp[i - 1, 1]) ? dp[i - 1, 0] + arr[i] : dp[i - 1, 1];
        }
        return dp[n - 1, 1];
    }

    public static int maxProfitTC2(int[] arr, int t)
    {
        int n = arr.Length;
        int[, ] dp = new int[n, 2];
        dp[0, 0] = -arr[0];
        dp[0, 1] = 0;

        for (int i = 1;i < n;i++)
        {
            dp[i, 0] = ((dp[i - 1, 1] - arr[i]) > dp[i - 1, 0]) ? (dp[i - 1, 1] - arr[i]) : dp[i - 1, 0];
            dp[i, 1] = ((dp[i - 1, 0] + arr[i] - t) > dp[i - 1, 1]) ? (dp[i - 1, 0] + arr[i] - t) : dp[i - 1, 1];
        }
        return dp[n - 1, 1];
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int[] arr = new int[] {10, 12, 9, 23, 25, 55, 49, 70};
        Console.WriteLine("Total profit: " + maxProfit(arr));
        Console.WriteLine("Total profit: " + maxProfit2(arr));
        Console.WriteLine("Total profit: " + maxProfitTC(arr, 2));
        Console.WriteLine("Total profit: " + maxProfitTC2(arr, 2));
    }
}

/*
Total profit: 69
Total profit: 69
Total profit: 63
Total profit: 63
*/