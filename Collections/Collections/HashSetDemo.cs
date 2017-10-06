using System;
using System.Collections.Generic;

public class HashSetDemo
{
	public static void Main3(string[] args)
	{
		// Create a hash set.
		HashSet<string> hs = new HashSet<string>();

		// Add elements to the hash set.
		hs.Add("India");
		hs.Add("USA");
		hs.Add("Brazile");
		hs.Add("Canada");
		hs.Add("UK");
		hs.Add("China");
		hs.Add("France");
		hs.Add("Spain");
		hs.Add("Italy");

		foreach (String str in hs)
			Console.Write(str);

		Console.WriteLine("Hash Table contains USA : " + hs.Contains("USA"));
		Console.WriteLine("Hash Table contains Russia : " + hs.Contains("Russia"));

		hs.Remove("USA");
		foreach (String str in hs)
			Console.Write(str);
		Console.WriteLine("Hash Table contains USA : " + hs.Contains("USA"));
	}
}