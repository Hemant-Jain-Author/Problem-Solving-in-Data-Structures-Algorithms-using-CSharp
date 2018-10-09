using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Introduction3333
{
	public static void Main333(string[] args)
	{
		int[] arr = new int[] { 1, -2, 3, 4, -4, 6, -14, 8, 2 };
		Console.WriteLine("Max sub array sum :" + maxSubArraySum2(arr, 9));
	}

	public static int maxSubArraySum2(int[] a, int size)
	{
		int maxSoFar = 0, maxEndingHere = 0;

		for (int i = 0; i < size; i++)
		{
			maxEndingHere = maxEndingHere + a[i];
			if (maxEndingHere < 0)
			{
				maxEndingHere = 0;
			}
			if (maxSoFar < maxEndingHere)
			{
				maxSoFar = maxEndingHere;
			}
		}
		return maxSoFar;
	}
}