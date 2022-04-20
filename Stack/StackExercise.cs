using System;
using System.Collections.Generic;
public class StackExercise
{
    public static void Function2()
    {
        Console.WriteLine("Function2 line 1");
    }

    public static void Function1()
    {
        Console.WriteLine("Function1 line 1");
        Function2();
        Console.WriteLine("Function1 line 2");
    }

    /* Testing code */
    public static void Main1()
    {
        Console.WriteLine("Main line 1");
        Function1();
        Console.WriteLine("Main line 2");
    }
    /*
Main line 1
Function1 line 1
Function2 line 1
Function1 line 2
Main line 2
    */

    public static bool IsBalancedParenthesis(string expn)
    {
        Stack<char> stk = new Stack<char>();
        foreach (char ch in expn.ToCharArray())
        {
            switch (ch)
            {
            case '{':
            case '[':
            case '(':
                stk.Push(ch);
                break;
            case '}':
                if (stk.Pop() != '{')
                {
                    return false;
                }
                break;
            case ']':
                if (stk.Pop() != '[')
                {
                    return false;
                }
                break;
            case ')':
                if (stk.Pop() != '(')
                {
                        return false;
                }
                    break;
            }
        }
        return stk.Count == 0;
    }

    // Testing code.
    public static void Main2()
    {
        string expn = "{()}[]";
        bool value = IsBalancedParenthesis(expn);
        Console.WriteLine("Result after isParenthesisMatched: " + value);
    }

    /*
    Result after isParenthesisMatched: True
    */

public static int PostfixEvaluate(string expn)
{
    Stack<int> stk = new Stack<int>();
    string[] tokens = expn.Split(' ');

    foreach (string token in tokens)
    {
        if ("+-*/".Contains(token))
        {
            int num1 = stk.Pop();
            int num2 = stk.Pop();

            switch (token)
            {
                case "+":
                    stk.Push(num1 + num2);
                    break;
                case "-":
                    stk.Push(num1 - num2);
                    break;
                case "*":
                    stk.Push(num1 * num2);
                    break;
                case "/":
                    stk.Push(num1 / num2);
                    break;
            }
        }
        else
        {
            stk.Push(Convert.ToInt32(token));
        }

    }
    return stk.Pop();
}

    // Testing code.
    public static void Main3()
    {
        string expn = "6 5 2 3 + 8 * + 3 + *";
        int value = PostfixEvaluate(expn);
        Console.WriteLine("Given Postfix Expn: " + expn);
        Console.WriteLine("Result after Evaluation: " + value);
    }

    /*
    Given Postfix Expn: 6 5 2 3 + 8 * + 3 + *
    Result after Evaluation: 288
    */

    public static int precedence(char x)
    {
        if (x == '(')
        {
            return (0);
        }
        if (x == '+' || x == '-')
        {
            return (1);
        }
        if (x == '*' || x == '/' || x == '%')
        {
            return (2);
        }
        if (x == '^')
        {
            return (3);
        }
        return (4);
    }

    public static string InfixToPostfix(string expn)
    {
        string output = "";
        char[] outVr = InfixToPostfix(expn.ToCharArray());

        foreach (char ch in outVr)
        {
            output = output + ch;
        }
        return output;
    }

    public static char[] InfixToPostfix(char[] expn)
    {
        Stack<char> stk = new Stack<char>();

        string output = "";
        char outVr;

        foreach (char ch in expn)
        {
            if (ch <= '9' && ch >= '0')
            {
                output = output + ch;
            }
            else
            {
                switch (ch)
                {
                case '+':
                case '-':
                case '*':
                case '/':
                case '%':
                case '^':
                    while (stk.Count > 0 && precedence(ch) <= precedence(stk.Peek()))
                    {
                        outVr = stk.Pop();
                        output = output + " " + outVr;
                    }
                    stk.Push(ch);
                    output = output + " ";
                    break;
                case '(':
                    stk.Push(ch);
                    break;
                case ')':
                    while (stk.Count > 0 && (outVr = stk.Pop()) != '(')
                    {
                        output = output + " " + outVr + " ";
                    }
                    break;
                }
            }
        }

        while (stk.Count > 0)
        {
            outVr = stk.Pop();
            output = output + outVr + " ";
        }
        return output.ToCharArray();
    }

