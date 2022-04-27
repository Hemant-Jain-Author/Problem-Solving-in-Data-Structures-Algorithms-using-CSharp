using System;

public class Queue
{
    private int capacity;
    private int[] data;
    private int size = 0;    
    private int front = 0;
    private int back = 0;

    public Queue(int n = 1000)
    {
        capacity = n;
        data = new int[n];
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public int Size()
    {
        return size;
    }

    public void Print()
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
    public bool Add(int value)
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

    public int Remove()
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

    // Testing code.
    public static void Main(string[] args)
    {
        Queue que = new Queue();
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