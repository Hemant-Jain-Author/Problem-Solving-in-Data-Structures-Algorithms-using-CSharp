using System;

public class BinaryIndexTree
{
	private int[] BIT;
	private int size;

	public BinaryIndexTree(int[] arr)
	{
		size = arr.Length;
		BIT = new int[size+1];
		Array.Fill(BIT, 0);

		// Populating bit. 
		for (int i = 0; i < size; i++)
		{
			Update(i, arr[i]);
		}
	}

	public void Set(int[] arr, int index, int val)
	{
		int diff = val - arr[index];
		arr[index] = val;

		// Difference is propagated.
		Update(index, diff);
	}

	private void Update(int index, int val)
	{
		// Index in bit is 1 more than the input array.
		index = index + 1;

		// Traverse to ancestors of nodes.
		while (index <= size)
		{
			// Add val to current node of Binary Index Tree.
			BIT[index] += val;

			// Next element which need to store val.
			index += index & (-index);
		}
	}

	// Range sum in the range start to end.
	public int RangeSum(int start, int end)
	{
		// Check for error conditions.
		if (start > end || start < 0 || end > size - 1)
		{
			Console.WriteLine("Invalid Input.");
			return -1;
		}

		return PrefixSum(end) - PrefixSum(start - 1);
	}

	// Prefix sum in the range 0 to index.
	public int PrefixSum(int index)
	{
		int sum = 0;
		index = index + 1;

		// Traverse ancestors of Binary Index Tree nodes.
		while (index > 0)
		{
			// Add current element to sum.
			sum += BIT[index];

			// Parent index calculation.
			index -= index & (-index);
		}
		return sum;
	}


	// Main function
	public static void Main(string[] args)
	{
		int[] arr = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
		BinaryIndexTree tree = new BinaryIndexTree(arr);

		Console.WriteLine("Sum of elements in range(0, 5): " + tree.PrefixSum(5));
		Console.WriteLine("Sum of elements in range(2, 5): " + tree.RangeSum(2, 5));

		// Set fourth element to 10.
		tree.Set(arr, 3, 10);

		// Find sum after the value is Updated
		Console.WriteLine("Sum of elements in range(0, 5): " + tree.PrefixSum(5));
	}
}

/*
Sum of elements in range(0, 5): 21
Sum of elements in range(2, 5): 15
Sum of elements in range(0, 5): 27
*/