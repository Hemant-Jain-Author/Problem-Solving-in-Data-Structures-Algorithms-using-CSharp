using System;
using System.Collections.Generic;

public class CountMap<T>
{
    internal Dictionary<T, int> hm = new Dictionary<T, int>();

    public void Add(T key)
    {
        if (hm.ContainsKey(key))
        {
            hm[key] = hm[key] + 1;
        }
        else
        {
            hm[key] = 1;
        }
    }

    public void Remove(T key)
    {
        if (hm.ContainsKey(key))
        {
            if (hm[key] == 1)
            {
                hm.Remove(key);
            }
            else
            {
                hm[key] = hm[key] - 1;
            }
        }
    }

    public int Get(T key)
    {
        if (hm.ContainsKey(key))
        {
            return hm[key];
        }
        return 0;
    }

    public bool ContainsKey(T key)
    {
        return hm.ContainsKey(key);
    }

    public int size()
    {
        return hm.Count;
    }
}
class countMapDemo
{
    // Testing code.
    public static void Main(string[] args)
    {
        CountMap<int> cm = new CountMap<int>();
        cm.Add(2);
        cm.Add(2);
        Console.WriteLine("count is : " + cm.Get(2));
        cm.Remove(2);
        Console.WriteLine("count is : " + cm.Get(2));
        cm.Remove(2);
        Console.WriteLine("count is : " + cm.Get(2));
    }
}

/*
count is : 2
count is : 1
count is : 0
*/