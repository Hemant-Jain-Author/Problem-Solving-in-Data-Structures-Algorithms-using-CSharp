using System;

public class Permutations
{
    private static void PrintArray(int[] arr, int n)
    {
        for (int i = 0;i < n;i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    private static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static void Permutation(int[] arr, int i, int length)
    {
        if (length == i)
        {
            PrintArray(arr, length);
            return;
        }

        for (int j = i; j < length; j++)
        {
            Swap(arr, i, j);
            Permutation(arr, i + 1, length);
            Swap(arr, i, j);
        }
        return;
    }

/*
1 2 3 4 
1 2 4 3 
.....
4 1 3 2 
4 1 2 3 
*/

    private static bool IsValid(int[] arr, int n)
    {
        for (int j = 1;j < n;j++)
        {
            if (Math.Abs(arr[j] - arr[j - 1]) < 2)
            {
                return false;
            }
        }
        return true;
    }

    public static void Permutation2(int[] arr, int i, int length)
    {
        if (length == i)
        {
            if (IsValid(arr, length))
            {
                PrintArray(arr, length);
            }
            return;
        }

        for (int j = i; j < length; j++)
        {
            Swap(arr, i, j);
            Permutation2(arr, i + 1, length);
            Swap(arr, i, j);
        }
        return;
    }

    private static bool IsValid2(int[] arr, int i)
    {
        if (i < 1 || Math.Abs(arr[i] - arr[i - 1]) >= 2)
        {
            return true;
        }
        return false;
    }

    public static void Permutation3(int[] arr, int i, int length)
    {
        if (length == i)
        {
            PrintArray(arr, length);
            return;
        }

        for (int j = i; j < length; j++)
        {
            Swap(arr, i, j);
            if (IsValid2(arr, i))
            {
                Permutation3(arr, i + 1, length);
            }
            Swap(arr, i, j);
        }
        return;
    }

    /* Testing code */
    public static void Main(string[] args)
    {
        int[] arr = {1, 2, 3, 4};
        Permutation(arr, 0, 4);
        Console.WriteLine();
        Permutation2(arr, 0, 4);
        Console.WriteLine();
        Permutation3(arr, 0, 4);
    }
}

/*
2 4 1 3 
3 1 4 2
*/