using System;

public class CountSort
{
    public void Sort(int[] arr, int lowerRange, int upperRange)
    {
        int i, j;
        int size = arr.Length;
        int range = upperRange - lowerRange;
        int[] count = new int[range];

        for (i = 0; i < size; i++)
        {
            count[arr[i] - lowerRange]++;
        }

        j = 0;
        for (i = 0; i < range; i++)
        {
            for (; count[i] > 0; (count[i])--)
            {
                arr[j++] = i + lowerRange;
            }
        }
    }

    public static void Main(string[] args)
    {
        int[] array = new int[] {23, 24, 22, 21, 26, 25, 27, 28, 21, 21};
        CountSort b = new CountSort();
        b.Sort(array, 20, 30);
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}

/*
21 21 21 22 23 24 25 26 27 28
*/