using System;

public class ActivitySelection
{
    internal class Activity : IComparable<Activity>
    {
        internal int start, stop;

        internal Activity(int s, int f)
        {
            start = s;
            stop = f;
        }

        public int CompareTo(Activity s2)
        {
            return this.stop - s2.stop;
        }
    }

    public void MaxActivities(int[] s, int[] f, int n)
    {
        Activity[] act = new Activity[n];
        int i;
        for (i = 0; i < n; i++)
        {
            act[i] = new Activity(s[i], f[i]);
        }
        Array.Sort(act); // sort according to finish time.

        i = 0; // The first activity at index 0 is always gets selected.
        Console.Write("Activities are : (" + act[i].start + "," + act[i].stop + ")");

        for (int j = 1; j < n; j++)
        {
            // Find next activity whose start time is greater than or equal
            // to the finish time of previous activity.
            if (act[j].start >= act[i].stop)
            {
                Console.Write(", (" + act[j].start + "," + act[j].stop + ")");
                i = j;
            }
        }
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int[] s = new int[] { 1, 5, 0, 3, 5, 6, 8 };
        int[] f = new int[] { 2, 6, 5, 4, 9, 7, 9 };
        int n = s.Length;
        ActivitySelection act = new ActivitySelection();
        act.MaxActivities(s, f, n);
    }
}

/*
Activities are : (1,2), (3,4), (5,6), (6,7), (8,9)
*/