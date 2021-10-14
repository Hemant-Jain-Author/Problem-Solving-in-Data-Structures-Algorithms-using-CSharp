using System;

public class Stringclass
{

	public static void Main(string[] args)
	{
		string str1 = "hello";
		string str2 = "hello";
		string str3 = "Hello";
		Console.WriteLine("str1 equals str2 :" + str1.Equals(str2));
		Console.WriteLine("str1 equals str3 :" + str1.Equals(str3));

	}
}
/*
str1 equals str2 :True
str1 equals str3 :False
*/
