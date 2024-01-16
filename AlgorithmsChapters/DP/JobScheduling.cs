using System;

// Also known as Activity Selection Weighted.
public class JobScheduling
{
    public class Job : IComparable<Job>
    {
        internal int start, stop, value;

        internal Job(int s, int f, int v)
        {
            start = s;
            stop = f;
            value = v;
        }

        public int CompareTo(Job j2)
        {
            return this.stop - j2.stop;
        }
    }

    public static int MaxValueJobsUtil(Job[] arr, int n)
    {
        // Base case
        if (n == 1)
        {
            return arr[0].value;
        }

        // Find Value when current job is included
        int incl = arr[n - 1].value;
        for (int j = n - 1; j >= 0; j--)
        {
            if (arr[j].stop <= arr[n - 1].start)
            {
                incl += MaxValueJobsUtil(arr, j + 1);
                break;
            }
        }

        // Find Value when current job is excluded
        int excl = MaxValueJobsUtil(arr, n - 1);

        return Math.Max(incl, excl);
    }


    public static int MaxValueJobs(int[] s, int[] f, int[] v, int n)
    {
        Job[] act = new Job[n];
        for (int i = 0;i < n;i++)
        {
            act[i] = new Job(s[i], f[i], v[i]);
        }
        Array.Sort(act); // sort according to finish time.
        return MaxValueJobsUtil(act, n);
    }

    private static int MaxValueJobsUtilTD(int[] dp, Job[] arr, int n)
    {
        // Base case
        if (n == 0)
        {
            return 0;
        }

        if (dp[n - 1] != 0)
        {
            return dp[n - 1];
        }

        // Find Value when current job is included
        int incl = arr[n - 1].value;
        for (int j = n - 2; j >= 0; j--)
        {
            if (arr[j].stop <= arr[n - 1].start)
            {
                incl += MaxValueJobsUtilTD(dp, arr, j + 1);
                break;
            }
        }

        // Find Value when current job is excluded
        int excl = MaxValueJobsUtilTD(dp, arr, n - 1);
        dp[n - 1] = Math.Max(incl, excl);
        return dp[n - 1];
    }


    public static int MaxValueJobsTD(int[] s, int[] f, int[] v, int n)
    {
        Job[] act = new Job[n];
        for (int i = 0;i < n;i++)
        {
            act[i] = new Job(s[i], f[i], v[i]);
        }
        Array.Sort(act); // sort according to finish time.
        int[] dp = new int[n];
        return MaxValueJobsUtilTD(dp, act, n);
    }

    public static int MaxValueJobsBU(int[] s, int[] f, int[] v, int n)
    {
        Job[] act = new Job[n];
        for (int i = 0;i < n;i++)
        {
            act[i] = new Job(s[i], f[i], v[i]);
        }
        Array.Sort(act); // sort according to finish time.

        int[] dp = new int[n];
        dp[0] = act[0].value;

        for (int i = 1; i < n; i++)
        {
            int incl = act[i].value;
            for (int j = i - 1; j >= 0; j--)
            {
                if (act[j].stop <= act[i].start)
                {
                    incl += dp[j];
                    break;
                }
            }
            dp[i] = Math.Max(incl, dp[i - 1]);
        }
        return dp[n - 1];
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int[] start = new int[] {1, 5, 0, 3, 5, 6, 8};
        int[] finish = new int[] {2, 6, 5, 4, 9, 7, 9};
        int[] value = new int[] {2, 2, 4, 3, 10, 2, 8};
        int n = start.Length;
        Console.WriteLine(MaxValueJobs(start, finish, value, n));
        Console.WriteLine(MaxValueJobsTD(start, finish, value, n));
        Console.WriteLine(MaxValueJobsBU(start, finish, value, n));
    }
}

/*
17
17
17
*/