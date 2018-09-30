using System;
using System.Collections.Generic;

public class LinkedListDemo
{
	public static void Main66(string[] args)
	{
		LinkedList<int> ll = new LinkedList<int>();
		ll.AddFirst(10);
		ll.AddLast(20);
		ll.AddFirst(9);
		ll.AddLast(21);
		ll.AddFirst(8);
		ll.AddLast(22);

		Console.Write("Contents of Linked List: ");
		foreach (int val in ll)
		{
			Console.Write(val + " ");
		}

		ll.RemoveFirst();
		ll.RemoveLast();

		Console.Write("\nContents of Linked List: ");
		foreach (int val in ll)
		{
			Console.Write(val + " ");
		}
	}
}