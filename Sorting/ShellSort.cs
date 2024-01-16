using System;

public class ShellSort
{
    private bool Greater(int value1, int value2)
    {
        return value1 > value2;
    }

    public void Sort(int[] arr)
    {
        int n = arr.Length;

        // Gap starts with n/2 and half in each iteration.
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            // Do a gapped insertion Sort.
            for (int i = gap; i < n; i += 1)
            {
                int curr = arr[i];

                // Shift elements of already Sorted list
                // to find right position for curr value.
                int j;
                for (j = i; j >= gap && Greater(arr[j - gap], curr); j -= gap)
                {
                    arr[j] = arr[j - gap];
                }

                // Put current value in its correct location
                arr[j] = curr;
            }
        }
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int[] array = new int[] {36, 32, 11, 6, 19, 31, 17, 3};

        ShellSort b = new ShellSort();
        b.Sort(array);
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}

/*
3 6 11 17 19 31 32 36 
*/