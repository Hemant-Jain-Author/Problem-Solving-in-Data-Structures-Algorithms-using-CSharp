using System;
using System.Collections.Generic;

public class Tree
{
	private class Node
	{
		internal int value;
		internal Node lChild;
		internal Node rChild;

		public Node(int v, Node l, Node r)
		{
			value = v;
			lChild = l;
			rChild = r;
		}

		public Node(int v)
		{
			value = v;
			lChild = null;
			rChild = null;
		}
	}

	private Node root;


	public Tree()
	{
		root = null;
	}


	public void levelOrderBinaryTree(int[] arr)
	{
		root = levelOrderBinaryTree(arr, 0);
	}

	private Node levelOrderBinaryTree(int[] arr, int start)
	{
		int size = arr.Length;
		Node curr = new Node(arr[start]);

		int left = 2 * start + 1;
		int right = 2 * start + 2;

		if (left < size)
		{
			curr.lChild = levelOrderBinaryTree(arr, left);
		}
		if (right < size)
		{
			curr.rChild = levelOrderBinaryTree(arr, right);
		}

		return curr;
	}


	public void InsertNode(int value)
	{
		root = InsertNode(value, root);
	}

	private Node InsertNode(int value, Node node)
	{
		if (node == null)
		{
			node = new Node(value, null, null);
		}
		else
		{
			if (node.value > value)
			{
				node.lChild = InsertNode(value, node.lChild);
			}
			else
			{
				node.rChild = InsertNode(value, node.rChild);
			}
		}
		return node;
	}


	public void PrintPreOrder()
	{
		PrintPreOrder(root);
	}

	private void PrintPreOrder(Node node) //   pre order
	{
		if (node != null)
		{
			Console.Write(" " + node.value);
			PrintPreOrder(node.lChild);
			PrintPreOrder(node.rChild);
		}
	}

	public void NthPreOrder(int index)
	{
		int[] counter = { 0 };
		NthPreOrder(root, index, counter);
	}

	private void NthPreOrder(Node node, int index, int[] counter) //   pre order
	{
		if (node != null)
		{
			counter[0]++;
			if (counter[0] == index)
			{
				Console.Write(" " + node.value);
			}
			NthPreOrder(node.lChild, index, counter);
			NthPreOrder(node.rChild, index, counter);
		}
	}


	public void PrintPostOrder()
	{
		PrintPostOrder(root);
	}

	private void PrintPostOrder(Node node) //   post order
	{
		if (node != null)
		{
			PrintPostOrder(node.lChild);
			PrintPostOrder(node.rChild);
			Console.Write(node.value);
		}
	}

	public void NthPostOrder(int index)
	{
		int[] counter = { 0 };
		NthPostOrder(root, index, counter);
	}

	private void NthPostOrder(Node node, int index, int[] counter) //   post order
	{
		if (node != null)
		{
			NthPostOrder(node.lChild, index, counter);
			NthPostOrder(node.rChild, index, counter);
			counter[0]++;
			if (counter[0] == index)
			{
				Console.Write(node.value);
			}
		}
	}


	public void PrintInOrder()
	{
		PrintInOrder(root);
	}

	private void PrintInOrder(Node node) //   In order
	{
		if (node != null)
		{
			PrintInOrder(node.lChild);
			Console.Write(" " + node.value);
			PrintInOrder(node.rChild);
		}
	}



	public void NthInOrder(int index)
	{
		int[] counter = { 0 };
		NthInOrder(root, index, counter);
	}

	private void NthInOrder(Node node, int index, int[] counter)
	{
		if (node != null)
		{
			NthInOrder(node.lChild, index, counter);
			counter[0]++;
			if (counter[0] == index)
			{
				Console.Write(node.value);
			}
			NthInOrder(node.rChild, index, counter);
		}
	}


	public void PrintBredthFirst()
	{
		Queue<Node> que = new Queue<Node>();
		Node temp;
		if (root != null)
		{
			que.Enqueue(root);
		}

		while (que.Count != 0)
		{
			temp = que.Dequeue();
			Console.WriteLine(temp.value);

			if (temp.lChild != null)
			{
				que.Enqueue(temp.lChild);
			}
			if (temp.rChild != null)
			{
				que.Enqueue(temp.rChild);
			}
		}
	}

