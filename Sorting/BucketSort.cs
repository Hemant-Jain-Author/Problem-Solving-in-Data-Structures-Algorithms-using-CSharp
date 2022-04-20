using System;
using System.Collections.Generic;

// Allowed values from 0 to maxValue.
public class BucketSort
{
    public void Sort(int[] arr, int maxValue)
    {
        int numBucket = 5;
        Sort(arr, maxValue, numBucket);
    }

    public void Sort(int[] arr, int maxValue, int numBucket)
    {
        int length = arr.Length;
        if (length == 0)
        {
            return;
        }

        List<List<int>> bucket = new List<List<int>>(numBucket);

        // Create empty buckets
        for (int i = 0; i < numBucket; i++)
        {
            bucket.Add(new List<int>());
        }

        int div = (int)Math.Ceiling((double)maxValue / (numBucket));

        // Add elements into the buckets
        for (int i = 0; i < length; i++)
        {
            if (arr[i] < 0 || arr[i] > maxValue)
            {
                Console.WriteLine("Value out of range.");
                return;
            }

            int bucketIndex = (arr[i] / div);

            // Maximum value will be assigned to last bucket.
            if (bucketIndex >= numBucket)
            {
                bucketIndex = numBucket - 1;
            }

            bucket[bucketIndex].Add(arr[i]);
        }

        // Sort the elements of each bucket.
        for (int i = 0; i < numBucket; i++)
        {
            bucket[i].Sort();
        }

        // Populate output from the Sorted subarray.
        int index = 0, count;
        for (int i = 0; i < numBucket; i++)
        {
            List<int> temp = bucket[i];
            count = temp.Count;
            for (int j = 0; j < count; j++)
            {
                arr[index++] = temp[j];
            }
        }
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int[] array = new int[] {1, 34, 7, 99, 5, 23, 45, 88, 77, 19, 91, 100};
        int maxValue = 100;
        BucketSort b = new BucketSort();
        b.Sort(array, maxValue);
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}

/*
1 5 7 19 23 34 45 77 88 91 99 100
 */