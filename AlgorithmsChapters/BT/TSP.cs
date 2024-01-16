using System;

public class TSP
{
    // Function to find the minimum weight Hamiltonian Cycle 
    private static int TSPPath(int[,] graph, int n, int[] path, int pSize, int pCost, bool[] visited, int ans, int[] ansPath)
    {
        int curr = path[pSize - 1];
        if (pSize == n)
        {
            if (graph[curr, 0] > 0 && ans > pCost + graph[curr, 0])
            {
                ans = pCost + graph[curr, 0];
                for (int i = 0; i <= n; i++)
                    ansPath[i] = path[i % n];
            }
            return ans;
        }

        for (int i = 0; i < n; i++)
        {
            if (visited[i] == false && graph[curr, i] > 0)
            {
                visited[i] = true;
                path[pSize] = i;
                ans = TSPPath(graph, n, path, pSize + 1, pCost + graph[curr, i], visited, ans, ansPath);
                visited[i] = false;
            }
        }
        return ans;
    }

    public static int TSPPath(int[,] graph, int n)
    {
        bool[] visited = new bool[n];
        int[] path = new int[n];
        int[] ansPath = new int[n + 1];

        path[0] = 0;
        visited[0] = true;
        int ans = int.MaxValue;
        ans = TSPPath(graph, n, path, 1, 0, visited, ans, ansPath);
        Console.WriteLine("Path length : " + ans);
        Console.Write("Path : ");
        for (int i = 0; i <= n; i++)
            Console.Write(ansPath[i] + " ");
        return ans;
    }

    // Testing code.
    public static void Main(string[] args)
    {
        int n = 4;
        int[,] graph = new int[,]
        {
            {0, 10, 15, 20},
            {10, 0, 35, 25},
            {15, 35, 0, 30},
            {20, 25, 30, 0}
        };
        TSPPath(graph, n);
    }
}

/*
Path length : 80
Path : 0 1 3 2 0 
*/