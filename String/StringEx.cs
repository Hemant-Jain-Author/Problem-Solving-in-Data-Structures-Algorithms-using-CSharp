using System;

public class StringEx
{
    public static bool Match(string src, string ptn)
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
            {
                iPattern++;
            }
            if (iPattern == patternLen)
            {
                return true;
            }
        }
        return false;
    }

    public static void Main2()
    {
        Console.WriteLine(Match("harrypottermustnotgotoschool", "pottergo"));
    }
    // True

    public static char[] MyStrdup(char[] src)
    {
        int index = 0;
        char[] dst = new char[src.Length];
        foreach (char ch in src)
        {
            dst[index] = ch;
        }
        return dst;
    }

    public static bool IsPrime(int n)
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

    public static void Main3()
    {
        Console.Write("Prime numbers under 10 :: ");
        for (int i = 0; i < 10; i++)
        {
            if (IsPrime(i))
            {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();
    }
    // Prime numbers under 10 :: 2 3 5 7 

    public static int MyAtoi(string str)
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

    public static void Main4()
    {
        Console.WriteLine(MyAtoi("1000"));
    }
    // 1000

    public static bool IsUniqueChar(string str)
    {
        bool[] bitarr = new bool[26];
        for (int i = 0; i < 26; i++)
        {
            bitarr[i] = false;
        }
        int index;

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
            if (bitarr[index])
            {
                Console.WriteLine("Duplicate detected!");
                return false;
            }
            bitarr[index] = true;
        }
        Console.WriteLine("No duplicate detected!");
        return true;
    }

    public static void Main5()
    {
        IsUniqueChar("aple");
        IsUniqueChar("apple");
    }
    /*
    No duplicate detected!
    Duplicate detected!
    */
    public static char ToUpper(char s)
    {
        if (s >= (char)97 && s <= (char)(97 + 25))
        {
            s = (char)(s - 32);
        }
        return s;
    }

    public static char ToLower(char s)
    {
        if (s >= (char)65 && s <= (char)(65 + 25))
        {
            s = (char)(s + 32);
        }
        return s;
    }

    public static char LowerUpper(char s)
    {
        if (s >= (char)97 && s <= (char)(97 + 25))
        {
            s = (char)(s - 32);
        }
        else if (s >= (char)65 && s <= (char)(65 + 25))
        {
            s = (char)(s + 32);
        }
        return s;
    }

    public static void Main6()
    {
        Console.WriteLine(ToLower('A'));
        Console.WriteLine(ToUpper('a'));
        Console.WriteLine(LowerUpper('s'));
        Console.WriteLine(LowerUpper('S'));
    }
    /*
    a
    A
    S
    s
    */

    public static bool IsPermutation(string s1, string s2)
    {
        int[] count = new int[256];
        int length = s1.Length;
        if (s2.Length != length)
        {
            Console.WriteLine("is permutation return false");
            return false;
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
                Console.WriteLine("Strings are not permutation.");
                return false;
            }
        }
        Console.WriteLine("Strings are permutation.");
        return true;
    }

    public static void Main7()
    {
        Console.WriteLine(IsPermutation("apple", "plepa"));
    }
    /*
    Strings are permutation.
    True
    */

    public static bool IsPalindrome(string str)
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

    public static void Main8()
    {
        IsPalindrome("hello");
        IsPalindrome("oyo");
    }
    /*
    String is not a Palindrome
    String is a Palindrome
    */
    
    public static int Pow(int x, int n)
    {
        int value;
        if (n == 0)
        {
            return (1);
        }
        else if (n % 2 == 0)
        {
            value = Pow(x, n / 2);
            return (value * value);
        }
        else
        {
            value = Pow(x, n / 2);
            return (x * value * value);
        }
    }

    public static void Main9()
    {
        Console.WriteLine(Pow(5, 2));
    }
    // 25

    public static int MyStrcmp(string a, string b)
    {
        int index = 0;
        int len1 = a.Length;
        int len2 = b.Length;
        int minlen = (len1 < len2)? len1 : len2;

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

    public static void Main10()
    {
        Console.WriteLine(MyStrcmp("abs", "abs"));
    }
    // 0

    public static string ReverseString(string str)
    {
        char[] a = str.ToCharArray();
        ReverseStringUtil(a);
        string expn = new string(a);
        return expn;
    }

    public static void ReverseStringUtil(char[] a)
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

    public static void ReverseStringUtil(char[] a, int lower, int upper)
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

    public static string ReverseWords(string str)
    {
        char[] a = str.ToCharArray();
        int length = a.Length;
        int lower = 0, upper = -1;
        for (int i = 0; i <= length; i++)
        {
            if (i == length || a[i] == ' ')
            {
                ReverseStringUtil(a, lower, upper);
                lower = i + 1;
                upper = i;
            }
            else
            {
                upper++;
            }
        }
        ReverseStringUtil(a, 0, length - 1);
        string expn = new string(a);
        return expn;
    }

    public static void Main11()
    {
        Console.WriteLine(ReverseString("apple"));
        Console.WriteLine(ReverseWords("hello world"));
    }
    /*
    elppa
    world hello
    */
    public static void PrintAnagram(string str)
    {
        PrintAnagram(str.ToCharArray(), 0, str.Length);
    }

    public static void PrintAnagram(char[] arr, int i, int length)
    {
        if (length == i)
        {
            PrintArray(arr, length);
            return;
        }

        for (int j = i; j < length; j++)
        {
            Swap(arr, i, j);
            PrintAnagram(arr, i + 1, length);
            Swap(arr, i, j);
        }
        return;
    }

    private static void PrintArray(char[] arr, int n)
    {
        for (int i = 0;i < n;i++)
        {
            Console.Write(arr[i]);
        }
        Console.WriteLine();
    }

    private static void Swap(char[] arr, int i, int j)
    {
        char temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static void Main12()
    {
        PrintAnagram("123");
    }

    /*
    123
    213
    321
    231
    132
    312
    */
    public static void Shuffle(string str)
    {
        char[] ar = str.ToCharArray();
        int n = ar.Length / 2;
        int count = 0;
        int k = 1;
        char temp = '\0', temp2;
        for (int i = 1; i < n; i = i + 2)
        {
            temp = ar[i];
            k = i;
            do
            {
                k = (2 * k) % (2 * n - 1);
                temp2 = temp;
                temp = ar[k];
                ar[k] = temp2;
                count++;
            } while (i != k);
            if (count == (2 * n - 2))
            {
                break;
            }
        }
        Console.WriteLine(ar);
    }

    public static void Main13()
    {
        Shuffle("ABCDE12345");
    }
    // A1B2C3D4E5

    public static string AddBinary(string st1, string st2)
    {
        char[] str1 = st1.ToCharArray();
        char[] str2 = st2.ToCharArray();
        int size1 = str1.Length;
        int size2 = str2.Length;
        int max = (size1 > size2)? size1 : size2;
        char[] total = new char[max + 1];
        int first = 0, second = 0, sum = 0, carry = 0;
        for (int index = max; index > 0; index--, size1--, size2--)
        {
            first = (size1 <= 0) ? 0 : str1[size1 - 1] - '0';
            second = (size2 <= 0) ? 0 : str2[size2 - 1] - '0';
            sum = first + second + carry;
            carry = sum >> 1;
            sum = sum & 1;
            total[index] = (sum == 0) ? '0' : '1';
        }
        total[0] = (carry == 0) ? '0' : '1';
        return new string(total);
    }

    public static void Main14()
    {
        Console.WriteLine(AddBinary("1000", "11111111"));
    }
    // 100000111 
    public static void Main(string[] args)
    {
        Main2();
        Main3();
        Main4();
        Main5();
        Main6();
        Main7();
        Main8();
        Main9();
        Main10();
        Main11();
        Main12();
        Main13();
        Main14();
    }
}