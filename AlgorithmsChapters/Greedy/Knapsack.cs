using System;
using System.Collections.Generic;

public class Knapsack
{
	private class Items
	{
		internal int wt;
		internal int cost;
		internal double density;

		internal Items(int w, int v)
		{
			wt = w;
			cost = v;
			density = (double)cost / wt;
		}
	}

	private class DecDensity : IComparer<Items>
	{
		public int Compare(Items a, Items b)
		{
			return (int)(b.density - a.density);
		}
	}

	// Approximate solution.
	public int GetMaxCostGreedy(int[] wt, int[] cost, int capacity)
	{
		int totalCost = 0;
		int n = wt.Length;
		Items[] itemList = new Items[n];
		for (int i = 0; i < n; i++)
		{
			itemList[i] = new Items(wt[i], cost[i]);
		}

		Array.Sort(itemList, new DecDensity());
		for (int i = 0; i < n && capacity > 0; i++)
		{
			if (capacity - itemList[i].wt >= 0)
			{
				capacity -= itemList[i].wt;
				totalCost += itemList[i].cost;
			}
		}
		return totalCost;
	}

	public static void Main(string[] args)
	{
		int[] wt = new int[] {10, 40, 20, 30};
		int[] cost = new int[] {60, 40, 90, 120};
		int capacity = 50;

		Knapsack kp = new Knapsack();
		int maxCost = kp.GetMaxCostGreedy(wt, cost, capacity);
		Console.WriteLine("Maximum cost obtained = " + maxCost);
	}
}

/*
Maximum cost obtained = 150
*/
