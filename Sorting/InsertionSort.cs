using System;

public class InsertionSort
{
    private bool Greater(int value1, int value2)
    {
        return value1 > value2;
    }

    public void Sort(int[] arr)
    {
        int size = arr.Length;
        int temp, j;
        for (int i = 1; i < size; i++)
        {
            temp = arr[i];
            for (j = i; j > 0 && Greater(arr[j - 1], temp); j--)
            {
                arr[j] = arr[j - 1];
            }
            arr[j] = temp;
        }
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int[] array = new int[] {9, 1, 8, 2, 7, 3, 6, 4, 5};
        InsertionSort srt = new InsertionSort();
        srt.Sort(array);
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");

        }
    }
}
/*
1 2 3 4 5 6 7 8 9
*/