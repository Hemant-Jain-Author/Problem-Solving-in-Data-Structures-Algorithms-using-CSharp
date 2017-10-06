using System;

public class StringAlgo
{

	public bool matchExpUtil(char[] exp, char[] str, int i, int j)
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


	public bool matchExp(char[] exp, char[] str)
	{
		return matchExpUtil(exp, str, 0, 0);
	}

	public int match(char[] source, char[] pattern)
	{
		int iSource = 0;
		int iPattern = 0;
		int sourceLen = source.Length;
		int patternLen = pattern.Length;
		for (iSource = 0; iSource < sourceLen; iSource++)
		{
			if (source[iSource] == pattern[iPattern])
			{
				iPattern++;
			}
			if (iPattern == patternLen)
			{
				return 1;
			}
		}
		return 0;
	}

	public char[] myStrdup(char[] src)
	{
		int index = 0;
		char[] dst = new char[src.Length];
		foreach (char ch in src)
		{
			dst[index] = ch;
		}
		return dst;
	}


	bool isPrime(int n)
	{
		bool answer = (n > 1) ? true : false;

		for (int i = 2; i * i <= n; ++i)
		{
			if (n % i == 0)
			{
				answer = true;
				break;
			}
		}
		return answer;
	}



	public int myAtoi(string str)
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

	public bool isUniqueChar(string str)
	{
		int[] bitarr = new int[26];
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
				c = (char)(c - 'A');
			}
			else if ('a' <= c && 'z' >= c)
			{
				c = (char)(c - 'a');
			}
			else
			{
				Console.WriteLine("Unknown Char!\n");
				return false;
			}
			if (bitarr[c] != 0)
			{
				Console.WriteLine("Duplicate detected!\n");
				return false;
			}
		}
		Console.WriteLine("No duplicate detected!\n");
		return true;
	}

	public char ToUpper(char s)
	{
		if (s >= 97 && s <= (97 + 25))
		{
			s = (char)(s - 32);
		}
		return s;
	}

	public char ToLower(char s)
	{
		if (s >= 65 && s <= (65 + 25))
		{
			s = (char)(s + 32);
		}
		return s;
	}



	public char LowerUpper(char s)
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


	public bool isPermutation(string s1, string s2)
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

	public bool isPalindrome(string str)
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

	public int pow(int x, int n)
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

	public int myStrcmp(string a, string b)
	{
		int index = 0;
		int len1 = a.Length;
		int len2 = b.Length;
		int minlen = len1;
		if (len1 > len2)
		{
			minlen = len2;
		}

		while (index < minlen && a[index] == b[index])
		{
			index++;
		}

		if (index == len1 && index == len2)
		{
			return 0;
		}
		else if (len1 == index)
		{
			return -1;
		}
		else if (len2 == index)
		{
			return 1;
		}
		else
		{
			return a[index] - b[index];
		}
	}

	public void reverseString(char[] a)
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

	public void reverseString(char[] a, int lower, int upper)
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

	public void reverseWords(char[] a)
	{
		int length = a.Length;
		int lower, upper = -1;
		lower = 0;
		for (int i = 0; i <= length; i++)
		{
			if (a[i] == ' ' || a[i] == '\0')
			{
				reverseString(a, lower, upper);
				lower = i + 1;
				upper = i;
			}
			else
			{
				upper++;
			}
		}
		reverseString(a, 0, length - 1); //-1 because we do not want to reverse �\0�
	}

	public void printAnagram(char[] a)
	{
		int n = a.Length;
		printAnagram(a, 0, n);
	}
	public void printAnagram(char[] a, int max, int n)
	{
		if (max == 1)
		{
			Console.WriteLine(a.ToString());
		}
		for (int i = -1; i < max - 1; i++)
		{
			if (i != -1)
			{
				a[i] ^= a[max - 1] ^= a[i] ^= a[max - 1];
			}
			printAnagram(a, max - 1, n);
			if (i != -1)
			{
				a[i] ^= a[max - 1] ^= a[i] ^= a[max - 1];
			}
		}
	}

	public void shuffle(char[] ar, int n)
	{
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
				temp ^= ar[k] ^= temp ^= ar[k];
				count++;
			} while (i != k);
			if (count == (2 * n - 2))
			{
				break;
			}
		}
	}

	public char[] addBinary(char[] first, char[] second)
	{
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
}