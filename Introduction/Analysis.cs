using System;

public class Analysis
{

	public int Fun1(int n)
	{
		int m = 0;
		for (int i = 0; i < n; i++)
		{
			m += 1;
		}
		return m;
	}

	public int Fun2(int n)
	{
		int i, j, m = 0;
		for (i = 0; i < n; i++)
		{
			for (j = 0; j < n; j++)
			{
				m += 1;
			}
		}
		return m;
	}

	public int Fun3(int n)
	{
		int i, j, m = 0;
		for (i = 0; i < n; i++)
		{
			for (j = 0; j < i; j++)
			{
				m += 1;
			}
		}
		return m;
	}

	public int Fun4(int n)
	{
		int i, m = 0;
		i = 1;
		while (i < n)
		{
			m += 1;
			i = i * 2;
		}
		return m;
	}

	public int Fun5(int n)
	{
		int i, m = 0;
		i = n;
		while (i > 0)
		{
			m += 1;
			i = i / 2;
		}
		return m;
	}

	public int Fun6(int n)
	{
		int i, j, k, m = 0;
		for (i = 0; i < n; i++)
		{
			for (j = 0; j < n; j++)
			{
				for (k = 0; k < n; k++)
				{
					m += 1;
				}
			}
		}
		return m;
	}

	public int Fun7(int n)
	{
		int i, j, k, m = 0;
		for (i = 0; i < n; i++)
		{
			for (j = 0; j < n; j++)
			{
				m += 1;
			}
		}
		for (i = 0; i < n; i++)
		{
			for (k = 0; k < n; k++)
			{
				m += 1;
			}
		}
		return m;
	}

	public int Fun8(int n)
	{
		int i, j, m = 0;
		for (i = 0; i < n; i++)
		{
			for (j = 0; j < Math.Sqrt(n); j++)
			{
				m += 1;
			}
		}
		return m;
	}

	public int Fun9(int n)
	{
		int i, j, m = 0;
		for (i = n; i > 0; i /= 2)
		{
			for (j = 0; j < i; j++)
			{
				m += 1;
			}
		}
		return m;
	}

	public int Fun10(int n)
	{
		int i, j, m = 0;
		for (i = 0; i < n; i++)
		{
			for (j = i; j > 0; j--)
			{
				m += 1;
			}
		}
		return m;
	}

	public int Fun11(int n)
	{
		int i, j, k, m = 0;
		for (i = 0; i < n; i++)
		{
			for (j = i; j < n; j++)
			{
				for (k = j + 1; k < n; k++)
				{
					m += 1;
				}
			}
		}
		return m;
	}

	public int Fun12(int n)
	{
		int i = 0, j = 0, m = 0;
		for (i = 0; i < n; i++)
		{
			for (; j < n; j++)
			{
				m += 1;
			}
		}
		return m;
	}

	public int Fun13(int n)
	{
		int i, j = 0, m = 0;
		for (i = 1; i <= n; i *= 2)
		{
			for (j = 0; j <= i; j++)
			{
				m += 1;
			}
		}
		return m;
	}

	public static void Main(string[] args)
	{
		Analysis a = new Analysis();
		Console.WriteLine("N = 100, Number of instructions in O(n)::" + a.Fun1(100));
		Console.WriteLine("N = 100, Number of instructions in O(n^2)::" + a.Fun2(100));
		Console.WriteLine("N = 100, Number of instructions in O(n^2)::" + a.Fun3(100));
		Console.WriteLine("N = 100, Number of instructions in O(log(n))::" + a.Fun4(100));
		Console.WriteLine("N = 100, Number of instructions in O(log(n))::" + a.Fun5(100));
		Console.WriteLine("N = 100, Number of instructions in O(n^3)::" + a.Fun6(100));
		Console.WriteLine("N = 100, Number of instructions in O(n^2)::" + a.Fun7(100));
		Console.WriteLine("N = 100, Number of instructions in O(n^(3/2))::" + a.Fun8(100));
		Console.WriteLine("N = 100, Number of instructions in O(n)::" + a.Fun9(100));
		Console.WriteLine("N = 100, Number of instructions in O(n^2)::" + a.Fun10(100));
		Console.WriteLine("N = 100, Number of instructions in O(n^3)::" + a.Fun11(100));
		Console.WriteLine("N = 100, Number of instructions in O(n)::" + a.Fun12(100));
		Console.WriteLine("N = 100, Number of instructions in O(n)::" + a.Fun13(100));
 }
}

/*
N = 100, Number of instructions in O(n)::100
N = 100, Number of instructions in O(n^2)::10000
N = 100, Number of instructions in O(n^2)::4950
N = 100, Number of instructions in O(log(n))::7
N = 100, Number of instructions in O(log(n))::7
N = 100, Number of instructions in O(n^3)::1000000
N = 100, Number of instructions in O(n^2)::20000
N = 100, Number of instructions in O(n^(3/2))::1000
N = 100, Number of instructions in O(n)::197
N = 100, Number of instructions in O(n^2)::4950
N = 100, Number of instructions in O(n^3)::166650
N = 100, Number of instructions in O(n)::100
N = 100, Number of instructions in O(n)::134
*/