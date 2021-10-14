using System;

public class RBTree
{
	private Node root;
	private Node NullNode;

	private class Node
	{
		internal Node left, right, parent;
		internal int data;
		internal bool colour; // true for red colour, false for black colour

		internal Node(int data, Node nullNode)
		{
			this.data = data;
			left = nullNode;
			right = nullNode;
			colour = true; // New node are red in colour.
			parent = nullNode;
		}
	}

	public RBTree()
	{
		NullNode = new Node(0, null);
		NullNode.colour = false;
		root = NullNode;

	}

	// To check whether node is of colour red or not.
	private bool IsRed(Node node)
	{
		return (node == null) ? false : (node.colour == true);
	}

	private Node GetUncle(Node node)
	{
		// If no parent or grandparent, then no uncle
		if (node.parent == NullNode || node.parent.parent == NullNode)
		{
			return null;
		}

		if (node.parent == node.parent.parent.left)
		{
			// uncle on right
			return node.parent.parent.right;
		}
		else
		{
			// uncle on left
			return node.parent.parent.left;
		}
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
		if (T != NullNode)
		{
			T.parent = x;
		}

		if (x == root)
		{
			root = y;
			return y;
		}

		if (y.parent.left == x)
		{
			y.parent.left = y;
		}
		else
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
		if (T != NullNode)
		{
			T.parent = x;
		}

		if (x == root)
		{
			root = y;
			return y;
		}

		if (y.parent.left == x)
		{
			y.parent.left = y;
		}
		else
		{
			y.parent.right = y;
		}

		// Return new root
		return y;
	}

	private Node RightLeftRotate(Node node)
	{
		node.right = RightRotate(node.right);
		return LeftRotate(node);
	}

	private Node LeftRightRotate(Node node)
	{
		node.left = LeftRotate(node.left);
		return RightRotate(node);
	}

