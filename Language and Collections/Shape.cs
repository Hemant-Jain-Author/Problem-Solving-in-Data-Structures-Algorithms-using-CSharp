using System;

//Abstract Class
public abstract class Shape
{
	//Abstract Method
	public abstract double area();

	//Abstract Method
	public abstract double perimeter();
}

public class Rectangle : Shape
{

	private double width, length;

	public Rectangle() : this(1, 1)
	{
	}

	public Rectangle(double w, double l)
	{
		width = w;
		length = l;
	}

	public virtual double Width
	{
		set
		{
			width = value;
		}
	}

	public virtual double Length
	{
		set
		{
			length = value;
		}
	}

	public override double area()
	{
		// Area = width * length
		return width * length;
	}

	public override double perimeter()
	{
		// Perimeter = 2(width + length)
		return 2 * (width + length);
	}
}

public class Circle : Shape
{
	private double radius;

	public Circle() : this(1)
	{
	}

	public Circle(double r)
	{
		radius = r;
	}

	public virtual double Radius
	{
		set
		{
			radius = value;
		}
	}

	public override double area()
	{
		// Area = πr^2
		return Math.PI * Math.Pow(radius, 2);
	}

	public override double perimeter()
	{
		// Perimeter = 2πr
		return 2 * Math.PI * radius;
	}
}

public class ShapeDemo
{
	public static void Main(string[] args)
	{

		double width = 2, length = 3;
		Shape rectangle = new Rectangle(width, length);
		Console.WriteLine("Rectangle width: " + width + " and length: " + length + " Area: " + rectangle.area() + " Perimeter: " + rectangle.perimeter());

		double radius = 10;
		Shape circle = new Circle(radius);
		Console.WriteLine("Circle radius: " + radius + " Area: " + circle.area() + " Perimeter: " + circle.perimeter());

	}
}
