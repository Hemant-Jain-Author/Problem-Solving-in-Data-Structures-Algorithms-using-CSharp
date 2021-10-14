using System;
using System.Collections.Generic;

public class SortedSetDemo
{
	public static void Main(string[] args)
	{
		// Create a tree set.
		SortedSet<string> ts = new SortedSet<string>();
		// Add elements to the hash set.
		ts.Add("Banana");
		ts.Add("Apple");
		ts.Add("Mango");
		foreach(var ele in ts){
			Console.Write(ele + " ");
		}
		Console.WriteLine();

		Console.WriteLine("Apple present : " + ts.Contains("Apple"));
		Console.WriteLine("Grapes present : " + ts.Contains("Grapes"));
		ts.Remove("Apple");
		Console.WriteLine("Apple present : " + ts.Contains("Apple"));
	}
}

/*
Apple Banana Mango 
Apple present : True
Grapes present : False
Apple present : False
*/