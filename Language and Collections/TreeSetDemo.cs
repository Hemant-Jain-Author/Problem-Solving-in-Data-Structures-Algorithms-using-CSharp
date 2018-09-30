using System;
using System.Collections.Generic;

public class TreeSetDemo
{
	public static void Main(string[] args)
	{
		// Create a tree set.
		SortedSet<string> ts = new SortedSet<string>();
		// Add elements to the tree set.
		ts.Add("India");
		ts.Add("USA");
		ts.Add("Brazile");
		ts.Add("Canada");
		ts.Add("UK");
		ts.Add("China");
		ts.Add("France");
		ts.Add("Spain");
		ts.Add("Italy");
		Console.WriteLine(ts);
	}
}