    // Testing code.
    public static void Main4()
    {
        string expn = "10+((3))*5/(16-4)";
        string value = InfixToPostfix(expn);
        Console.WriteLine("Infix Expn: " + expn);
        Console.WriteLine("Postfix Expn: " + value);
    }

    /*
    Infix Expn: 10+((3))*5/(16-4)
    Postfix Expn: 10 3 5 * 16 4 - / + 
    */

    public static string InfixToPrefix(string expn)
    {
        char[] arr = expn.ToCharArray();
        ReverseString(arr);
        ReplaceParenthesis(arr);
        arr = InfixToPostfix(arr);
        ReverseString(arr);
        expn = new string(arr);
        return expn;
    }

    public static void ReplaceParenthesis(char[] a)
    {
        int lower = 0;
        int upper = a.Length - 1;
        while (lower <= upper)
        {
            if (a[lower] == '(')
            {
                a[lower] = ')';
            }
            else if (a[lower] == ')')
            {
                a[lower] = '(';
            }
            lower++;
        }
    }

    public static void ReverseString(char[] expn)
    {
        int lower = 0;
        int upper = expn.Length - 1;
        char tempChar;
        while (lower < upper)
        {
            tempChar = expn[lower];
            expn[lower] = expn[upper];
            expn[upper] = tempChar;
            lower++;
            upper--;
        }
    }

    // Testing code.
    public static void Main5()
    {
        string expn = "10+((3))*5/(16-4)";
        string value = InfixToPrefix(expn);
        Console.WriteLine("Infix Expn: " + expn);
        Console.WriteLine("Prefix Expn: " + value);
    }

    /*
    Infix Expn: 10+((3))*5/(16-4)
    Prefix Expn:  +10 * 3 / 5  - 16 4
    */

    public static int[] StockSpanRange(int[] arr)
    {
        int[] SR = new int[arr.Length];
        SR[0] = 1;
        for (int i = 1; i < arr.Length; i++)
        {
            SR[i] = 1;
            for (int j = i - 1; (j >= 0) && (arr[i] >= arr[j]); j--)
            {
                SR[i]++;
            }
        }
        return SR;
    }

    public static int[] StockSpanRange2(int[] arr)
    {
        Stack<int> stk = new Stack<int>();

        int[] SR = new int[arr.Length];
        stk.Push(0);
        SR[0] = 1;
        for (int i = 1; i < arr.Length; i++)
        {
            while (stk.Count > 0 && arr[stk.Peek()] <= arr[i])
            {
                stk.Pop();
            }
            SR[i] = (stk.Count == 0) ? (i + 1) : (i - stk.Peek());
            stk.Push(i);
        }
        return SR;
    }

    // Testing code.
    public static void Main6()
    {
        int[] arr = new int[] {6, 5, 4, 3, 2, 4, 5, 7, 9};
        int[] value = StockSpanRange(arr);
        Console.Write("StockSpanRange : ");
        foreach (int val in value)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();

        value = StockSpanRange2(arr);
        Console.Write("StockSpanRange : ");
        foreach (int val in value)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();
    }

    /*
    StockSpanRange : 1 1 1 1 1 4 6 8 9 
    StockSpanRange : 1 1 1 1 1 4 6 8 9 
    */

    public static int GetMaxArea(int[] arr)
    {
        int size = arr.Length;
        int maxArea = -1;
        int currArea;
        int minHeight = 0;
        for (int i = 1; i < size; i++)
        {
            minHeight = arr[i];
            for (int j = i - 1; j >= 0; j--)
            {
                if (minHeight > arr[j])
                {
                    minHeight = arr[j];
                }
                currArea = minHeight * (i - j + 1);
                if (maxArea < currArea)
                {
                    maxArea = currArea;
                }
            }
        }
        return maxArea;
    }

    public static int GetMaxArea2(int[] arr)
    {
        int size = arr.Length;
        Stack<int> stk = new Stack<int>();
        int maxArea = 0;
        int top;
        int topArea;
        int i = 0;
        while (i < size)
        {
            while ((i < size) && (stk.Count == 0 || arr[stk.Peek()] <= arr[i]))
            {
                stk.Push(i);
                i++;
            }
            while (stk.Count > 0 && (i == size || arr[stk.Peek()] > arr[i]))
            {
                top = stk.Peek();
                stk.Pop();
                topArea = arr[top] * (stk.Count == 0 ? i : i - stk.Peek() - 1);
                if (maxArea < topArea)
                {
                    maxArea = topArea;
                }
            }
        }
        return maxArea;
    }

