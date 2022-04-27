using System;
using System.Collections.Generic;

public class HeapEx
{
    public static void Main(string[] args)
    {
        PriorityQueue<string, int> queue = new PriorityQueue<string, int>();
        queue.Enqueue("A", 95);
        queue.Enqueue("B", 96);
        queue.Enqueue("C", 97);
        queue.Enqueue("D", 98);
        while (queue.TryDequeue(out string item, out int priority))
        {
            Console.WriteLine($"Popped Item : {item}. Priority Was : {priority}");
        }
    }
}