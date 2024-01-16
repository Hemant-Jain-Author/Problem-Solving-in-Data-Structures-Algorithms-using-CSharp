using System;

public class MinMaxValueTest
{
    public static void Main(string[] args)
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

/* 
Range of byte :: -128 to 127.
Range of short :: -32768 to 32767.
Range of integer :: -2147483648 to 2147483647.
Range of long :: -9223372036854775808 to 9223372036854775807.
Range of float :: 1.401298E-45 to 3.402823E+38.
Range of double :: 4.94065645841247E-324 to 1.79769313486232E+308.
 */