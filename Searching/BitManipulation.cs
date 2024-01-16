using System;

public class BitManipulation
{
    public static int AndEx(int a, int b)
    {
        return a & b;
    }

    public static int OrEx(int a, int b)
    {
        return a | b;
    }

    public static int XorEx(int a, int b)
    {
        return a ^ b;
    }

    public static int LeftShiftEx(int a) // multiply by 2
    { 
        return a << 1;
    }

    public static int RightShiftEx(int a) // divide by 2
    { 
        return a >> 1;
    }

    public static int BitReversalEx(int a)
    {
        return ~a;
    }

    public static int TwosComplementEx(int a)
    {
        return -a;
    }

    public static bool KthBitCheck(int a, int k)
    {
        return (a & 1 << (k - 1)) > 0;
    }

    public static int KthBitSet(int a, int k)
    {
        return (a | 1 << (k - 1));
    }

    public static int KthBitReset(int a, int k)
    {
        return (a & ~(1 << (k - 1)));
    }

    public static int KthBitToggle(int a, int k)
    {
        return (a ^ (1 << (k - 1)));
    }

    public static int RightMostBit(int a)
    {
        return a & -a;
    }

    public static int ResetRightMostBit(int a)
    {
        return a & (a - 1);
    }

    public static bool IsPowerOf2(int a)
    {
        if ((a & (a - 1)) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int CountBits(int a)
    {
        int count = 0;
        while (a > 0)
        {
            count += 1;
            a = a & (a - 1); // reset least significant bit.
        }
        return count;
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int a = 4;
        int b = 8;
        
        Console.WriteLine(AndEx(a, b));
        Console.WriteLine(OrEx(a, b));
        Console.WriteLine(XorEx(a, b));
        Console.WriteLine(LeftShiftEx(a)); // multiply by 2
        Console.WriteLine(RightShiftEx(a)); // divide by 2
        Console.WriteLine(BitReversalEx(a));
        Console.WriteLine(TwosComplementEx(a));
        Console.WriteLine(KthBitCheck(a, 3));
        Console.WriteLine(KthBitSet(a, 2));
        Console.WriteLine(KthBitReset(a, 3));
        Console.WriteLine(KthBitToggle(a, 3));
        Console.WriteLine(RightMostBit(a));
        Console.WriteLine(ResetRightMostBit(a));
        Console.WriteLine(IsPowerOf2(a));
        
        for (int i = 0;i < 10;i++)
        {
            Console.WriteLine(i + " bit count : " + CountBits(i));
        }
    }
}

/*
0
12
12
8
2
-5
-4
True
6
0
0
4
0
True
*/

/*
0 bit count : 0
1 bit count : 1
2 bit count : 1
3 bit count : 2
4 bit count : 1
5 bit count : 2
6 bit count : 2
7 bit count : 3
8 bit count : 1
9 bit count : 2
*/