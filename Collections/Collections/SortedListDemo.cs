using System;
using System.Collections.Generic;

public class SortedListDemo
{
	public static void Main(string[] args)
	{
		// Create a Sorted List.
		SortedList<string, int> tm = new SortedList<string, int>();

		// Put elements into Sorted List
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
