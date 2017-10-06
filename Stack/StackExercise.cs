using System;
using System.Collections.Generic;

public class StackExercise
{
	public static bool isBalancedParenthesis(string expn)
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

	public static void main2(string[] args)
	{
		string expn = "{()}[";
		bool value = isBalancedParenthesis(expn);
		Console.WriteLine("Given Expn:" + expn);
		Console.WriteLine("Result after isParenthesisMatched:" + value);
	}

	public static void insertAtBottom<T>(Stack<T> stk, T value)
	{
		if (stk.Count == 0)
		{
			stk.Push(value);
		}
		else
		{
			T popvalue = stk.Pop();
			insertAtBottom(stk, value);
			stk.Push(popvalue);
		}
	}

	public static void reverseStack<T>(Stack<T> stk)
	{
		if (stk.Count == 0)
		{
			return;
		}
		else
		{
			T value = stk.Pop();
			reverseStack(stk);
			insertAtBottom(stk, value);
		}
	}


	public static int postfixEvaluate(string expn)
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

	public static void Main435436(string[] args)
	{
		string expn = "6 5 2 3 + 8 * + 3 + *";
		int value = postfixEvaluate(expn);
		Console.WriteLine("Given Postfix Expn: " + expn);
		Console.WriteLine("Result after Evaluation: " + value);
	}

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

	public static string infixToPostfix(string expn)
	{
		string output = "";
		char[] outArr = infixToPostfix(expn.ToCharArray());

		foreach (char ch in outArr)
		{
			output = output + ch;
		}
		return output;
	}
}
public static char[] infixToPostfix(char[] expn)
{
	Stack<char> stk = new Stack<char>();

	string output = "";
	char temp;

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
					while (stk.Count != 0 && precedence(ch) <= precedence(stk.Peek()))
					{
						temp = stk.Pop();
						output = output + " " + temp;
					}
					stk.Push(ch);
					output = output + " ";
					break;
				case '(':
					stk.Push(ch);
					break;
				case ')':
					while (stk.Count != 0 && (temp = stk.Pop()) != '(')
					{
						output = output + " " + temp + " ";
					}
					break;
			}
		}
	}

	while (stk.Count != 0)
	{
		temp = stk.Pop();
		output = output + temp + " ";
	}
	return output.ToCharArray();
}

public static void Main(string[] args)
{
	string expn = "10+((3))*5/(16-4)";
	string value = infixToPostfix(expn);
	Console.WriteLine("Infix Expn: " + expn);
	Console.WriteLine("Postfix Expn: " + value);
}

public static string infixToPrefix(string expn)
{
	char[] arr = expn.ToCharArray();
	reverseString(arr);
	replaceParanthesis(arr);
	arr = infixToPostfix(arr);
	reverseString(arr);
	expn = new string(arr);
	return expn;
}

public static void replaceParanthesis(char[] a)
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

public static void reverseString(char[] expn)
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

public static void main5(string[] args)
{
	string expn = "10+((3))*5/(16-4)";
	string value = infixToPrefix(expn);
	Console.WriteLine("Infix Expn: " + expn);
	Console.WriteLine("Prefix Expn: " + value);
}



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

internal virtual int[] StockSpanRange2(int[] arr)
{
	Stack<int> stk = new Stack<int>();

	int[] SR = new int[arr.Length];
	stk.Push(0);
	SR[0] = 1;
	for (int i = 1; i < arr.Length; i++)
	{
		while (stk.Count != 0 && arr[stk.Peek()] <= arr[i])
		{
			stk.Pop();
		}
		SR[i] = (stk.Count == 0) ? (i + 1) : (i - stk.Peek());
		stk.Push(i);
	}
	return SR;
}

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
		while (stk.Count != 0 && (i == size || arr[stk.Peek()] > arr[i]))
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
}
