using System;

public class ForDemo
{

	private const string text = "Hello, World!";
	internal const double PI = 3.141592653589793;

	public static void Main1000(string[] args)
	{
        if (true)
        {
            // statements
        }

        if (true)
        {
            // if condition statements boolean condition true
        }
        else
        {
            // else condition statements, boolean condition false
        }
    }

    public static void Main1(string[] args)
    {
        int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
        }
        Console.WriteLine("Sum is :: " + sum);
    }


    public static void Main88(string[] args)
	{

		int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		int sum = 0;
		for (int i = 0; i < numbers.Length; i++)
		{
			sum += numbers[i];
		}

		Console.WriteLine("Sum is :: " + sum);
	}

	public static void Main3(string[] args)
	{

		int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		int sum = 0;
		int i = 0;
		while (i < numbers.Length)
		{
			sum += numbers[i];
			i++;
		}
		Console.WriteLine("Sum is :: " + sum);
	}


	//	String[] stra=new String[2];
	//	stra[0]="hello";
	//	stra[1]="hello";
	//	main2(stra);


}
