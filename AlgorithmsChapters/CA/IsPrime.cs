using System;

public class IsPrime
{
    public static bool TestPrime(int n)
    {
        bool answer = (n > 1) ? true : false;
        for (int i = 2; i * i <= n; ++i)
        {
            if (n % i == 0)
            {
                answer = false;
                break;
            }
        }
        return answer;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(IsPrime.TestPrime(7));
    }
}
// True