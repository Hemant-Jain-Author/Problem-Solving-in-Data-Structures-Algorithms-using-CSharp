using System;

public class Fibo
{
	public static int Fibonacci(int n)
	{
		if (n <= 2)
		{
			return n - 1;
		}
		return Fibonacci(n - 1) + Fibonacci(n - 2);
	}

	public static void FibonacciSeries(int n)
	{
		for (int i = 1;i <= n;i++)
		{
			Console.Write(Fibonacci(i) + " ");
		}
	}


	public static int FibonacciBU(int n)
	{
		if (n <= 2)
		{
			return n - 1;
		}

		int first = 0, second = 1;
		int temp = 0;

		for (int i = 2; i < n; i++)
		{
			temp = first + second;
			first = second;
			second = temp;
		}
		return temp;
	}

	public static void FibonacciSeriesBU(int n)
	{
		if (n < 1)
		{
			return;
		}

		int[] dp = new int[n];
		dp[0] = 0;
		dp[1] = 1;

		for (int i = 2; i < n; i++)
		{
			dp[i] = dp[i - 2] + dp[i - 1];
		}

		for (int i = 0;i < n;i++)
		{
			Console.Write(dp[i] + " ");
		}
	}

	public static void FibonacciSeriesTD(int n)
	{
		if (n < 1)
		{
			return;
		}
		int[] dp = new int[n];

		FibonacciSeriesTD(n - 1, dp);

		for (int i = 0;i < n;i++)
		{
			Console.Write(dp[i] + " ");
		}
	}

	private static int FibonacciSeriesTD(int n, int[] dp)
	{
		if (n <= 1)
		{
			return dp[n] = n;
		}

		if (dp[n] != 0)
		{
			return dp[n];
		}

		dp[n] = FibonacciSeriesTD(n - 1, dp) + FibonacciSeriesTD(n - 2, dp);
		return dp[n];
	}

	public static void Main(string[] args)
	{
		
		FibonacciSeries(6);
		Console.WriteLine();

		FibonacciSeriesBU(6);
		Console.WriteLine();

		FibonacciSeriesTD(6);
		Console.WriteLine();

		Console.WriteLine(Fibonacci(6));
		Console.WriteLine(FibonacciBU(6));
	}
}

/*
0 1 1 2 3 5 
0 1 1 2 3 5 
0 1 1 2 3 5 
5
5
*/