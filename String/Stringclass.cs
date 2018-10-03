using System;

public class Stringclass
{

	public Stringclass()
	{
		//string text = "Hello, World!";

		string str1 = "hello";
		string str2 = "hello";
		string str3 = "Hello";

		Console.WriteLine("str1 equals str2 :" + str1.Equals(str2));
		Console.WriteLine("str1 equals str3 :" + str1.Equals(str3));

	}

	internal virtual void demo()
	{
		string str1 = "hello";
		string str2 = "hello";
		string str3 = "Hello";

		Console.WriteLine("str1 equals str2 :" + str1.Equals(str2));
		Console.WriteLine("str1 equals str3 :" + str1.Equals(str3));

	}


	internal virtual void demo2()
	{
		//string str;
		string text = "Hello, World!";
		Console.WriteLine(text[7]);

		char[] array = text.ToCharArray();

		Console.WriteLine(text[7]);

		char[] arr = new char[] { 'H', 'e', 'l', 'l', 'o', ',', ' ', 'W', 'o', 'r', 'l', 'd', '!' };


		string hello = new string(arr);

		string first = "Hello, ";
		string second = "World!";
		//String helloworld = first + second;
		string helloworld = first + second;

	}
}
