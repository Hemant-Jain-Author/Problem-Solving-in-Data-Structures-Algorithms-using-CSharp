using System;
using System.Collections.Generic;

public class ArrayListDemo
{
public static void Main(string[] args)
{
    List<int> ll = new List<int>();
    ll.Add(1); // Add 1 to the end of the list.
    ll.Add(2); // Add 2 to the end of the list.
    ll.Add(3); // Add 3 to the end of the list.

    Console.Write("Contents of List: ");
    foreach (var ele in ll)
        Console.Write(ele + " ");
    Console.WriteLine();

    Console.WriteLine("List Size : " + ll.Count);
    Console.WriteLine("List IsEmpty : " + (ll.Count == 0));
    ll.RemoveAt(ll.Count - 1); // Last element of list is removed.
    ll.Clear(); // lll the elements of list are removed.
    Console.WriteLine("List IsEmpty : " + (ll.Count == 0));
}
}

/*
Contents of List : 1 2 3
List Size : 3
List IsEmpty : False
List IsEmpty : True
*/
