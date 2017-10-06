using System;


public class MyInt
{
	public int value;
}

public class Introduction2
{

	public static void increment(int var)
	{
		var++;
	}



	public static void Main66(string[] args)
	{
		int x = 10;
		Console.WriteLine("Value of i before increment is :  " + x);
		increment(x);
		Console.WriteLine("Value of i after increment is :  " + x);
	}

	public static void increment(MyInt value)
	{
		(value.value)++;
	}
	public static void Maineee(string[] args)
	{
		MyInt x = new MyInt();
		x.value = 10;
		Console.WriteLine("Value of i before increment is :  " + x.value);
		increment(x);
		Console.WriteLine("Value of i after increment is :  " + x.value);
	}



	public static void printArray(int[] arr, int count)
	{
		Console.Write("\n Values stored in array are : ");
		for (int i = 0; i < count; i++)
		{
			Console.Write(" " + arr[i]);
		}
	}

	public static void swap(int[] arr, int x, int y)
	{
		int temp = arr[x];
		arr[x] = arr[y];
		arr[y] = temp;
		return;
	}
	public static void permutation(int[] arr, int i, int length)
	{
		if (length == i)
		{
			printArray(arr, length);
			return;
		}
		int j = i;
		for (j = i; j < length; j++)
		{
			swap(arr, i, j);
			permutation(arr, i + 1, length);
			swap(arr, i, j);
		}
		return;
	}

	internal virtual void main12()
	{
		int[] arr = new int[5];
		for (int i = 0; i < 5; i++)
		{
			arr[i] = i;
		}
		permutation(arr, 0, 5);
	}


	public static void Main33(string[] args)
	{
		int[] arr = new int[5];
		for (int i = 0; i < 5; i++)
		{
			arr[i] = i;
		}
		permutation(arr, 0, 5);
	}

	public static int GCD(int m, int n)
	{
		if (m < n)
		{
			return (GCD(n, m));
		}
		if (m % n == 0)
		{
			return (n);
		}
		return (GCD(n, m % n));
	}


	public static void towerOfHanoi(int num, char src, char dst, char temp)
	{
		if (num < 1)
		{
			return;
		}

		towerOfHanoi(num - 1, src, temp, dst);
		Console.WriteLine("Move " + num + " disk  from peg " + src + " to peg " + dst);
		towerOfHanoi(num - 1, temp, dst, src);
	}


	public static void Main3443(string[] args)
	{
		int num = 4;
		Console.WriteLine("The sequence of moves involved in the Tower of Hanoi are :\n");
		towerOfHanoi(num, 'A', 'C', 'B');
	}

	//	System.out.println("main line 1");
	//	function1();
	//	System.out.println("main line 2");

	//		MyInt x = new MyInt();
	//		x.value = 10;
	//		System.out.println("Value of i before increment is :  " +  x.value);
	//		increment(x);
	//		System.out.println("Value of i before increment is :  " +  x.value);


	public static void function2()
	{
		Console.WriteLine("fun2 line 1");
	}

	public static void function1()
	{
		Console.WriteLine("fun1 line 1");
		function2();
		Console.WriteLine("fun1 line 2");
	}

	public static void main7()
	{
		Console.WriteLine("main line 1");
		function1();
		Console.WriteLine("main line 2");
	}


	//	public static void main(String[] args) {
	//		
	//		
	//		
	//		
	//		//int[] arr = {1,2,3,4,5,6, 7,8,9};
	//		//System.out.println("Max sub array sum : " + maxSubArraySum(arr, 9));
	//		//System.out.println("Max sub array sum : " + SumArray(arr));
	//		//System.out.println("Binary search : " );
	//		//reverseArray(arr);
	//		//System.out.println("Binary search : " + BinarySearch(arr,9,15));
	//		//printArray1(arr,9);
	//	}

	public static int maxSubArraySum(int[] a, int size)
	{
		int maxSoFar = 0, maxEndingHere = 0;

		for (int i = 0; i < size; i++)
		{
			maxEndingHere = maxEndingHere + a[i];
			if (maxEndingHere < 0)
			{
				maxEndingHere = 0;
			}
			if (maxSoFar < maxEndingHere)
			{
				maxSoFar = maxEndingHere;
			}
		}
		return maxSoFar;
	}

	internal static void variableExample()
	{
		int var1, var2, var3;
		var1 = 100;
		var2 = 200;
		var3 = var1 + var2;
		Console.WriteLine("Adding " + var1 + " and " + var2 + " will give " + var3);
	}

	public static void arrayExample()
	{
		int[] arr = new int[10];
		for (int i = 0; i < 10; i++)
		{
			arr[i] = i;
		}
		printArray1(arr, 10);
	}

	public static void printArray1(int[] arr, int count)
	{
		Console.WriteLine("Values stored in array are : ");
		for (int i = 0; i < count; i++)
		{
			Console.WriteLine(" " + arr[i]);
		}
	}

