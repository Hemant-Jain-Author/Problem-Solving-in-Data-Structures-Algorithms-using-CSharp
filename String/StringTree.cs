using System;

public class StringTree
{
	internal class Node
	{
		internal string value;
		internal int count;
		internal Node lChild;
		internal Node rChild;
	}
	internal Node root = null;
	//Other Methods.


	public virtual void print()
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
	public virtual void insert(string value)
	{
		root = insert(value, root);
	}

	internal virtual Node insert(string value, Node curr)
	{
		int compare;
		if (curr == null)
		{
			curr = new Node();
			curr.value = value;
			curr.lChild = curr.rChild = null;
			curr.count = 1;
		}
		else
		{
			compare = curr.value.CompareTo(value);
			if (compare == 0)
			{
				curr.count++;
			}
			else if (compare == 1)
			{
				curr.lChild = insert(value, curr.lChild);
			}
			else
			{
				curr.rChild = insert(value, curr.rChild);
			}
		}
		return curr;
	}

	internal virtual void freeTree()
	{
		root = null;
	}

	internal virtual bool find(string value)
	{
		bool ret = find(root, value);
		Console.WriteLine("Find " + value + " Return " + ret);
		return ret;
	}

	internal virtual bool find(Node curr, string value)
	{
		int compare;
		if (curr == null)
		{
			return false;
		}
		compare = curr.value.CompareTo(value);
		if (compare == 0)
		{
			return true;
		}
		else
		{
			if (compare == 1)
			{
				return find(curr.lChild, value);
			}
			else
			{
				return find(curr.rChild, value);
			}
		}
	}

	internal virtual int frequency(string value)
	{
		return frequency(root, value);

	}

	internal virtual int frequency(Node curr, string value)
	{
		int compare;
		if (curr == null)
		{
			return 0;
		}

		compare = curr.value.CompareTo(value);
		if (compare == 0)
		{
			return curr.count;
		}
		else
		{
			if (compare > 0)
			{
				return frequency(curr.lChild, value);
			}
			else
			{
				return frequency(curr.rChild, value);
			}
		}
	}
	public static void Main55(string[] args)
	{
		StringTree tt = new StringTree();
		tt.insert("banana");
		tt.insert("apple");
		tt.insert("mango");
		tt.insert("banana");
		tt.insert("apple");
		tt.insert("mango");
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
