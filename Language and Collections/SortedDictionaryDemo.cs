using System;
using System.Collections.Generic;

public class TreeMapDemo
{
    public static void Main(string[] args)
    {
        // create a tree map.
        SortedDictionary<string, int> tm = new SortedDictionary<string, int>();
        // Put elements into the map
        tm["Apple"] = 40;
        tm["Banana"] = 10;
        tm["Mango"] = 20;

        Console.WriteLine("Size :: " + tm.Count);
        foreach (string key in tm.Keys)
        {
            Console.WriteLine(key + " cost :" + tm[key]);
        }
        Console.WriteLine("Apple present ::" + tm.ContainsKey("Apple"));
        Console.WriteLine("Grapes present :: " + tm.ContainsKey("Grapes"));
    }
}

/*
Size :: 3
Apple cost :40
Banana cost :10
Mango cost :20
Apple present ::True
Grapes present :: False
*/