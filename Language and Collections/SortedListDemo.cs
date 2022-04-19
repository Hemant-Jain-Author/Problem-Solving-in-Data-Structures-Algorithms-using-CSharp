using System;
using System.Collections.Generic;

public class SortedListDemo
{
    public static void Main(string[] args)
    {
        // Create a Sorted List.
        SortedList<string, int> tm = new SortedList<string, int>();

        // Put elements into Sorted List
        tm["Apple"] = 40;
        tm["Mango"] = 20;
        tm["Banana"] = 10;

        Console.WriteLine("Size :: " + tm.Count);
        foreach (string key in tm.Keys)
        {
            Console.WriteLine(key + " cost :" + tm[key]);
        }

        Console.WriteLine("Apple present :: " + tm.ContainsKey("Apple"));
        Console.WriteLine("Grapes present :: " + tm.ContainsKey("Grapes"));

        tm.Remove("Apple");
        Console.WriteLine("Apple present :: " + tm.ContainsKey("Apple"));
    }
}
/*
Size :: 3
Apple cost :40
Banana cost :10
Mango cost :20
Apple present :: True
Grapes present :: False
Apple present :: False
*/
