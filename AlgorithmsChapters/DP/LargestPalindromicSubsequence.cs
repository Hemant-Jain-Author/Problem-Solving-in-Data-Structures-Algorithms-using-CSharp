using System;

// Palindromic Subsequence
public class LargestPalindromicSubsequence
{
	public static int PalindromicSubsequence(string str)
	{
		int n = str.Length;
		int[, ] dp = new int[n, n];

		for (int i = 0;i < n;i++) // each char is itself palindromic with length 1
		{
			dp[i, i] = 1;
		}

		for (int l = 1; l < n; l++)
		{
			for (int i = 0, j = i + l; j < n; i++, j++)
			{
				if (str[i] == str[j])
				{
					dp[i, j] = dp[i + 1, j - 1] + 2;
				}
				else
				{
					dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
				}
			}
		}
		return dp[0, n - 1];
	}

	public static void Main(string[] args)
	{
		string str = "ABCAUCBCxxCBA";
		Console.WriteLine("Max Palindromic Subsequence length: " + PalindromicSubsequence(str));

	}
}

/*
Max Palindromic Subsequence length: 9
*/
