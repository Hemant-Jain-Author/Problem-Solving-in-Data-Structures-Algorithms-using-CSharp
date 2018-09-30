using System;
using System.Collections.Generic;

public class CountMap<T>
{
	internal Dictionary<T, int> hm = new Dictionary<T, int>();

	public void add(T key)
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

	public void remove(T key)
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

	public int get(T key)
	{
		if (hm.ContainsKey(key))
		{
			return hm[key];
		}
		return 0;
	}

	public bool containsKey(T key)
	{
		return hm.ContainsKey(key);
	}

	public int size()
	{
		return hm.Count;
	}

	public static void Main(string[] args)
	{
		CountMap<int> cm = new CountMap<int>();
		cm.add(2);
		cm.add(2);
		Console.WriteLine("count is : " + cm.get(2));
		cm.remove(2);
		Console.WriteLine("count is : " + cm.get(2));
		cm.remove(2);
		Console.WriteLine("count is : " + cm.get(2));
	}
}
