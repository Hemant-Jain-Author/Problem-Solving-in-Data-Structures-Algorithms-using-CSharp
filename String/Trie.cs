using System;

public class Trie
{
	private const int CharCount = 26;
	private Node root = null;

	private class Node
	{
		private bool isLastChar;
		private char ch;
		private Node[] child;
		public Node(char c)
		{
			child = new Node[CharCount];
			for (int i = 0; i < CharCount; i++)
			{
				child[i] = null;
			}
			isLastChar = false;
			ch = c;
		}
		public bool IsLastChar
		{
			get
			{
				return isLastChar;
			}
			set
			{
				isLastChar = value;
			}
		}
		public Node[] Child
		{
			get
			{
				return child;
			}
			set
			{
				child = value;
			}

		}
	}

	public Trie()
	{
		root = new Node(' '); //first node with dummy value.
	}

	public void Insert(string str)
	{
		if (string.ReferenceEquals(str, null))
		{
			return;
		}
		Insert(root, str.ToLower(), 0);
	}

	private Node Insert(Node curr, string str, int index)
	{
		if (curr == null)
		{
			curr = new Node(str[index - 1]);
		}

		if (str.Length == index)
		{
			curr.IsLastChar = true;
		}
		else
		{
			curr.Child[str[index] - 'a'] = Insert(curr.Child[str[index] - 'a'], str, index + 1);
		}

		return curr;
	}

	internal void Remove(string str)
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
			if (curr.IsLastChar)
			{
				curr.IsLastChar = false;
			}
			return;
		}

		Remove(curr.Child[str[index] - 'a'], str, index + 1);
	}


	internal bool Find(string str)
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
			return curr.IsLastChar;
		}

		return Find(curr.Child[str[index] - 'a'], str, index + 1);
	}



	public static void Main2(string[] args)
	{
		Trie t = new Trie();
		string a = "hemant";
		//string b = "heman";
		string c = "hemantjain";
		string d = "jain";
		t.Insert(a);
		t.Insert(d);
		Console.WriteLine(t.Find(a));
		//System.out.println(t.Find(b));
		t.Remove(a);
		t.Remove(d);
		Console.WriteLine(t.Find(a));



		Console.WriteLine(t.Find(c));
		Console.WriteLine(t.Find(d));



	}
}
