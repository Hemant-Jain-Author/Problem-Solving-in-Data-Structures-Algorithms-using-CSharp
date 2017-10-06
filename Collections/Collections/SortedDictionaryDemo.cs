using System;
using System.Collections.Generic;

public class SortedDictionaryDemo
{
	public static void Main88(string[] args)
	{
		// Create a Sorted Dictionary.
		SortedDictionary<string, int> tm = new SortedDictionary<string, int>();

		// Put elements into Sorted Dictionary
		tm["Mason"] = 55;
		tm["Jacob"] = 77;
		tm["William"] = 99;
		tm["Alexander"] = 80;
		tm["Michael"] = 50;
		tm["Emma"] = 65;
		tm["Olivia"] = 77;
		tm["Sophia"] = 88;
		tm["Emily"] = 99;
		tm["Isabella"] = 100;

		Console.WriteLine("Total number of students in class :: " + tm.Count);
		foreach (string key in tm.Keys)
		{
			Console.WriteLine(key + " score marks :" + tm[key]);
		}

		Console.WriteLine("Emma present in class :: " + tm.ContainsKey("Emma"));
		Console.WriteLine("John present in class :: " + tm.ContainsKey("John"));
		tm.Remove("Emma");
		Console.WriteLine("Emma present in class :: " + tm.ContainsKey("Emma"));
	}
}
