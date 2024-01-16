using System;

public class QueueLL
{
    private Node tail = null;
    private int size = 0;

    private class Node
    {
        internal int value;
        internal Node next;

        internal Node(int v, Node n)
        {
            value = v;
            next = n;
        }
    }

    public int Size()
    {
        return size;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public int Peek()
    {
        if (IsEmpty())
        {
            throw new System.InvalidOperationException("StackEmptyException");
        }
        int value;
        if (tail == tail.next)
        {
            value = tail.value;
        }
        else
        {
            value = tail.next.value;
        }

        return value;
    }

    public void Add(int value)
    {
        Node temp = new Node(value, null);
        if (tail == null)
        {
            tail = temp;
            tail.next = tail;
        }
        else
        {
            temp.next = tail.next;
            tail.next = temp;
            tail = temp;
        }
        size++;
    }

    public int Remove()
    {
        if (size == 0)
        {
            throw new System.InvalidOperationException("StackEmptyException");
        }

        int value = 0;
        if (tail == tail.next)
        {
            value = tail.value;
            tail = null;
        }
        else
        {
            value = tail.next.value;
            tail.next = tail.next.next;
        }
        size--;
        return value;
    }

    public void Print()
    {
        if (size == 0)
        {
            Console.Write("Queue is empty.");
            return;
        }
        Node temp = tail.next;
        Console.Write("Queue is : ");
        for (int i = 0;i < size;i++)
        {
            Console.Write(temp.value + " ");
            temp = temp.next;
        }
        Console.WriteLine();
    }

    // Testing code.
    public static void Main(string[] args)
    {
        QueueLL que = new QueueLL();
        que.Add(1);
        que.Add(2);
        que.Add(3);
        Console.WriteLine("IsEmpty : " + que.IsEmpty());
        Console.WriteLine("Size : " + que.Size());
        Console.WriteLine("Queue remove : " + que.Remove());
        Console.WriteLine("Queue remove : " + que.Remove());
    }
}
/*
IsEmpty : False
Size : 3
Queue remove : 1
Queue remove : 2
*/