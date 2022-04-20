using System;

public class Queue
{
    private int size;
    private int capacity = 100;
    private int[] data;
    internal int front = 0;
    internal int back = 0;

    public Queue(int n)
    {
        size = 0;
        capacity = n;
        data = new int[n];
    }

    public bool add(int value)
    {
        if (size >= capacity)
        {
            Console.WriteLine("Queue is full.");
            return false;
        }
        else
        {
            size++;
            data[back] = value;
            back = (++back) % capacity;
        }
        return true;
    }

    public int remove()
    {
        int value;
        if (size <= 0)
        {
            Console.WriteLine("Queue is empty.");
            return -999;
        }
        else
        {
            size--;
            value = data[front];
            front = (++front) % capacity;
        }
        return value;
    }

    internal bool isEmpty()
    {
        return size == 0;
    }

    internal int Size()
    {
        return size;
    }

    internal void print()
    {
        if (size == 0)
        {
            Console.Write("Queue is empty.");
            return;
        }
        int temp = front;
        int s = size;
        Console.Write("Queue is : ");
        while (s > 0)
        {
            s--;
            Console.Write(data[temp] + " ");
            temp = (++temp) % capacity;
        }
        Console.WriteLine();
    }

    // Testing code.
    public static void Main(string[] args)
    {
        Queue que = new Queue(5);
        for (int i = 0;i < 5;i++)
        {
            que.add(i);
        }
        que.print();

        for (int i = 0; i < 5; i++)
        {
            Console.Write(que.remove() + " ");
        }
    }
}

/*
Queue is : 0 1 2 3 4 
0 1 2 3 4 
*/