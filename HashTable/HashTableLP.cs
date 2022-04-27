using System;

public class HashTableLP
{
    private static int EMPTY_VALUE = -1;
    private static int DELETED_VALUE = -2;
    private static int FILLED_VALUE = 0;

    private int tableSize;
    private int[] key;
    private int[] value;
    private int[] flag;

    public HashTableLP(int tSize)
    {
        tableSize = tSize;
        key = new int[tSize + 1];
        value = new int[tSize + 1];
        flag = new int[tSize + 1];
        Array.Fill(flag, EMPTY_VALUE);
    }

    /* Other Methods */

    private int ComputeHash(int key)
    {
        return key % tableSize;
    }

    private int ResolverFun(int index)
    {
        return index;
    }

    private int ResolverFun2(int index)
    {
        return index * index;
    }

    public bool Add(int ky, int val)
    {
        int hashValue = ComputeHash(ky);
        for (int i = 0; i < tableSize; i++)
        {
            if (flag[hashValue] == EMPTY_VALUE || flag[hashValue] == DELETED_VALUE)
            {
                key[hashValue] = ky;
                value[hashValue] = val;
                flag[hashValue] = FILLED_VALUE;
                return true;
            }
            hashValue += ResolverFun(i);
            hashValue %= tableSize;
        }
        return false;
    }

    public bool Add(int val)
    {
        return Add(val, val);
    }

    public bool Find(int ky)
    {
        int hashValue = ComputeHash(ky);
        for (int i = 0; i < tableSize; i++)
        {
            if (flag[hashValue] == EMPTY_VALUE)
            {
                return false;
            }

            if (flag[hashValue] == FILLED_VALUE && key[hashValue] == ky)
            {
                return true;
            }

            hashValue += ResolverFun(i);
            hashValue %= tableSize;
        }
        return false;
    }


    public int Get(int ky)
    {
        int hashValue = ComputeHash(ky);
        for (int i = 0; i < tableSize; i++)
        {
            if (flag[hashValue] == EMPTY_VALUE)
            {
                return -1;
            }

            if (flag[hashValue] == FILLED_VALUE && key[hashValue] == ky)
            {
                return value[hashValue]; ;
            }

            hashValue += ResolverFun(i);
            hashValue %= tableSize;
        }
        return -1;
    }

    public bool Remove(int ky)
    {
        int hashValue = ComputeHash(ky);
        for (int i = 0; i < tableSize; i++)
        {
            if (flag[hashValue] == EMPTY_VALUE)
            {
                return false;
            }

            if (flag[hashValue] == FILLED_VALUE && key[hashValue] == ky)
            {
                flag[hashValue] = DELETED_VALUE;
                return true;
            }
            hashValue += ResolverFun(i);
            hashValue %= tableSize;
        }
        return false;
    }

    public void Print()
    {
        Console.Write("Hash Table contains :: ");
        for (int i = 0; i < tableSize; i++)
        {
            if (flag[i] == FILLED_VALUE)
            {
                Console.Write("(" + key[i] + "=>" + value[i] + ") ");
            }
        }
        Console.WriteLine();
    }


    // Testing code.
    public static void Main(string[] args)
    {
        HashTableLP ht = new HashTableLP(1000);
        ht.Add(1, 10);
        ht.Add(2, 20);
        ht.Add(3, 30);
        ht.Print();
        Console.WriteLine("Find key 2 : " + ht.Find(2));
        Console.WriteLine("Value at key 2 : " + ht.Get(2));
        ht.Remove(2);
        ht.Print();
        Console.WriteLine("Find key 2 : " + ht.Find(2));
    }
}

/*
Hash Table contains :: (1=>10) (2=>20) (3=>30) 
Find key 2 : True
Value at key 2 : 20
Hash Table contains :: (1=>10) (3=>30) 
Find key 2 : False
*/