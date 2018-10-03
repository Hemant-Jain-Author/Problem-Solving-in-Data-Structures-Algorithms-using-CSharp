using System;

public class StringAlgo
{
	public static bool matchExpUtil(char[] exp, char[] str, int i, int j)
	{
		if (i == exp.Length && j == str.Length)
		{
			return true;
		}
		if ((i == exp.Length && j != str.Length) || (i != exp.Length && j == str.Length))
		{
			return false;
		}
		if (exp[i] == '?' || exp[i] == str[j])
		{
			return matchExpUtil(exp, str, i + 1, j + 1);
		}
		if (exp[i] == '*')
		{
			return matchExpUtil(exp, str, i + 1, j) || matchExpUtil(exp, str, i, j + 1) || matchExpUtil(exp, str, i + 1, j + 1);
		}
		return false;
	}

	public static bool matchExp(string exp, string str)
	{
		return matchExpUtil(exp.ToCharArray(), str.ToCharArray(), 0, 0);
	}

	public static void main1()
	{
		Console.WriteLine(matchExp("*llo,?World?", "Hello, World!"));
	}

	public static bool match(string src, string ptn)
	{
		char[] source = src.ToCharArray();
		char[] pattern = ptn.ToCharArray();
		int iSource = 0;
		int iPattern = 0;
		int sourceLen = source.Length;
		int patternLen = pattern.Length;
		for (iSource = 0; iSource < sourceLen; iSource++)
		{
			if (source[iSource] == pattern[iPattern])
				iPattern++;

			if (iPattern == patternLen)
				return true;
		}
		return false;
	}

	public static void main2()
	{
		Console.WriteLine(match("harrypottermustnotgotoschool", "pottergo"));
	}

	public static char[] myStrdup(char[] src)
	{
		int index = 0;
		char[] dst = new char[src.Length];
		foreach (char ch in src)
		{
			dst[index] = ch;
		}
		return dst;
	}

	public static bool isPrime(int n)
	{
		bool answer = (n > 1) ? true : false;
		for (int i = 2; i * i < n; ++i)
		{
			if (n % i == 0)
			{
				answer = false;
				break;
			}
		}
		return answer;
	}

	public static void main3()
	{
		Console.Write("Prime numbers under 100 :: ");
		for (int i = 0; i < 100; i++)
		{
			if (isPrime(i))
			{
				Console.Write(i + " ");
			}
		}
		Console.WriteLine();
	}

	public static int myAtoi(string str)
	{
		int value = 0;
		int size = str.Length;
		for (int i = 0; i < size; i++)
		{
			char ch = str[i];
			value = (value << 3) + (value << 1) + (ch - '0');
		}
		return value;
	}

	public static void main4()
	{
		Console.WriteLine(myAtoi("1000"));
	}

	public static bool isUniqueChar(string str)
	{
		int[] bitarr = new int[26];
		int index;
		for (int i = 0; i < 26; i++)
		{
			bitarr[i] = 0;
		}
		int size = str.Length;
		for (int i = 0; i < size; i++)
		{
			char c = str[i];
			if ('A' <= c && 'Z' >= c)
			{
				index = (c - 'A');
			}
			else if ('a' <= c && 'z' >= c)
			{
				index = (c - 'a');
			}
			else
			{
				Console.WriteLine("Unknown Char!\n");
				return false;
			}
			if (bitarr[index] != 0)
			{
				Console.WriteLine("Duplicate detected!");
				return false;
			}
			bitarr[index] += 1;
		}
		Console.WriteLine("No duplicate detected!");
		return true;
	}

	public static void main5()
	{
		Console.WriteLine(isUniqueChar("aple"));
		Console.WriteLine(isUniqueChar("apple"));
	}

	public static char ToUpper(char s)
	{
		if (s >= 97 && s <= (97 + 25))
		{
			s = (char)(s - 32);
		}
		return s;
	}

	public static char ToLower(char s)
	{
		if (s >= 65 && s <= (65 + 25))
		{
			s = (char)(s + 32);
		}
		return s;
	}

	public static char LowerUpper(char s)
	{
		if (s >= 97 && s <= (97 + 25))
		{
			s = (char)(s - 32);
		}
		else if (s >= 65 && s <= (65 + 25))
		{
			s = (char)(s + 32);
		}
		return s;
	}

	public static void main6()
	{
		Console.WriteLine(ToLower('A'));
		Console.WriteLine(ToUpper('a'));
		Console.WriteLine(LowerUpper('s'));
		Console.WriteLine(LowerUpper('S'));
	}

	public static bool isPermutation(string s1, string s2)
	{
		int[] count = new int[256];
		int length = s1.Length;
		if (s2.Length != length)
		{
			Console.WriteLine("is permutation return false\n");
			return false;
		}
		for (int i = 0; i < 256; i++)
		{
			count[i] = 0;
		}
		for (int i = 0; i < length; i++)
		{
			char ch = s1[i];
			count[ch]++;
			ch = s2[i];
			count[ch]--;
		}
		for (int i = 0; i < length; i++)
		{
			if (count[i] != 0)
			{
				Console.WriteLine("is permutation return false\n");
				return false;
			}
		}
		Console.WriteLine("is permutation return true\n");
		return true;
	}

	public static void main7()
	{
		Console.WriteLine(isPermutation("apple", "plepa"));
	}

