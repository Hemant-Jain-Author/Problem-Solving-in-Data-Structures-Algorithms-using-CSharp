using System;

public class StringTree
{
    private Node root = null;

    private class Node
    {
        internal string value;
        internal int count;
        internal Node lChild;
        internal Node rChild;
    }

    // Other Methods.
    public void Print()
    {
        Print(root);
    }

    private void Print(Node curr) // pre order
    {
        if (curr != null)
        {
            Console.Write(" value is ::" + curr.value);
            Console.WriteLine(" count is :: " + curr.count);
            Print(curr.lChild);
            Print(curr.rChild);
        }
    }

    public void Add(string value)
    {
        root = Add(value, root);
    }

    private Node Add(string value, Node curr)
    {
        if (curr == null)
        {
            curr = new Node();
            curr.value = value;
            curr.lChild = curr.rChild = null;
            curr.count = 1;
        }
        else
        {
            int compare = string.CompareOrdinal(curr.value, value);
            if (compare == 0)
            {
                curr.count++;
            }
            else if (compare == 1)
            {
                curr.lChild = Add(value, curr.lChild);
            }
            else
            {
                curr.rChild = Add(value, curr.rChild);
            }
        }
        return curr;
    }

    public bool Find(string value)
    {
        return Find(root, value);
    }

    private bool Find(Node curr, string value)
    {
        if (curr == null)
        {
            return false;
        }
        int compare = string.CompareOrdinal(curr.value, value);
        if (compare == 0)
        {
            return true;
        }

        if (compare == 1)
        {
            return Find(curr.lChild, value);
        }

        return Find(curr.rChild, value);
    }

    public int Frequency(string value)
    {
        return Frequency(root, value);
    }

    private int Frequency(Node curr, string value)
    {
        if (curr == null)
        {
            return 0;
        }

        int compare = string.CompareOrdinal(curr.value, value);
        if (compare == 0)
        {
            return curr.count;
        }

        if (compare > 0)
        {
            return Frequency(curr.lChild, value);
        }

        return Frequency(curr.rChild, value);
    }

    public void FreeTree()
    {
        root = null;
    }

    // Testing code.
    public static void Main(string[] args)
    {
        StringTree tt = new StringTree();
        tt.Add("banana");
        tt.Add("apple");
        tt.Add("mango");
        Console.WriteLine("Apple Found : " + tt.Find("apple"));
        Console.WriteLine("Banana Found : " + tt.Find("banana"));
        Console.WriteLine("Grapes Found : " + tt.Find("grapes"));

    }
}

/*
Apple Found : True
Banana Found : True
Grapes Found : False
*/