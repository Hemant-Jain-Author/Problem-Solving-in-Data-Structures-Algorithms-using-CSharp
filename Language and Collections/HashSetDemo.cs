using System;
using System.Collections.Generic;

public class HashSetDemo
{
	public static void Main(string[] args)
	{
		// Create a hash set.
		HashSet<string> hs = new HashSet<string>();
		// Add elements to the hash set.
		hs.Add("Banana");
		hs.Add("Apple");
		hs.Add("Mango");
		foreach(var ele in hs)
		{
			Console.Write(ele + " ");
		}
		Console.WriteLine();
		
		Console.WriteLine("Apple present : " + hs.Contains("Apple"));
		Console.WriteLine("Grapes present : " + hs.Contains("Grapes"));
		hs.Remove("Apple");
		Console.WriteLine("Apple present : " + hs.Contains("Apple"));
		foreach(var ele in hs)
		{
			Console.Write(ele + " ");
		}
		Console.WriteLine();		
	}
}

/*
Banana Apple Mango 
Apple present : True
Grapes present : False
Apple present : False
Banana Mango 
*/