using System;
using System.Collections.Generic;

class QueueDemo
{
    public static void Main(string[] args)
    {
        Queue<int> que = new Queue<int>();
        que.Enqueue(1);
        que.Enqueue(2);
        que.Enqueue(3);

        Console.Write("Queue : ");
        foreach (var ele in que)
            Console.Write(ele + " ");
        Console.WriteLine();

        Console.WriteLine("Queue size : " + que.Count);
        Console.WriteLine("Queue peek : " + que.Peek());
        Console.WriteLine("Queue remove : " + que.Dequeue());
        Console.WriteLine("Queue isEmpty : " + (que.Count == 0));
    }
}


/* 
Queue : 1 2 3 
Queue size : 3
Queue peek : 1
Queue remove : 1
Queue isEmpty : False
*/