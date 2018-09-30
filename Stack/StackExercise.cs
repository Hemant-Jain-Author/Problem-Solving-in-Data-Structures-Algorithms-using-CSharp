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

	public static void Main(string[] args)
	{
		string expn = "{()}[]";
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
			T popValue = stk.Pop();
			insertAtBottom(stk, value);
			stk.Push(popValue);
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
		Stack<int?> stk = new Stack<int?>();
		Scanner tokens = new Scanner(expn);

		while (tokens.hasNext())
		{
			if (tokens.hasNextInt())
			{
				stk.Push(tokens.Next());
			}
			else
			{
				int num1 = stk.Pop();
				int num2 = stk.Pop();
				char op = tokens.next().charAt(0);
				switch (op)
				{
					case '+':
						stk.Push(num1 + num2);
						break;
					case '-':
						stk.Push(num1 - num2);
						break;
					case '*':
						stk.Push(num1 * num2);
						break;
					case '/':
						stk.Push(num1 / num2);
						break;
				}
			}
		}
		tokens.close();
		return stk.Pop();
	}

	public static void main2(string[] args)
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
		char[] @out = infixToPostfix(expn.ToCharArray());

		foreach (char ch in @out)
		{
			output = output + ch;
		}
		return output;
	}

	public static char[] infixToPostfix(char[] expn)
	{
		Stack<char?> stk = new Stack<char?>();

		string output = "";
		char @out;

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
							@out = stk.Pop();
							output = output + " " + @out;
						}
						stk.Push(ch);
						output = output + " ";
						break;
					case '(':
						stk.Push(ch);
						break;
					case ')':
						while (stk.Count > 0 && (@out = stk.Pop()) != '(')
						{
							output = output + " " + @out + " ";
						}
						break;
				}
			}
		}

		while (stk.Count > 0)
		{
			@out = stk.Pop();
			output = output + @out + " ";
		}
		return output.ToCharArray();
	}

	public static void main3(string[] args)
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

	public static void main4(string[] args)
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

	public static int[] StockSpanRange2(int[] arr)
	{
		Stack<int?> stk = new Stack<int?>();

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

	public static void main5(string[] args)
	{
		int[] arr = new int[] { 6, 5, 4, 3, 2, 4, 5, 7, 9 };
		int size = arr.Length;
		int[] value = StockSpanRange(arr);
		Console.Write("\nStockSpanRange : ");
		foreach (int val in value)
		{
			Console.Write(" " + val);
		}
		value = StockSpanRange2(arr);
		Console.Write("\nStockSpanRange : ");
		foreach (int val in value)
		{
			Console.Write(" " + val);
		}
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
		Stack<int?> stk = new Stack<int?>();
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

	public static void main6(string[] args)
	{
		int[] arr = new int[] { 7, 6, 5, 4, 4, 1, 6, 3, 1 };
		int size = arr.Length;
		int value = GetMaxArea(arr);
		Console.WriteLine("GetMaxArea :: " + value);
		value = GetMaxArea2(arr);
		Console.WriteLine("GetMaxArea :: " + value);
	}

	public static void sortedInsert(Stack<int?> stk, int element)
	{
		int temp;
		if (stk.Count == 0 || element > stk.Peek())
		{
			stk.Push(element);
		}
		else
		{
			temp = stk.Pop();
			sortedInsert(stk, element);
			stk.Push(temp);
		}
	}

	public static void sortStack(Stack<int?> stk)
	{
		int temp;
		if (stk.Count > 0)
		{
			temp = stk.Pop();
			sortStack(stk);
			stk.Push(temp);
		}
	}

	public static void sortStack2(Stack<int?> stk)
	{
		int temp;
		Stack<int?> stk2 = new Stack<int?>();
		while (stk.Count > 0)
		{
			temp = stk.Pop();
			while ((stk.Count > 0) && (stk2.Peek() < temp))
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

	public static void bottomInsert(Stack<int?> stk, int element)
	{
		int temp;
		if (stk.Count == 0)
		{
			stk.Push(element);
		}
		else
		{
			temp = stk.Pop();
			bottomInsert(stk, element);
			stk.Push(temp);
		}
	}

	public static void reverseStack2(Stack<int?> stk)
	{
		ArrayDeque<int?> que = new ArrayDeque<int?>();
		while (stk.Count > 0)
		{
			que.add(stk.Pop());
		}

		while (que.Empty == false)
		{
			stk.Push(que.remove());
		}
	}

	public static void reverseKElementInStack(Stack<int?> stk, int k)
	{
		ArrayDeque<int?> que = new ArrayDeque<int?>();
		int i = 0;
		while (stk.Count > 0 && i < k)
		{
			que.add(stk.Pop());
			i++;
		}
		while (que.Empty == false)
		{
			stk.Push(que.remove());
		}
	}

	public static void reverseQueue(ArrayDeque<int?> que)
	{
		Stack<int?> stk = new Stack<int?>();
		while (que.Empty == false)
		{
			stk.Push(que.remove());
		}

		while (stk.Count > 0)
		{
			que.add(stk.Pop());
		}
	}

	public static void reverseKElementInQueue(ArrayDeque<int?> que, int k)
	{
		Stack<int?> stk = new Stack<int?>();
		int i = 0, diff, temp;
		while (que.Empty == false && i < k)
		{
			stk.Push(que.remove());
			i++;
		}
		while (stk.Count > 0)
		{
			que.add(stk.Pop());
		}
		diff = que.size() - k;
		while (diff > 0)
		{
			temp = que.remove();
			que.add(temp);
			diff -= 1;
		}
	}

	public static void main7(string[] args)
	{
		Stack<int?> stk = new Stack<int?>();
		stk.Push(1);
		stk.Push(2);
		stk.Push(3);
		stk.Push(4);
		stk.Push(5);
		Console.WriteLine(stk);
	}

	public static void main8(string[] args)
	{
		Stack<int?> stk = new Stack<int?>();
		stk.Push(-2);
		stk.Push(13);
		stk.Push(16);
		stk.Push(-6);
		stk.Push(40);
		Console.WriteLine(stk);

		reverseStack2(stk);
		Console.WriteLine(stk);
		reverseKElementInStack(stk, 2);
		Console.WriteLine(stk);
		/*
		 * System.out.println(stk); sortStack2(stk); System.out.println(stk);
		 */
		ArrayDeque<int?> que = new ArrayDeque<int?>();
		que.add(1);
		que.add(2);
		que.add(3);
		que.add(4);
		que.add(5);
		que.add(6);
		Console.WriteLine(que);
		reverseQueue(que);
		Console.WriteLine(que);
		reverseKElementInQueue(que, 2);
		Console.WriteLine(que);
	}

	public static int maxDepthParenthesis(string expn, int size)
	{
		Stack<char?> stk = new Stack<char?>();
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

	public static int maxDepthParenthesis2(string expn, int size)
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

	public static void main9(string[] args)
	{
		string expn = "((((A)))((((BBB()))))()()()())";
		int size = expn.Length;
		int value = maxDepthParenthesis(expn, size);
		int value2 = maxDepthParenthesis2(expn, size);

		Console.WriteLine("Given expn " + expn);
		Console.WriteLine("Max depth parenthesis is " + value);
		Console.WriteLine("Max depth parenthesis is " + value2);
	}

	public static int longestContBalParen(string @string, int size)
	{
		Stack<int?> stk = new Stack<int?>();
		stk.Push(-1);
		int length = 0;

		for (int i = 0; i < size; i++)
		{

			if (@string[i] == '(')
			{
				stk.Push(i);
			}
			else // string[i] == ')'
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

	public static void main10(string[] args)
	{
		string expn = "())((()))(())()(()";
		int size = expn.Length;
		int value = longestContBalParen(expn, size);
		Console.WriteLine("longestContBalParen " + value);
	}

	public static int reverseParenthesis(string expn, int size)
	{
		Stack<char?> stk = new Stack<char?>();
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
		int reversal = (int)Math.Ceiling(openCount / 2.0) + (int)Math.Ceiling(closeCount / 2.0);
		return reversal;
	}

	public static void main11(string[] args)
	{
		string expn = "())((()))(())()(()()()()))";
		string expn2 = ")(())(((";
		int size = expn2.Length;
		int value = reverseParenthesis(expn2, size);
		Console.WriteLine("Given expn : " + expn2);
		Console.WriteLine("reverse Parenthesis is : " + value);
	}

	public static bool findDuplicateParenthesis(string expn, int size)
	{
		Stack<char?> stk = new Stack<char?>();
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

	public static void main12(string[] args)
	{
		// expn = "(((a+(b))+(c+d)))"
		// expn = "(b)"
		string expn = "(((a+b))+c)";
		Console.WriteLine("Given expn : " + expn);
		int size = expn.Length;
		bool value = findDuplicateParenthesis(expn, size);
		Console.WriteLine("Duplicate Found : " + value);
	}

	public static void printParenthesisNumber(string expn, int size)
	{
		char ch;
		Stack<int?> stk = new Stack<int?>();
		string output = "";
		int count = 1;
		for (int i = 0; i < size; i++)
		{
			ch = expn[i];
			if (ch == '(')
			{
				stk.Push(count);
				output += count;
				count += 1;
			}
			else if (ch == ')')
			{
				output += stk.Pop();
			}
		}
		Console.WriteLine("Parenthesis Count ");
		Console.WriteLine(output);
	}

	public static void main13(string[] args)
	{
		string expn1 = "(((a+(b))+(c+d)))";
		string expn2 = "(((a+b))+c)(((";
		int size = expn1.Length;
		Console.WriteLine("Given expn " + expn1);
		printParenthesisNumber(expn1, size);
		size = expn2.Length;
		Console.WriteLine("\nGiven expn " + expn2);
		printParenthesisNumber(expn2, size);
	}

	public static void nextLargerElement(int[] arr, int size)
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
	}

	public static void nextLargerElement2(int[] arr, int size)
	{
		Stack<int?> stk = new Stack<int?>();
		// output = [-1] * size;
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
		// index which dont have any next Larger.
		while (stk.Count > 0)
		{
			index = stk.Pop();
			output[index] = -1;
		}
		foreach (int val in output)
		{
			Console.Write(val + " ");
		}
	}

	public static void nextSmallerElement(int[] arr, int size)
	{
		Stack<int?> stk = new Stack<int?>();
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
		// index which dont have any next Smaller.
		while (stk.Count > 0)
		{
			index = stk.Pop();
			output[index] = -1;
		}
		foreach (int val in output)
		{
			Console.Write(val + " ");
		}
	}

	public static void main14(string[] args)
	{
		int[] arr = new int[] { 13, 21, 3, 6, 20, 3 };
		int size = arr.Length;
		nextLargerElement(arr, size);
		nextLargerElement2(arr, size);
		nextSmallerElement(arr, size);
	}

	public static void nextLargerElementCircular(int[] arr, int size)
	{
		Stack<int?> stk = new Stack<int?>();
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
		// index which dont have any next Larger.
		while (stk.Count > 0)
		{
			index = stk.Pop();
			output[index] = -1;
		}
		foreach (int val in output)
		{
			Console.Write(val + " ");
		}
	}

	public static void main15(string[] args)
	{
		int[] arr = new int[] { 6, 3, 9, 8, 10, 2, 1, 15, 7 };
		int size = arr.Length;
		nextLargerElementCircular(arr, size);
	}

	public static void RottenFruitUtil(int[][] arr, int maxCol, int maxRow, int currCol, int currRow, int[][] traversed, int day)
	{ // Range check
		if (currCol < 0 || currCol >= maxCol || currRow < 0 || currRow >= maxRow)
		{
			return;
		}
		// Traversable and rot if not already rotten.
		if (traversed[currCol][currRow] <= day || arr[currCol][currRow] == 0)
		{
			return;
		}
		// Update rot time.
		traversed[currCol][currRow] = day;
		// each line corresponding to 4 direction.
		RottenFruitUtil(arr, maxCol, maxRow, currCol - 1, currRow, traversed, day + 1);
		RottenFruitUtil(arr, maxCol, maxRow, currCol + 1, currRow, traversed, day + 1);
		RottenFruitUtil(arr, maxCol, maxRow, currCol, currRow + 1, traversed, day + 1);
		RottenFruitUtil(arr, maxCol, maxRow, currCol, currRow - 1, traversed, day + 1);
	}

	public static int RottenFruit(int[][] arr, int maxCol, int maxRow)
	{
		//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class 
		//reproduces the rectangular array initialization that is automatic in Java:
		//ORIGINAL LINE: int[][] traversed = new int[maxCol][maxRow];
		int[][] traversed = RectangularArrays.ReturnRectangularIntArray(maxCol, maxRow);
		for (int i = 0; i < maxCol; i++)
		{
			for (int j = 0; j < maxRow; j++)
			{
				traversed[i][j] = int.MaxValue;
			}
		}

		for (int i = 0; i < maxCol - 1; i++)
		{
			for (int j = 0; j < maxRow - 1; j++)
			{
				if (arr[i][j] == 2)
				{
					RottenFruitUtil(arr, maxCol, maxRow, i, j, traversed, 0);
				}
			}
		}

		int maxDay = 0;
		for (int i = 0; i < maxCol - 1; i++)
		{
			for (int j = 0; j < maxRow - 1; j++)
			{
				if (arr[i][j] == 1)
				{
					if (traversed[i][j] == int.MaxValue)
					{
						return -1;
					}
					if (maxDay < traversed[i][j])
					{
						maxDay = traversed[i][j];
					}
				}
			}
		}
		return maxDay;
	}

	public static void main16(string[] args)
	{
		int[][] arr = new int[][]
		{
			new int[] {1, 0, 1, 1, 0},
			new int[] {2, 1, 0, 1, 0},
			new int[] {0, 0, 0, 2, 1},
			new int[] {0, 2, 0, 0, 1},
			new int[] {1, 1, 0, 0, 1}
		};
		Console.WriteLine(RottenFruit(arr, 5, 5));
	}

	public static void StepsOfKnightUtil(int size, int currCol, int currRow, int[][] traversed, int dist)
	{
		// Range check
		if (currCol < 0 || currCol >= size || currRow < 0 || currRow >= size)
		{
			return;
		}

		// Traversable and rot if not already rotten.
		if (traversed[currCol][currRow] <= dist)
		{
			return;
		}

		// Update rot time.
		traversed[currCol][currRow] = dist;
		// each line corresponding to 4 direction.
		StepsOfKnightUtil(size, currCol - 2, currRow - 1, traversed, dist + 1);
		StepsOfKnightUtil(size, currCol - 2, currRow + 1, traversed, dist + 1);
		StepsOfKnightUtil(size, currCol + 2, currRow - 1, traversed, dist + 1);
		StepsOfKnightUtil(size, currCol + 2, currRow + 1, traversed, dist + 1);
		StepsOfKnightUtil(size, currCol - 1, currRow - 2, traversed, dist + 1);
		StepsOfKnightUtil(size, currCol + 1, currRow - 2, traversed, dist + 1);
		StepsOfKnightUtil(size, currCol - 1, currRow + 2, traversed, dist + 1);
		StepsOfKnightUtil(size, currCol + 1, currRow + 2, traversed, dist + 1);
	}

	public static int StepsOfKnight(int size, int srcX, int srcY, int dstX, int dstY)
	{
		//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper
		// class reproduces the rectangular array initialization that is automatic in Java:
		//ORIGINAL LINE: int[][] traversed = new int[size][size];
		int[][] traversed = RectangularArrays.ReturnRectangularIntArray(size, size);
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				traversed[i][j] = int.MaxValue;
			}
		}

		StepsOfKnightUtil(size, srcX - 1, srcY - 1, traversed, 0);
		int retval = traversed[dstX - 1][dstY - 1];
		return retval;
	}

	public static void main17(string[] args)
	{
		Console.WriteLine(StepsOfKnight(20, 10, 10, 20, 20));
	}

	public static void DistNearestFillUtil(int[][] arr, int maxCol, int maxRow, int currCol, int currRow, int[][] traversed, int dist)
	{ // Range check
		if (currCol < 0 || currCol >= maxCol || currRow < 0 || currRow >= maxRow)
		{
			return;
		}
		// Traversable if their is a better distance.
		if (traversed[currCol][currRow] <= dist)
		{
			return;
		}
		// Update distance.
		traversed[currCol][currRow] = dist;
		// each line corresponding to 4 direction.
		DistNearestFillUtil(arr, maxCol, maxRow, currCol - 1, currRow, traversed, dist + 1);
		DistNearestFillUtil(arr, maxCol, maxRow, currCol + 1, currRow, traversed, dist + 1);
		DistNearestFillUtil(arr, maxCol, maxRow, currCol, currRow + 1, traversed, dist + 1);
		DistNearestFillUtil(arr, maxCol, maxRow, currCol, currRow - 1, traversed, dist + 1);
	}

	public static void DistNearestFill(int[][] arr, int maxCol, int maxRow)
	{
		//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
		//ORIGINAL LINE: int[][] traversed = new int[maxCol][maxRow];
		int[][] traversed = RectangularArrays.ReturnRectangularIntArray(maxCol, maxRow);
		for (int i = 0; i < maxCol; i++)
		{
			for (int j = 0; j < maxRow; j++)
			{
				traversed[i][j] = int.MaxValue;
			}
		}
		for (int i = 0; i < maxCol; i++)
		{
			for (int j = 0; j < maxRow; j++)
			{
				if (arr[i][j] == 1)
				{
					DistNearestFillUtil(arr, maxCol, maxRow, i, j, traversed, 0);
				}
			}
		}

		for (int i = 0; i < maxCol; i++)
		{
			for (int j = 0; j < maxRow; j++)
			{
				Console.WriteLine("" + traversed[i][j]);
			}
			Console.WriteLine("\n");
		}
	}

	public static void main18(string[] args)
	{
		int[][] arr = new int[][]
		{
			new int[] {1, 0, 1, 1, 0},
			new int[] {1, 1, 0, 1, 0},
			new int[] {0, 0, 0, 0, 1},
			new int[] {0, 0, 0, 0, 1},
			new int[] {0, 0, 0, 0, 1}
		};
		DistNearestFill(arr, 5, 5);
	}

	public static int findLargestIslandUtil(int[][] arr, int maxCol, int maxRow, int currCol, int currRow, int value, int[][] traversed)
	{
		if (currCol < 0 || currCol >= maxCol || currRow < 0 || currRow >= maxRow)
		{
			return 0;
		}
		if (traversed[currCol][currRow] == 1 || arr[currCol][currRow] != value)
		{
			return 0;
		}
		traversed[currCol][currRow] = 1;
		// each call corresponding to 8 direction.
		return 1 + findLargestIslandUtil(arr, maxCol, maxRow, currCol - 1, currRow - 1, value, traversed) + findLargestIslandUtil(arr, maxCol, maxRow, currCol - 1, currRow, value, traversed) + findLargestIslandUtil(arr, maxCol, maxRow, currCol - 1, currRow + 1, value, traversed) + findLargestIslandUtil(arr, maxCol, maxRow, currCol, currRow - 1, value, traversed) + findLargestIslandUtil(arr, maxCol, maxRow, currCol, currRow + 1, value, traversed) + findLargestIslandUtil(arr, maxCol, maxRow, currCol + 1, currRow - 1, value, traversed) + findLargestIslandUtil(arr, maxCol, maxRow, currCol + 1, currRow, value, traversed) + findLargestIslandUtil(arr, maxCol, maxRow, currCol + 1, currRow + 1, value, traversed);
	}

	public static int findLargestIsland(int[][] arr, int maxCol, int maxRow)
	{
		int maxVal = 0;
		int currVal = 0;
		//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' 
		// helper class reproduces the rectangular array initialization that is automatic in Java:
		//ORIGINAL LINE: int[][] traversed = new int[maxCol][maxRow];
		int[][] traversed = RectangularArrays.ReturnRectangularIntArray(maxCol, maxRow);
		for (int i = 0; i < maxCol; i++)
		{
			for (int j = 0; j < maxRow; j++)
			{
				traversed[i][j] = int.MaxValue;
			}
		}
		for (int i = 0; i < maxCol; i++)
		{
			for (int j = 0; j < maxRow; j++)
			{
				{
					currVal = findLargestIslandUtil(arr, maxCol, maxRow, i, j, arr[i][j], traversed);
					if (currVal > maxVal)
					{
						maxVal = currVal;
					}
				}
			}
		}
		return maxVal;
	}

	public static void main19(string[] args)
	{
		int[][] arr = new int[][]
		{
			new int[] {1, 0, 1, 1, 0},
			new int[] {1, 0, 0, 1, 0},
			new int[] {0, 1, 1, 1, 1},
			new int[] {0, 1, 0, 0, 0},
			new int[] {1, 1, 0, 0, 1}
		};
		Console.WriteLine("Largest Island : " + findLargestIsland(arr, 5, 5));
	}

	public static bool isKnown(int[][] relation, int a, int b)
	{
		if (relation[a][b] == 1)
		{
			return true;
		}
		return false;
	}

	public static int findCelebrity(int[][] relation, int count)
	{
		Stack<int?> stk = new Stack<int?>();
		int first = 0, second = 0;
		for (int i = 0; i < count; i++)
		{
			stk.Push(i);
		}
		first = stk.Pop();
		while (stk.Count != 0)
		{
			second = stk.Pop();
			if (isKnown(relation, first, second))
			{
				first = second;
			}
		}
		for (int i = 0; i < count; i++)
		{
			if (first != i && isKnown(relation, first, i))
			{
				return -1;
			}
			if (first != i && isKnown(relation, i, first) == false)
			{
				return -1;
			}
		}
		return first;
	}

	public static int findCelebrity2(int[][] relation, int count)
	{
		int first = 0;
		int second = 1;

		for (int i = 0; i < (count - 1); i++)
		{
			if (isKnown(relation, first, second))
			{
				first = second;
			}
			second = second + 1;
		}
		for (int i = 0; i < count; i++)
		{
			if (first != i && isKnown(relation, first, i))
			{
				return -1;
			}
			if (first != i && isKnown(relation, i, first) == false)
			{
				return -1;
			}
		}
		return first;
	}

	public static void main20(string[] args)
	{
		int[][] arr = new int[][]
		{
			new int[] {1, 0, 1, 1, 0},
			new int[] {1, 0, 0, 1, 0},
			new int[] {0, 0, 1, 1, 1},
			new int[] {0, 0, 0, 0, 0},
			new int[] {1, 1, 0, 1, 1}
		};

		Console.WriteLine("Celebrity : " + findCelebrity(arr, 5));
		Console.WriteLine("Celebrity : " + findCelebrity2(arr, 5));
	}

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
}
