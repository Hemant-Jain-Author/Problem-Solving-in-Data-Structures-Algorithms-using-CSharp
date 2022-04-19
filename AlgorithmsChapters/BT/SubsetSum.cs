using System;

public class SubsetSum
{
    private static void PrintSubset(bool[] flags, int[] arr, int size)
    {
        for (int i = 0; i < size; i++)
        {
            if (flags[i])
            {
                Console.Write(arr[i] + " ");
            }
        }
        Console.WriteLine();
    }

    public static void FindSubsetSum(int[] arr, int n, int target)
    {
        bool[] flags = new bool[n];
        FindSubsetSum(arr, n, flags, 0, 0, target);
    }

    private static void FindSubsetSum(int[] arr, int n, bool[] flags, int sum, int curr, int target)
    {
        if (target == sum)
        {
            PrintSubset(flags, arr, n); // Solution found.
            return;
        }

        // constraint check
        if (curr >= n || sum > target)
        {
            // Backtracking.
            return;
        }

        // Current element included.
        flags[curr] = true;
        FindSubsetSum(arr, n, flags, sum + arr[curr], curr + 1, target);
        // Current element excluded.
        flags[curr] = false;
        FindSubsetSum(arr, n, flags, sum, curr + 1, target);
    }

    public static void Main(string[] args)
    {
        int[] arr = new int[] {15, 22, 14, 26, 32, 9, 16, 8};
        int target = 53;
        int n = arr.Length;
        SubsetSum.FindSubsetSum(arr, n, target);
    }
}

/*
15 22 16 
15 14 16 8 
22 14 9 8 
*/