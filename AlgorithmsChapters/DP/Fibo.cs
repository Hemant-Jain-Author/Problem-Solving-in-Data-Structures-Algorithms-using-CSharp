using System;

public class Fibo
{
	public static int Fibonacci(int n)
	{
		if (n < 2)
		{
			return n;
		}
		return Fibonacci(n - 1) + Fibonacci(n - 2);
	}


	public static int FibonacciBU2(int n)
	{
		if (n < 2)
		{
			return n;
		}

		int first = 0, second = 1;
		int temp = 0;

		for (int i = 2; i <= n; i++)
		{
			temp = first + second;
			first = second;
			second = temp;
		}
		return temp;
	}

	public static int FibonacciBU(int n)
	{
		if (n < 2)
		{
			return n;
		}

		int[] dp = new int[n+1];
		dp[0] = 0;
		dp[1] = 1;

		for (int i = 2; i <= n; i++)
		{
			dp[i] = dp[i - 2] + dp[i - 1];
		}

		return dp[n];
	}

	public static int FibonacciTD(int n)
	{
		int[] dp = new int[n+1];
		FibonacciTD(n, dp);
		return dp[n];
	}

	private static int FibonacciTD(int n, int[] dp)
	{
		if (n < 2)
			return dp[n] = n;

		if (dp[n] != 0)
			return dp[n];

		dp[n] = FibonacciTD(n-1, dp) + FibonacciTD(n-2, dp);
		return dp[n];
	}

	public static void Main(string[] args)
	{
		Console.WriteLine(Fibonacci(10));
		Console.WriteLine(FibonacciBU2(10));
		Console.WriteLine(FibonacciBU(10));
		Console.WriteLine(FibonacciTD(10));
	}
}

/*
55
55
55
55
*/