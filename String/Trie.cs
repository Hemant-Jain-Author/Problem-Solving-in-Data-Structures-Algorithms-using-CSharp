using System;

public class Trie
{
    private const int CharCount = 26;
    private Node root = null;

    private class Node
    {
        internal bool isLastChar;
        internal Node[] child;

        internal Node(char c)
        {
            child = new Node[CharCount];
            for (int i = 0; i < CharCount; i++)
            {
                child[i] = null;
            }
            isLastChar = false;
        }
    }

    public Trie()
    {
        root = new Node(' ');
    }

    public void Add(string str)
    {
        if (str == null)
            return;
        Add(root, str.ToLower(), 0);
    }

    private Node Add(Node curr, string str, int index)
    {
        if (curr == null)
        {
            curr = new Node(str[index - 1]);
        }

        if (str.Length == index)
        {
            curr.isLastChar = true;
        }
        else
        {
            curr.child[str[index] - 'a'] = Add(curr.child[str[index] - 'a'], str, index + 1);
        }
        return curr;
    }

    public void Remove(string str)
    {
        if (string.ReferenceEquals(str, null))
        {
            return;
        }
        str = str.ToLower();
        Remove(root, str, 0);
    }

    private void Remove(Node curr, string str, int index)
    {
        if (curr == null)
        {
            return;
        }
        if (str.Length == index)
        {
            if (curr.isLastChar)
            {
                curr.isLastChar = false;
            }
            return;
        }
        Remove(curr.child[str[index] - 'a'], str, index + 1);
    }

    public bool Find(string str)
    {
        if (string.ReferenceEquals(str, null))
        {
            return false;
        }
        str = str.ToLower();
        return Find(root, str, 0);
    }

    private bool Find(Node curr, string str, int index)
    {
        if (curr == null)
        {
            return false;
        }
        if (str.Length == index)
        {
            return curr.isLastChar;
        }
        return Find(curr.child[str[index] - 'a'], str, index + 1);
    }

    // Testing code.
    public static void Main(string[] args)
    {
        Trie tt = new Trie();
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