using System;

public class GraphColouring
{
    // Is it safe to colour vth vertice with c colour.
    private static bool IsSafe(bool[, ] graph, int V, int[] colour, int v, int c)
    {
        for (int i = 0; i < V; i++)
        {
            if (graph[v, i] == true && c == colour[i])
            {
                return false;
            }
        }
        return true;
    }

    private static bool ColouringUtil(bool[, ] graph, int V, int m, int[] colour, int i)
    {
        if (i == V)
        {
            PrintSolution(colour, V);
            return true;
        }

        for (int j = 1; j <= m; j++)
        {
            if (IsSafe(graph, V, colour, i, j))
            {
                colour[i] = j;
                if (ColouringUtil(graph, V, m, colour, i + 1))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool Colouring(bool[, ] graph, int V, int m)
    {
        int[] colour = new int[V];
        if (ColouringUtil(graph, V, m, colour, 0))
        {
            return true;
        }
        return false;
    }

    private static void PrintSolution(int[] colour, int V)
    {
        Console.Write("Assigned colours are::");
        for (int i = 0; i < V; i++)
        {
            Console.Write(" " + colour[i]);
        }
        Console.WriteLine();
    }

    // Check if the whole graph is coloured properly.
    private static bool IsSafe2(bool[, ] graph, int[] colour, int V)
    {
        for (int i = 0; i < V; i++)
        {
            for (int j = i + 1; j < V; j++)
            {
                if (graph[i, j] && colour[j] == colour[i])
                {
                    return false;
                }
            }
        }
        return true;
    }

    private static bool Colouring2(bool[, ] graph, int V, int m, int[] colour, int i)
    {
        if (i == V)
        {
            if (IsSafe2(graph, colour, V))
            {
                PrintSolution(colour, V);
                return true;
            }
            return false;
        }

        // Assign each colour from 1 to m
        for (int j = 1; j <= m; j++)
        {
            colour[i] = j;
            if (Colouring2(graph, V, m, colour, i + 1))
            {
                return true;
            }
        }
        return false;
    }


    public static bool Colouring2(bool[, ] graph, int V, int m)
    {
        int[] colour = new int[V];
        if (Colouring2(graph, V, m, colour, 0))
        {
                return true;
        }
        return false;
    }

    // Testing code.
    public static void Main(string[] args)
    {
        bool[, ] graph = new bool[, ]
        {
            {false, true, false, false, true},
            {true, false, true, false, true},
            {false, true, false, true, true},
            {false, false, true, false, true},
            {true, true, true, true, false}
        };
        int V = 5; // Number of vertices
        int m = 4; // Number of colours
        if (!GraphColouring.Colouring2(graph, V, m))
        {
            Console.WriteLine("Solution does not exist");
        }
        if (!GraphColouring.Colouring(graph, V, m))
        {
            Console.WriteLine("Solution does not exist");
        }
    }
}
/*
Assigned colours are:: 1 2 1 2 3
Assigned colours are:: 1 2 1 2 3
*/