	public void PrintDepthFirst()
	{
		Stack<Node> stk = new Stack<Node>();
		Node temp;

		if (root != null)
		{
			stk.Push(root);
		}

		while (stk.Count != 0)
		{
			temp = stk.Pop();
			Console.WriteLine(temp.value);

			if (temp.lChild != null)
			{
				stk.Push(temp.lChild);
			}
			if (temp.rChild != null)
			{
				stk.Push(temp.rChild);
			}
		}
	}



	public bool Find(int value)
	{
		Node curr = root;

		while (curr != null)
		{
			if (curr.value == value)
			{
				return true;
			}
			else if (curr.value > value)
			{
				curr = curr.lChild;
			}
			else
			{
				curr = curr.rChild;
			}
		}
		return false;
	}

	public bool Find2(int value)
	{
		Node curr = root;
		while (curr != null && curr.value != value)
		{
			curr = (curr.value > value) ? curr.lChild : curr.rChild;
		}
		return curr != null;
	}


	public int FindMin()
	{
		Node node = root;
		if (node == null)
		{
			return int.MaxValue;
		}

		while (node.lChild != null)
		{
			node = node.lChild;
		}
		return node.value;
	}

	public int FindMax()
	{
		Node node = root;
		if (node == null)
		{
			return int.MinValue;
		}

		while (node.rChild != null)
		{
			node = node.rChild;
		}
		return node.value;
	}

