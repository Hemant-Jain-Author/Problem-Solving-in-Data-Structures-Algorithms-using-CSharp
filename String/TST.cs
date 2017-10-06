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

	public virtual void insert(string word)
	{
		root = insert(root, word, 0);
	}

	private Node insert(Node curr, string word, int wordIndex)
	{
		if (curr == null)
		{
			curr = new Node(word[wordIndex]);
		}
		if (word[wordIndex] < curr.data)
		{
			curr.left = insert(curr.left, word, wordIndex);
		}
		else if (word[wordIndex] > curr.data)
		{
			curr.right = insert(curr.right, word, wordIndex);
		}
		else
		{
			if (wordIndex < word.Length - 1)
			{
				curr.equal = insert(curr.equal, word, wordIndex + 1);
			}
			else
			{
				curr.isLastChar = true;
			}
		}
		return curr;
	}

	private bool find(Node curr, string word, int wordIndex)
	{
		if (curr == null)
		{
			return false;
		}
		if (word[wordIndex] < curr.data)
		{
			return find(curr.left, word, wordIndex);
		}
		else if (word[wordIndex] > curr.data)
		{
			return find(curr.right, word, wordIndex);
		}
		else
		{
			if (wordIndex == word.Length - 1)
			{
				return curr.isLastChar;
			}
			return find(curr.equal, word, wordIndex + 1);
		}
	}

	public virtual bool find(string word)
	{
		bool ret = find(root, word, 0);
		Console.Write(word + " :: ");
		if (ret)
		{
			Console.WriteLine(" Found ");
		}
		else
		{
			Console.WriteLine("Not Found ");
		}
		return ret;
	}

	public static void Main(string[] args)
	{

		TST tt = new TST();
		tt.insert("banana");
		tt.insert("apple");
		tt.insert("mango");
		Console.WriteLine("\nSearch results for apple, banana, grapes and mango :");
		tt.find("apple");
		tt.find("banana");
		tt.find("mango");
		tt.find("grapes");
	}
}