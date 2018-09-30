using System;
using System.Collections.Generic;

class SortedSetDemo
{
	public static void Main66(string[] args)
	{
		// Create a Sorted set.
		SortedSet<string> ts = new SortedSet<string>();

		// Add elements to the Sorted set.
		ts.Add("India");
		ts.Add("USA");
		ts.Add("Brazile");
		ts.Add("Canada");
		ts.Add("UK");
		ts.Add("China");
		ts.Add("France");
		ts.Add("Spain");
		ts.Add("Italy");

		foreach (String str in ts)
			Console.Write(str + " ");
	}
}

