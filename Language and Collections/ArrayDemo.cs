using System;

public class ArrayDemo
{
    public static void oneD()
    {
        int[] arr = new int[10];
        for (int i = 0; i < 10; i++)
        {
            arr[i] = i;
        }
        for (int i = 0; i < 10; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    private static void twoD()
    {
        int[,] arr = new int[4, 4];

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                arr[i, j] = i + j;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(arr[i, j]);
            }
            Console.WriteLine(" ");
        }
    }

    // Testing code.
    public static void Main(string[] args)
    {
        oneD();
        twoD();
    }
}

/*
0 1 2 3 4 5 6 7 8 9 

0123 
1234 
2345 
3456 
*/