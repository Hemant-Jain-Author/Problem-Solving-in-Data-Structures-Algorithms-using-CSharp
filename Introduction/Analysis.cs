using System;

public class Analysis
{
public static int Fun1(int n)
{
    int m = 0;
    for (int i = 0; i < n; i++)
    {
        m += 1;
    }
    return m;
}

public static int Fun2(int n)
{
    int i, j, m = 0;
    for (i = 0; i < n; i++)
    {
        for (j = 0; j < n; j++)
        {
            m += 1;
        }
    }
    return m;
}

public static int Fun3(int n)
{
    int i, j, k, m = 0;
    for (i = 0; i < n; i++)
    {
        for (j = 0; j < n; j++)
        {
            for (k = 0; k < n; k++)
        {
            m += 1;
        }
    }
    }
    return m;
}

public static int Fun4(int n)
{
    int i, j, k, m = 0;
    for (i = 0; i < n; i++)
    {
        for (j = i; j < n; j++)
        {
            for (k = j + 1; k < n; k++)
            {
                m += 1;
            }
        }
    }
    return m;
}

public static int Fun5(int n)
{
    int i, j, m = 0;
    for (i = 1; i <= n; i++)
    {
        for (j = 0; j < i; j++)
        {
            m += 1;
        }
    }
    return m;
}

public static int Fun6(int n)
{
    int i, m = 0;
    i = 1;
    while (i < n)
    {
        m += 1;
        i = i * 2;
    }
    return m;
}

public static int Fun7(int n)
{
    int i, m = 0;
    i = n;
    while (i > 0)
    {
        m += 1;
        i = i / 2;
    }
    return m;
}

public static int Fun8(int n)
{
    int i, j, k, m = 0;
    for (i = 0; i < n; i++)
    {
        for (j = 0; j < n; j++)
        {
            m += 1;
        }
    }
    for (i = 0; i < n; i++)
    {
        for (k = 0; k < n; k++)
        {
            m += 1;
        }
    }
    return m;
}

public static int Fun9(int n)
{
    int i, j, m = 0;
    for (i = 0; i < n; i++)
    {
        for (j = 0; j < Math.Sqrt(n); j++)
        {
            m += 1;
        }
    }
    return m;
}

public static int Fun10(int n)
{
    int i, j, m = 0;
    for (i = n; i > 0; i /= 2)
    {
        for (j = 0; j < i; j++)
        {
            m += 1;
        }
    }
    return m;
}

public static int Fun11(int n)
{
    int i, j = 0, m = 0;
    for (i = 1; i <= n; i *= 2)
    {
        for (j = 0; j <= i; j++)
        {
            m += 1;
        }
    }
    return m;
}

public static int Fun12(int n)
{
    int i, j, m = 0;
    for (i = 0; i < n; i++)
    {
        for (j = i; j > 0; j--)
        {
            m += 1;
        }
    }
    return m;
}

public static int Fun13(int n)
{
    int i = 0, j = 0, m = 0;
    for (i = 0; i < n; i++)
    {
        for (; j < n; j++)
        {
            m += 1;
        }
    }
    return m;
}

    // Testing code.
public static void Main(string[] args)
{
    Console.WriteLine("N = 100, Number of instructions in O(n)::" + Fun1(100));
    Console.WriteLine("N = 100, Number of instructions in O(n^2)::" + Fun2(100));
    Console.WriteLine("N = 100, Number of instructions in O(n^3)::" + Fun3(100));
    Console.WriteLine("N = 100, Number of instructions in O(n^3)::" + Fun4(100));
    Console.WriteLine("N = 100, Number of instructions in O(n^2)::" + Fun5(100));
    Console.WriteLine("N = 100, Number of instructions in O(log(n))::" + Fun6(100));
    Console.WriteLine("N = 100, Number of instructions in O(log(n))::" + Fun7(100));
    Console.WriteLine("N = 100, Number of instructions in O(n^2)::" + Fun8(100));
    Console.WriteLine("N = 100, Number of instructions in O(n^(3/2))::" + Fun9(100));
    Console.WriteLine("N = 100, Number of instructions in O(n)::" + Fun10(100));
    Console.WriteLine("N = 100, Number of instructions in O(n)::" + Fun11(100));
    Console.WriteLine("N = 100, Number of instructions in O(n^2)::" + Fun12(100));
    Console.WriteLine("N = 100, Number of instructions in O(n)::" + Fun13(100));
}
}

/*
N = 100, Number of instructions in O(n)::100
N = 100, Number of instructions in O(n^2)::10000
N = 100, Number of instructions in O(n^3)::1000000
N = 100, Number of instructions in O(n^3)::166650
N = 100, Number of instructions in O(n^2)::5050
N = 100, Number of instructions in O(log(n))::7
N = 100, Number of instructions in O(log(n))::7
N = 100, Number of instructions in O(n^2)::20000
N = 100, Number of instructions in O(n^(3/2))::1000
N = 100, Number of instructions in O(n)::197
N = 100, Number of instructions in O(n)::134
N = 100, Number of instructions in O(n^2)::4950
N = 100, Number of instructions in O(n)::100
*/