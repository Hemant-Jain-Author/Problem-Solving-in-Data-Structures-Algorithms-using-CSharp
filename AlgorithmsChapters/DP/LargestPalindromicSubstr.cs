using System;

// Palindromic Substrings
public class LargestPalindromicSubstr
{
    public static int PalindromicSubstring(string str)
    {
        int n = str.Length;
        int[,] dp = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            dp[i, i] = 1;
        }

        int max = 1;
        int start = 0;

        for (int l = 1; l < n; l++)
        {
            for (int i = 0, j = l; j < n; i++, j++)
            {
                if (str[i] == str[j] && dp[i + 1, j - 1] == j - i - 1)
                {
                    dp[i, j] = dp[i + 1, j - 1] + 2;
                    if (dp[i, j] > max)
                    {
                        max = dp[i, j]; // Keeping track of max length and
                        start = i; // starting position of sub-string.
                    }
                }
                else
                {
                    dp[i, j] = 0;
                }
            }
        }
        Console.WriteLine("Max Length Palindromic Substrings : " + str.Substring(start, max));
        return max;
    }

    // Testing code.
    public static void Main(string[] args)
    {
        string str = "ABCAUCBCxxCBA";
        Console.WriteLine("Max Palindromic Substrings len: " + PalindromicSubstring(str));
    }
}

/*
Max Length Palindromic Substrings : BCxxCB
Max Palindromic Substrings len: 6
*/

/*
//If asked to find how many different palindromic substrings are possible.
int count = 0;
for(int i=0;i<n;i++)
    for(int j=0;j<n;j++)
    if(dp[i, j] > 0)
        count++;
return count;
*/