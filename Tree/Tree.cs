using System;
using System.Collections.Generic;

public class Tree
{
    private Node root;

    private class Node
    {
        internal int value;
        internal Node lChild;
        internal Node rChild;

        internal Node(int v, Node l, Node r)
        {
            value = v;
            lChild = l;
            rChild = r;
        }

        internal Node(int v)
        {
            value = v;
            lChild = null;
            rChild = null;
        }
    }

    public Tree()
    {
        root = null;
    }
    /* Other methods */

    public void CreateCompleteBinaryTree(int[] arr)
    {
        root = CreateCompleteBinaryTree(arr, 0);
    }

    private Node CreateCompleteBinaryTree(int[] arr, int start)
    {
        int size = arr.Length;
        Node curr = new Node(arr[start]);

        int left = 2 * start + 1;
        int right = 2 * start + 2;

        if (left < size)
        {
            curr.lChild = CreateCompleteBinaryTree(arr, left);
        }
        if (right < size)
        {
            curr.rChild = CreateCompleteBinaryTree(arr, right);
        }

        return curr;
    }

    public void Insert(int value)
    {
        root = Insert(root, value);
    }

    private Node Insert(Node node, int value)
    {
        if (node == null)
        {
            node = new Node(value, null, null);
        }
        else
        {
            if (node.value > value)
            {
                node.lChild = Insert(node.lChild, value);
            }
            else
            {
                node.rChild = Insert(node.rChild, value);
            }
        }
        return node;
    }

    public void PrintPreOrder()
    {
        PrintPreOrder(root);
        Console.WriteLine();
    }

    private void PrintPreOrder(Node node) // pre order
    {
        if (node != null)
        {
            Console.Write(node.value + " ");
            PrintPreOrder(node.lChild);
            PrintPreOrder(node.rChild);
        }
    }

    public void NthPreOrder(int index)
    {
        int[] counter = new int[] { 0 };
        NthPreOrder(root, index, counter);
    }

    private void NthPreOrder(Node node, int index, int[] counter) // pre order
    {
        if (node != null && counter[0] < index)
        {
            counter[0]++;
            if (counter[0] == index)
            {
                Console.WriteLine("NthPreOrder : " + node.value);
            }
            NthPreOrder(node.lChild, index, counter);
            NthPreOrder(node.rChild, index, counter);
        }
    }

    public void PrintPostOrder()
    {
        PrintPostOrder(root);
        Console.WriteLine();
    }

    private void PrintPostOrder(Node node) // post order
    {
        if (node != null)
        {
            PrintPostOrder(node.lChild);
            PrintPostOrder(node.rChild);
            Console.Write(node.value + " ");
        }
    }

    public void NthPostOrder(int index)
    {
        int[] counter = new int[] { 0 };
        NthPostOrder(root, index, counter);
    }

