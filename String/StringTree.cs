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
	public void print()
	{
		print(root);
	}

	private void print(Node curr) // pre order
	{
		if (curr != null)
		{
			Console.Write(" value is ::" + curr.value);
			Console.WriteLine(" count is :: " + curr.count);
			print(curr.lChild);
			print(curr.rChild);
		}
	}

	public void add(string value)
	{
		root = add(value, root);
	}

	private Node add(string value, Node curr)
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
			int compare = curr.value.CompareTo(value);
			if (compare == 0)
				curr.count++;
			else if (compare == 1)
				curr.lChild = add(value, curr.lChild);
			else
				curr.rChild = add(value, curr.rChild);
		}
		return curr;
	}

	public bool find(string value)
	{
		bool ret = find(root, value);
		Console.WriteLine("Find " + value + " Return " + ret);
		return ret;
	}

	private bool find(Node curr, string value)
	{
		if (curr == null)
		{
			return false;
		}
		int compare = curr.value.CompareTo(value);
		if (compare == 0)
		{
			return true;
		}
		else
		{
			if (compare == 1)
				return find(curr.lChild, value);
			else
				return find(curr.rChild, value);
		}
	}

	public int frequency(string value)
	{
		return frequency(root, value);
	}

	private int frequency(Node curr, string value)
	{
		if (curr == null)
			return 0;

		int compare = curr.value.CompareTo(value);
		if (compare == 0)
		{
			return curr.count;
		}
		else
		{
			if (compare > 0)
				return frequency(curr.lChild, value);
			else
				return frequency(curr.rChild, value);
		}
	}

	public void freeTree()
	{
		root = null;
	}

	public static void Main(string[] args)
	{
		StringTree tt = new StringTree();
		tt.add("banana");
		tt.add("apple");
		tt.add("mango");
		tt.add("banana");
		tt.add("apple");
		tt.add("mango");
		Console.WriteLine("\nSearch results for apple, banana, grapes and mango :\n");
		tt.find("apple");
		tt.find("banana");
		tt.find("banan");
		tt.find("applkhjkhkj");
		tt.find("grapes");
		tt.find("mango");
		tt.print();
		Console.WriteLine("frequency returned :: " + tt.frequency("apple"));
		Console.WriteLine("frequency returned :: " + tt.frequency("banana"));
		Console.WriteLine("frequency returned :: " + tt.frequency("mango"));
		Console.WriteLine("frequency returned :: " + tt.frequency("hemant"));
	}
}