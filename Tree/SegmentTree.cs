using System;

public class SegmentTree
{
	private int[] segArr;
	private int size;

	public SegmentTree(int[] input)
	{
		size = input.Length;
		// Height of segment tree.
		int x = (int)(Math.Ceiling(Math.Log(size) / Math.Log(2)));
		//Maximum size of segment tree
		int max_size = 2 * (int) Math.Pow(2, x) - 1;
		// Allocate memory for segment tree
		segArr = new int[max_size];
		ConstructST(input, 0, size - 1, 0);
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
		// and store the sum of values in current node.
		int mid = (start + end) / 2;
		segArr[index] = ConstructST(input, start, mid, index * 2 + 1) + ConstructST(input, mid + 1, end, index * 2 + 2);
		 return segArr[index];
	}

	public int GetSum(int start, int end)
	{
		// Check for error conditions.
		if (start > end || start < 0 || end > size - 1)
		{
			Console.WriteLine("Invalid Input.");
			return -1;
		}
		return GetSumUtil(0, size - 1, start, end, 0);
	}

	private int GetSumUtil(int segStart, int segEnd, int queryStart, int queryEnd, int index)
	{
		if (queryStart <= segStart && segEnd <= queryEnd) // complete overlapping case.
		{
			return segArr[index];
		}

		if (segEnd < queryStart || queryEnd < segStart) // no overlapping case.
		{
			return 0;
		}

		// Segment tree is partly overlaps with the query range.
		int mid = (segStart + segEnd) / 2;
		return GetSumUtil(segStart, mid, queryStart, queryEnd, 2 * index + 1) + GetSumUtil(mid + 1, segEnd, queryStart, queryEnd, 2 * index + 2);
	}

	public void Set(int[] arr, int ind, int val)
	{
		// Check for error conditions.
		if (ind < 0 || ind > size - 1)
		{
			Console.WriteLine("Invalid Input.");
			return;
		}

		arr[ind] = val;

		// Set new value in segment tree
		SetUtil(0, size - 1, ind, val, 0);
	}

	// Always diff will be returned.
	private int SetUtil(int segStart, int segEnd, int ind, int val, int index)
	{
		// set index lies outside the range of current segment.
		// So diff to its parent node will be zero.
		if (ind < segStart || ind > segEnd)
		{
			return 0;
		}

		// If the input index is in range of this node, then set the
		// value of the node and its children
		int diff = 0;
		if (segStart == segEnd)
		{
			if (segStart == ind)
			{ // Index that need to be set.
				diff = val - segArr[index];
				segArr[index] = val;
				return diff;
			}
			else
			{
				return 0;
			}
		}

		int mid = (segStart + segEnd) / 2;
		diff = SetUtil(segStart, mid, ind, val, 2 * index + 1) + SetUtil(mid + 1, segEnd, ind, val, 2 * index + 2);

		// Current node value is set with diff. 
		segArr[index] = segArr[index] + diff;

		// Value of diff is propagated to the parent node.
		return diff;
	}

	public static void Main(string[] args)
	{
		int[] arr = new int[] {1, 2, 4, 8, 16, 32, 64};
		SegmentTree tree = new SegmentTree(arr);
		Console.WriteLine("Sum of values in the range(0, 3): " + tree.GetSum(1, 3));
		Console.WriteLine("Sum of values of all the elements: " + tree.GetSum(0, arr.Length - 1));

		tree.Set(arr, 1, 10);
		Console.WriteLine("Sum of values in the range(0, 3): " + tree.GetSum(1, 3));
		Console.WriteLine("Sum of values of all the elements: " + tree.GetSum(0, arr.Length - 1));
	}
}

/*
Sum of values in the range(0, 3): 14
Sum of values of all the elements: 127
Sum of values in the range(0, 3): 22
Sum of values of all the elements: 135
*/