    private void NthPostOrder(Node node, int index, int[] counter) // post order
    {
        if (node != null && counter[0] < index)
        {
            NthPostOrder(node.lChild, index, counter);
            NthPostOrder(node.rChild, index, counter);
            counter[0]++;
            if (counter[0] == index)
            {
                Console.WriteLine("NthPostOrder : " + node.value);
            }
        }
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
            PrintInOrder(node.lChild);
            Console.Write(node.value + " ");
            PrintInOrder(node.rChild);
        }
    }

    public void NthInOrder(int index)
    {
        int[] counter = new int[] { 0 };
        NthInOrder(root, index, counter);
    }

    private void NthInOrder(Node node, int index, int[] counter)
    {

        if (node != null && counter[0] < index)
        {
            NthInOrder(node.lChild, index, counter);
            counter[0]++;
            if (counter[0] == index)
            {
                Console.WriteLine("NthInOrder : " + node.value);
                return;
            }
            NthInOrder(node.rChild, index, counter);
        }
    }

    public void PrintBreadthFirst()
    {
        Queue<Node> que = new Queue<Node>();
        if (root != null)
        {
            que.Enqueue(root);
        }

        while (que.Count > 0)
        {
            Node temp = que.Dequeue();
            Console.Write(temp.value + " ");

            if (temp.lChild != null)
            {
                que.Enqueue(temp.lChild);
            }
            if (temp.rChild != null)
            {
                que.Enqueue(temp.rChild);
            }
        }
        Console.WriteLine();
    }

    public void PrintDepthFirst()
    {
        Stack<Node> stk = new Stack<Node>();
        if (root != null)
        {
            stk.Push(root);
        }

        while (stk.Count > 0)
        {
            Node temp = stk.Pop();
            Console.Write(temp.value + " ");

            if (temp.lChild != null)
            {
                stk.Push(temp.lChild);
            }
            if (temp.rChild != null)
            {
                stk.Push(temp.rChild);
            }
        }
        Console.WriteLine();
    }

    public void PrintLevelOrderLineByLine()
    {
        Queue<Node> que1 = new Queue<Node>();
        Queue<Node> que2 = new Queue<Node>();
        Node temp = null;
        if (root != null)
        {
            que1.Enqueue(root);
        }
        while (que1.Count != 0 || que2.Count != 0)
        {
            while (que1.Count != 0)
            {
                temp = que1.Dequeue();
                Console.Write(temp.value + " ");
                if (temp.lChild != null)
                {
                    que2.Enqueue(temp.lChild);
                }
                if (temp.rChild != null)
                {
                    que2.Enqueue(temp.rChild);
                }
            }
            Console.WriteLine("");

            while (que2.Count != 0)
            {
                temp = que2.Dequeue();
                Console.Write(temp.value + " ");
                if (temp.lChild != null)
                {
                    que1.Enqueue(temp.lChild);
                }
                if (temp.rChild != null)
                {
                    que1.Enqueue(temp.rChild);
                }
            }
            Console.WriteLine("");
        }
    }

    public void PrintLevelOrderLineByLine2()
    {
        Queue<Node> que = new Queue<Node>();
        Node temp = null;
        int count = 0;

        if (root != null)
        {
            que.Enqueue(root);
        }
        while (que.Count != 0)
        {
            count = que.Count;
            while (count > 0)
            {
                temp = que.Dequeue();
                Console.Write(temp.value + " ");
                if (temp.lChild != null)
                {
                    que.Enqueue(temp.lChild);
                }
                if (temp.rChild != null)
                {
                    que.Enqueue(temp.rChild);
                }
                count -= 1;
            }
            Console.WriteLine("");
        }
    }
    public void PrintSpiralTree()
    {
        Stack<Node> stk1 = new Stack<Node>();
        Stack<Node> stk2 = new Stack<Node>();
        Node temp;
        if (root != null)
        {
            stk1.Push(root);
        }
        while (stk1.Count != 0 || stk2.Count != 0)
        {
            while (stk1.Count != 0)
            {
                temp = stk1.Pop();
                Console.Write(temp.value + " ");
                if (temp.rChild != null)
                {
                    stk2.Push(temp.rChild);
                }
                if (temp.lChild != null)
                {
                    stk2.Push(temp.lChild);
                }
            }
            while (stk2.Count != 0)
            {
                temp = stk2.Pop();
                Console.Write(temp.value + " ");
                if (temp.lChild != null)
                {
                    stk1.Push(temp.lChild);
                }
                if (temp.rChild != null)
                {
                    stk1.Push(temp.rChild);
                }
            }
        }
        Console.WriteLine();
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
        if (root == null)
        {
            return int.MaxValue;
        }
        Node node = root;
        while (node.lChild != null)
        {
            node = node.lChild;
        }
        return node.value;
    }

    public int FindMax()
    {
        if (root == null)
        {
            return int.MinValue;
        }
        Node node = root;
        while (node.rChild != null)
        {
            node = node.rChild;
        }
        return node.value;
    }

    private Node FindMaxNode(Node node)
    {
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

    private Node FindMinNode(Node node)
    {
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

    public void Delete(int value)
    {
        root = Delete(root, value);
    }

    private Node Delete(Node node, int value)
    {
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
                        return node.rChild;
                    }

                    if (node.rChild == null)
                    {
                        return node.lChild;
                    }
                    Node minNode = FindMinNode(node.rChild);
                    int minValue = minNode.value;
                    node.value = minValue;
                    node.rChild = Delete(node.rChild, minValue);
                }
            }
            else
            {
                if (node.value > value)
                {
                    node.lChild = Delete(node.lChild, value);
                }
                else
                {
                    node.rChild = Delete(node.rChild, value);
                }
            }
        }
        return node;
    }

    public int TreeDepth()
    {
        return TreeDepth(root);
    }

    private int TreeDepth(Node curr)
    {
        if (curr == null)
            return 0;
        return 1 + Math.Max(TreeDepth(curr.lChild), TreeDepth(curr.rChild));
    }

    public bool IsEqual(Tree T2)
    {
        return IsEqualUtil(root, T2.root);
    }

    private bool IsEqualUtil(Node node1, Node node2)
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
            return (IsEqualUtil(node1.lChild, node2.lChild) && IsEqualUtil(node1.rChild, node2.rChild) && (node1.value == node2.value));
        }
    }

    private int Ancestor(int first, int second)
    {
        if (first > second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
        Node nd = Ancestor(root, first, second);
        return (nd != null) ? nd.value : -1;
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
        tree2.root = CopyMirrorTree(root);
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

    public int NumNodes()
    {
        return NumNodes(root);
    }

    private int NumNodes(Node curr)
    {
        if (curr == null)
        {
            return 0;
        }
        else
        {
            return (1 + NumNodes(curr.rChild) + NumNodes(curr.lChild));
        }
    }

    public int NumFullNodesBT()
    {
        return NumFullNodesBT(root);
    }

    private int NumFullNodesBT(Node curr)
    {
        if (curr == null)
        {
            return 0;
        }

        int count = NumFullNodesBT(curr.rChild) + NumFullNodesBT(curr.lChild);
        if (curr.rChild != null && curr.lChild != null)
        {
            count++;
        }
        return count;
    }

    public int MaxLengthPathBT()
    {
        return MaxLengthPathBT(root);
    }

    private int MaxLengthPathBT(Node curr) // diameter
    {
        if (curr == null)
        {
            return 0;
        }

        // Max when current node included.
        int max = TreeDepth(curr.lChild) + TreeDepth(curr.rChild) + 1;
        // Max of left subtree.
        int leftMax = MaxLengthPathBT(curr.lChild);
        // Max of right subtree.
        int rightMax = MaxLengthPathBT(curr.rChild);

        max = Math.Max(max, leftMax);
        max = Math.Max(max, rightMax);
        return max;
    }

    public int NumLeafNodes()
    {
        return NumLeafNodes(root);
    }

    private int NumLeafNodes(Node curr)
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
            return (NumLeafNodes(curr.rChild) + NumLeafNodes(curr.lChild));
        }
    }

    public int SumAllBT()
    {
        return SumAllBT(root);
    }

    private int SumAllBT(Node curr)
    {
        if (curr == null)
        {
            return 0;
        }

        return (curr.value + SumAllBT(curr.lChild) + SumAllBT(curr.rChild));
    }

    public void IterativePreOrder()
    {
        Stack<Node> stk = new Stack<Node>();
        Node curr;

        if (root != null)
        {
            stk.Push(root);
        }

        while (stk.Count > 0)
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
        Console.WriteLine();
    }

    public void IterativePostOrder()
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

        while (stk.Count > 0)
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
        Console.WriteLine();
    }

    public void IterativeInOrder()
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

        while (stk.Count > 0)
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
        Console.WriteLine();
    }

    private bool IsBST3(Node root)
    {
        if (root == null)
        {
            return true;
        }
        if (root.lChild != null && FindMaxNode(root.lChild).value > root.value)
        {
            return false;
        }
        if (root.rChild != null && FindMinNode(root.rChild).value <= root.value)
        {
            return false;
        }
        return (IsBST3(root.lChild) && IsBST3(root.rChild));
    }

    public bool IsBST3()
    {
        return IsBST3(root);
    }

    public bool IsBST()
    {
        return IsBST(root, int.MinValue, int.MaxValue);
    }

    private bool IsBST(Node curr, int min, int max)
    {
        if (curr == null)
        {
            return true;
        }

        if (curr.value < min || curr.value > max)
        {
            return false;
        }

        return IsBST(curr.lChild, min, curr.value) && IsBST(curr.rChild, curr.value, max);
    }

    public bool IsBST2()
    {
        int[] count = new int[1];
        return IsBST2(root, count);
    }

    private bool IsBST2(Node root, int[] count) // in order traversal
    {
        bool ret;
        if (root != null)
        {
            ret = IsBST2(root.lChild, count);
            if (!ret)
            {
                return false;
            }

            if (count[0] > root.value)
            {
                return false;
            }
            count[0] = root.value;

            ret = IsBST2(root.rChild, count);
            if (!ret)
            {
                return false;
            }
        }
        return true;
    }

    public bool IsCompleteTree()
    {
        Queue<Node> que = new Queue<Node>();
        Node temp = null;
        int noChild = 0;
        if (root != null)
        {
            que.Enqueue(root);
        }
        while (que.Count != 0)
        {
            temp = que.Dequeue();
            if (temp.lChild != null)
            {
                if (noChild == 1)
                {
                    return false;
                }
                que.Enqueue(temp.lChild);
            }
            else
            {
                noChild = 1;
            }

            if (temp.rChild != null)
            {
                if (noChild == 1)
                {
                    return false;
                }
                que.Enqueue(temp.rChild);
            }
            else
            {
                noChild = 1;
            }
        }
        return true;
    }


    private bool IsCompleteTreeUtil(Node curr, int index, int count)
    {
        if (curr == null)
        {
            return true;
        }
        if (index > count)
        {
            return false;
        }
        return IsCompleteTreeUtil(curr.lChild, index * 2 + 1, count) && IsCompleteTreeUtil(curr.rChild, index * 2 + 2, count);
    }

    public bool IsCompleteTree2()
    {
        int count = NumNodes();
        return IsCompleteTreeUtil(root, 0, count);
    }

    private bool IsHeapUtil(Node curr, int parentValue)
    {
        if (curr == null)
        {
            return true;
        }
        if (curr.value < parentValue)
        {
            return false;
        }
        return (IsHeapUtil(curr.lChild, curr.value) && IsHeapUtil(curr.rChild, curr.value));
    }

    public bool IsHeap()
    {
        int infinite = -9999999;
        return (IsCompleteTree() && IsHeapUtil(root, infinite));
    }

    private bool IsHeapUtil2(Node curr, int index, int count, int parentValue)
    {
        if (curr == null)
        {
            return true;
        }
        if (index > count)
        {
            return false;
        }
        if (curr.value < parentValue)
        {
            return false;
        }
        return IsHeapUtil2(curr.lChild, index * 2 + 1, count, curr.value) && IsHeapUtil2(curr.rChild, index * 2 + 2, count, curr.value);
    }

    public bool IsHeap2()
    {
        int count = NumNodes();
        int parentValue = -9999999;
        return IsHeapUtil2(root, 0, count, parentValue);
    }
    /*
    public Node TreeToListRec() {
        return treeToListRec(root);
    }
    */
    private Node TreeToListRec(Node curr)
    {
        Node head = null, tail = null;
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
            head = TreeToListRec(curr.lChild);
            tail = head.lChild;

            curr.lChild = tail;
            tail.rChild = curr;
        }
        else
        {
            head = curr;
        }

        if (curr.rChild != null)
        {
            Node tempHead = TreeToListRec(curr.rChild);
            tail = tempHead.lChild;

            curr.rChild = tempHead;
            tempHead.lChild = curr;
        }
        else
        {
            tail = curr;
        }

        head.lChild = tail;
        tail.rChild = head;
        return head;
    }

    public void PrintAllPath()
    {
        Stack<int> stk = new Stack<int>();
        PrintAllPathUtil(root, stk);
    }

    private void PrintAllPathUtil(Node curr, Stack<int> stk)
    {
        if (curr == null)
        {
            return;
        }

        stk.Push(curr.value);

        if (curr.lChild == null && curr.rChild == null)
        {
            foreach (var ele in stk)
                Console.Write(ele + " ");
            Console.WriteLine();
            stk.Pop();
            return;
        }

        PrintAllPathUtil(curr.rChild, stk);
        PrintAllPathUtil(curr.lChild, stk);
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

    public int LCABST(int first, int second)
    {
        int result;
        if (first > second)
        {
            result = LCABST(root, second, first);
        }
        else
        {
            result = LCABST(root, first, second);
        }

        if (result == int.MaxValue)
        {
            Console.WriteLine("LCA does not exist");
        }
        else
        {
            Console.WriteLine("LCA is :" + result);
        }
        return result;
    }

    private int LCABST(Node curr, int first, int second)
    {
        if (curr == null)
        {
            return int.MaxValue;
        }

        if (curr.value > second)
        {
            return LCABST(curr.lChild, first, second);
        }
        if (curr.value < first)
        {
            return LCABST(curr.rChild, first, second);
        }
        if (Find(first) && Find(second))
        {
            return curr.value;
        }
        return int.MaxValue;
    }

    public void TrimOutsideRange(int min, int max)
    {
        TrimOutsideRange(root, min, max);
    }

    private Node TrimOutsideRange(Node curr, int min, int max)
    {
        if (curr == null)
            return null;

        curr.lChild = TrimOutsideRange(curr.lChild, min, max);
        curr.rChild = TrimOutsideRange(curr.rChild, min, max);

        if (curr.value < min)
            return curr.rChild;

        if (curr.value > max)
            return curr.lChild;

        return curr;
    }

    public void PrintInRange(int min, int max)
    {
        PrintInRange(root, min, max);
        Console.WriteLine();
    }

    private void PrintInRange(Node root, int min, int max)
    {
        if (root == null)
        {
            return;
        }

        PrintInRange(root.lChild, min, max);

        if (root.value >= min && root.value <= max)
        {
            Console.Write(root.value + " ");
        }

        PrintInRange(root.rChild, min, max);
    }

    public int FloorBST(double val)
    {
        Node curr = root;
        int floor = int.MaxValue;

        while (curr != null)
        {
            if (curr.value == val)
            {
                floor = curr.value;
                break;
            }
            else if (curr.value > val)
            {
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

    public int CeilBST(double val)
    {
        Node curr = root;
        int ceil = int.MinValue;

        while (curr != null)
        {
            if (curr.value == val)
            {
                ceil = curr.value;
                break;
            }
            else if (curr.value > val)
            {
                ceil = curr.value;
                curr = curr.lChild;
            }
            else
            {
                curr = curr.rChild;
            }
        }
        return ceil;
    }

    public int FindMaxBT()
    {
        int ans = FindMaxBT(root);
        return ans;
    }

    private int FindMaxBT(Node curr)
    {
        if (curr == null)
        {
            return int.MinValue;
        }
        int max = Math.Max(FindMaxBT(curr.lChild), FindMaxBT(curr.rChild));
        return Math.Max(max, curr.value);
    }

    public bool SearchBT(int value)
    {
        return SearchBTUtil(root, value);
    }

    private bool SearchBTUtil(Node curr, int value)
    {
        if (curr == null)
        {
            return false;
        }

        if (curr.value == value || SearchBTUtil(curr.lChild, value) ||
                    SearchBTUtil(curr.rChild, value))
        {
            return true;
        }

        return false;
    }

    public void CreateBinarySearchTree(int[] arr)
    {
        root = CreateBinarySearchTree(arr, 0, arr.Length - 1);
    }

    private Node CreateBinarySearchTree(int[] arr, int start, int end)
    {
        Node curr = null;
        if (start > end)
        {
            return null;
        }

        int mid = (start + end) / 2;
        curr = new Node(arr[mid]);
        curr.lChild = CreateBinarySearchTree(arr, start, mid - 1);
        curr.rChild = CreateBinarySearchTree(arr, mid + 1, end);
        return curr;
    }

    public bool IsBSTArray(int[] preorder)
    {
        int size = preorder.Length;
        Stack<int> stk = new Stack<int>();
        int value;
        int root = -999999;
        for (int i = 0; i < size; i++)
        {
            value = preorder[i];

            // If value of the right child is less than root.
            if (value < root)
            {
                return false;
            }
            // First left child values will be popped
            // Last popped value will be the root.
            while (stk.Count > 0 && stk.Peek() < value)
            {
                root = stk.Pop();
            }
            // add current value to the stack.
            stk.Push(value);
        }
        return true;
    }

    // Testing code.
    public static void Main1()
    {
        Tree t = new Tree();
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        t.CreateCompleteBinaryTree(arr);

        t.PrintPreOrder();
        // 1 2 4 8 9 5 10 3 6 7 

        t.PrintPostOrder();
        // 8 9 4 10 5 2 6 7 3 1 

        t.PrintInOrder();
        // 8 4 9 2 10 5 1 6 3 7 

        t.IterativePreOrder();
        // 1 2 4 8 9 5 10 3 6 7 

        t.IterativePostOrder();
        // 8 9 4 10 5 2 6 7 3 1 

        t.IterativeInOrder();
        // 8 4 9 2 10 5 1 6 3 7 

        t.PrintBreadthFirst();
        // 1 2 3 4 5 6 7 8 9 10 

        t.PrintDepthFirst();
        // 1 3 7 6 2 5 10 4 9 8

        t.PrintLevelOrderLineByLine();
        /*
        1 
        2 3 
        4 5 6 7 
        8 9 10 
        */

        t.PrintLevelOrderLineByLine2();
        /*
        1 
        2 3 
        4 5 6 7 
        8 9 10 
        */

        t.PrintSpiralTree();
        // 1 2 3 7 6 5 4 8 9 10 

        t.NthInOrder(2);
        t.NthPostOrder(2);
        t.NthPreOrder(2);

        /*
        NthInOrder : 4
        NthPostOrder : 9
        NthPreOrder : 2
        */

        t.PrintAllPath();

        /*
        7 3 1 
        6 3 1 
        10 5 2 1 
        9 4 2 1 
        8 4 2 1 
        */
    }

    // Testing code.
    public static void Main2()
    {
        Tree t = new Tree();
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        t.CreateCompleteBinaryTree(arr);

        Console.WriteLine("NumNodes : " + t.NumNodes());
        // NumNodes : 10

        Console.WriteLine("SumAllBT : " + t.SumAllBT());
        // SumAllBT : 55

        Console.WriteLine("NumLeafNodes : " + t.NumLeafNodes());
        // NumLeafNodes : 5

        Console.WriteLine("NumFullNodesBT : " + t.NumFullNodesBT());
        // NumFullNodesBT : 4

        Console.WriteLine("SearchBT : " + t.SearchBT(9));
        // SearchBT : True

        Console.WriteLine("FindMaxBT : " + t.FindMaxBT());
        // FindMaxBT : 10

        Console.WriteLine("TreeDepth : " + t.TreeDepth());
        // TreeDepth : 4

        Console.WriteLine("MaxLengthPathBT : " + t.MaxLengthPathBT());
        // MaxLengthPathBT : 6
    }

    // Testing code.
    public static void Main3()
    {
        Tree t = new Tree();
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        t.CreateCompleteBinaryTree(arr);

        Tree t2 = t.CopyTree();
        t.PrintInOrder();
        t2.PrintInOrder();

        /*
        8 4 9 2 10 5 1 6 3 7 
        8 4 9 2 10 5 1 6 3 7 
        */

        Tree t3 = t.CopyMirrorTree();
        t3.PrintInOrder();
        /*
        7 3 6 1 5 10 2 9 4 8 
        */
        Console.WriteLine("IsEqual : " + t.IsEqual(t2));
        /*
        IsEqual : True
        */
        Console.WriteLine("IsHeap : " + t.IsHeap());
        Console.WriteLine("IsHeap : " + t.IsHeap2());
        Console.WriteLine("IsCompleteTree : " + t.IsCompleteTree());
        Console.WriteLine("IsCompleteTree : " + t.IsCompleteTree2());
        /*
        IsHeap : True
        IsHeap : True
        IsCompleteTree : True
        IsCompleteTree : True
        */
    }

    // Testing code.
    public static void Main4()
    {
        Tree t = new Tree();
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        t.CreateBinarySearchTree(arr);
        Console.WriteLine("Find : " + t.Find(3));
        Console.WriteLine("Find : " + t.Find(16));
        /*
        Find : True
        Find : False
        */

        Console.WriteLine("IsBST : " + t.IsBST());
        Console.WriteLine("IsBST : " + t.IsBST2());
        Console.WriteLine("IsBST : " + t.IsBST3());
        /*
        IsBST : True
        IsBST : True
        IsBST : True
        */
    }

    // Testing code.
    public static void Main5()
    {
        Tree t = new Tree();
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        t.CreateBinarySearchTree(arr);
        Console.WriteLine("FindMin : " + t.FindMin());
        Console.WriteLine("FindMax : " + t.FindMax());
        t.LCABST(3, 4);
        t.LCABST(1, 4);
        t.LCABST(10, 4);
    }

    /*
    FindMin : 1
    FindMax : 10
    LCA is :3
    LCA is :2
    LCA is :5
    */

    // Testing code.
    public static void Main6()
    {
        Tree t = new Tree();
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        t.CreateBinarySearchTree(arr);
        t.PrintInOrder();
        t.PrintInRange(4, 7);
        t.TrimOutsideRange(4, 7);
        t.PrintInOrder();
    }

    /*
    1 2 3 4 5 6 7 8 9 10 
    4 5 6 7 
    4 5 6 7 
    */

    // Testing code.
    public static void Main7()
    {
        Tree t = new Tree();
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        t.CreateBinarySearchTree(arr);
        Console.WriteLine("Ancestor : " + t.Ancestor(1, 10));
        // Ancestor : 5

        Console.WriteLine("CeilBST : " + t.CeilBST(5.5));
        // CeilBST : 6

        Console.WriteLine("FloorBST : " + t.FloorBST(5.5));
        // FloorBST : 5

        int[] arr1 = new int[] { 5, 2, 4, 6, 9, 10 };
        int[] arr2 = new int[] { 5, 2, 6, 4, 7, 9, 10 };
        Console.WriteLine("IsBSTArray : " + t.IsBSTArray(arr1));
        Console.WriteLine("IsBSTArray : " + t.IsBSTArray(arr2));
        /*
        IsBSTArray : True
        IsBSTArray : False
        */
    }

    // Testing code.
    public static void Main8()
    {
        Tree t = new Tree();
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        t.CreateBinarySearchTree(arr);

        Console.Write("Before delete operation: ");
        t.PrintInOrder();

        t.Delete(2);
        Console.Write("After delete operation: ");
        t.PrintInOrder();
    }
    /*
    Before delete operation: 1 2 3 4 5 6 7 8 9 10 
    After delete operation: 1 3 4 5 6 7 8 9 10 
    */

    public static void Main(string[] args)
    {
        Main1();
        Main2();
        Main3();
        Main4();
        Main5();
        Main6();
        Main7();
        Main8();
    }
}
