using System;

public class FractionalKnapsack
{
    private class Items : IComparable<Items>
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

        public int CompareTo(Items s2) // decreasing order.
        { 
            return (int)(s2.density - this.density);
        }
    }

    public double GetMaxCostFractional(int[] wt, int[] cost, int capacity)
    {
        double totalCost = 0;
        int n = wt.Length;
        Items[] itemList = new Items[n];
        for (int i = 0; i < n; i++)
        {
            itemList[i] = new Items(wt[i], cost[i]);
        }

        Array.Sort(itemList);
        for (int i = 0; i < n; i++)
        {
            if (capacity - itemList[i].wt >= 0)
            {
                capacity -= itemList[i].wt;
                totalCost += itemList[i].cost;
            }
            else
            {
                totalCost += (itemList[i].density * capacity);
                break;
            }
        }
        return totalCost;
    }

    public static void Main(string[] args)
    {
        int[] wt = new int[] {10, 40, 20, 30};
        int[] cost = new int[] {60, 40, 90, 120};
        int capacity = 50;

        FractionalKnapsack kp = new FractionalKnapsack();
        double maxCost = kp.GetMaxCostFractional(wt, cost, capacity);
        Console.WriteLine("Maximum cost obtained = " + maxCost);
    }
}

/*
Maximum cost obtained = 230.0
*/