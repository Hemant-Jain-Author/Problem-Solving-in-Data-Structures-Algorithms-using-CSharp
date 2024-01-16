using System;
using System.Collections.Generic;

public class QueueUsingStack
{

    private Stack<int> stk1;
    private Stack<int> stk2;

    public QueueUsingStack()
    {
        stk1 = new Stack<int>();
        stk2 = new Stack<int>();
    }

    public void Add(int value)
    {
        stk1.Push(value);
    }

    public int Remove()
    {
        int value;
        if (stk2.Count > 0)
        {
            return stk2.Pop();
        }

        while (stk1.Count > 0)
        {
            value = stk1.Pop();
            stk2.Push(value);
        }
        return stk2.Pop();
    }

    // Testing code.
    public static void Main(string[] args)
    {
        QueueUsingStack que = new QueueUsingStack();
        que.Add(1);
        que.Add(2);
        que.Add(3);
        Console.WriteLine("Queue remove : " + que.Remove());
        Console.WriteLine("Queue remove : " + que.Remove());
    }
}

/*
1
2
*/