	private Node FindNode(int data)
	{
		Node curr = root;
		while (curr != NullNode)
		{
			if (curr.data == data)
			{
				return curr;
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
		return null;
	}
	public bool Search(int data)
	{
		Node curr = root;
		while (curr != NullNode)
		{
			if (curr.data == data)
			{
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
	public void PrintTree()
	{
		PrintTree(root, "", false);
		Console.WriteLine();
	}

	private void PrintTree(Node node, string indent, bool isLeft)
	{
		if (node == NullNode)
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
		Console.WriteLine(node.data + (node.colour? "(Red)":"(Black)"));
		PrintTree(node.left, indent, true);
		PrintTree(node.right, indent, false);
	}

	public void Insert(int data)
	{
		root = Insert(root, data);
		Node temp = FindNode(data);
		FixRedRed(temp);
	}

	private Node Insert(Node node, int data)
	{
		if (node == NullNode)
		{
			node = new Node(data, NullNode);
		}
		else if (node.data > data)
		{
			node.left = Insert(node.left, data);
			node.left.parent = node;
		}
		else if (node.data < data)
		{
			node.right = Insert(node.right, data);
			node.right.parent = node;
		}
		return node;
	}

	private void FixRedRed(Node x)
	{
		// if x is root colour it black and return
		if (x == root)
		{
			x.colour = false;
			return;
		}

		if (x.parent == NullNode || x.parent.parent == NullNode)
		{
			return;
		}
		// Initialize parent, grandparent, uncle
		Node parent = x.parent;
		Node grandparent = parent.parent;
		Node uncle = GetUncle(x);
		Node mid = null;

		if (parent.colour == false)
		{
			return;
		}

		// parent colour is red. gp is black.
		if (uncle != NullNode && uncle.colour == true)
		{
			// uncle and parent is red.
			parent.colour = false;
			uncle.colour = false;
			grandparent.colour = true;
			FixRedRed(grandparent);
			return;
		}

		// parent is red, uncle is black and gp is black.
		// Perform LR, LL, RL, RR
		if (parent == grandparent.left && x == parent.left) // LL
		{
			mid = RightRotate(grandparent);
		}
		else if (parent == grandparent.left && x == parent.right) // LR
		{
			mid = LeftRightRotate(grandparent);
		}
		else if (parent == grandparent.right && x == parent.left) // RL
		{
			mid = RightLeftRotate(grandparent);
		}
		else if (parent == grandparent.right && x == parent.right) // RR
		{
			mid = LeftRotate(grandparent);
		}

		mid.colour = false;
		mid.left.colour = true;
		mid.right.colour = true;
	}

	public void Delete(int data)
	{
		Delete(this.root, data);
	}

	private void Delete(Node node, int key)
	{
		Node z = NullNode;
		Node x, y;
		while (node != NullNode)
		{
			if (node.data == key)
			{
				z = node;
				break;
			}
			else if (node.data <= key)
			{
				node = node.right;
			}
			else
			{
				node = node.left;
			}
		}

		if (z == NullNode)
		{
			Console.WriteLine("Couldn't FindNode key in the tree");
			return;
		}

		y = z;
		bool yColour = y.colour;
		if (z.left == NullNode)
		{
			x = z.right;
			JoinParentChild(z, z.right);
		}
		else if (z.right == NullNode)
		{
			x = z.left;
			JoinParentChild(z, z.left);
		}
		else
		{
			y = Minimum(z.right);
			yColour = y.colour;
			z.data = y.data;
			JoinParentChild(y, y.right);
			x = y.right;
		}

		if (yColour == false)
		{
			if (x.colour == true)
			{
				x.colour = false;
				return;
			}
			else
			{
				FixDoubleBlack(x);
			}
		}
	}
	private void FixDoubleBlack(Node x)
	{
		if (x == root) // Root node.
		{
			return;
		}

		Node sib = Sibling(x);
		Node parent = x.parent;
		if (sib == NullNode)
		{
			// No sibling double black shifted to parent.
			FixDoubleBlack(parent);
		}
		else
		{
			if (sib.colour == true)
			{
				// Sibling colour is red.
				parent.colour = true;
				sib.colour = false;
				if (sib.parent.left == sib)
				{
					// Sibling is left child.
					RightRotate(parent);
				}
				else
				{
					// Sibling is right child.
					LeftRotate(parent);
				}
				FixDoubleBlack(x);
			}
			else
			{
				// Sibling colour is black
				// At least one child is red.
				if (sib.left.colour == true || sib.right.colour == true)
				{
					if (sib.parent.left == sib)
					{
						// Sibling is left child.
						if (sib.left != NullNode && sib.left.colour == true)
						{
							// left left case.
							sib.left.colour = sib.colour;
							sib.colour = parent.colour;
							RightRotate(parent);
						}
						else
						{
							// left right case.
							sib.right.colour = parent.colour;
							LeftRotate(sib);
							RightRotate(parent);
						}
					}
					else
					{
						// Sibling is right child.
						if (sib.left != NullNode && sib.left.colour == true)
						{
							// right left case.
							sib.left.colour = parent.colour;
							RightRotate(sib);
							LeftRotate(parent);
						}
						else
						{
							// right right case.
							sib.right.colour = sib.colour;
							sib.colour = parent.colour;
							LeftRotate(parent);
						}
					}
					parent.colour = false;
				}
				else
				{
					// Both children black.
					sib.colour = true;
					if (parent.colour == false)
					{
						FixDoubleBlack(parent);
					}
					else
					{
						parent.colour = false;
					}
				}
			}
		}
	}

	private Node Sibling(Node node)
	{
		// sibling null if no parent
		if (node.parent == NullNode)
		{
			return null;
		}

		if (node.parent.left == node)
		{
			return node.parent.right;
		}

		return node.parent.left;
	}

	private void JoinParentChild(Node u, Node v)
	{
		if (u.parent == NullNode)
		{
			root = v;
		}
		else if (u == u.parent.left)
		{
			u.parent.left = v;
		}
		else
		{
			u.parent.right = v;
		}
		v.parent = u.parent;
	}

	private Node Minimum(Node node)
	{
		while (node.left != NullNode)
		{
			node = node.left;
		}
		return node;
	}

	public static void Main(string[] arg)
	{
		RBTree tree = new RBTree();
		tree.Insert(1);
		tree.Insert(2);
		tree.Insert(3);
		tree.Insert(4);
		tree.Insert(5);
		tree.Insert(7);
		tree.Insert(6);
		tree.Insert(8);
		tree.Insert(9);
		tree.PrintTree();

		tree.Delete(4);
		tree.PrintTree();
		Console.WriteLine(tree.Search(7));
		tree.Delete(7);
		tree.PrintTree();
	}
}

/*
R:4(Black)
   L:2(Red)
   |  L:1(Black)
   |  R:3(Black)
   R:6(Red)
      L:5(Black)
      R:8(Black)
         L:7(Red)
         R:9(Red)

R:5(Black)
   L:2(Red)
   |  L:1(Black)
   |  R:3(Black)
   R:7(Red)
      L:6(Black)
      R:8(Black)
         R:9(Red)

True
R:5(Black)
   L:2(Red)
   |  L:1(Black)
   |  R:3(Black)
   R:8(Red)
      L:6(Black)
      R:9(Black)
*/
