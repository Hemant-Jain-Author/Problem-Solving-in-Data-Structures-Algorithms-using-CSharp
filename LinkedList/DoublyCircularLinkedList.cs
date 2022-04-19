using System;

public class DoublyCircularLinkedList
{
    private Node head = null;
    private Node tail = null;
    private int size = 0;

    private class Node
    {
        internal int value;
        internal Node next;
        internal Node prev;

        internal Node(int v, Node nxt, Node prv)
        {
            value = v;
            next = nxt;
            prev = prv;
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

    public int PeekHead()
    {
        if (IsEmpty())
        {
            throw new System.InvalidOperationException("EmptyListException");
        }
        return head.value;
    }

    public void AddHead(int value)
    {
        Node newNode = new Node(value, null, null);
        if (size == 0)
        {
            tail = head = newNode;
            newNode.next = newNode;
            newNode.prev = newNode;
        }
        else
        {
            newNode.next = head;
            newNode.prev = head.prev;
            head.prev = newNode;
            newNode.prev.next = newNode;
            head = newNode;
        }
        size++;
    }

    public void AddTail(int value)
    {
        Node newNode = new Node(value, null, null);
        if (size == 0)
        {
            head = tail = newNode;
            newNode.next = newNode;
            newNode.prev = newNode;
        }
        else
        {
            newNode.next = tail.next;
            newNode.prev = tail;
            tail.next = newNode;
            newNode.next.prev = newNode;
            tail = newNode;
        }
        size++;
    }

    public int RemoveHead()
    {
        if (size == 0)
        {
            throw new System.InvalidOperationException("EmptyListException");
        }

        int value = head.value;
        size--;

        if (size == 0)
        {
            head = null;
            tail = null;
            return value;
        }

        Node next = head.next;
        next.prev = tail;
        tail.next = next;
        head = next;
        return value;
    }

    public int RemoveTail()
    {
        if (size == 0)
        {
            throw new System.InvalidOperationException("EmptyListException");
        }

        int value = tail.value;
        size--;

        if (size == 0)
        {
            head = null;
            tail = null;
            return value;
        }

        Node prev = tail.prev;
        prev.next = head;
        head.prev = prev;
        tail = prev;
        return value;
    }

    public bool Search(int key)
    {
        Node temp = head;
        if (head == null)
        {
            return false;
        }

        do
        {
            if (temp.value == key)
            {
                return true;
            }
            temp = temp.next;
        } while (temp != head);

        return false;
    }

    public void DeleteList()
    {
        head = null;
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
        Node temp = head;
        while (temp != tail)
        {
            Console.Write(temp.value + " ");
            temp = temp.next;
        }
        Console.WriteLine(temp.value);
    }

    public static void Main1()
    {
        DoublyCircularLinkedList ll = new DoublyCircularLinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.Print();
        Console.WriteLine(ll.Size());
        Console.WriteLine(ll.IsEmpty());
        Console.WriteLine(ll.PeekHead());
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
        DoublyCircularLinkedList ll = new DoublyCircularLinkedList();
        ll.AddTail(1);
        ll.AddTail(2);
        ll.AddTail(3);
        ll.Print();

        ll.RemoveHead();
        ll.Print();
        ll.RemoveTail();
        ll.Print();
        ll.DeleteList();
        ll.Print();
    }

/*
1 2 3
2 3
2
Empty List.
*/

    public static void Main3()
    {
        DoublyCircularLinkedList ll = new DoublyCircularLinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.Print();

        ll.RemoveHead();
        ll.Print();

    }
/*
3 2 1
2 1
*/
    public static void Main4()
    {
        DoublyCircularLinkedList ll = new DoublyCircularLinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.Print();

        ll.RemoveTail();
        ll.Print();
    }
/*
3 2 1
3 2
*/
    public static void Main(string[] args)
    {
        Main1();
        Main2();
        Main3();
        Main4();
    }
}