    // Testing code.
    public static void Main7()
    {
        int[] arr = new int[] {7, 6, 5, 4, 4, 1, 6, 3, 1};
        int value = GetMaxArea(arr);
        Console.WriteLine("GetMaxArea :: " + value);
        value = GetMaxArea2(arr);
        Console.WriteLine("GetMaxArea :: " + value);
    }

    /*
    GetMaxArea :: 20
    GetMaxArea :: 20
    */


public static void StockAnalystAdd(Stack<int> stk, int value)
{
    while (stk.Count > 0 && stk.Peek() <= value)
    {
        stk.Pop();
    }
    stk.Push(value);
}

// Testing code.
public static void Main7a()
{
    int[] arr = new int[] {20, 19, 10, 21, 40, 35, 39, 50, 45, 42};
    Stack<int> stk = new Stack<int>();
    for (int i = arr.Length - 1;i >= 0;i--)
    {
        StockAnalystAdd(stk, arr[i]);
    }
    foreach(var ele in stk) 
        Console.Write(ele + " "); 
    Console.WriteLine();
    }

    public static void SortedInsert(Stack<int> stk, int element)
    {
        int temp;
        if (stk.Count == 0 || element > stk.Peek())
        {
            stk.Push(element);
        }
        else
        {
            temp = stk.Pop();
            SortedInsert(stk, element);
            stk.Push(temp);
        }
    }

    // Testing code.
    public static void Main8()
    {
        Stack<int> stk = new Stack<int>();
        stk.Push(1);
        stk.Push(3);
        stk.Push(4);
        foreach(var ele in stk) 
            Console.Write(ele + " "); 
        Console.WriteLine();
        
        SortedInsert(stk, 2);
        foreach(var ele in stk) 
            Console.Write(ele + " "); 
        Console.WriteLine();
    }
    /*
4 3 1 
4 3 2 1 
    */

    public static void SortStack(Stack<int> stk)
    {
        int temp;
        if (stk.Count > 0)
        {
            temp = stk.Pop();
            SortStack(stk);
            SortedInsert(stk, temp);
        }
    }

    public static void SortStack2(Stack<int> stk)
    {
        int temp;
        Stack<int> stk2 = new Stack<int>();
        while (stk.Count > 0)
        {
            temp = stk.Pop();
            while ((stk2.Count > 0) && (stk2.Peek() < temp))
            {
                stk.Push(stk2.Pop());
            }
            stk2.Push(temp);
        }
        while (stk2.Count > 0)
        {
            stk.Push(stk2.Pop());
        }
    }

    // Testing code.
    public static void Main9()
    {
        Stack<int> stk = new Stack<int>();
        stk.Push(3);
        stk.Push(1);
        stk.Push(4);
        stk.Push(2);
        foreach(var ele in stk) 
            Console.Write(ele + " "); 
        Console.WriteLine();
        SortStack(stk);
        foreach(var ele in stk) 
            Console.Write(ele + " "); 
        Console.WriteLine();

        stk = new Stack<int>();
        stk.Push(3);
        stk.Push(1);
        stk.Push(4);
        stk.Push(2);
        foreach(var ele in stk) 
            Console.Write(ele + " "); 
        Console.WriteLine();
        SortStack2(stk);
        foreach(var ele in stk) 
            Console.Write(ele + " "); 
        Console.WriteLine();
    }

    /*
2 4 1 3 
4 3 2 1 
2 4 1 3 
4 3 2 1 
    */

    public static void BottomInsert(Stack<int> stk, int element)
    {
        int temp;
        if (stk.Count == 0)
        {
            stk.Push(element);
        }
        else
        {
            temp = stk.Pop();
            BottomInsert(stk, element);
            stk.Push(temp);
        }
    }

