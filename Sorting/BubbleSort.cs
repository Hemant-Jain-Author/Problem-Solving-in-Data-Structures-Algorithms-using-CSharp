using System;

public class BubbleSort
{
    private bool Less(int value1, int value2)
    {
        return value1 < value2;
    }

    private bool More(int value1, int value2)
    {
        return value1 > value2;
    }

    public void Sort(int[] arr)
    {
        int size = arr.Length;
        int i, j, temp;
        for (i = 0; i < (size - 1); i++)
        {
            for (j = 0; j < size - i - 1; j++)
            {
                if (More(arr[j], arr[j + 1]))
                {
                    /* Swapping */
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    public void Sort2(int[] arr)
    {
        int size = arr.Length;
        int i, j, temp, swapped = 1;
        for (i = 0; i < (size - 1) && swapped == 1; i++)
        {
            swapped = 0;
            for (j = 0; j < size - i - 1; j++)
            {
                if (More(arr[j], arr[j + 1]))
                {
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = 1;
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        int[] array = new int[] {9, 1, 8, 2, 7, 3, 6, 4, 5};
        BubbleSort b = new BubbleSort();
        b.Sort(array);
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
        int[] array2 = new int[] {9, 1, 8, 2, 7, 3, 6, 4, 5};
        b = new BubbleSort();
        b.Sort2(array2);
        for (int i = 0; i < array2.Length; i++)
        {
            Console.Write(array2[i] + " ");
        }
    }
}
/*
1 2 3 4 5 6 7 8 9 
1 2 3 4 5 6 7 8 9
*/