using System;
using System.Collections.Generic;
public class LinkedListDemo
{
    public static void Main(string[] args)
    {
        LinkedList<int> ll = new LinkedList<int>();
        ll.AddFirst(1);
        ll.AddLast(3);
        ll.AddFirst(2);
        ll.AddLast(4);
        Console.Write("Linked List: ");
        foreach (var ele in ll)
            Console.Write(ele + " ");
        Console.WriteLine();
        ll.RemoveFirst();
        ll.RemoveLast();
        Console.Write("Linked List: ");
        foreach (var ele in ll)
            Console.Write(ele + " ");
        Console.WriteLine();
    }
}

/* 
Linked List: 2 1 3 4 
Linked List: 1 3 
*/