    // Testing code.
    public static void Main10()
    {
        Stack<int> stk = new Stack<int>();
        stk.Push(1);
        stk.Push(2);
        stk.Push(3);
        foreach(var ele in stk) 
            Console.Write(ele + " "); 
        Console.WriteLine();
        BottomInsert(stk, 4);
        foreach(var ele in stk) 
            Console.Write(ele + " "); 
        Console.WriteLine();
    }

    /*
    [1, 2, 3]
    [4, 1, 2, 3]
    */

    public static void BottomInsert<T>(Stack<T> stk, T value)
    {
        if (stk.Count == 0)
        {
            stk.Push(value);
        }
        else
        {

            T outVr = stk.Pop();
            BottomInsert(stk, value);
            stk.Push(outVr);
        }
    }

    public static void ReverseStack<T>(Stack<T> stk)
    {
        if (stk.Count == 0)
        {
            return;
        }
        else
        {

            T value = stk.Pop();
            ReverseStack(stk);
            BottomInsert(stk, value);
        }
    }

    public static void ReverseStack2(Stack<int> stk)
{
    Queue<int> que = new Queue<int>();
    while (stk.Count > 0)
    {
        que.Enqueue(stk.Pop());
    }

    while (que.Count != 0)
    {
        stk.Push(que.Dequeue());
    }
}

    public static void ReverseKElementInStack(Stack<int> stk, int k)
{
    Queue<int> que = new Queue<int>();
    int i = 0;
    while (stk.Count > 0 && i < k)
    {
        que.Enqueue(stk.Pop());
        i++;
    }
    while (que.Count != 0)
    {
        stk.Push(que.Dequeue());
    }
}

public static void reverseQueue(Queue<int> que)
{
    Stack<int> stk = new Stack<int>();
    while (que.Count != 0)
    {
        stk.Push(que.Dequeue());
    }

    while (stk.Count > 0)
    {
        que.Enqueue(stk.Pop());
    }
}

    public static void ReverseKElementInQueue(Queue<int> que, int k)
    {
        Stack<int> stk = new Stack<int>();
        int i = 0, diff, temp;
        while (que.Count > 0 && i < k)
        {
            stk.Push(que.Dequeue());
            i++;
        }
        while (stk.Count > 0)
        {
            que.Enqueue(stk.Pop());
        }
        diff = que.Count - k;
        while (diff > 0)
        {
            temp = que.Dequeue();
            que.Enqueue(temp);
            diff -= 1;
        }
    }

    // Testing code.
    public static void Main11()
    {
        Stack<int> stk = new Stack<int>();
        stk.Push(1);
        stk.Push(2);
        stk.Push(3);
        foreach(var ele in stk) 
            Console.Write(ele + " "); 
        Console.WriteLine();
    }

    // [1, 2, 3]

    // Testing code.
    public static void Main12()
    {
        Stack<int> stk = new Stack<int>();
        stk.Push(1);
        stk.Push(2);
        stk.Push(3);
        stk.Push(4);
        foreach(var ele in stk) 
            Console.Write(ele + " "); 
        Console.WriteLine();
        ReverseStack(stk);
        foreach(var ele in stk) 
            Console.Write(ele + " "); 
        Console.WriteLine();
        ReverseStack2(stk);
        foreach(var ele in stk) 
            Console.Write(ele + " "); 
        Console.WriteLine();
        ReverseKElementInStack(stk, 2);
        foreach(var ele in stk) 
            Console.Write(ele + " "); 
        Console.WriteLine();
    }
    /*
    [1, 2, 3, 4]
    [4, 3, 2, 1]
    [1, 2, 3, 4]
    [1, 2, 4, 3]
    */

    // Testing code.
    public static void Main13()
    {
        Queue<int> que = new Queue<int>();
        que.Enqueue(1);
        que.Enqueue(2);
        que.Enqueue(3);
        foreach(var ele in que) 
            Console.Write(ele + " "); 
        Console.WriteLine();
        
        reverseQueue(que);
        foreach(var ele in que) 
            Console.Write(ele + " "); 
        Console.WriteLine();
        ReverseKElementInQueue(que, 2);
        
        foreach(var ele in que) 
            Console.Write(ele + " "); 
        Console.WriteLine();
    }

    /*
    [1, 2, 3]
    [3, 2, 1]
    [2, 3, 1]
    */

