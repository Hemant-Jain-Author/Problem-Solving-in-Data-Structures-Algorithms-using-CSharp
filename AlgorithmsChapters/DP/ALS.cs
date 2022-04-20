using System;

public class ALS
{
    public static int FastestWayBU2(int[, ] a, int[, ] t, int[] e, int[] x, int n)
    {
        int[] f1 = new int[n];
        int[] f2 = new int[n];

        // Time taken to leave first station.
        f1[0] = e[0] + a[0, 0];
        f2[0] = e[1] + a[1, 0];

        // Fill the tables f1[] and f2[] using
        // bottom up approach.
        for (int i = 1; i < n; ++i)
        {
            f1[i] = Math.Min(f1[i - 1] + a[0, i], f2[i - 1] + t[1, i - 1] + a[0, i]);
            f2[i] = Math.Min(f2[i - 1] + a[1, i], f1[i - 1] + t[0, i - 1] + a[1, i]);
        }

        // Consider exit times and return minimum.
        return Math.Min(f1[n - 1] + x[0], f2[n - 1] + x[1]);
    }

    public static int FastestWayBU(int[, ] a, int[, ] t, int[] e, int[] x, int n)
    {
        int[, ] f = new int[n, n];

        // Time taken to leave first station.
        f[0, 0] = e[0] + a[0, 0];
        f[1, 0] = e[1] + a[1, 0];

        // Fill the tables f1[] and f2[] using
        // bottom up approach.
        for (int i = 1; i < n; ++i)
        {
            f[0, i] = Math.Min(f[0, i - 1] + a[0, i], f[1, i - 1] + t[1, i - 1] + a[0, i]);
            f[1, i] = Math.Min(f[1, i - 1] + a[1, i], f[0, i - 1] + t[0, i - 1] + a[1, i]);
        }

        // Consider exit times and return minimum.
        return Math.Min(f[0, n - 1] + x[0], f[1, n - 1] + x[1]);
    }


    public static int FastestWayTD(int[, ] a, int[, ] t, int[] e, int[] x, int n)
    {
        int[, ] f =new int[n, n];

        // Time taken to leave first station.
        f[0, 0] = e[0] + a[0, 0];
        f[1, 0] = e[1] + a[1, 0];

        FastestWayTD(f, a, t, n - 1);
        return Math.Min(f[0, n - 1] + x[0], f[1, n - 1] + x[1]);
    }

    private static void FastestWayTD(int[, ] f, int[, ] a, int[, ] t, int i)
    {
        if (i == 0)
        {
            return;
        }
        FastestWayTD(f, a, t, i - 1);
        // Fill the tables f1[] and f2[] using top-down approach.
        f[0, i] = Math.Min(f[0, i - 1] + a[0, i], f[1, i - 1] + t[1, i - 1] + a[0, i]);
        f[1, i] = Math.Min(f[1, i - 1] + a[1, i], f[0, i - 1] + t[0, i - 1] + a[1, i]);
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int[, ] a = new int[, ]
        {
            {7, 9, 3, 4, 8, 4},
            {8, 5, 6, 4, 5, 7}
        };
        int[, ] t = new int[, ]
        {
            {2, 3, 1, 3, 4},
            {2, 1, 2, 2, 1}
        };
        int[] e = new int[] {2, 4};
        int[] x = new int[] {3, 2};
        int n = 6;
        Console.WriteLine(FastestWayBU2(a, t, e, x, n));
        Console.WriteLine(FastestWayBU(a, t, e, x, n));
        Console.WriteLine(FastestWayTD(a, t, e, x, n));
    }
}

/*
38
38
38
*/