	public static bool isPalindrome(string str)
	{
		int i = 0, j = str.Length - 1;
		while (i < j && str[i] == str[j])
		{
			i++;
			j--;
		}
		if (i < j)
		{
			Console.WriteLine("String is not a Palindrome");
			return false;
		}
		else
		{
			Console.WriteLine("String is a Palindrome");
			return true;
		}
	}

	public static void main8()
	{
		Console.WriteLine(isPalindrome("hello"));
		Console.WriteLine(isPalindrome("eoloe"));
	}

	public static int pow(int x, int n)
	{
		int value;
		if (n == 0)
		{
			return (1);
		}
		else if (n % 2 == 0)
		{
			value = pow(x, n / 2);
			return (value * value);
		}
		else
		{
			value = pow(x, n / 2);
			return (x * value * value);
		}
	}

	public static void main9()
	{
		Console.WriteLine(pow(5, 2));
	}

	public static int myStrcmp(string a, string b)
	{
		int index = 0;
		int len1 = a.Length;
		int len2 = b.Length;
		int minlen = len1;

		if (len1 > len2)
			minlen = len2;

		while (index < minlen && a[index] == b[index])
			index++;

		if (index == len1 && index == len2)
			return 0;
		else if (len1 == index)
			return -1;
		else if (len2 == index)
			return 1;
		else
			return a[index] - b[index];
	}

	public static void main10()
	{
		Console.WriteLine(myStrcmp("abs", "abs"));
	}

	public static string reverseString(string str)
	{
		char[] a = str.ToCharArray();
		reverseStringUtil(a);
		string expn = new string(a);
		return expn;
	}

	public static void reverseStringUtil(char[] a)
	{
		int lower = 0;
		int upper = a.Length - 1;
		char tempChar;
		while (lower < upper)
		{
			tempChar = a[lower];
			a[lower] = a[upper];
			a[upper] = tempChar;
			lower++;
			upper--;
		}
	}

	public static void reverseStringUtil(char[] a, int lower, int upper)
	{
		char tempChar;
		while (lower < upper)
		{
			tempChar = a[lower];
			a[lower] = a[upper];
			a[upper] = tempChar;
			lower++;
			upper--;
		}
	}

	public static string reverseWords(string str)
	{
		char[] a = str.ToCharArray();
		int length = a.Length;
		int lower = 0, upper = -1;
		for (int i = 0; i <= length; i++)
		{
			if (i == length || a[i] == ' ')
			{
				reverseStringUtil(a, lower, upper);
				lower = i + 1;
				upper = i;
			}
			else
			{
				upper++;
			}
		}
		reverseStringUtil(a, 0, length - 1);
		string expn = new string(a);
		return expn;
	}

	public static void main11()
	{
		Console.WriteLine(reverseString("apple"));
		Console.WriteLine(reverseWords("hello world"));
	}

	public static void printAnagram(string str)
	{
		char[] a = str.ToCharArray();
		int n = a.Length;
		printAnagram(a, n, n);
	}

	public static void printAnagram(char[] a, int max, int n)
	{
		if (max == 1)
			Console.WriteLine(a);

		char temp;
		for (int i = -1; i < max - 1; i++)
		{
			if (i != -1)
			{
				temp = a[i];
				a[i] = a[max - 1];
				a[max - 1] = temp;
			}
			printAnagram(a, max - 1, n);
			if (i != -1)
			{
				temp = a[i];
				a[i] = a[max - 1];
				a[max - 1] = temp;
			}
		}
	}

	public static void main12()
	{
		printAnagram("123");
	}

	public static string shuffle(string str)
	{
		char[] ar = str.ToCharArray();
		int n = ar.Length / 2;
		int count = 0;
		int k = 1;
		char temp = '\0';
		for (int i = 1; i < n; i = i + 2)
		{
			temp = ar[i];
			k = i;
			do
			{
				k = (2 * k) % (2 * n - 1);
				//Swap
				char temp2 = temp;
				temp = ar[k];
				ar[k] = temp2;

				count++;
			} while (i != k);

			if (count == (2 * n - 2))
				break;
		}
		string st = new string(ar);
		Console.WriteLine(st);
		return st;
	}

	public static void main13()
	{
		shuffle("ABCDE12345");
	}

	public static char[] addBinary(string firstStr, string secondStr)
	{
		char[] first = firstStr.ToCharArray();
		char[] second = secondStr.ToCharArray();
		int size1 = first.Length;
		int size2 = second.Length;
		int totalIndex;
		char[] total;
		if (size1 > size2)
		{
			total = new char[size1 + 2];
			totalIndex = size1;
		}
		else
		{
			total = new char[size2 + 2];
			totalIndex = size2;
		}
		total[totalIndex + 1] = '\0';
		int carry = 0;
		size1--;
		size2--;
		while (size1 >= 0 || size2 >= 0)
		{
			int firstValue = (size1 < 0) ? 0 : first[size1] - '0';
			int secondValue = (size2 < 0) ? 0 : second[size2] - '0';
			int sum = firstValue + secondValue + carry;
			carry = sum >> 1;
			sum = sum & 1;
			total[totalIndex] = (sum == 0) ? '0' : '1';
			totalIndex--;
			size1--;
			size2--;
		}
		total[totalIndex] = (carry == 0) ? '0' : '1';
		return total;
	}

	public static void main14()
	{
		Console.WriteLine(addBinary("1000", "11111111"));
	}

	public static void Main(string[] args)
	{
		main1();
		main2();
		main3();
		main4();
		main5();
		main6();
		main7();
		main8();
		main9();
		main10();
		main11();
		main12();
		main13();
		main14();
	}
}