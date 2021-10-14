using System;

public class AVLTree
{
	private Node root;

	private class Node
	{
		internal int data;
		internal Node left;
		internal Node right;
		internal int Height;

		internal Node(int d, Node l, Node r)
		{
			data = d;
			left = l;
			right = r;
			Height = 0;
		}
	}

	public AVLTree()
	{
		root = null;
	}

	private int Height(Node n)
	{
		if (n == null)
		{
			return -1;
		}
		return n.Height;
	}

	private int GetBalance(Node node)
	{
		return (node == null) ? 0 : Height(node.left) - Height(node.right);
	}

	public void Insert(int data)
	{
		root = Insert(root, data);
	}

	private Node Insert(Node node, int data)
	{
		if (node == null)
		{
			return new Node(data, null, null);
		}

		if (node.data > data)
		{
			node.left = Insert(node.left, data);
		}
		else if (node.data < data)
		{
			node.right = Insert(node.right, data);
		}
		else
		{ // Duplicate data not allowed
			return node;
		}

		node.Height = Max(Height(node.left), Height(node.right)) + 1;
		int balance = GetBalance(node);

		if (balance > 1)
		{
			if (data < node.left.data) // Left Left Case
			{
				return RightRotate(node);
			}
			if (data > node.left.data) // Left Right Case
			{
				return LeftRightRotate(node);
			}
		}

		if (balance < -1)
		{
			if (data > node.right.data) // Right Right Case
			{
				return LeftRotate(node);
			}
			if (data < node.right.data) // Right Left Case
			{
				return RightLeftRotate(node);
			}
		}
		return node;
	}

	// Function to right rotate subtree rooted with x
	private Node RightRotate(Node x)
	{
		Node y = x.left;
		Node T = y.right;

		// Rotation
		y.right = x;
		x.left = T;

		// Update Heights
		x.Height = Max(Height(x.left), Height(x.right)) + 1;
		y.Height = Max(Height(y.left), Height(y.right)) + 1;

		// Return new root
		return y;
	}

	// Function to left rotate subtree rooted with x
	private Node LeftRotate(Node x)
	{
		Node y = x.right;
		Node T = y.left;

		// Rotation
		y.left = x;
		x.right = T;

		// Update Heights
		x.Height = Max(Height(x.left), Height(x.right)) + 1;
		y.Height = Max(Height(y.left), Height(y.right)) + 1;

		// Return new root
		return y;
	}

	// Function to right then left rotate subtree rooted with x
	private Node RightLeftRotate(Node x)
	{
		x.right = RightRotate(x.right);
		return LeftRotate(x);
	}

	// Function to left then right rotate subtree rooted with x
	private Node LeftRightRotate(Node x)
	{
		x.left = LeftRotate(x.left);
		return RightRotate(x);
	}

	public void Delete(int data)
	{
		root = Delete(root, data);
	}

	private Node Delete(Node node, int data)
	{
		if (node == null)
		{
			return null;
		}

		if (node.data == data)
		{
			if (node.left == null && node.right == null)
			{
				return null;
			}
			else if (node.left == null)
			{
				return node.right; // no need to modify Height
			}
			else if (node.right == null)
			{
				return node.left; // no need to modify Height
			}
			else
			{
				Node minNode = FindMin(node.right);
				node.data = minNode.data;
				node.right = Delete(node.right, minNode.data);
			}
		}
		else
		{
			if (node.data > data)
			{
				node.left = Delete(node.left, data);
			}
			else
			{
				node.right = Delete(node.right, data);
			}
		}

		node.Height = Max(Height(node.left), Height(node.right)) + 1;
		int balance = GetBalance(node);

		if (balance > 1)
		{
			if (data >= node.left.data) // Left Left Case
			{
				return RightRotate(node);
			}
			if (data < node.left.data) // Left Right Case
			{
				return LeftRightRotate(node);
			}
		}

		if (balance < -1)
		{
			if (data <= node.right.data) // Right Right Case
			{
				return LeftRotate(node);
			}
			if (data > node.right.data) // Right Left Case
			{
				return RightLeftRotate(node);
			}
		}
		return node;
	}

	private Node FindMin(Node curr)
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

		Console.WriteLine(node.data + "(" + node.Height + ")");
		PrintTree(node.left, indent, true);
		PrintTree(node.right, indent, false);
	}

	private int Max(int a, int b)
	{
		return (a > b) ? a : b;
	}

	public static void Main(string[] arg)
	{
		AVLTree t = new AVLTree();
		t.Insert(1);
		t.Insert(2);
		t.Insert(3);
		t.Insert(4);
		t.Insert(5);
		t.Insert(6);
		t.Insert(7);
		t.Insert(8);
		t.PrintTree();

		/*
 R:4(3)
   L:2(1)
   |  L:1(0)
   |  R:3(0)
   R:6(2)
	  L:5(0)
	  R:7(1)
		 R:8(0)

		*/

		t.Delete(5);
		t.PrintTree();

		/*
 R:4(2)
   L:2(1)
   |  L:1(0)
   |  R:3(0)
   R:7(1)
	  L:6(0)
	  R:8(0)

	   */

		t.Delete(1);
		t.PrintTree();

		/*
R:4(2)
   L:2(1)
   |  R:3(0)
   R:7(1)
	  L:6(0)
	  R:8(0)

		*/

		t.Delete(2);
		t.PrintTree();

		/*
R:4(2)
   L:3(0)
   R:7(1)
	  L:6(0)
	  R:8(0) 
		*/
	}
}