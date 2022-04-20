using System;
using System.Collections.Generic;

public class StackDemo
{
    public static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Console.WriteLine("Stack size : " + stack.Count);
        Console.Write("Stack : ");
        foreach (var ele in stack)
            Console.Write(ele + " ");
        Console.WriteLine();

        Console.WriteLine("Stack pop : " + stack.Pop());
        Console.WriteLine("Stack top : " + stack.Peek());
        Console.WriteLine("Stack isEmpty : " + (stack.Count == 0));
    }
}

/* 
Stack size : 3
Stack : 3 2 1 
Stack pop : 3
Stack top : 2
Stack isEmpty : False
*/