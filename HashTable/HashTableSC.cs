using System;

public class HashTableSC
{
    private int tableSize;
    private Node[] listArray;

    private class Node
    {
        internal int value;
        internal Node next;

        public Node(int v, Node n)
        {
            value = v;
            next = n;
        }
    }

    public HashTableSC()
    {
        tableSize = 512;
        listArray = new Node[tableSize];
        for (int i = 0; i < tableSize; i++)
        {
            listArray[i] = null;
        }
    }

    private int ComputeHash(int key) // division method
    {
        int hashValue = key;
        return hashValue % tableSize;
    }

    public void Add(int value)
    {
        int index = ComputeHash(value);
        listArray[index] = new Node(value, listArray[index]);
    }

    public bool Remove(int value)
    {
        int index = ComputeHash(value);
        Node nextNode, head = listArray[index];
        if (head != null && head.value == value)
        {
            listArray[index] = head.next;
            return true;
        }
        while (head != null)
        {
            nextNode = head.next;
            if (nextNode != null && nextNode.value == value)
            {
                head.next = nextNode.next;
                return true;
            }
            else
            {
                head = nextNode;
            }
        }
        return false;
    }

    public void Print()
    {
        Console.Write("Hash Table contains ::");
        for (int i = 0; i < tableSize; i++)
        {
            Node head = listArray[i];
            while (head != null)
            {
                Console.Write(head.value + " ");
                head = head.next;
            }
        }
        Console.WriteLine();
    }

    public bool Find(int value)
    {
        int index = ComputeHash(value);
        Node head = listArray[index];
        while (head != null)
        {
            if (head.value == value)
            {
                return true;
            }
            head = head.next;
        }
        return false;
    }

    // Testing code.
    public static void Main(string[] args)
    {
        HashTableSC ht = new HashTableSC();
        ht.Add(1);
        ht.Add(2);
        ht.Add(3);
        ht.Print();
        Console.WriteLine("Find key 2 : " + ht.Find(2));
        ht.Remove(2);
        Console.WriteLine("Find key 2 : " + ht.Find(2));
    }
}

/*
Hash Table contains ::1 2 3 
Find key 2 : true
Find key 2 : false
*/