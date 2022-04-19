using System;

// Towers Of Hanoi problem.
public class TOH
{
    private static void TOHUtil(int num, char from, char to, char temp)
    {
        if (num < 1)
        {
            return;
        }

        TOHUtil(num - 1, from, temp, to);
        Console.WriteLine("Move disk " + num + " from peg " + from + " to peg " + to);
        TOHUtil(num - 1, temp, to, from);
    }

    public static void TOHSteps(int num)
    {
        Console.WriteLine("Moves involved in the Tower of Hanoi are :");
        TOHUtil(num, 'A', 'C', 'B');
    }

    public static void Main(string[] args)
    {
        TOH.TOHSteps(3);
    }
}
/*
Moves involved in the Tower of Hanoi are :
Move disk 1 from peg A to peg C
Move disk 2 from peg A to peg B
Move disk 1 from peg C to peg B
Move disk 3 from peg A to peg C
Move disk 1 from peg B to peg A
Move disk 2 from peg B to peg C
Move disk 1 from peg A to peg C
*/