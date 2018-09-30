using System;
using System.Collections;
using System.Collections.Generic;

internal class PriorityQueueEnumerator<T> : IEnumerator<T> where T : IComparable<T>
{
	private PriorityQueue<T> priorityQueue;
	int index;
	T current;

	public PriorityQueueEnumerator(PriorityQueue<T> pq)
	{
		this.priorityQueue = pq;
		current = default(T);
		index = 1;
	}

	public T Current
	{
		get
		{
			return current;
		}
	}

	object IEnumerator.Current
	{
		get
		{
			return this.Current;
		}
	}

	public void Dispose()
	{
		priorityQueue = null;
		current = default(T);
		index = 1;
	}

	public bool MoveNext()
	{
		if (index <= priorityQueue.Count)
		{
			current = priorityQueue.CurrIndex(index);
			index++;
			return true;
		}
		return false;
	}

	public void Reset()
	{
		current = default(T);
		index = 1;
	}
}