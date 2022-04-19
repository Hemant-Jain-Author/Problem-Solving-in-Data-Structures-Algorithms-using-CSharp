using System;

public class Polynomial
{
    public class Node
    {
        internal int coeff;
        internal int pow;
        internal Node next;
        internal Node(int c, int p)
        {
            coeff = c;
            pow = p;
            next = null;
        }
    }

    public static Node add(Node p1, Node p2)
    {
        Node head = null, tail = null, temp = null;
        while (p1 != null || p2 != null)
        {
            if (p1 == null || p1.pow < p2.pow)
            {
                temp = new Node(p2.coeff, p2.pow);
                p2 = p2.next;
            }
            else if (p2 == null || p1.pow > p2.pow)
            {
                temp = new Node(p1.coeff, p1.pow);
                p1 = p1.next;
            }
            else if (p1.pow == p2.pow)
            {
                temp = new Node(p1.coeff + p2.coeff, p1.pow);
                p1 = p1.next;
                p2 = p2.next;
            }

            if (head == null)
            {
                head = tail = temp;
            }
            else
            {
                tail.next = temp;
                tail = tail.next;
            }
        }
        return head;
    }

    public static Node create(int[] coeffs, int[] pows, int size)
    {
        Node head = null, tail = null, temp = null;
        for (int i = 0; i < size; i++)
        {
            temp = new Node(coeffs[i], pows[i]);
            if (head == null)
            {
                head = tail = temp;
            }
            else
            {
                tail.next = temp;
                tail = tail.next;
            }
        }
        return head;
    }

    public static void print(Node head)
    {
        while (head != null)
        {
            Console.Write(head.coeff + "x^" + head.pow);
            if (head.next != null)
            {
                Console.Write(" + ");
            }
                head = head.next;
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        int[] c1 = new int[] {6, 5, 4};
        int[] p1 = new int[] {2, 1, 0};
        int s1 = c1.Length;
        Node first = create(c1, p1, s1);
        print(first);

        int[] c2 = new int[] {3, 2, 1};
        int[] p2 = new int[] {3, 1, 0};
        int s2 = c2.Length;
        Node second = create(c2, p2, s2);
        print(second);

        Node sum = add(first, second);
        print(sum);
    }
}

/*
6x^2 + 5x^1 + 4x^0
3x^3 + 2x^1 + 1x^0
3x^3 + 6x^2 + 7x^1 + 5x^0
*/