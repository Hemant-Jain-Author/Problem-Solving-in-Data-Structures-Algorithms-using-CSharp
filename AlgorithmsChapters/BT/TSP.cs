using System;

public class TSP
{
	// Function to find the minimum weight Hamiltonian Cycle 
	internal static int FindPath(int[, ] graph, int n, int[] path, int pSize, int pCost, bool[] visited, int ans)
	{
		int curr = path[n - 1];
		if (pSize == n && graph[curr, 0] > 0)
		{
			ans = Math.Min(ans, pCost + graph[curr, 0]);
			return ans;
		}

		for (int i = 0; i < n; i++)
		{
			if (visited[i] == false && graph[curr, i] > 0)
			{
				visited[i] = true;
				path[pSize] = i;
				ans = FindPath(graph, n, path, pSize+1, pCost + graph[curr, i],visited, ans);
				visited[i] = false;
			}
		}
		return ans;
	}

	internal static int FindPath(int[, ] graph, int n)
	{
		bool[] visited = new bool[n];
		int[] path = new int[n];
		path[0] = 0;
		visited[0] = true;
		int ans = int.MaxValue;
		ans = FindPath(graph, n, path, 1, 0, visited, ans);
		Console.WriteLine(ans);
		return ans;
	}

	public static void Main(string[] args)
	{
		int n = 4;
		int[, ] graph = new int[, ]
		{
			{0, 10, 15, 20},
			{10, 0, 35, 25},
			{15, 35, 0, 30},
			{20, 25, 30, 0}
		};
		TSP.FindPath(graph, n);
	}
}

// 65