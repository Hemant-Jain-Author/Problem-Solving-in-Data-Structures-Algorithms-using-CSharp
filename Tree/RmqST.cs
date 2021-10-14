using System;

public class RmqST
{
	private int[] segArr;
	private int n;

	public RmqST(int[] input)
	{
		n = input.Length;
		// Height of segment tree.
		int x = (int)(Math.Ceiling(Math.Log(n) / Math.Log(2)));
		//Maximum size of segment tree
		int max_size = 2 * (int) Math.Pow(2, x) - 1;
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
		segArr[index] = Min(ConstructST(input, start, mid, index * 2 + 1), ConstructST(input, mid + 1, end, index * 2 + 2));
		 return segArr[index];
	}

	private int Min(int first, int second)
	{
		if (first < second)
		{
			return first;
		}
		else
		{
			return second;
		}
	}

	public int GetMin(int start, int end)
	{
		// Check for error conditions.
		if (start > end || start < 0 || end > n - 1)
		{
			Console.WriteLine("Invalid Input.");
			return int.MaxValue;
		}
		return GetMinUtil(0, n - 1, start, end, 0);
	}

	private int GetMinUtil(int segStart, int segEnd, int queryStart, int queryEnd, int index)
	{
		if (queryStart <= segStart && segEnd <= queryEnd) // complete overlapping case.
		{
			return segArr[index];
		}

		if (segEnd < queryStart || queryEnd < segStart) // no overlapping case.
		{
			return int.MaxValue;
		}

		// Segment tree is partly overlaps with the query range.
		int mid = (segStart + segEnd) / 2;
		return Min(GetMinUtil(segStart, mid, queryStart, queryEnd, 2 * index + 1), GetMinUtil(mid + 1, segEnd, queryStart, queryEnd, 2 * index + 2));
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
		segArr[index] = Min(UpdateUtil(segStart, mid, ind, val, 2 * index + 1), UpdateUtil(mid + 1, segEnd, ind, val, 2 * index + 2));

		// Value of diff is propagated to the parent node.
		return segArr[index];
	}

	public static void Main(string[] args)
	{
		int[] arr = new int[] {2, 3, 1, 7, 12, 5};
		RmqST tree = new RmqST(arr);
		Console.WriteLine("Min value in the range(1, 5): " + tree.GetMin(1, 5));
		Console.WriteLine("Min value of all the elements: " + tree.GetMin(0, arr.Length - 1));

		tree.Update(2, -1);
		Console.WriteLine("Min value in the range(1, 5): " + tree.GetMin(1, 5));
		Console.WriteLine("Min value of all the elements: " + tree.GetMin(0, arr.Length - 1));

		tree.Update(5, -2);
		Console.WriteLine("Min value in the range(0, 4): " + tree.GetMin(0, 4));
		Console.WriteLine("Min value of all the elements: " + tree.GetMin(0, arr.Length - 1));
	}
}

/*
Min value in the range(1, 5): 1
Min value of all the elements: 1
Min value in the range(1, 5): -1
Min value of all the elements: -1
Min value in the range(0, 4): -1
Min value of all the elements: -2
*/