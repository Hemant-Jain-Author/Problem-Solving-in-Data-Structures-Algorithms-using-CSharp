using System;
using System.Collections.Generic;

public class Stack
{
    private Queue<int> que1 = new Queue<int>();
    private Queue<int> que2 = new Queue<int>();
    private int size = 0;

    public void Push(int value)
    {
        que1.Enqueue(value);
        size += 1;
    }

    public int Pop()
    {
        int value = 0, s = size;
        while (s > 0)
        {
            value = que1.Peek();
            que1.Dequeue();
            if (s > 1)
            {
                que2.Enqueue(value);
            }
            s--;
        }
        Queue<int> temp = que1;
        que1 = que2;
        que2 = temp;
        size -= 1;
        return value;
    }

    public int Pop2()
    {
        int value = 0, s = size;
        while (s > 0)
        {
            value = que1.Peek();
            que1.Dequeue();
            if (s > 1)
            {
                que1.Enqueue(value);
            }
            s--;
        }
        size -= 1;
        return value;
    }

    // Testing code.
    public static void Main1()
    {
        Stack s = new Stack();
        s.Push(1);
        s.Push(2);
        s.Push(3);
        Console.WriteLine("Stack pop : " + s.Pop() + " ");
        Console.WriteLine("Stack pop : " + s.Pop() + " ");
    }

    /*
    Stack pop : 3 
    Stack pop : 2     
    */

    public static void Main2()
    {
        Stack s = new Stack();
        s.Push(1);
        s.Push(2);
        s.Push(3);
        Console.WriteLine("Stack pop : " + s.Pop2() + " ");
        Console.WriteLine("Stack pop : " + s.Pop2() + " ");
    }

    /*
    Stack pop : 3 
    Stack pop : 2     
    */

    public static void Main(string[] args)
    {
        Main1();
        Main2();
    }
}
