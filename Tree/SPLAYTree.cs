using System;

public class SPLAYTree
{
	private Node root;

	private class Node
	{
		internal int data;
		internal Node left, right, parent;
		internal Node(int d, Node l, Node r)
		{
			data = d;
			left = l;
			right = r;
			parent = null;
		}
	}

	public SPLAYTree()
	{
		root = null;
	}

	public void PrintTree()
	{
		PrintTree(root, "", false);
		Console.WriteLine();
	}

	private void PrintTree(Node node, string indent, bool isLeft)
	{
		if (node == null)
		{
			return;
		}
		if (isLeft)
		{
			Console.Write(indent + "L:");
			indent += "|  ";
		}
		else
		{
			Console.Write(indent + "R:");
			indent += "   ";
		}

		Console.WriteLine(node.data);
		PrintTree(node.left, indent, true);
		PrintTree(node.right, indent, false);
	}


	// Function to right rotate subtree rooted with x
	private Node RightRotate(Node x)
	{
		Node y = x.left;
		Node T = y.right;

		// Rotation
		y.parent = x.parent;
		y.right = x;
		x.parent = y;
		x.left = T;
		if (T != null)
		{
			T.parent = x;
		}

		if (y.parent != null && y.parent.left == x)
		{
			y.parent.left = y;
		}
		else if (y.parent != null && y.parent.right == x)
		{
			y.parent.right = y;
		}
		// Return new root
		return y;
	}

	// Function to left rotate subtree rooted with x
	private Node LeftRotate(Node x)
	{
		Node y = x.right;
		Node T = y.left;

		// Rotation
		y.parent = x.parent;
		y.left = x;
		x.parent = y;
		x.right = T;
		if (T != null)
		{
			T.parent = x;
		}

		if (y.parent != null && y.parent.left == x)
		{
			y.parent.left = y;
		}
		else if (y.parent != null && y.parent.right == x)
		{
			y.parent.right = y;
		}
		// Return new root
		return y;
	}

	private Node Parent(Node node)
	{
		if (node == null || node.parent == null)
		{
			return null;
		}
		return node.parent;
	}

	private void Splay(Node node)
	{
		Node parent, grand;
		while (node != root)
		{
			parent = this.Parent(node);
			grand = this.Parent(parent);
			if (parent == null)
			{ // rotations had created new root, always last condition.
				root = node;
			}
			else if (grand == null)
			{ // single rotation case.
				if (parent.left == node)
				{
				   node = RightRotate(parent);
				}
				else
				{
					node = LeftRotate(parent);
				}
			}
			else if (grand.left == parent && parent.left == node)
			{ // Zig Zig case.
				RightRotate(grand);
				node = RightRotate(parent);
			}
			else if (grand.right == parent && parent.right == node)
			{ // Zag Zag case.
				LeftRotate(grand);
				node = LeftRotate(parent);
			}
			else if (grand.left == parent && parent.right == node)
			{ //Zig Zag case.
				LeftRotate(parent);
				node = RightRotate(grand);
			}
			else if (grand.right == parent && parent.left == node)
			{ // Zag Zig case.
				RightRotate(parent);
				node = LeftRotate(grand);
			}
		}
	}

	public bool Find(int data)
	{
		Node curr = root;
		while (curr != null)
		{
			if (curr.data == data)
			{
				Splay(curr);
				return true;
			}
			else if (curr.data > data)
			{
				curr = curr.left;
			}
			else
			{
				curr = curr.right;
			}
		}
		return false;
	}

	public void Insert(int data)
	{
		Node newNode = new Node(data, null, null);
		if (root == null)
		{
			root = newNode;
			return;
		}

		Node node = root;
		Node parent = null;
		while (node != null)
		{
			parent = node;
			if (node.data > data)
			{
				node = node.left;
			}
			else if (node.data < data)
			{
				node = node.right;
			}
			else
			{
				Splay(node); // duplicate Insertion not allowed but splaying for it.
				return;
			}
		}

		newNode.parent = parent;
		if (parent.data > data)
		{
			parent.left = newNode;
		}
		else
		{
			parent.right = newNode;
		}
		Splay(newNode);
	}

	private Node FindMinNode(Node curr)
	{
		Node node = curr;
		if (node == null)
		{
			return null;
		}
		while (node.left != null)
		{
			node = node.left;
		}
		return node;
	}

	public void Delete(int data)
	{
		Node node = root;
		Node parent = null;
		Node next = null;
		while (node != null)
		{
			if (node.data == data)
			{
				parent = node.parent;
				if (node.left == null && node.right == null)
				{
					next = null;
				}
				else if (node.left == null)
				{
					next = node.right;
				}
				else if (node.right == null)
				{
					next = node.left;
				}

				if (node.left == null || node.right == null)
				{
					if (node == root)
					{
						root = next;
						return;
					}
					if (parent.left == node)
					{
						parent.left = next;
					}
					else
					{
						parent.right = next;
					}
					if (next != null)
					{
						next.parent = parent;
					}
					break;
				}

				Node minNode = FindMinNode(node.right);
				data = minNode.data;
				node.data = data;
				node = node.right;

			}
			else if (node.data > data)
			{
				parent = node;
				node = node.left;
			}
			else
			{
				parent = node;
				node = node.right;
			}
		}
		Splay(parent); // Splaying for the parent of the node deleted.
	}

	public void PrintInOrder()
	{
		PrintInOrder(root);
		Console.WriteLine();
	}

	private void PrintInOrder(Node node) // In order
	{
		if (node != null)
		{
			PrintInOrder(node.left);
			Console.Write(node.data + " ");
			PrintInOrder(node.right);
		}
	}

	public static void Main(string[] arg)
	{
		SPLAYTree tree = new SPLAYTree();
		tree.Insert(5);
		tree.Insert(4);
		tree.Insert(6);
		tree.Insert(3);
		tree.Insert(2);
		tree.Insert(1);
		tree.Insert(3);
		tree.PrintTree();

		Console.WriteLine("Value 2 found: " + tree.Find(2));
		tree.Delete(2);
		tree.Delete(5);
		tree.PrintTree();
	}
}

/*
R:3
   L:2
   |  L:1
   R:6
      L:4
      |  R:5

Value 2 found: True
R:4
   L:3
   |  L:1
   R:6 
*/
