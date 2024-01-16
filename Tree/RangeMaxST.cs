using System;

public class RangeMaxST
{
    private int[] segArr;
    private int n;

    public RangeMaxST(int[] input)
    {
        n = input.Length;
        // Height of segment tree.
        int x = (int)(Math.Ceiling(Math.Log(n) / Math.Log(2)));
        //Maximum size of segment tree
        int max_size = 2 * (int)Math.Pow(2, x) - 1;
        // Allocate memory for segment tree
        segArr = new int[max_size];
        ConstructST(input, 0, n - 1, 0);
    }


    private int ConstructST(int[] input, int start, int end, int index)
    {
        // Store it in current node of the segment tree and return
        if (start == end)
        {
            segArr[index] = input[start];
            return input[start];
        }

        // If there are more than one elements, 
        // then traverse left and right subtrees 
        // and store the minimum of values in current node.
        int mid = (start + end) / 2;
        segArr[index] = Math.Max(ConstructST(input, start, mid, index * 2 + 1), ConstructST(input, mid + 1, end, index * 2 + 2));
        return segArr[index];
    }

    public int GetMax(int start, int end)
    {
        // Check for error conditions.
        if (start > end || start < 0 || end > n - 1)
        {
            Console.WriteLine("Invalid Input.");
            return int.MinValue;
        }
        return GetMaxUtil(0, n - 1, start, end, 0);
    }

    private int GetMaxUtil(int segStart, int segEnd, int queryStart, int queryEnd, int index)
    {
        if (queryStart <= segStart && segEnd <= queryEnd) // complete overlapping case.
        {
            return segArr[index];
        }

        if (segEnd < queryStart || queryEnd < segStart) // no overlapping case.
        {
            return int.MinValue;
        }

        // Segment tree is partly overlaps with the query range.
        int mid = (segStart + segEnd) / 2;
        return Math.Max(GetMaxUtil(segStart, mid, queryStart, queryEnd, 2 * index + 1),
        GetMaxUtil(mid + 1, segEnd, queryStart, queryEnd, 2 * index + 2));
    }

    public void Update(int ind, int val)
    {
        // Check for error conditions.
        if (ind < 0 || ind > n - 1)
        {
            Console.WriteLine("Invalid Input.");
            return;
        }

        // Update the values in segment tree
        UpdateUtil(0, n - 1, ind, val, 0);
    }

    // Always min inside valid range will be returned.
    private int UpdateUtil(int segStart, int segEnd, int ind, int val, int index)
    {
        // Update index lies outside the range of current segment.
        // So minimum will not change.
        if (ind < segStart || ind > segEnd)
        {
            return segArr[index];
        }

        // If the input index is in range of this node, then update the
        // value of the node and its children

        if (segStart == segEnd)
        {
            if (segStart == ind)
            { // Index value need to be updated.
                segArr[index] = val;
                return val;
            }
            else
            {
                return segArr[index]; // index value is not changed.
            }
        }

        int mid = (segStart + segEnd) / 2;

        // Current node value is updated with min. 
        segArr[index] = Math.Max(UpdateUtil(segStart, mid, ind, val, 2 * index + 1), UpdateUtil(mid + 1, segEnd, ind, val, 2 * index + 2));

        // Value of diff is propagated to the parent node.
        return segArr[index];
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int[] arr = new int[] { 1, 8, 2, 7, 3, 6, 4, 5 };
        RangeMaxST tree = new RangeMaxST(arr);
        Console.WriteLine("Max value in the range(1, 5): " + tree.GetMax(1, 5));
        Console.WriteLine("Max value in the range(2, 7): " + tree.GetMax(2, 7));
        Console.WriteLine("Max value of all the elements: " + tree.GetMax(0, arr.Length - 1));

        tree.Update(2, 9);
        Console.WriteLine("Max value in the range(1, 5): " + tree.GetMax(1, 5));
        Console.WriteLine("Max value of all the elements: " + tree.GetMax(0, arr.Length - 1));
    }
}

/*
Max value in the range(1, 5): 8
Max value in the range(2, 7): 7
Max value of all the elements: 8
Max value in the range(1, 5): 9
Max value of all the elements: 9
*/
