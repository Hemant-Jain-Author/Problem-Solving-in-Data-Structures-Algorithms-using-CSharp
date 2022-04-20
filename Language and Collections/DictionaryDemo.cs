using System;
using System.Collections.Generic;

/*
A Dictionary is an object that stores associations between keys and values, or key/value pairs.
Both keys and values are objects. The keys must be unique, but the values may be duplicated.
*/

public class DictionaryDemo
{

    // Testing code.
    public static void Main(string[] args)
    {
        // Create a dictionary.
        Dictionary<string, int> hm = new Dictionary<string, int>();

        // Add elements into the dictionary.
        hm["Apple"] = 40;
        hm["Banana"] = 10;
        hm["Mango"] = 20;

        Console.WriteLine("Dictionary Size :: " + hm.Count);
        foreach (string key in hm.Keys)
        {
            Console.WriteLine(key + " cost :" + hm[key]);
        }

        Console.WriteLine("Apple present ::" + hm.ContainsKey("Apple"));
        Console.WriteLine("Grapes present :: " + hm.ContainsKey("Grapes"));
    }
}

/*
Dictionary Size :: 3
Apple cost :40
Banana cost :10
Mango cost :20
Apple present ::True
Grapes present :: False
*/