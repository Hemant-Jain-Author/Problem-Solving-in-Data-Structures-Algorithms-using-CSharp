using System;
using System.Collections.Generic;

public class SortedListDemo
{
	public static void Main(string[] args)
	{
		// Create a Sorted List.
		SortedList<string, int> tm = new SortedList<string, int>();

		// Put elements into Sorted List
		tm["William"] = 99;
		tm["Alexander"] = 80;
		tm["Michael"] = 50;
		tm["Emma"] = 65;

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
/*
Total number of students in class :: 4
Alexander score marks :80
Emma score marks :65
Michael score marks :50
William score marks :99
Emma present in class :: True
John present in class :: False
Emma present in class :: False
*/
