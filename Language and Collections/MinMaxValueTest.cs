using System;

public class MinMaxValueTest
{

	public static void Main33(string[] args)
	{

		sbyte maxByte = sbyte.MaxValue;
		sbyte minByte = sbyte.MinValue;

		short maxShort = short.MaxValue;
		short minShort = short.MinValue;

		int maxInteger = int.MaxValue;
		int minInteger = int.MinValue;

		long maxLong = long.MaxValue;
		long minLong = long.MinValue;

		float maxFloat = float.MaxValue;
		float minFloat = float.Epsilon;

		double maxDouble = double.MaxValue;
		double minDouble = double.Epsilon;

		Console.WriteLine("Range of byte :: " + minByte + " to " + maxByte + ".");
		Console.WriteLine("Range of short :: " + minShort + " to " + maxShort + ".");
		Console.WriteLine("Range of integer :: " + minInteger + " to " + maxInteger + ".");
		Console.WriteLine("Range of long :: " + minLong + " to " + maxLong + ".");
		Console.WriteLine("Range of float :: " + minFloat + " to " + maxFloat + ".");
		Console.WriteLine("Range of double :: " + minDouble + " to " + maxDouble + ".");
	}
}