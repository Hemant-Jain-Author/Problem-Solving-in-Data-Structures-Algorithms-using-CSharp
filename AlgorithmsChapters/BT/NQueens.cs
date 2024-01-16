using System;

public class NQueens
{
    public static void Print(int[] Q, int n)
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

    public static void NQueensPattern(int[] Q, int k, int n)
    {
        if (k == n)
        {
            Print(Q, n);
            return;
        }
        for (int i = 0; i < n; i++)
        {
            Q[k] = i;
            if (Feasible(Q, k))
            {
                NQueensPattern(Q, k + 1, n);
            }
        }
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int[] Q = new int[8];
        NQueensPattern(Q, 0, 8);
    }
}

/*
 0 4 7 5 2 6 1 3 
 0 5 7 2 6 3 1 4 
 ......
 7 2 0 5 1 4 6 3 
 7 3 0 2 5 1 6 4 
 */