using System;
using System.Collections.Generic;

public class DictionaryDemo
{
	public static void Main(string[] args)
	{
		// Create a Dictionary or map.
		Dictionary<string, int> hm = new Dictionary<string, int>();

		// Put elements into the Dictionary or map
		hm["William"] = 99;
		hm["Alexander"] = 80;
		hm["Michael"] = 50;
		hm["Emma"] = 65;

		Console.WriteLine("Total number of students in class :: " + hm.Count);
		foreach (string key in hm.Keys)
			Console.WriteLine(key + " score marks :" + hm[key]);

		Console.WriteLine("Emma present in class :: " + hm.ContainsKey("Emma"));
		Console.WriteLine("John present in class :: " + hm.ContainsKey("John"));
	}
}