	public static void twoDArrayExample()
	{
		int[,] arr = new int[4, 2];
		int count = 0;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				arr[i, j] = count++;
			}
		}
		print2DArray(arr, 4, 2);
	}

	public static void print2DArray(int[,] arr, int row, int col)
	{
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				Console.WriteLine(" " + arr[i, j]);
			}
		}
	}

	public static int SumArray(int[] arr)
	{
		int size = arr.Length;
		int total = 0;
		int index = 0;
		for (index = 0; index < size; index++)
		{
			total = total + arr[index];
		}
		return total;
	}

	public static int SequentialSearch(int[] arr, int size, int value)
	{
		for (int i = 0; i < size; i++)
		{
			if (value == arr[i])
			{
				return i;
			}
		}
		return -1;
	}

	// Binary Search Algorithm � Iterative Way  
	public static int BinarySearch(int[] arr, int size, int value)
	{
		int mid;
		int low = 0;
		int high = size - 1;
		while (low <= high)
		{
			mid = low + (high - low) / 2; // To avoid the overflow
			if (arr[mid] == value)
			{
				return mid;
			}
			else if (arr[mid] < value)
			{
				low = mid + 1;
			}
			else
			{
				high = mid - 1;
			}
		}
		return -1;
	}

	public static void rotateArray(int[] a, int n, int k)
	{
		reverseArray(a, 0, k - 1);
		reverseArray(a, k, n - 1);
		reverseArray(a, 0, n - 1);
	}

	public static void reverseArray(int[] a, int start, int end)
	{
		for (int i = start, j = end; i < j; i++, j--)
		{
			int temp = a[i];
			a[i] = a[j];
			a[j] = temp;
		}
	}

	public static void reverseArray(int[] a)
	{
		int start = 0;
		int end = a.Length - 1;
		for (int i = start, j = end; i < j; i++, j--)
		{
			int temp = a[i];
			a[i] = a[j];
			a[j] = temp;
		}
	}

	internal class coord
	{
		internal int x;
		internal int y;
	}

	internal virtual int main2()
	{
		coord point = new coord();
		point.x = 10;
		point.y = 10;
		Console.WriteLine("X axis coord value is  " + point.x);
		Console.WriteLine("Y axis coord value is  " + point.y);
		return 0;
	}

	internal class student
	{

		internal int rollNo;
		internal string firstName;
		internal string lastName;
	}

	internal virtual int main3()
	{
		student stud = new student();
		student refStud;
		refStud = stud;
		refStud.rollNo = 1;
		refStud.firstName = "john";
		refStud.lastName = "smith";
		Console.WriteLine("Roll No:   Student Name:  " + refStud.rollNo + refStud.firstName + refStud.lastName);

		return 0;
	}

	// function declaration 
	internal virtual int main4()
	{
		// local variable definition 
		int x = 10;
		int y = 20;
		int result;
		// calling a function to find sum 
		result = sum(x, y);
		Console.WriteLine("Sum is : " + result);
		return 0;
	}

	// function returning the sum of two numbers 
	internal virtual int sum(int num1, int num2)
	{
		// local variable declaration 
		int result;
		result = num1 + num2;
		return result;
	}

	//	void increment(int var)
	//	{
	//		var++;
	//	}

	//	void main8()
	//	{
	//		int i = 10;
	//		System.out.println("Value of i before increment is :  " +  i);
	//		increment(i);
	//		System.out.println("Value of i before increment is :  " +  i);
	//	}

	//	void main9()
	//	{
	//		int i = 10;
	//		System.out.println("Value of i before increment is :  " +  i);
	//		increment(i);
	//		System.out.println("Value of i before increment is :  " +  i);
	//	}

	public static int factorial(int i)
	{
		// Termination Condition 
		if (i <= 1)
		{
			return 1;
		}
		// Body, Recursive Expansion 
		return i * factorial(i - 1);
	}

	public static void printInt1(int number)
	{
		char digit = (char)(number % 10 + '0');
		number = number / 10;
		if (number != 0)
		{
			printInt1(number / 10);
		}
		Console.Write("%c" + digit);
	}

	//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
	//ORIGINAL LINE: public static void printInt2(int number, final int super)
	public static void printInt2(int number, int baseValue)
	{
		string conversion = "0123456789ABCDEF";
		char digit = (char)(number % baseValue);
		number = number / baseValue;
		if (number != 0)
		{
			printInt2(number, baseValue);
		}
		Console.Write(" " + conversion[digit]);
	}

	//			char * intToStr(char *p, unsigned int number)
	//			{
	//				char digit = number % 10 + '0';
	//				if (number /= 10) 
	//					p = intToStr(p, number);
	//				*p++ = digit;
	//				return (p);
	//			}









	public static int fibonacci(int n)
	{
		if (n <= 1)
		{
			return n;
		}
		return fibonacci(n - 1) + fibonacci(n - 2);
	}




	// Binary Search Algorithm � Recursive Way 
	public static int BinarySearchRecursive(int[] arr, int low, int high, int value)
	{
		int mid = low + (high - low) / 2; // To avoid the overflow
		if (arr[mid] == value)
		{
			return mid;
		}
		else if (arr[mid] < value)
		{
			return BinarySearchRecursive(arr, mid + 1, high, value);
		}
		else
		{
			return BinarySearchRecursive(arr, low, mid - 1, value);
		}
	}


}