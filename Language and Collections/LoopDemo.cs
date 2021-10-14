using System;

public class ForDemo
{

	internal const double PI = 3.141592653589793;

	public static void main1()
	{
		int[] numbers = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
		int sum = 0;
		foreach (int n in numbers)
		{
			sum += n;
		}

		Console.WriteLine("Sum is :: " + sum);
	}

	public static void main2()
	{
		int[] numbers = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
		int sum = 0;
		for (int i = 0; i < numbers.Length; i++)
		{
			sum += numbers[i];
		}

		Console.WriteLine("Sum is :: " + sum);
	}

	public static void main3()
	{
		int[] numbers = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
		int sum = 0;
		int i = 0;
		while (i < numbers.Length)
		{
			sum += numbers[i];
			i++;
		}
		Console.WriteLine("Sum is :: " + sum);
	}

	public static void Main(string[] args)
	{
		main1();
		main2();
		main3();
	}
}

/*
Sum is :: 55
Sum is :: 55
Sum is :: 55
*/