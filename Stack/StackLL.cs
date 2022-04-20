using System;

public class StackLL
{
    private Node head = null;
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
        return head.value;
    }

    public void Push(int value)
    {
        head = new Node(value, head);
        size++;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            throw new System.InvalidOperationException("StackEmptyException");
        }
        int value = head.value;
        head = head.next;
        size--;
        return value;
    }

    public void InsertAtBottom(int value)
    {
        if (IsEmpty())
        {
            Push(value);
        }
        else
        {
            int temp = Pop();
            InsertAtBottom(value);
            Push(temp);
        }
    }

    public void Print()
    {
        Node temp = head;
        while (temp != null)
        {
            Console.Write(temp.value + " ");
            temp = temp.next;
        }
        Console.WriteLine();
    }

    // Testing code.
    public static void Main(string[] args)
    {
        StackLL s = new StackLL();
        s.Push(1);
        s.Push(2);
        s.Push(3);
        s.Print();
        Console.WriteLine(s.Pop());
        Console.WriteLine(s.Pop());
    }
}
/*
3 2 1 
3
2
*/