	private Node FindMax(Node curr)
	{
		Node node = curr;
		if (node == null)
		{
			return null;
		}

		while (node.rChild != null)
		{
			node = node.rChild;
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

		while (node.lChild != null)
		{
			node = node.lChild;
		}
		return node;
	}

	public void Free()
	{
		root = null;
	}

	public void DeleteNode(int value)
	{
		root = DeleteNode(root, value);
	}

	private Node DeleteNode(Node node, int value)
	{
		Node temp = null;

		if (node != null)
		{
			if (node.value == value)
			{
				if (node.lChild == null && node.rChild == null)
				{
					return null;
				}
				else
				{
					if (node.lChild == null)
					{
						temp = node.rChild;
						return temp;
					}

					if (node.rChild == null)
					{
						temp = node.lChild;
						return temp;
					}

					Node maxNode = FindMax(node);
					int maxValue = maxNode.value;
					node.value = maxValue;
					node.lChild = DeleteNode(node.lChild, maxValue);
				}
			}
			else
			{
				if (node.value > value)
				{
					node.lChild = DeleteNode(node.lChild, value);
				}
				else
				{
					node.rChild = DeleteNode(node.rChild, value);
				}
			}
		}
		return node;
	}

	public int TreeDepth()
	{
		return TreeDepth(root);
	}

	private int TreeDepth(Node root)
	{
		if (root == null)
		{
			return 0;
		}
		else
		{
			int lDepth = TreeDepth(root.lChild);
			int rDepth = TreeDepth(root.rChild);

			if (lDepth > rDepth)
			{
				return lDepth + 1;
			}
			else
			{
				return rDepth + 1;
			}
		}
	}


	public bool isEqual(Tree T2)
	{
		return isEqual(root, T2.root);
	}
	private bool isEqual(Node node1, Node node2)
	{
		if (node1 == null && node2 == null)
		{
			return true;
		}
		else if (node1 == null || node2 == null)
		{
			return false;
		}
		else
		{
			return (isEqual(node1.lChild, node2.lChild) && isEqual(node1.rChild, node2.rChild) && (node1.value == node2.value));
		}
	}
	public int Ancestor(int first, int second)
	{
		if (first > second)
		{
			int temp = first;
			first = second;
			second = temp;
		}
		return Ancestor(root, first, second).value;
	}

	private Node Ancestor(Node curr, int first, int second)
	{
		if (curr == null)
		{
			return null;
		}

		if (curr.value > first && curr.value > second)
		{
			return Ancestor(curr.lChild, first, second);
		}
		if (curr.value < first && curr.value < second)
		{
			return Ancestor(curr.rChild, first, second);
		}
		return curr;
	}


	public Tree CopyTree()
	{
		Tree tree2 = new Tree();
		tree2.root = CopyTree(root);
		return tree2;
	}

	private Node CopyTree(Node curr)
	{
		Node temp;
		if (curr != null)
		{
			temp = new Node(curr.value);
			temp.lChild = CopyTree(curr.lChild);
			temp.rChild = CopyTree(curr.rChild);
			return temp;
		}
		else
		{
			return null;
		}
	}

	public Tree CopyMirrorTree()
	{
		Tree tree2 = new Tree();
		tree2.root = CopyTree(root);
		return tree2;
	}

	private Node CopyMirrorTree(Node curr)
	{
		Node temp;
		if (curr != null)
		{
			temp = new Node(curr.value);
			temp.rChild = CopyMirrorTree(curr.lChild);
			temp.lChild = CopyMirrorTree(curr.rChild);
			return temp;
		}
		else
		{
			return null;
		}
	}

	public int numNodes()
	{
		return numNodes(root);
	}

	private int numNodes(Node curr)
	{
		if (curr == null)
		{
			return 0;
		}
		else
		{
			return (1 + numNodes(curr.rChild) + numNodes(curr.lChild));
		}
	}

	public int numFullNodesBT()
	{
		return numNodes(root);
	}

	private int numFullNodesBT(Node curr)
	{
		int count;
		if (curr == null)
		{
			return 0;
		}

		count = numFullNodesBT(curr.rChild) + numFullNodesBT(curr.lChild);
		if (curr.rChild != null && curr.lChild != null)
		{
			count++;
		}

		return count;
	}

	public int maxLengthPathBT()
	{
		return maxLengthPathBT(root);
	}
	private int maxLengthPathBT(Node curr) //diameter
	{
		int max;
		int leftPath, rightPath;
		int leftMax, rightMax;

		if (curr == null)
		{
			return 0;
		}

		leftPath = TreeDepth(curr.lChild);
		rightPath = TreeDepth(curr.rChild);

		max = leftPath + rightPath + 1;

		leftMax = maxLengthPathBT(curr.lChild);
		rightMax = maxLengthPathBT(curr.rChild);

		if (leftMax > max)
		{
			max = leftMax;
		}

		if (rightMax > max)
		{
			max = rightMax;
		}

		return max;
	}

	public int numLeafNodes()
	{
		return numLeafNodes(root);
	}

	private int numLeafNodes(Node curr)
	{
		if (curr == null)
		{
			return 0;
		}
		if (curr.lChild == null && curr.rChild == null)
		{
			return 1;
		}
		else
		{
			return (numLeafNodes(curr.rChild) + numLeafNodes(curr.lChild));
		}
	}


	public int sumAllBT()
	{
		return sumAllBT(root);
	}

	private int sumAllBT(Node curr)
	{
		int sum, leftSum, rightSum;

		if (curr == null)
		{
			return 0;
		}

		rightSum = sumAllBT(curr.rChild);
		leftSum = sumAllBT(curr.lChild);

		sum = rightSum + leftSum + curr.value;

		return sum;
	}

	public void iterativePreOrder()
	{
		Stack<Node> stk = new Stack<Node>();
		Node curr;

		if (root != null)
		{
			stk.Push(root);
		}

		while (stk.Count != 0)
		{
			curr = stk.Pop();
			Console.Write(curr.value + " ");

			if (curr.rChild != null)
			{
				stk.Push(curr.rChild);
			}

			if (curr.lChild != null)
			{
				stk.Push(curr.lChild);
			}
		}
	}

	public void iterativePostOrder()
	{
		Stack<Node> stk = new Stack<Node>();
		Stack<int> visited = new Stack<int>();
		Node curr;
		int vtd;

		if (root != null)
		{
			stk.Push(root);
			visited.Push(0);
		}

		while (stk.Count != 0)
		{

			curr = stk.Pop();
			vtd = visited.Pop();
			if (vtd == 1)
			{
				Console.Write(curr.value + " ");
			}
			else
			{
				stk.Push(curr);
				visited.Push(1);
				if (curr.rChild != null)
				{
					stk.Push(curr.rChild);
					visited.Push(0);
				}

				if (curr.lChild != null)
				{
					stk.Push(curr.lChild);
					visited.Push(0);
				}
			}
		}
	}

	public void iterativeInOrder()
	{
		Stack<Node> stk = new Stack<Node>();
		Stack<int> visited = new Stack<int>();
		Node curr;
		int vtd;

		if (root != null)
		{
			stk.Push(root);
			visited.Push(0);
		}

		while (stk.Count != 0)
		{

			curr = stk.Pop();
			vtd = visited.Pop();
			if (vtd == 1)
			{
				Console.Write(curr.value + " ");
			}
			else
			{
				if (curr.rChild != null)
				{
					stk.Push(curr.rChild);
					visited.Push(0);
				}

				stk.Push(curr);
				visited.Push(1);

				if (curr.lChild != null)
				{
					stk.Push(curr.lChild);
					visited.Push(0);
				}
			}
		}
	}


	private bool isBST3(Node root)
	{
		if (root == null)
		{
			return true;
		}
		if (root.lChild != null && FindMax(root.lChild).value > root.value)
		{
			return false;
		}
		if (root.rChild != null && FindMin(root.rChild).value <= root.value)
		{
			return false;
		}
		return (isBST3(root.lChild) && isBST3(root.rChild));
	}



	public bool isBst()
	{
		return isBST(root, int.MinValue, int.MaxValue);
	}

	private bool isBST(Node curr, int min, int max)
	{
		if (curr == null)
		{
			return true;
		}

		if (curr.value < min || curr.value > max)
		{
			return false;
		}

		return isBST(curr.lChild, min, curr.value) && isBST(curr.rChild, curr.value, max);
	}

	internal class counter
	{
		internal int value;
	}

	internal bool isBST2()
	{
		counter c = new counter();
		return isBST2(root, c);
	}

	private bool isBST2(Node root, counter count) //  in order  traversal
	{
		bool ret;
		if (root != null)
		{
			ret = isBST2(root.lChild, count);
			if (!ret)
			{
				return false;
			}

			if (count.value > root.value)
			{
				return false;
			}
			count.value = root.value;

			ret = isBST2(root.rChild, count);
			if (!ret)
			{
				return false;
			}
		}
		return true;
	}

	//	void DFS(Node head)
	//	{
	//		Node curr = head, prev;
	//		int count = 0;
	//		while (curr && ! curr.visited)
	//		{
	//			count++;
	//			if (curr.lChild && ! curr.lChild.visited)
	//			{
	//				curr= curr.lChild;
	//			}
	//			else if (curr.rChild && ! curr.rChild.visited)
	//			{
	//				curr= curr.rChild;
	//			}
	//			else
	//			{
	//				System.out.print(("  " + curr.value);
	//				curr.visited = 1;
	//				curr = head;
	//			}
	//		}
	//		System.out.print(("count is : " + count);
	//	}


	private Node treeToListRec()
	{
		Node head = treeToListRec(root);
		Node temp = head;
		return temp;
	}

	private Node treeToListRec(Node curr)
	{
		Node Head = null, Tail = null;
		if (curr == null)
		{
			return null;
		}

		if (curr.lChild == null && curr.rChild == null)
		{
			curr.lChild = curr;
			curr.rChild = curr;
			return curr;
		}

		if (curr.lChild != null)
		{
			Head = treeToListRec(curr.lChild);
			Tail = Head.lChild;

			curr.lChild = Tail;
			Tail.rChild = curr;
		}
		else
		{
			Head = curr;
		}

		if (curr.rChild != null)
		{
			Node tempHead = treeToListRec(curr.rChild);
			Tail = tempHead.lChild;

			curr.rChild = tempHead;
			tempHead.lChild = curr;
		}
		else
		{
			Tail = curr;
		}

		Head.lChild = Tail;
		Tail.rChild = Head;
		return Head;
	}

	public void printAllPath()
	{
		Stack<int> stk = new Stack<int>();
		printAllPath(root, stk);
	}

	private void printAllPath(Node curr, Stack<int> stk)
	{
		if (curr == null)
		{
			return;
		}

		stk.Push(curr.value);

		if (curr.lChild == null && curr.rChild == null)
		{
			Console.WriteLine(stk);
			stk.Pop();
			return;
		}

		printAllPath(curr.rChild, stk);
		printAllPath(curr.lChild, stk);
		stk.Pop();
	}

	public int LCA(int first, int second)
	{
		Node ans = LCA(root, first, second);
		if (ans != null)
		{
			return ans.value;
		}
		else
		{
			return int.MinValue;
		}
	}

	private Node LCA(Node curr, int first, int second)
	{
		Node left, right;

		if (curr == null)
		{
			return null;
		}

		if (curr.value == first || curr.value == second)
		{
			return curr;
		}

		left = LCA(curr.lChild, first, second);
		right = LCA(curr.rChild, first, second);

		if (left != null && right != null)
		{
			return curr;
		}
		else if (left != null)
		{
			return left;
		}
		else
		{
			return right;
		}
	}

	public int LcaBST(int first, int second)
	{
		return LcaBST(root, first, second);
	}
	private int LcaBST(Node curr, int first, int second)
	{
		if (curr == null)
		{
			return int.MaxValue;
		}

		if (curr.value > first && curr.value > second)
		{
			return LcaBST(curr.lChild, first, second);
		}
		if (curr.value < first && curr.value < second)
		{
			return LcaBST(curr.rChild, first, second);
		}
		return curr.value;
	}
	public void trimOutsideRange(int min, int max)
	{
		trimOutsideRange(root, min, max);
	}
	private Node trimOutsideRange(Node curr, int min, int max)
	{
		if (curr == null)
		{
			return null;
		}

		curr.lChild = trimOutsideRange(curr.rChild, min, max);
		curr.rChild = trimOutsideRange(curr.lChild, min, max);

		if (curr.value < min)
		{
			return curr.rChild;
		}

		if (curr.value > max)
		{
			return curr.lChild;
		}

		return curr;
	}
	public void printInRange(int min, int max)
	{
		printInRange(root, min, max);
	}
	private void printInRange(Node root, int min, int max)
	{
		if (root == null)
		{
			return;
		}

		printInRange(root.lChild, min, max);

		if (root.value >= min && root.value <= max)
		{
			Console.Write(root.value + " ");
		}

		printInRange(root.rChild, min, max);
	}


	public int FloorBST(int val)
	{
		Node curr = root;
		int ceil = int.MinValue;
		int floor = int.MaxValue;

		while (curr != null)
		{
			if (curr.value == val)
			{
				ceil = curr.value;
				floor = curr.value;
				break;
			}
			else if (curr.value > val)
			{
				ceil = curr.value;
				curr = curr.lChild;
			}
			else
			{
				floor = curr.value;
				curr = curr.rChild;
			}
		}
		return floor;
	}

	public int CeilBST(int val)
	{
		Node curr = root;
		int ceil = int.MinValue;
		int floor = int.MaxValue;

		while (curr != null)
		{
			if (curr.value == val)
			{
				ceil = curr.value;
				floor = curr.value;
				break;
			}
			else if (curr.value > val)
			{
				ceil = curr.value;
				curr = curr.lChild;
			}
			else
			{
				floor = curr.value;
				curr = curr.rChild;
			}
		}
		return ceil;
	}

	public int findMaxBT()
	{
		int ans = findMaxBT(root);
		return ans;
	}

	private int findMaxBT(Node curr)
	{
		int left, right;

		if (curr == null)
		{
			return int.MinValue;
		}

		int max = curr.value;

		left = findMaxBT(curr.lChild);
		right = findMaxBT(curr.rChild);

		if (left > max)
		{
			max = left;
		}
		if (right > max)
		{
			max = right;
		}

		return max;
	}

	private bool searchBT(Node root, int value)
	{
		int max;
		bool left, right;

		if (root == null)
		{
			return false;
		}

		if (root.value == value)
		{
			return true;
		}

		left = searchBT(root.lChild, value);
		if (left)
		{
			return true;
		}

		right = searchBT(root.rChild, value);
		if (right)
		{
			return true;
		}

		return false;
	}

	public void CreateBinaryTree(int[] arr)
	{
		root = CreateBinaryTree(arr, 0, arr.Length - 1);
	}

	private Node CreateBinaryTree(int[] arr, int start, int end)
	{
		Node curr = null;
		if (start > end)
		{
			return null;
		}

		int mid = (start + end) / 2;
		curr = new Node(arr[mid]);
		curr.lChild = CreateBinaryTree(arr, start, mid - 1);
		curr.rChild = CreateBinaryTree(arr, mid + 1, end);
		return curr;
	}


	public static void Main(string[] args)
	{
		Tree t = new Tree();
		int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		t.levelOrderBinaryTree(arr);
		t.NthInOrder(4);
		t.NthPostOrder(4);
		t.NthPreOrder(4);
		//t.PrintBredthFirst();
		//t.treeToListRec();
		//t.printAllPath();
		//System.out.println(t.LCA(10, 3));
		//System.out.println(t.());
		//t.PrintPreOrder();
		//Console.WriteLine("");
		//t.iterativePreOrder();
		//Console.WriteLine("");

		//t.PrintPostOrder();
		//Console.WriteLine("");
		//t.iterativePostOrder();
		//Console.WriteLine("");

		//t.PrintInOrder();
		//Console.WriteLine("");
		//t.iterativeInOrder();
		//Console.WriteLine("");

		//t.PrintPreOrder();
		//t.CreateBinaryTree(arr);
		//System.out.println(t.isBST2());

	}
}
