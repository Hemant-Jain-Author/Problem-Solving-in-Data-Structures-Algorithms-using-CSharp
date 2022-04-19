using System;

public class CircularLinkedList
{
    private Node tail;
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

    /* Other methods */

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
            throw new System.InvalidOperationException("EmptyListException");
        }
        return tail.next.value;
    }

    public void AddTail(int value)
    {
        Node temp = new Node(value, null);
        if (IsEmpty())
        {
            tail = temp;
            temp.next = temp;
        }
        else
        {
            temp.next = tail.next;
            tail.next = temp;
            tail = temp;
        }
        size++;
    }

    public void AddHead(int value)
    {
        Node temp = new Node(value, null);
        if (IsEmpty())
        {
            tail = temp;
            temp.next = temp;
        }
        else
        {
            temp.next = tail.next;
            tail.next = temp;
        }
        size++;
    }
    public int RemoveHead()
    {
        if (IsEmpty())
        {
            throw new System.InvalidOperationException("EmptyListException");
        }
        int value = tail.next.value;
        if (tail == tail.next)
        {
            tail = null;
        }
        else
        {
            tail.next = tail.next.next;
        }

        size--;
        return value;
    }

    public bool DeleteNode(int key)
    {
        if (IsEmpty())
        {
            return false;
        }
        Node prev = tail;
        Node curr = tail.next;
        Node head = tail.next;

        if (curr.value == key) // head and single node case.
        {
            if (curr == curr.next) // single node case
            {
                tail = null;
            }
            else // head case
            {
                tail.next = tail.next.next;
            }
            return true;
        }

        prev = curr;
        curr = curr.next;

        while (curr != head)
        {
            if (curr.value == key)
            {
                if (curr == tail)
                {
                    tail = prev;
                }
                prev.next = curr.next;
                return true;
            }
            prev = curr;
            curr = curr.next;
        }

        return false;
    }

    public CircularLinkedList CopyListReversed()
    {
        CircularLinkedList cl = new CircularLinkedList();
        if (tail == null)
        {
            return cl;
        }
        Node curr = tail.next;
        Node head = curr;

        if (curr != null)
        {
            cl.AddHead(curr.value);
            curr = curr.next;
        }
        while (curr != head)
        {
            cl.AddHead(curr.value);
            curr = curr.next;
        }
        return cl;
    }

    public CircularLinkedList CopyList()
    {
        CircularLinkedList cl = new CircularLinkedList();
        if (tail == null)
        {
            return cl;
        }
        Node curr = tail.next;
        Node head = curr;

        if (curr != null)
        {
            cl.AddTail(curr.value);
            curr = curr.next;
        }
        while (curr != head)
        {
            cl.AddTail(curr.value);
            curr = curr.next;
        }
        return cl;
    }

    public bool Search(int data)
    {
        Node temp = tail;
        for (int i = 0; i < size; i++)
        {
            if (temp.value == data)
            {
                return true;
            }
            temp = temp.next;
        }
        return false;
    }

    public void DeleteList()
    {
        tail = null;
        size = 0;
    }

    public void Print()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Empty List.");
            return;
        }
        Node temp = tail.next;
        while (temp != tail)
        {
            Console.Write(temp.value + " ");
            temp = temp.next;
        }
        Console.WriteLine(temp.value);
    }

    public static void Main1()
    {
        CircularLinkedList ll = new CircularLinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.Print();
        Console.WriteLine(ll.Size());
        Console.WriteLine(ll.IsEmpty());
        Console.WriteLine(ll.Peek());
        Console.WriteLine(ll.Search(3));
    }

    /*
3 2 1
3
False
3
True
    */

    public static void Main2()
    {
        CircularLinkedList ll = new CircularLinkedList();
        ll.AddTail(1);
        ll.AddTail(2);
        ll.AddTail(3);
        ll.Print();
    }

    /*
    1 2 3
    */

    public static void Main3()
    {
        CircularLinkedList ll = new CircularLinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.Print();
        ll.RemoveHead();
        ll.Print();
        ll.DeleteNode(2);
        ll.Print();
        ll.DeleteList();
        ll.Print();
    }

    /*
3 2 1
2 1
1
Empty List.
    */

    public static void Main4()
    {
        CircularLinkedList ll = new CircularLinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.Print();
        CircularLinkedList ll2 = ll.CopyList();
        ll2.Print();
        CircularLinkedList ll3 = ll.CopyListReversed();
        ll3.Print();
    }

    /*
    3 2 1
    3 2 1
    1 2 3
    */

    public static void Main5()
    {
        CircularLinkedList ll = new CircularLinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.Print();
        ll.DeleteNode(2);
        ll.Print();
    }

    /*
    3 2 1
    3 1
    */

    public static void Main(string[] args)
    {
        Main1();
        Main2();
        Main3();
        Main4();
        Main5();
    }
}