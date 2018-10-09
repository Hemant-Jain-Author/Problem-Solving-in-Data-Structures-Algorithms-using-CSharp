using System;
using System.Collections.Generic;

public class HashSetDemo
{
	public static void Main(string[] args)
	{
		// Create a hash set.
		HashSet<string> hs = new HashSet<string>();
		
		// Add elements to the hash set.
		hs.Add("India");
		hs.Add("USA");
		hs.Add("Brazil");
		hs.Add("Canada");
		foreach (String str in hs)
			Console.Write(str+ " ");

		Console.WriteLine("Hash Table contains USA : " + hs.Contains("USA"));
		Console.WriteLine("Hash Table contains Russia:"+ hs.Contains("Russia"));
		hs.Remove("USA");
		Console.WriteLine("Hash Table contains USA : " + hs.Contains("USA"));
	}
}
