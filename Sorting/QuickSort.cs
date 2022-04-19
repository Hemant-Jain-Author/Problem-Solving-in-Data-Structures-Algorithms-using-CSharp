using System;

public class QuickSort
{
    private void Sort(int[] arr, int lower, int upper)
    {
        if (upper <= lower)
        {
            return;
        }
        int pivot = arr[lower];
        int start = lower;
        int stop = upper;

        while (lower < upper)
        {
            while (arr[lower] <= pivot && lower < upper)
            {
                lower++;
            }
            while (arr[upper] > pivot && lower <= upper)
            {
                upper--;
            }
            if (lower < upper)
            {
                Swap(arr, upper, lower);
            }
        }
        Swap(arr, upper, start); // upper is the pivot position
        Sort(arr, start, upper - 1); // pivot -1 is the upper for left sub array.
        Sort(arr, upper + 1, stop); // pivot + 1 is the lower for right sub array
    }

    public void Sort(int[] arr)
    {
        int size = arr.Length;
        Sort(arr, 0, size - 1);
    }

    private void Swap(int[] arr, int first, int second)
    {
        int temp = arr[first];
        arr[first] = arr[second];
        arr[second] = temp;
    }

    public static void Main(string[] args)
    {
        int[] array = new int[] {3, 4, 2, 1, 6, 5, 7, 8, 10, 9};
        QuickSort srt = new QuickSort();
        srt.Sort(array);
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}
// 1 2 3 4 5 6 7 8 9 10