using System;

internal class Bulb2
{
	//Class Variables 
	private static int TotalBulbCount = 0;

	//Instance Variables 
	private bool isOn = false;

	//Constructor
	public Bulb2()
	{
		TotalBulbCount++;
	}

	//Class Method
	public static int BulbCount
	{
		get
		{
			return TotalBulbCount;
		}
	}

	//Instance Method
	public virtual void turnOn()
	{
		isOn = true;
	}

	//Instance Method
	public virtual void turnOff()
	{
		isOn = false;
	}
	//Instance Method
	public virtual bool IsOn
	{
		get
		{
			return isOn;
		}
	}
}



public class BulbDemo
{
	public static void Main(string[] args)
	{
		Bulb2 b = new Bulb2();
		Bulb2 c = new Bulb2();
		Console.WriteLine("Bulb Count :" + Bulb2.BulbCount);
	}
}


const double PI = 3.141592653589793;
const string text = "Hello, World!";

internal class Bulb3
{
	internal enum BulbSize { SMALL, MEDIUM, LARGE }  //Enums
	internal BulbSize size;
	//Other bulb class fields and methods.
}


public class BulbDemo3
{
	public static void Main(string[] args)
	{
		Bulb3 b = new Bulb3();
		b.size = Bulb3.BulbSize.MEDIUM;
		Console.WriteLine("Bulb Size :" + b.size);
	}
}















