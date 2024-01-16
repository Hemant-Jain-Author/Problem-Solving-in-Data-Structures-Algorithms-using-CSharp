using System;

public class HashTableSC
{
    private int tableSize;
    private Node[] listArray;

    private class Node
    {
        internal int key;
        internal int value;
        internal Node next;

        public Node(int k, int v, Node n)
        {
            key = k;
            value = v;
            next = n;
        }
    }

    public HashTableSC()
    {
        tableSize = 512;
        listArray = new Node[tableSize];
        Array.Fill(listArray, null);
    }

    private int ComputeHash(int key) // division method
    {
        int hashValue = key;
        return hashValue % tableSize;
    }

    public void Add(int key, int value)
    {
        int index = ComputeHash(key);
        listArray[index] = new Node(key, value, listArray[index]);
    }

    public void Add(int value)
    {
        Add(value, value);
    }

    public bool Remove(int key)
    {
        int index = ComputeHash(key);
        Node nextNode, head = listArray[index];
        if (head != null && head.key == key)
        {
            listArray[index] = head.next;
            return true;
        }
        while (head != null)
        {
            nextNode = head.next;
            if (nextNode != null && nextNode.key == key)
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
                Console.Write("(" + head.key + "=>" + head.value + ") ");
                head = head.next;
            }
        }
        Console.WriteLine();
    }

    public bool Find(int key)
    {
        int index = ComputeHash(key);
        Node head = listArray[index];
        while (head != null)
        {
            if (head.key == key)
            {
                return true;
            }
            head = head.next;
        }
        return false;
    }

    public int Get(int key)
    {
        int index = ComputeHash(key);
        Node head = listArray[index];
        while (head != null)
        {
            if (head.key == key)
            {
                return head.value;
            }
            head = head.next;
        }
        return -1;
    }

    // Testing code.
    public static void Main(string[] args)
    {
        HashTableSC ht = new HashTableSC();
        ht.Add(1, 10);
        ht.Add(2, 20);
        ht.Add(3, 30);
        ht.Print();
        Console.WriteLine("Find key 2 : " + ht.Find(2));
        Console.WriteLine("Value at  key 2 : " + ht.Get(2));
        ht.Remove(2);
        Console.WriteLine("Find key 2 : " + ht.Find(2));
        ht.Print();
    }
}

/*
Hash Table contains ::(1=>10) (2=>20) (3=>30) 
Find key 2 : True
Value at  key 2 : 20
Find key 2 : False
Hash Table contains ::(1=>10) (3=>30) 
*/