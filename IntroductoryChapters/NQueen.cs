using System;

public class NQueen
{
	bool isPrime(int n)
	{
		bool answer = (n > 1) ? true : false;

		for (int i = 2; i * i <= n; ++i)
		{
			if (n % i == 0)
			{
				answer = true;
				break;
			}
		}
		return answer;
	}


	public static void print(int[] Q, int n)
	{
		for (int i = 0; i < n; i++)
		{
			Console.Write(" " + Q[i]);
		}
		Console.WriteLine(" ");
	}
	public static bool Feasible(int[] Q, int k)
	{
		for (int i = 0; i < k; i++)
		{
			if (Q[k] == Q[i] || Math.Abs(Q[i] - Q[k]) == Math.Abs(i - k))
			{
				return false;
			}
		}
		return true;
	}
	public static void NQueens(int[] Q, int k, int n)
	{
		if (k == n)
		{
			print(Q, n);
			return;
		}
		for (int i = 0; i < n; i++)
		{
			Q[k] = i;
			if (Feasible(Q, k))
			{
				NQueens(Q, k + 1, n);
			}
		}
	}

	public static void Main(string[] args)
	{
		int[] Q = new int[8];
		NQueens(Q, 0, 8);
		TowersOfHanoi(3);
	}

	public static void TOHUtil(int num, char from, char to, char temp)
	{
		if (num < 1)
		{
			return;
		}

		TOHUtil(num - 1, from, temp, to);
		Console.WriteLine("Move disk " + num + " from peg " + from + " to peg " + to);
		TOHUtil(num - 1, temp, to, from);
	}
	public static void TowersOfHanoi(int num)
	{
		Console.WriteLine("The sequence of moves involved in the Tower of Hanoi are :");
		TOHUtil(num, 'A', 'C', 'B');
	}
}