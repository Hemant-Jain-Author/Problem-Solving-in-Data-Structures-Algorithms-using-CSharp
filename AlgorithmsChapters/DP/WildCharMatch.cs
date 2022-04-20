﻿using System;

public class WildCharMatch
{
    public static bool matchExp(string exp, string str)
    {
        return matchExpUtil(exp.ToCharArray(), str.ToCharArray(), 0, 0);
    }

    private static bool matchExpUtil(char[] exp, char[] str, int m, int n)
    {
        if (m == exp.Length && (n == str.Length || exp[m - 1] == '*'))
        {
            return true;
        }
        if ((m == exp.Length && n != str.Length) || (m != exp.Length && n == str.Length))
        {
            return false;
        }
        if (exp[m] == '?' || exp[m] == str[n])
        {
            return matchExpUtil(exp, str, m + 1, n + 1);
        }
        if (exp[m] == '*')
        {
            return matchExpUtil(exp, str, m + 1, n) || matchExpUtil(exp, str, m, n + 1);
        }
        return false;
    }

    public static bool matchExpDP(string exp, string str)
    {
        return matchExpUtilDP(exp.ToCharArray(), str.ToCharArray(), exp.Length, str.Length);
    }

    private static bool matchExpUtilDP(char[] exp, char[] str, int m, int n)
    {
        bool[, ] lookup = new bool[m + 1, n + 1];
        lookup[0, 0] = true; // empty exp and empty str match.

        // 0 row will remain all false. empty exp can't match any str.
        // '*' can match with empty string, column 0 update.
        for (int i = 1; i <= m; i++)
        {
            if (exp[i - 1] == '*')
            {
                lookup[i, 0] = lookup[i - 1, 0];
            }
            else
            {
                break;
            }
        }

        // Fill the table in bottom-up fashion
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                // If we see a '*' in pattern:
                // 1) We ignore '*' character and consider 
                // next character in the pattern.
                // 2) We ignore one character in the input str
                // and consider next character.
                if (exp[i - 1] == '*')
                {
                    lookup[i, j] = lookup[i - 1, j] || lookup[i, j - 1];
                }
                // Condition when both the pattern and input string
                // have same character. Also '?' match with all the
                // characters.
                else if (exp[i - 1] == '?' || str[j - 1] == exp[i - 1])
                {
                    lookup[i, j] = lookup[i - 1, j - 1];
                }
                // If characters don't match
                else
                {
                    lookup[i, j] = false;
                }
            }
        }
        return lookup[m, n];
    }

    // Testing code.
    public static void Main(string[] args)
    {
        Console.WriteLine(matchExp("*llo,?World?", "Hello, World!"));
        Console.WriteLine(matchExpDP("*llo,?World?", "Hello, World!"));
    }
/*
True
True
*/

    // Testing code.
    public static void main2(string[] args)
    {
        string str = "baaabab";
        string[] pattern = new string[] {"*****ba*****ab", "ba*****ab", "ba*ab", "a*ab", "a*****ab", "*a*****ab", "ba*ab****", "****", "*", "aa?ab", "b*b", "a*a", "baaabab", "?baaabab", "*baaaba*"};

        foreach (string p in pattern)
        {
            if (matchExp(p, str) != matchExpDP(p, str))
            {
                Console.Write(matchExpDP(p, str) + " for ");
                Console.WriteLine(p + " == " + str);
            }
        }
    }
}