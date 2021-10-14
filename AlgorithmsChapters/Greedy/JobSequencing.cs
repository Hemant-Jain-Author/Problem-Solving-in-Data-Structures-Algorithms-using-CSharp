using System;

public class JobSequencing
{
	private Job[] jobs;
	private int n;
	private int maxDL;

	internal class Job
	{
		internal char id;
		internal int deadline, profit;

		internal Job(char id, int deadline, int profit)
		{
			this.id = id;
			this.deadline = deadline;
			this.profit = profit;
		}
	}

	public JobSequencing(char[] ids, int[] deadlines, int[] profits, int n)
	{
		this.jobs = new Job[n];
		this.n = n;
		this.maxDL = deadlines[0];
		for (int i = 1;i < n;i++)
		{
			if (deadlines[i] > this.maxDL)
			{
			this.maxDL = deadlines[i];
			}
		}

		for (int i = 0;i < n;i++)
		{
			this.jobs[i] = new Job(ids[i], deadlines[i], profits[i]);
		}
	}

	public void Print()
	{
		Array.Sort(this.jobs, (a, b) => b.profit - a.profit);
		bool[] result = new bool[this.maxDL];
		char[] job = new char[this.maxDL];
		int profit = 0;

		// Iterate through all given jobs
		for (int i = 0; i < n; i++)
		{
			for (int j = this.jobs[i].deadline - 1; j >= 0; j--)
			{
				if (result[j] == false)
				{
					result[j] = true;
					job[j] = this.jobs[i].id;
					profit += this.jobs[i].profit;
					break;
				}
			}
		}
		Console.WriteLine("Profit is :: " + profit);
		Console.Write("Jobs selected are::");
		for (int i = 0;i < this.maxDL;i++)
		{
			if (job[i] != '\u0000')
			{
				Console.Write(" " + job[i]);
			}
		}
	}


	public static void Main(string[] args)
	{
		char[] id = new char[] {'a', 'b', 'c', 'd', 'e'};
		int[] deadline = new int[] {3, 1, 2, 4, 4};
		int[] profit = new int[] {50, 40, 27, 31, 30};
		JobSequencing js = new JobSequencing(id, deadline, profit, 5);
		js.Print();
	}
}

/*
Profit is :: 151
Jobs selected are:: b e a d
*/