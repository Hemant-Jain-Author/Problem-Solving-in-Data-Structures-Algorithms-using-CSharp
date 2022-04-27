using System;
using System.Collections.Generic;

public class LinkedList
{
    private class Node
    {
        internal int value;
        internal Node next;

        internal Node(int v, Node n)
        {
            value = v;
            next = n;
        }
    }

    private Node head = null;
    private int size = 0;

    // Other Methods.
    public int Size()
    {
        return size;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    // Other Methods.
    public int Peek()
    {
        if (IsEmpty())
        {
            throw new System.InvalidOperationException("EmptyListException");
        }
        return head.value;
    }

    public void AddHead(int value)
    {
        head = new Node(value, head);
        size++;
    }

    public void AddTail(int value)
    {
        Node newNode = new Node(value, null);
        Node curr = head;

        if (head == null)
        {
            head = newNode;
        }

        while (curr.next != null)
        {
            curr = curr.next;
        }
        curr.next = newNode;
    }

    public int RemoveHead()
    {
        if (IsEmpty())
        {
            throw new System.InvalidOperationException("EmptyListException");
        }
        int value = head.value;
        head = head.next;
        size--;
        return value;
    }

    public bool Search(int data)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.value == data)
            {
                return true;
            }
            temp = temp.next;
        }
        return false;
    }

    public bool DeleteNode(int delValue)
    {
        Node temp = head;

        if (IsEmpty())
        {
            return false;
        }

        if (delValue == head.value)
        {
            head = head.next;
            size--;
            return true;
        }

        while (temp.next != null)
        {
            if (temp.next.value == delValue)
            {
                temp.next = temp.next.next;
                size--;
                return true;
            }
            temp = temp.next;
        }
        return false;
    }

    public bool DeleteNodes(int delValue)
    {
        Node currNode = head;
        Node nextNode;
        bool found = false;
        while (currNode != null && currNode.value == delValue)
        { // first node
            head = currNode.next;
            currNode = head;
            found = true;
        }

        while (currNode != null)
        {
            nextNode = currNode.next;
            if (nextNode != null && nextNode.value == delValue)
            {
                currNode.next = nextNode.next;
                found = true;
            }
            else
            {
                currNode = nextNode;
            }
        }
        return found;
    }

    private Node ReverseRecurseUtil(Node currentNode, Node nextNode)
    {
        Node ret;
        if (currentNode == null)
        {
            return null;
        }
        if (currentNode.next == null)
        {
            currentNode.next = nextNode;
            return currentNode;
        }

        ret = ReverseRecurseUtil(currentNode.next, currentNode);
        currentNode.next = nextNode;
        return ret;
    }

    public void ReverseRecurse()
    {
        head = ReverseRecurseUtil(head, null);
    }

    public void Reverse()
    {
        Node curr = head;
        Node prev = null;
        Node next = null;
        while (curr != null)
        {
            next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        head = prev;
    }

    public LinkedList CopyListReversed()
    {
        Node tempNode = null;
        Node tempNode2 = null;
        Node curr = head;
        while (curr != null)
        {
            tempNode2 = new Node(curr.value, tempNode);
            curr = curr.next;
            tempNode = tempNode2;
        }
        LinkedList ll2 = new LinkedList();
        ll2.head = tempNode;
        return ll2;
    }

    public LinkedList CopyList()
    {
        Node headNode = null;
        Node tailNode = null;
        Node tempNode = null;
        Node curr = head;

        if (curr == null)
        {
            return null;
        }

        headNode = new Node(curr.value, null);
        tailNode = headNode;
        curr = curr.next;

        while (curr != null)
        {
            tempNode = new Node(curr.value, null);
            tailNode.next = tempNode;
            tailNode = tempNode;
            curr = curr.next;
        }
        LinkedList ll2 = new LinkedList();
        ll2.head = headNode;
        return ll2;
    }

    public bool CompareList(LinkedList ll)
    {
        return CompareList(head, ll.head);
    }

    private bool CompareList(Node head1, Node head2)
    {
        if (head1 == null && head2 == null)
        {
            return true;
        }
        else if ((head1 == null) || (head2 == null) || (head1.value != head2.value))
        {
            return false;
        }
        else
        {
            return CompareList(head1.next, head2.next);
        }
    }

    public bool CompareList2(LinkedList ll2)
    {
        Node head1 = head;
        Node head2 = ll2.head;

        while (head1 != null && head2 != null)
        {
            if (head1.value != head2.value)
            {
                return false;
            }
            head1 = head1.next;
            head2 = head2.next;
        }

        if (head1 == null && head2 == null)
        {
            return true;
        }
        return false;
    }

    public int FindLength()
    {
        Node curr = head;
        int count = 0;
        while (curr != null)
        {
            count++;
            curr = curr.next;
        }
        return count;
    }

    public int NthNodeFromBeginning(int index)
    {
        if (index > Size() || index < 1)
        {
            return int.MaxValue;
        }
        int count = 0;
        Node curr = head;
        while (curr != null && count < index - 1)
        {
            count++;
            curr = curr.next;
        }
        return curr.value;
    }

    public int NthNodeFromEnd(int index)
    {
        int size = FindLength();
        int startIndex;
        if (size != 0 && size < index)
        {
            return int.MaxValue;
        }
        startIndex = size - index + 1;
        return NthNodeFromBeginning(startIndex);
    }

    public int NthNodeFromEnd2(int index)
    {
        int count = 1;
        Node forward = head;
        Node curr = head;
        while (forward != null && count <= index)
        {
            count++;
            forward = forward.next;
        }

        if (forward == null)
        {
            return int.MaxValue;
        }

        while (forward != null)
        {
            forward = forward.next;
            curr = curr.next;
        }
        return curr.value;
    }


    public int FindIntersection(LinkedList lst2)
    {
        Node head2 = lst2.head;
        int l1 = 0;
        int l2 = 0;
        Node tempHead = this.head;
        Node tempHead2 = head2;
        while (tempHead != null)
        {
            l1++;
            tempHead = tempHead.next;
        }
        while (tempHead2 != null)
        {
            l2++;
            tempHead2 = tempHead2.next;
        }

        int diff;
        tempHead = this.head;
        tempHead2 = head2;
        if (l1 < l2)
        {
            Node temp = tempHead;
            tempHead = tempHead2;
            tempHead2 = temp;
            diff = l2 - l1;
        }
        else
        {
            diff = l1 - l2;
        }

        for (; diff > 0; diff--)
        {
            tempHead = tempHead.next;
        }
        while (tempHead != tempHead2)
        {
            tempHead = tempHead.next;
            tempHead2 = tempHead2.next;
        }
        return (tempHead != null) ? tempHead.value : -1;
    }

    public void DeleteList()
    {
        head = null;
        size = 0;
    }

    public void Print()
    {
        Node temp = head;
        while (temp != null)
        {
            Console.Write(temp.value + " ");
            temp = temp.next;
        }
        Console.WriteLine("");
    }

    public void SortedInsert(int value)
    {
        Node newNode = new Node(value, null);
        Node curr = head;

        if (curr == null || curr.value > value)
        {
            newNode.next = head;
            head = newNode;
            return;
        }
        while (curr.next != null && curr.next.value < value)
        {
            curr = curr.next;
        }

        newNode.next = curr.next;
        curr.next = newNode;
    }

    public void BubbleSort()
    {
        Node curr, end = null;
        int temp;

        if (head == null || head.next == null)
        {
            return;
        }

        bool flag = true;
        while (flag)
        {
            flag = false;
            curr = head;
            while (curr.next != end)
            {
                if (curr.value > curr.next.value)
                {
                    flag = true;
                    temp = curr.value;
                    curr.value = curr.next.value;
                    curr.next.value = temp;
                }
                curr = curr.next;
            }
            end = curr;
        }
    }

    public void SelectionSort()
    {
        Node curr, end = null, maxNode;
        int temp, max;

        if (head == null || head.next == null)
        {
            return;
        }

        while (head != end)
        {
            curr = head;
            max = curr.value;
            maxNode = curr;
            while (curr.next != end)
            {
                if (max < curr.next.value)
                {
                    maxNode = curr.next;
                    max = curr.next.value;
                }
                curr = curr.next;
            }
            end = curr;
            if (curr.value < max)
            {
                temp = curr.value;
                curr.value = max;
                maxNode.value = temp;
            }
        }
    }

    public void InsertionSort()
    {
        Node curr, stop;
        int temp;

        if (head == null || head.next == null)
        {
            return;
        }

        stop = head.next;
        while (stop != null)
        {
            curr = head;
            while (curr != stop)
            {
                if (curr.value > stop.value)
                {
                    temp = curr.value;
                    curr.value = stop.value;
                    stop.value = temp;
                }
                curr = curr.next;
            }
            stop = stop.next;
        }
    }

    public void RemoveDuplicate()
    {
        Node curr = head;
        while (curr != null)
        {
            if (curr.next != null && curr.value == curr.next.value)
            {
                curr.next = curr.next.next;
            }
            else
            {
                curr = curr.next;
            }
        }
    }

    public void MakeLoop()
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.next == null)
            {
                temp.next = head;
                return;
            }
            temp = temp.next;
        }
    }

    public bool LoopDetect()
    {
        Node curr = head;
        HashSet<Node> hs = new HashSet<Node>();
        while (curr != null)
        {
            if (hs.Contains(curr))
            {
                Console.WriteLine("loop found");
                return true;
            }
            hs.Add(curr);
            curr = curr.next;
        }
        Console.WriteLine("loop not found");
        return false;
    }

    public bool LoopDetect2()
    {
        Node slowPtr;
        Node fastPtr;
        slowPtr = fastPtr = head;

        while (fastPtr.next != null && fastPtr.next.next != null)
        {
            slowPtr = slowPtr.next;
            fastPtr = fastPtr.next.next;
            if (slowPtr == fastPtr)
            {
                Console.WriteLine("loop found");
                return true;
            }
        }
        Console.WriteLine("loop not found");
        return false;
    }

    public bool ReverseListLoopDetect()
    {
        Node tempHead = head;
        Reverse();
        if (tempHead == head)
        {
            Reverse();
            Console.WriteLine("loop found");
            return true;
        }
        else
        {
            Reverse();
            Console.WriteLine("loop not found");
            return false;
        }
    }

    public int LoopTypeDetect()
    {
        Node slowPtr;
        Node fastPtr;
        slowPtr = fastPtr = head;

        while (fastPtr.next != null && fastPtr.next.next != null)
        {
            if (head == fastPtr.next || head == fastPtr.next.next)
            {
                Console.WriteLine("circular list loop found");
                return 2;
            }
            slowPtr = slowPtr.next;
            fastPtr = fastPtr.next.next;
            if (slowPtr == fastPtr)
            {
                Console.WriteLine("loop found");
                return 1;
            }
        }
        Console.WriteLine("loop not found");
        return 0;
    }

    private Node LoopPointDetect()
    {
        Node slowPtr;
        Node fastPtr;
        slowPtr = fastPtr = head;

        while (fastPtr.next != null && fastPtr.next.next != null)
        {
            slowPtr = slowPtr.next;
            fastPtr = fastPtr.next.next;
            if (slowPtr == fastPtr)
            {
                return slowPtr;
            }
        }
        return null;
    }

    public void RemoveLoop()
    {
        Node LoopPoint = LoopPointDetect();
        if (LoopPoint == null)
        {
            return;
        }

        Node firstPtr = head;
        if (LoopPoint == head)
        {
            while (firstPtr.next != head)
            {
                firstPtr = firstPtr.next;
            }
            firstPtr.next = null;
            return;
        }

        Node secondPtr = LoopPoint;
        while (firstPtr.next != secondPtr.next)
        {
            firstPtr = firstPtr.next;
            secondPtr = secondPtr.next;
        }
        secondPtr.next = null;
    }

    // Testing code.
    public static void Main1()
    {
        LinkedList ll = new LinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.Print();
        Console.WriteLine("Size : " + ll.Size());
        Console.WriteLine("Size : " + ll.FindLength());
        Console.WriteLine("Is empty : " + ll.IsEmpty());
        Console.WriteLine("Peek : " + ll.Peek());
        ll.AddTail(4);
        ll.Print();
    }

    /*
    3 2 1 
    Size : 3
    Size : 3
    Is empty : False
    Peek : 3
    3 2 1 4 
    */

    // Testing code.
    public static void Main2()
    {
        LinkedList ll = new LinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.Print();
        Console.WriteLine("Search : " + ll.Search(2));
        ll.RemoveHead();
        ll.Print();
    }

    /*
    3 2 1 
    Search : True
    2 1 
    */

    // Testing code.
    public static void Main3()
    {
        LinkedList ll = new LinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.Print();
        Console.WriteLine("DeleteNode : " + ll.DeleteNode(2));
        ll.Print();
    }

    /*
    3 2 1 
    DeleteNode : True
    3 1
    */

    public static void Main3A()
    {
        LinkedList ll = new LinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(1);
        ll.AddHead(3);
        ll.AddHead(1);
        ll.Print();
        Console.WriteLine("DeleteNodes : " + ll.DeleteNodes(1));
        ll.Print();
    }

    /*
    1 3 1 2 1 
    DeleteNode : True
    3 2
    */

    // Testing code.
    public static void Main4()
    {
        LinkedList ll = new LinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.Print();

        ll.Reverse();
        ll.Print();

        ll.ReverseRecurse();
        ll.Print();

        LinkedList l2 = ll.CopyList();
        l2.Print();
        LinkedList l3 = ll.CopyListReversed();
        l3.Print();
    }

    /*
    3 2 1 
    1 2 3 
    3 2 1 
    3 2 1 
    1 2 3 
    */

    // Testing code.
    public static void Main5()
    {
        LinkedList ll = new LinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.Print();

        LinkedList l2 = ll.CopyList();
        l2.Print();
        LinkedList l3 = ll.CopyListReversed();
        l3.Print();
        Console.WriteLine("CompareList : " + ll.CompareList(l2));
        Console.WriteLine("CompareList : " + ll.CompareList2(l2));
        Console.WriteLine("CompareList : " + ll.CompareList(l3));
        Console.WriteLine("CompareList : " + ll.CompareList2(l3));
    }

    /*
    3 2 1 
    3 2 1 
    1 2 3 
    CompareList : True
    CompareList : True
    CompareList : False
    CompareList : False
    */

    // Testing code.
    public static void Main6()
    {
        LinkedList ll = new LinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(3);
        Console.WriteLine(ll.NthNodeFromBeginning(2));
        Console.WriteLine(ll.NthNodeFromEnd(2));
        Console.WriteLine(ll.NthNodeFromEnd2(2));
    }

    /*
    2
    2
    2
    */

    // Testing code.
    public static void Main7()
    {
        LinkedList ll = new LinkedList();
        ll.SortedInsert(1);
        ll.SortedInsert(2);
        ll.SortedInsert(3);
        ll.SortedInsert(1);
        ll.SortedInsert(2);
        ll.SortedInsert(3);
        ll.Print();
        ll.RemoveDuplicate();
        ll.Print();
    }

    /*
    1 1 2 2 3 3 
    1 2 3
    */

    // Testing code.
    public static void Main8()
    {
        LinkedList ll = new LinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.Print();
        ll.MakeLoop();
        ll.LoopDetect();
        ll.LoopDetect2();
        ll.LoopTypeDetect();
        ll.RemoveLoop();
        ll.LoopDetect2();
    }

    /*
    3 2 1 
    loop found
    circular list loop found
    loop not found
    */

    // Testing code.
    public static void Main9()
    {
        LinkedList ll = new LinkedList();
        ll.AddHead(1);
        ll.AddHead(2);
        LinkedList ll2 = new LinkedList();
        ll2.AddHead(3);
        ll2.head.next = ll.head;
        ll.AddHead(4);
        ll2.AddHead(5);
        ll.Print();
        ll2.Print();
        int val = ll.FindIntersection(ll2);
        Console.WriteLine("Intersection:: " + val);
    }

    /*
    4 2 1 
    5 3 2 1 
    Intersection:: 2
    */

    // Testing code.
    public static void Main10()
    {
        LinkedList ll = new LinkedList();
        ll.AddHead(1);
        ll.AddHead(10);
        ll.AddHead(9);
        ll.AddHead(7);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.AddHead(5);
        ll.AddHead(4);
        ll.AddHead(6);
        ll.AddHead(8);

        ll.BubbleSort();
        ll.Print();

        ll.AddHead(10);
        ll.AddHead(9);
        ll.AddHead(7);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.AddHead(5);
        ll.AddHead(4);
        ll.AddHead(6);
        ll.AddHead(8);

        ll.SelectionSort();
        ll.Print();

        ll.AddHead(10);
        ll.AddHead(9);
        ll.AddHead(7);
        ll.AddHead(2);
        ll.AddHead(3);
        ll.AddHead(5);
        ll.AddHead(4);
        ll.AddHead(6);
        ll.AddHead(8);

        ll.InsertionSort();
        ll.Print();
    }

    /*
    1 2 3 4 5 6 7 8 9 10 
    1 2 2 3 3 4 4 5 5 6 6 7 7 8 8 9 9 10 10 
    1 2 2 2 3 3 3 4 4 4 5 5 5 6 6 6 7 7 7 8 8 8 9 9 9 10 10 10 
    */

    public static void Main(string[] args)
    {
        Main1();
        Main2();
        Main3();
        Main3A();
        Main4();
        Main5();
        Main6();
        Main7();
        Main8();
        Main9();
        Main10();
    }
}