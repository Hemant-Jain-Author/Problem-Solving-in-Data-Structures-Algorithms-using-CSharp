using System;

public class Trie
{
	private const int CharCount = 26;
	private Node root = null;

	private class Node
	{
		internal bool isLastChar;
		internal Node[] child;

		public Node(char c)
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
		root = new Node(' '); // first node with dummy value.
	}

	public bool Add(string str)
	{
		if (string.ReferenceEquals(str, null))
			return false;

		if (Add(root, str.ToLower(), 0) != null)
			return true;
		return false;
	}

	private Node Add(Node curr, string str, int index)
	{
		if (curr == null)
			curr = new Node(str[index - 1]);

		if (str.Length == index)
			curr.isLastChar = true;
		else
			curr.child[str[index] - 'a'] = Add(curr.child[str[index] - 'a'], str, index + 1);
		return curr;
	}

	public void Remove(string str)
	{
		if (string.ReferenceEquals(str, null))
			return;
		str = str.ToLower();
		Remove(root, str, 0);
	}

	private void Remove(Node curr, string str, int index)
	{
		if (curr == null)
			return;

		if (str.Length == index)
		{
			if (curr.isLastChar)
				curr.isLastChar = false;
			return;
		}
		Remove(curr.child[str[index] - 'a'], str, index + 1);
	}

	public bool Find(string str)
	{
		if (string.ReferenceEquals(str, null))
			return false;

		str = str.ToLower();
		return Find(root, str, 0);
	}

	private bool Find(Node curr, string str, int index)
	{
		if (curr == null)
			return false;

		if (str.Length == index)
			return curr.isLastChar;

		return Find(curr.child[str[index] - 'a'], str, index + 1);
	}

	public static void Main(string[] args)
	{
		Trie t = new Trie();
		string a = "hemant";
		string b = "heman";
		string c = "hemantjain";
		string d = "jain";
		t.Add(a);
		t.Add(d);
		Console.WriteLine(t.Find(a));
		t.Remove(a);
		t.Remove(d);
		Console.WriteLine(t.Find(a));
		Console.WriteLine(t.Find(c));
		Console.WriteLine(t.Find(d));
	}
}