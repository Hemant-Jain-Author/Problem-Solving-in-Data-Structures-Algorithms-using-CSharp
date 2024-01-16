using System;
using System.Collections.Generic;

public class Introduction
{
    public static void PrintArray(int[] arr, int count)
    {
        Console.Write("[");
        for (int i = 0; i < count; i++)
        {
            Console.Write(" " + arr[i]);
        }
        Console.WriteLine(" ]");
    }

    public static void Swap(int[] arr, int x, int y)
    {
        int temp = arr[x];
        arr[x] = arr[y];
        arr[y] = temp;
        return;
    }
    
public static int Factorial(int i)
{
    // Termination Condition
    if (i <= 1)
    {
        return 1;
    }
    // Body, Recursive Expansion
    return i * Factorial(i - 1);
}

/* Testing code */
public static void Main14()
{
    Console.WriteLine("Factorial:" + Factorial(5));
}
    // Factorial:120

    public static void PrintInt10(int number)
    {
        char digit = (char)(number % 10 + '0');
        number = number / 10;
        if (number != 0)
        {
            PrintInt10(number);
        }
        Console.Write(digit);
    }

public static void PrintInt(int number, int outputbase)
{
    string conversion = "0123456789ABCDEF";
    char digit = (char)(number % outputbase);
    number = number / outputbase;
    if (number != 0)
    {
        PrintInt(number, outputbase);
    }
    Console.Write(conversion[digit]);
}

/* Testing code */
public static void Main15()
{
    PrintInt(500, 16);
    Console.WriteLine();
}

/*
1F4
*/


public static void TowerOfHanoi(int num, char src, char dst, char temp)
{
    if (num < 1)
    {
        return;
    }

    TowerOfHanoi(num - 1, src, temp, dst);
    Console.WriteLine("Move " + num + " disk  from peg " + src + " to peg " + dst);
    TowerOfHanoi(num - 1, temp, dst, src);
}

/* Testing code */
public static void Main16()
{
    int num = 3;
    Console.WriteLine("Moves involved in the Tower of Hanoi are:");
    TowerOfHanoi(num, 'A', 'C', 'B');
}

/*
Moves involved in the Tower of Hanoi are:
Move 1 disk  from peg A to peg C
Move 2 disk  from peg A to peg B
Move 1 disk  from peg C to peg B
Move 3 disk  from peg A to peg C
Move 1 disk  from peg B to peg A
Move 2 disk  from peg B to peg C
Move 1 disk  from peg A to peg C
*/

public static int Gcd(int m, int n)
{
    if (n == 0)
        return m;

    if (m == 0)
        return n;

    return (Gcd(n, m % n));
}

/* Testing code */
public static void Main17()
{
    Console.WriteLine("Gcd is:: " + Gcd(5, 2));
}

    /*
    Gcd is:: 1
    */

public static int Fibonacci(int n)
{
    if (n < 2)
    {
        return n;
    }
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

/* Testing code */
public static void Main18()
{
    Console.WriteLine(Fibonacci(10) + " ");
}

    /*
    55
    */

    public static void Permutation(int[] arr, int i, int length)
    {
        if (length == i)
        {
            PrintArray(arr, length);
            return;
        }
        int j = i;
        for (j = i; j < length; j++)
        {
            Swap(arr, i, j);
            Permutation(arr, i + 1, length);
            Swap(arr, i, j);
        }
        return;
    }

    /* Testing code */
    public static void Main19()
    {
        int[] arr = new int[3];
        for (int i = 0; i < 3; i++)
        {
            arr[i] = i;
        }
        Permutation(arr, 0, 3);
    }
    /*
    [ 0 1 2 ]
    [ 0 2 1 ]
    [ 1 0 2 ]
    [ 1 2 0 ]
    [ 2 1 0 ]
    [ 2 0 1 ]
    */
    
    public static void Main(string[] args)
    {
        Main1();
        Introduction i = new Introduction();
        i.Main2();
        Main3();
        Main4();
        Main5();
        Main6();
        Main7();
        Main8();
        Main9();
        Main10();
        Main11();
        Main12();
        Main13();
        Main14();
        Main15();
        Main16();
        Main17();
        Main18();
        Main19();
        Main20();
    }
}

