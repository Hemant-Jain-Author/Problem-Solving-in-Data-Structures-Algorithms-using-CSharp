using System;
using System.Collections.Generic;

public class ClosestPair
{
    public class Point
    {
        internal int x, y;
        internal Point(int a, int b)
        {
            x = a;
            y = b;
        }
    }

    public double ClosestPairBF(int[, ] arr)
    {
        int n = arr.GetLength(0);
        double dmin = double.MaxValue, d;
        for (int i = 0; i < n - 1 ; i++)
        {
            for (int j = i + 1; j < n ; j++)
            {
                d = Math.Sqrt((arr[i, 0] - arr[j, 0]) * (arr[i, 0] - arr[j, 0]) + (arr[i, 1] - arr[j, 1]) * (arr[i, 1] - arr[j, 1]));
                if (d < dmin)
                {
                    dmin = d;
                }
            }
        }
        return dmin;
    }

    private static double Distance(Point a, Point b)
    {
        return Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
    }

    internal class xComp : IComparer<Point>
    {
        public int Compare(Point s1, Point s2)
        {
            return (s1.x - s2.x);
        }
    }
    
    internal class yComp : IComparer<Point>
    {
        public int Compare(Point s1, Point s2)
        {
            return (s1.y - s2.y);
        }
    }

    private static double StripMin(Point[] q, int n, double d)
    {
        double min = d;

        // Find the Distance between all the points in the strip. 
        // Array q is sorted according to the y axis coordinate.
        // The inner loop will run at most 6 times for each point.
        for (int i = 0; i < n; ++i)
        {
            for (int j = i + 1; j < n && (q[j].y - q[i].y) < min; ++j)
            {
                d = Distance(q[i],q[j]);
                if (d < min)
                {
                    min = d;
                }
            }
        }
        return min;
    }

    private double ClosestPairUtil(Point[] p, int start, int stop, Point[] q, int n)
    {
        if (stop - start < 1)
        {
            return double.MaxValue;
        }

        if (stop - start == 1)
        {
            return Distance(p[start], p[stop]);
        }

        // Find the middle point
        int mid = (start + stop) / 2;

        double dl = ClosestPairUtil(p, start, mid, q, n);
        double dr = ClosestPairUtil(p, mid + 1, stop, q, n);
        double d = Math.Min(dl, dr);

        // Build an array strip[] that contains points whose x axis coordinate
        // in the range p[mid]-d and p[mid]+d.
        // Points are already sorted according to y axis.
        Point[] strip = new Point[n];
        int j = 0;
        for (int i = 0; i < n; i++)
        {
            if (Math.Abs(q[i].x - p[mid].x) < d)
            {
                strip[j] = q[i];
                j++;
            }
        }
        // Find the closest points in strip and compare with d.
        return Math.Min(d, StripMin(strip, j, d));
    }


    public double ClosestPairDC(int[, ] arr)
    {
        int n =arr.GetLength(0);
        Point[] p = new Point[n];
        for (int i = 0; i < n; i++)
        {
            p[i] = new Point(arr[i, 0], arr[i, 1]);
        }
        // Sort according to x axis.
        Array.Sort(p, new xComp());

        Point[] q = (ClosestPair.Point[])p.Clone();
        // Sort according to y axis.
        Array.Sort(q, new yComp());
        return ClosestPairUtil(p, 0, n - 1, q, n);
    }

    public static void Main(string[] args)
    {
        int[, ] arr = new int[,]
        {
            {648, 896},
            {269, 879},
            {250, 922},
            {453, 347},
            {213, 17}
        };
        ClosestPair cp = new ClosestPair();
        Console.WriteLine("Smallest Distance is:" + cp.ClosestPairBF(arr));
        Console.WriteLine("Smallest Distance is:" + cp.ClosestPairDC(arr));
    }
}

/*
Smallest Distance is:47.0106370941726
Smallest Distance is:47.0106370941726
*/