using System;

public class TST
{
    private Node root;

    private class Node
    {
        internal char data;
        internal bool isLastChar;
        internal Node left, equal, right;

        internal Node(char d)
        {
            data = d;
            isLastChar = false;
            left = equal = right = null;
        }
    }

    public void Add(string word)
    {
        root = Add(root, word, 0);
    }

    private Node Add(Node curr, string word, int wordIndex)
    {
        if (curr == null)
        {
            curr = new Node(word[wordIndex]);
        }

        if (word[wordIndex] < curr.data)
        {
            curr.left = Add(curr.left, word, wordIndex);
        }
        else if (word[wordIndex] > curr.data)
        {
            curr.right = Add(curr.right, word, wordIndex);
        }
        else if (wordIndex < word.Length - 1)
        {
            curr.equal = Add(curr.equal, word, wordIndex + 1);
        }
        else
        {
            curr.isLastChar = true;
        }
        return curr;
    }

    private bool Find(Node curr, string word, int wordIndex)
    {
        if (curr == null)
        {
            return false;
        }
        if (word[wordIndex] < curr.data)
        {
            return Find(curr.left, word, wordIndex);
        }
        else if (word[wordIndex] > curr.data)
        {
            return Find(curr.right, word, wordIndex);
        }
        else if (wordIndex == word.Length - 1)
        {
            return curr.isLastChar;
        }
        
        return Find(curr.equal, word, wordIndex + 1);
    }

    public bool Find(string word)
    {
        bool ret = Find(root, word, 0);
        return ret;
    }

    // Testing code.
    public static void Main(string[] args)
    {
        TST tt = new TST();
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