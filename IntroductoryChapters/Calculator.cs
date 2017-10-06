using System;

public class Calculator
{
	private int value;

	public Calculator()
	{
		value = 0;
	}

	public Calculator(int arr)
	{
		value = arr;
	}

	public virtual void reset()
	{
		value = 0;
	}
	public virtual int Value
	{
		get
		{
			return value;
		}
	}

	public virtual void add(int data)
	{
		value = value + data;
	}

	public virtual void increment()
	{
		value += 1;
	}

	public virtual void subtract(int data)
	{
		value = value - data;
	}

	public virtual void decrement()
	{
		value -= 1;
	}
}





//public HelloWorld() {
//}

//Calculator c;
//c = new Calculator();
//c.increment();
//c.increment();
//System.out.print("value stored in c is:");
//System.out.println(c.getValue());
//bedReset(c);
//System.out.print("value stored in c is:");
//System.out.println(c.getValue());
//goodReset(c);
//System.out.print("value stored in c is:");
//System.out.println(c.getValue());
//stringPrint("Hello, World!");
//stringPrint("Hello,"," World!");


//public static void bedReset(Calculator c){
//	c = new Calculator();
//}
//
//public static void goodReset(Calculator c){
//	c.reset();
//}
//
//public static void stringPrint(String s){
//	System.out.println(s);
//}
//
//public static void stringPrint(String s1, String s2){
//	String s= s1+s2;
//	System.out.println(s);
//}



