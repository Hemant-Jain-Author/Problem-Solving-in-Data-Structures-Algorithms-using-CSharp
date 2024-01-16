using System;

public class MatrixCM
{

    private static int MatrixChainMulBruteForce(int[] p, int i, int j)
    {
        if (i == j)
            return 0;

        int min = int.MaxValue;

        // place parenthesis at different places between
        // first and last matrix, recursively calculate
        // count of multiplications for each parenthesis
        // placement and return the minimum count
        for (int k = i; k < j; k++)
        {
            int count = MatrixChainMulBruteForce(p, i, k) + MatrixChainMulBruteForce(p, k + 1, j) + p[i - 1] * p[k] * p[j];

            if (count < min)
            {
                min = count;
            }
        }

        // Return minimum count
        return min;
    }

    public static int MatrixChainMulBruteForce(int[] p, int n)
    {
        int i = 1, j = n - 1;
        return MatrixChainMulBruteForce(p, i, j);
    }

    public static int MatrixChainMulTD(int[] p, int n)
    {
        int[,] dp = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                dp[i, j] = int.MaxValue;
            dp[i, i] = 0;
        }
        return MatrixChainMulTD(dp, p, 1, n - 1);
    }

    private static int MatrixChainMulTD(int[,] dp, int[] p, int i, int j)
    {
        // Base Case
        if (dp[i, j] != int.MaxValue)
        {
            return dp[i, j];
        }

        for (int k = i; k < j; k++)
        {
            dp[i, j] = Math.Min(dp[i, j], MatrixChainMulTD(dp, p, i, k) + MatrixChainMulTD(dp, p, k + 1, j) + p[i - 1] * p[k] * p[j]);
        }
        return dp[i, j];
    }



    public static int MatrixChainMulBU(int[] p, int n)
    {
        int[,] dp = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                dp[i, j] = int.MaxValue;
            dp[i, i] = 0;
        }

        for (int l = 1; l < n; l++) // l is length of range.
        {
            for (int i = 1, j = i + l; j < n; i++, j++)
            {
                for (int k = i; k < j; k++)
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[i, k] + p[i - 1] * p[k] * p[j] + dp[k + 1, j]);
                }
            }
        }
        return dp[1, n - 1];
    }

    static void PrintOptPar(int n, int[,] pos, int i, int j)
    {
        if (i == j)
            Console.Write("M" + pos[i, i] + " ");

        else
        {
            Console.Write("( ");
            PrintOptPar(n, pos, i, pos[i, j]);
            PrintOptPar(n, pos, pos[i, j] + 1, j);
            Console.Write(") ");
        }
    }

    static void PrintOptimalParenthesis(int n, int[,] pos)
    {
        Console.Write("OptimalParenthesis : ");
        PrintOptPar(n, pos, 1, n - 1);
        Console.WriteLine();
    }

    public static int MatrixChainMulBU2(int[] p, int n)
    {
        int[,] dp = new int[n, n];
        int[,] pos = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                dp[i, j] = int.MaxValue;
            dp[i, i] = 0;
            pos[i, i] = i;
        }

        for (int l = 1; l < n; l++) // l is length of range.
        {
            for (int i = 1, j = i + l; j < n; i++, j++)
            {
                for (int k = i; k < j; k++)
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[i, k] + p[i - 1] * p[k] * p[j] + dp[k + 1, j]);
                    pos[i, j] = k;
                }
            }
        }
        PrintOptimalParenthesis(n, pos);
        return dp[1, n - 1];
    }



    // Testing code.
    public static void Main(string[] args)
    {
        int[] arr = new int[] { 1, 2, 3, 4 };
        int n = arr.Length;
        Console.WriteLine("Matrix Chain Multiplication is: " + MatrixChainMulBruteForce(arr, n));
        Console.WriteLine("Matrix Chain Multiplication is: " + MatrixChainMulTD(arr, n));
        Console.WriteLine("Matrix Chain Multiplication is: " + MatrixChainMulBU(arr, n));
        Console.WriteLine("Matrix Chain Multiplication is: " + MatrixChainMulBU2(arr, n));
    }
}

/*
Matrix Chain Multiplication is: 18
Matrix Chain Multiplication is: 18
Matrix Chain Multiplication is: 18
OptimalParenthesis : ( ( M1 M2 ) M3 ) 
Matrix Chain Multiplication is: 18
*/

