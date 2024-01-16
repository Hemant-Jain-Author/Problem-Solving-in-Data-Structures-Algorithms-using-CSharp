using System;

public class RadixSort
{
    private int GetMax(int[] arr, int n)
    {
        int max = arr[0];
        for (int i = 1; i < n; i++)
        {
            if (max < arr[i])
            {
                max = arr[i];
            }
        }
        return max;
    }

    private void CountSort(int[] arr, int n, int dividend)
    {
        int[] temp = (int[])arr.Clone();
        int[] count = new int[10];
        Array.Fill(count, 0);

        // Store count of occurrences in count array.
        // (number / dividend) % 10 is used to find the working digit.
        for (int i = 0; i < n; i++)
        {
            count[(temp[i] / dividend) % 10]++;
        }

        // Change count[i] so that count[i] contains 
        // number of elements till index i in output.
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        // Copy content to input arr.
        for (int i = n - 1; i >= 0; i--)
        {
            arr[count[(temp[i] / dividend) % 10] - 1] = temp[i];
            count[(temp[i] / dividend) % 10]--;
        }
    }

    public void Sort(int[] arr)
    {
        int n = arr.Length;
        int m = GetMax(arr, n);

        // Counting Sort for every digit.
        // The dividend passed is used to calculate current working digit.
        for (int div = 1; m / div > 0; div *= 10)
        {
            CountSort(arr, n, div);
        }
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int[] array = new int[] {100, 49, 65, 91, 702, 29, 4, 55};
        RadixSort b = new RadixSort();
        b.Sort(array);
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}

/*
4 29 49 55 65 91 100 702
*/
