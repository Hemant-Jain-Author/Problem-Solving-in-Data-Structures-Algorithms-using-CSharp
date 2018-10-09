using System;
using System.Collections.Generic;

class SortedSetDemo
{
	public static void Main(string[] args)
	{
		// Create a Sorted set.
		SortedSet<string> ts = new SortedSet<string>();
		// Add elements to the Sorted set.
		ts.Add("India");
		ts.Add("USA");
		ts.Add("Brazil");
		ts.Add("Canada");
		
		foreach(String str in ts)
			Console.Write(str + " ");
	}
}
