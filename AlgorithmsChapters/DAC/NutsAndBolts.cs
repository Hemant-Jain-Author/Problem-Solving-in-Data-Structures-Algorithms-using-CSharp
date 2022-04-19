using System;

public class NutsAndBolts
{
    private static void PrintArray(int[] arr)
    {
        Console.Write("[ ");
        foreach (int i in arr)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("]");
    }

    public static void MakePairs(int[] nuts, int[] bolts)
    {
        MakePairs(nuts, bolts, 0, nuts.Length - 1);
        Console.WriteLine("Matched nuts and bolts are : ");
        PrintArray(nuts);
        PrintArray(bolts);
    }

    // Quick sort kind of approach.
    private static void MakePairs(int[] nuts, int[] bolts, int low, int high)
    {
        if (low < high)
        {
            // Choose first element of bolts array as pivot to partition nuts.
            int pivot = Partition(nuts, low, high, bolts[low]);

            // Using nuts[pivot] as pivot to partition bolts.
            Partition(bolts, low, high, nuts[pivot]);

            // Recursively lower and upper half of nuts and bolts are matched.
            MakePairs(nuts, bolts, low, pivot - 1);
            MakePairs(nuts, bolts, pivot + 1, high);
        }
    }
    private static void Swap(int[] arr, int first, int second)
    {
        int temp = arr[first];
        arr[first] = arr[second];
        arr[second] = temp;
    }

    // Partition method similar to quick sort algorithm.
    private static int Partition(int[] arr, int low, int high, int pivot)
    {
        int i = low;
        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                Swap(arr, i, j);
                i++;
            }
            else if (arr[j] == pivot)
            {
                Swap(arr, high, j);
                j--;
            }
        }
        Swap(arr, i, high);
        return i;
    }

    public static void Main(string[] args)
    {
        int[] nuts = new int[] {1, 2, 6, 5, 4, 3};
        int[] bolts = new int[] {6, 4, 5, 1, 3, 2};
        MakePairs(nuts, bolts);
    }
}

/*
Matched nuts and bolts are : 
[ 1 2 3 4 5 6 ]
[ 1 2 3 4 5 6 ]
*/