    public static int MaxDepthParenthesis(string expn, int size)
    {
        Stack<char> stk = new Stack<char>();
        int maxDepth = 0;
        int depth = 0;
        char ch;

        for (int i = 0; i < size; i++)
        {
            ch = expn[i];

            if (ch == '(')
            {
                stk.Push(ch);
                depth += 1;
            }
            else if (ch == ')')
            {
                stk.Pop();
                depth -= 1;
            }
            if (depth > maxDepth)
            {
                maxDepth = depth;
            }
        }
        return maxDepth;
    }

    public static int MaxDepthParenthesis2(string expn, int size)
    {
        int maxDepth = 0;
        int depth = 0;
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = expn[i];
            if (ch == '(')
            {
                depth += 1;
            }
            else if (ch == ')')
            {
                depth -= 1;
            }

            if (depth > maxDepth)
            {
                maxDepth = depth;
            }
        }
        return maxDepth;
    }

    // Testing code.
    public static void Main14()
    {
        string expn = "((((A)))((((BBB()))))()()()())";
        int size = expn.Length;
        Console.WriteLine("Max depth parenthesis is " + MaxDepthParenthesis(expn, size));
        Console.WriteLine("Max depth parenthesis is " + MaxDepthParenthesis2(expn, size));
    }

    /*
    Max depth parenthesis is 6
    Max depth parenthesis is 6
    */

    public static int LongestContBalParen(string str, int size)
    {
        Stack<int> stk = new Stack<int>();
        stk.Push(-1);
        int length = 0;

        for (int i = 0; i < size; i++)
        {
            if (str[i] == '(')
            {
                stk.Push(i);
            }
            else
            {
                stk.Pop();
                if (stk.Count != 0)
                {
                    length = Math.Max(length, i - stk.Peek());
                }
                else
                {
                    stk.Push(i);
                }
            }
        }
        return length;
    }
    
    // Testing code.
    public static void Main15()
    {
        string expn = "())((()))(())()(()";
        int size = expn.Length;
        Console.WriteLine("LongestContBalParen " + LongestContBalParen(expn, size));
    }

    // LongestContBalParen 12

        public static int ReverseParenthesis(string expn, int size)
    {
        Stack<char> stk = new Stack<char>();
        int openCount = 0;
        int closeCount = 0;
        char ch;

        if (size % 2 == 1)
        {
            Console.WriteLine("Invalid odd length " + size);
            return -1;
        }
        for (int i = 0; i < size; i++)
        {
            ch = expn[i];
            if (ch == '(')
            {
                stk.Push(ch);
            }
            else if (ch == ')')
            {
                if (stk.Count != 0 && stk.Peek() == '(')
                {
                    stk.Pop();
                }
                else
                {
                    stk.Push(')');
                }
            }
        }
        while (stk.Count != 0)
        {
            if (stk.Pop() == '(')
            {
                openCount += 1;
            }
            else
            {
                closeCount += 1;
            }
        }
        int reversal = (int) Math.Ceiling(openCount / 2.0) + (int) Math.Ceiling(closeCount / 2.0);
        return reversal;
    }

    // Testing code.
    public static void Main16()
    {
        string expn2 = ")(())(((";
        int size = expn2.Length;
        int value = ReverseParenthesis(expn2, size);
        Console.WriteLine("reverse Parenthesis is : " + value);
    }

    // reverse Parenthesis is : 3

    public static bool FindDuplicateParenthesis(string expn, int size)
    {
        Stack<char> stk = new Stack<char>();
        char ch;
        int count;

        for (int i = 0; i < size; i++)
        {
            ch = expn[i];
            if (ch == ')')
            {
                count = 0;
                while (stk.Count != 0 && stk.Peek() != '(')
                {
                    stk.Pop();
                    count += 1;
                }
                if (count <= 1)
                {
                    return true;
                }
            }
            else
            {
                stk.Push(ch);
            }
        }
        return false;
    }

    // Testing code.
    public static void Main17()
    {
        string expn = "(((a+b))+c)";
        int size = expn.Length;
        bool value = FindDuplicateParenthesis(expn, size);
        Console.WriteLine("Duplicate Found : " + value);
    }

    // Duplicate Found : True

    public static void PrintParenthesisNumber(string expn, int size)
    {
        char ch;
        Stack<int> stk = new Stack<int>();
        string output = "";
        int count = 1;
        for (int i = 0; i < size; i++)
        {
            ch = expn[i];
            if (ch == '(')
            {
                stk.Push(count);
                output += count;
                output += " ";
                count += 1;
            }
            else if (ch == ')')
            {
                output += stk.Pop();
                output += " ";
            }

        }
        Console.WriteLine("Parenthesis Count " + output);
    }

    // Testing code.
    public static void Main18()
    {
        string expn1 = "(((a+(b))+(c+d)))";
        string expn2 = "(((a+b))+c)(((";
        PrintParenthesisNumber(expn1, expn1.Length);
        PrintParenthesisNumber(expn2, expn2.Length);
    }

    /*
    Parenthesis Count 1 2 3 4 4 3 5 5 2 1 
    Parenthesis Count 1 2 3 3 2 1 4 5 6 
    */

    public static void NextLargerElement(int[] arr, int size)
    {
        int[] output = new int[size];
        int outIndex = 0;
        int next;

        for (int i = 0; i < size; i++)
        {
            next = -1;
            for (int j = i + 1; j < size; j++)
            {
                if (arr[i] < arr[j])
                {
                    next = arr[j];
                    break;
                }
            }
            output[outIndex++] = next;
        }
        foreach (int val in output)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();
    }

    public static void NextLargerElement2(int[] arr, int size)
    {
        Stack<int> stk = new Stack<int>();
        int[] output = new int[size];
        int index = 0;
        int curr;

        for (int i = 0; i < size; i++)
        {
            curr = arr[i];
            // stack always have values in decreasing order.
            while (stk.Count > 0 && arr[stk.Peek()] <= curr)
            {
                index = stk.Pop();
                output[index] = curr;
            }
            stk.Push(i);
        }
        // index which don't have any next Larger.
        while (stk.Count > 0)
        {
            index = stk.Pop();
            output[index] = -1;
        }
        foreach (int val in output)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();
    }

    public static void NextSmallerElement(int[] arr, int size)
    {
        int[] output = new int[size];
        Array.Fill(output, -1);
        for (int i = 0; i < size; i++)
        {
            for (int j = i + 1;j < size;j++)
            {
                if (arr[j] < arr[i])
                {
                    output[i] = arr[j];
                    break;
                }
            }
        }

        foreach (int val in output)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();
    }

    public static void NextSmallerElement2(int[] arr, int size)
    {
        Stack<int> stk = new Stack<int>();
        int[] output = new int[size];
        int curr, index;
        for (int i = 0; i < size; i++)
        {
            curr = arr[i];
            // stack always have values in increasing order.
            while (stk.Count > 0 && arr[stk.Peek()] > curr)
            {
                index = stk.Pop();
                output[index] = curr;
            }
            stk.Push(i);
        }
        // index which don't have any next Smaller.
        while (stk.Count > 0)
        {
            index = stk.Pop();
            output[index] = -1;
        }
        foreach (int val in output)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();
    }

    // Testing code.
    public static void Main19()
    {
        int[] arr = new int[] {13, 21, 3, 6, 20, 3};
        int size = arr.Length;
        NextLargerElement(arr, size);
        NextLargerElement2(arr, size);
        NextSmallerElement(arr, size);
        NextSmallerElement2(arr, size);
    }

    /*
    21 -1 6 20 -1 -1 
    21 -1 6 20 -1 -1 
    3 3 -1 3 3 -1 
    3 3 -1 3 3 -1 
    */

    public static void NextLargerElementCircular(int[] arr, int size)
    {
        int[] output = new int[size];
        Array.Fill(output, -1);
        for (int i = 0; i < size; i++)
        {
            for (int j = 1;j < size;j++)
            {
                if (arr[i] < arr[(i + j) % size])
                {
                    output[i] = arr[(i + j) % size];
                    break;
                }
            }
        }

        foreach (int val in output)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();
    }


    public static void NextLargerElementCircular2(int[] arr, int size)
    {
        Stack<int> stk = new Stack<int>();
        int curr, index;
        int[] output = new int[size];
        for (int i = 0; i < (2 * size - 1); i++)
        {
            curr = arr[i % size];
            // stack always have values in decreasing order.
            while (stk.Count > 0 && arr[stk.Peek()] <= curr)
            {
                index = stk.Pop();
                output[index] = curr;
            }
            stk.Push(i % size);
        }
        // index which don't have any next Larger.
        while (stk.Count > 0)
        {
            index = stk.Pop();
            output[index] = -1;
        }
        foreach (int val in output)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();
    }

    // Testing code.
    public static void Main20()
    {
        int[] arr = new int[] {6, 3, 9, 8, 10, 2, 1, 15, 7};
        NextLargerElementCircular(arr, arr.Length);
        NextLargerElementCircular2(arr, arr.Length);
    }

    // 9 9 10 10 15 15 15 -1 9
    // 9 9 10 10 15 15 15 -1 9

    public static bool IsKnown(int[, ] relation, int a, int b)
    {
        if (relation[a, b] == 1)
        {
            return true;
        }
        return false;
    }

    public static int FindCelebrity(int[, ] relation, int count)
    {
        int i, j;
        bool cel = true;
        for (i = 0; i < count; i++)
        {
            cel = true;
            for (j = 0; j < count; j++)
            {
                if (i != j && (!IsKnown(relation, j, i) || IsKnown(relation, i, j)))
                {
                    cel = false;
                    break;
                }
            }
            if (cel == true)
            {
                return i;
            }
        }
        return -1;
    }

    public static int FindCelebrity2(int[, ] relation, int count)
    {
        Stack<int> stk = new Stack<int>();
        int first = 0, second = 0;
        for (int i = 0; i < count; i++)
        {
            stk.Push(i);
        }
        first = stk.Pop();
        while (stk.Count != 0)
        {
            second = stk.Pop();
            if (IsKnown(relation, first, second))
            {
                first = second;
            }
        }
        for (int i = 0; i < count; i++)
        {
            if (first != i && IsKnown(relation, first, i))
            {
                return -1;
            }
            if (first != i && IsKnown(relation, i, first) == false)
            {
                return -1;
            }
        }
        return first;
    }

    public static int FindCelebrity3(int[, ] relation, int count)
    {
        int first = 0;
        int second = 1;

        for (int i = 0; i < (count - 1); i++)
        {
            if (IsKnown(relation, first, second))
            {
                first = second;
            }
            second = second + 1;
        }
        for (int i = 0; i < count; i++)
        {
            if (first != i && IsKnown(relation, first, i))
            {
                return -1;
            }
            if (first != i && IsKnown(relation, i, first) == false)
            {
                return -1;
            }
        }
        return first;
    }

    // Testing code.
    public static void Main21()
    {
        int[, ] arr = new int[, ]
        {
            {1, 0, 1, 1, 0},
            {1, 0, 0, 1, 0},
            {0, 0, 1, 1, 1},
            {0, 0, 0, 0, 0},
            {1, 1, 0, 1, 1}
        };

        Console.WriteLine("Celebrity : " + FindCelebrity3(arr, 5));
        Console.WriteLine("Celebrity : " + FindCelebrity(arr, 5));
        Console.WriteLine("Celebrity : " + FindCelebrity2(arr, 5));
    }

    /*
    Celebrity : 3
    Celebrity : 3
    Celebrity : 3

    */

    public static int IsMinHeap(int[] arr, int size)
    {
        for (int i = 0; i <= (size - 2) / 2; i++)
        {
            if (2 * i + 1 < size)
            {
                if (arr[i] > arr[2 * i + 1])
                {
                    return 0;
                }
            }
            if (2 * i + 2 < size)
            {
                if (arr[i] > arr[2 * i + 2])
                {
                    return 0;
                }
            }
        }
        return 1;
    }

    public static int IsMaxHeap(int[] arr, int size)
    {
        for (int i = 0; i <= (size - 2) / 2; i++)
        {
            if (2 * i + 1 < size)
            {
                if (arr[i] < arr[2 * i + 1])
                {
                    return 0;
                }
            }
            if (2 * i + 2 < size)
            {
                if (arr[i] < arr[2 * i + 2])
                {
                    return 0;
                }
            }
        }
        return 1;
    }

    public static void Main(string[] args)
    {
        Main1();
        Main2();
        Main3();
        Main4();
        Main5();
        Main6();
        Main7();
        Main7a();
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
        Main21();
    }
}