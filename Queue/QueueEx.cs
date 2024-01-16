using System;
using System.Collections.Generic;

public class QueueEx
{
    public static int CircularTour(int[,] arr, int n)
    {
        for (int i = 0; i < n; i++)
        {
            int total = 0;
            bool found = true;
            for (int j = 0; j < n; j++)
            {
                total += (arr[(i + j) % n, 0] - arr[(i + j) % n, 1]);
                if (total < 0)
                {
                    found = false;
                    break;
                }
            }
            if (found)
            {
                return i;
            }
        }
        return -1;
    }

    public static int CircularTour2(int[,] arr, int n)
    {
        Queue<int> que = new Queue<int>();
        int nextPump = 0, prevPump;
        int count = 0;
        int petrol = 0;

        while (que.Count != n)
        {
            while (petrol >= 0 && que.Count != n)
            {
                que.Enqueue(nextPump);
                petrol += (arr[nextPump, 0] - arr[nextPump, 1]);
                nextPump = (nextPump + 1) % n;
            }
            while (petrol < 0 && que.Count > 0)
            {
                prevPump = que.Dequeue();
                petrol -= (arr[prevPump, 0] - arr[prevPump, 1]);
            }
            count += 1;
            if (count == n)
            {
                return -1;
            }
        }
        if (petrol >= 0)
        {
            return que.Dequeue();
        }
        else
        {
            return -1;
        }
    }

    // Testing code
    public static void Main1()
    {
        int[,] tour = new int[,] { { 8, 6 }, { 1, 4 }, { 7, 6 } };
        Console.WriteLine("Circular Tour : " + CircularTour(tour, 3));
        Console.WriteLine("Circular Tour : " + CircularTour2(tour, 3));
    }

    /*
    Circular Tour : 2
    Circular Tour : 2
    */
    public static int ConvertXY(int src, int dst)
    {
        Queue<int> que = new Queue<int>();
        int[] arr = new int[100];
        int Steps = 0;
        int index = 0;
        int value;

        que.Enqueue(src);
        while (que.Count != 0)
        {
            value = que.Dequeue();
            arr[index++] = value;

            if (value == dst)
            {
                return Steps;
            }
            Steps++;
            if (value < dst)
            {
                que.Enqueue(value * 2);
            }
            else
            {
                que.Enqueue(value - 1);
            }
        }
        return -1;
    }

    // Testing code.
    public static void Main2()
    {
        Console.WriteLine("Steps count :: " + ConvertXY(2, 7));
    }

    /*
    Steps count :: 3
    */

    public static void MaxSlidingWindows(int[] arr, int size, int k)
    {
        for (int i = 0; i < size - k + 1; i++)
        {
            int max = arr[i];
            for (int j = 1; j < k; j++)
            {
                max = Math.Max(max, arr[i + j]);
            }
            Console.Write(max + " ");
        }
        Console.WriteLine();
    }

    public static void MaxSlidingWindows2(int[] arr, int size, int k)
    {
        LinkedList<int> dque = new LinkedList<int>();
        for (int i = 0; i < size; i++)
        {
            // Remove out of range elements
            if (dque.Count > 0 && dque.First.Value <= i - k)
            {
                dque.RemoveFirst();
            }
            // Remove smaller values at left.
            while (dque.Count > 0 && arr[dque.Last.Value] <= arr[i])
            {
                dque.RemoveLast();
            }

            dque.AddLast(i);
            // Largest value in window of size k is at index que[0]
            // It is displayed to the screen.
            if (i >= (k - 1))
            {
                Console.Write(arr[dque.First.Value] + " ");
            }
        }
    }

    // Testing code.
    public static void Main3()
    {
        int[] arr = new int[] { 11, 2, 75, 92, 59, 90, 55 };
        MaxSlidingWindows(arr, 7, 3);
        MaxSlidingWindows2(arr, 7, 3);
    }

    /*
    75 92 92 92 90 
    */

    public static int MinOfMaxSlidingWindows(int[] arr, int size, int k)
    {
        LinkedList<int> dque = new LinkedList<int>();
        int minVal = 999999;
        for (int i = 0; i < size; i++)
        {
            // Remove out of range elements
            if (dque.Count > 0 && dque.First.Value <= i - k)
            {
                dque.RemoveFirst();
            }
            // Remove smaller values at left.
            while (dque.Count > 0 && arr[dque.Last.Value] <= arr[i])
            {
                dque.RemoveLast();
            }
            dque.AddLast(i);
            // window of size k
            if (i >= (k - 1) && minVal > arr[dque.First.Value])
            {
                minVal = arr[dque.First.Value];
            }
        }
        Console.WriteLine("Min of max is :: " + minVal);
        return minVal;
    }

    // Testing code.
    public static void Main4()
    {
        int[] arr = new int[] { 11, 2, 75, 92, 59, 90, 55 };
        MinOfMaxSlidingWindows(arr, 7, 3);
    }

    /*
    Min of max is :: 75
    */
    public static void MaxOfMinSlidingWindows(int[] arr, int size, int k)
    {
        LinkedList<int> dque = new LinkedList<int>();
        int maxVal = -999999;
        for (int i = 0; i < size; i++)
        {
            // Remove out of range elements
            if (dque.Count > 0 && dque.First.Value <= i - k)
            {
                dque.RemoveFirst();
            }
            // Remove smaller values at left.
            while (dque.Count > 0 && arr[dque.Last.Value] >= arr[i])
            {
                dque.RemoveLast();
            }
            dque.AddLast(i);
            // window of size k
            if (i >= (k - 1) && maxVal < arr[dque.First.Value])
            {
                maxVal = arr[dque.First.Value];
            }
        }
        Console.WriteLine("Max of min is :: " + maxVal);
    }

    // Testing code.
    public static void Main5()
    {
        int[] arr = new int[] { 11, 2, 75, 92, 59, 90, 55 };
        MaxOfMinSlidingWindows(arr, 7, 3);
    }

    /*
    Max of min is :: 59
    */

    public static void FirstNegSlidingWindows(int[] arr, int size, int k)
    {
        Queue<int> que = new Queue<int>();

        for (int i = 0; i < size; i++)
        {
            // Remove out of range elements
            if (que.Count > 0 && que.Peek() <= i - k)
            {
                que.Dequeue();
            }
            if (arr[i] < 0)
            {
                que.Enqueue(i);
            }
            // window of size k
            if (i >= (k - 1))
            {
                if (que.Count > 0)
                {
                    Console.Write(arr[que.Peek()] + " ");
                }
                else
                {
                    Console.Write("NAN");
                }
            }
        }
    }

    // Testing code.
    public static void Main6()
    {
        int[] arr = new int[] { 3, -2, -6, 10, -14, 50, 14, 21 };
        FirstNegSlidingWindows(arr, 8, 3);
    }

    /*
    -2 -2 -6 -14 -14 NAN
    */

    private static void RottenFruitUtil(int[,] arr, int maxCol, int maxRow, int currCol, int currRow, int[,] traversed, int day)
    {
        int[,] dir = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
        int x, y;
        for (int i = 0; i < 4; i++)
        {
            x = currCol + dir[i, 0];
            y = currRow + dir[i, 1];
            if (x >= 0 && x < maxCol && y >= 0 && y < maxRow && traversed[x, y] > day + 1 && arr[x, y] == 1)
            {
                traversed[x, y] = day + 1;
                RottenFruitUtil(arr, maxCol, maxRow, x, y, traversed, day + 1);
            }
        }
    }

    public static int RottenFruit(int[,] arr, int maxCol, int maxRow)
    {
        int[,] traversed = new int[maxCol, maxRow];
        for (int i = 0; i < maxCol; i++)
        {
            for (int j = 0; j < maxRow; j++)
            {
                traversed[i, j] = int.MaxValue;
            }
        }

        for (int i = 0; i < maxCol; i++)
        {
            for (int j = 0; j < maxRow; j++)
            {
                if (arr[i, j] == 2)
                {
                    traversed[i, j] = 0;
                    RottenFruitUtil(arr, maxCol, maxRow, i, j, traversed, 0);
                }
            }
        }

        int maxDay = 0;
        for (int i = 0; i < maxCol; i++)
        {
            for (int j = 0; j < maxRow; j++)
            {
                if (arr[i, j] == 1)
                {
                    if (traversed[i, j] == int.MaxValue)
                    {
                        return -1;
                    }
                    if (maxDay < traversed[i, j])
                    {
                        maxDay = traversed[i, j];
                    }
                }
            }
        }
        return maxDay;
    }

    private class Fruit
    {
        internal int x, y;
        internal int day;
        internal Fruit(int a, int b, int d)
        {
            x = a;
            y = b;
            day = d;
        }
    }

    public static int RottenFruit2(int[,] arr, int maxCol, int maxRow)
    {
        bool[,] traversed = new bool[maxCol, maxRow];
        int[,] dir = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
        Queue<Fruit> que = new Queue<Fruit>();

        for (int i = 0; i < maxCol; i++)
        {
            for (int j = 0; j < maxRow; j++)
            {
                traversed[i, j] = false;
                if (arr[i, j] == 2)
                {
                    que.Enqueue(new Fruit(i, j, 0));
                    traversed[i, j] = true;
                }
            }
        }
        int max = 0, x, y, day;
        Fruit temp;
        while (que.Count > 0)
        {
            temp = que.Peek();
            que.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                x = temp.x + dir[i, 0];
                y = temp.y + dir[i, 1];
                day = temp.day + 1;
                if (x >= 0 && x < maxCol && y >= 0 && y < maxRow && arr[x, y] != 0 && traversed[x, y] == false)
                {
                    que.Enqueue(new Fruit(x, y, day));
                    max = Math.Max(max, day);
                    traversed[x, y] = true;
                }
            }
        }
        for (int i = 0; i < maxCol; i++)
        {
            for (int j = 0; j < maxRow; j++)
            {
                if (arr[i, j] == 1 && traversed[i, j] == false)
                {
                    return -1;
                }
            }
        }
        return max;
    }

    // Testing code.
    public static void Main7()
    {
        int[,] arr = new int[,]
            {{1, 0, 1, 1, 0},
            {2, 1, 0, 1, 0},
            {0, 0, 0, 2, 1},
            {0, 2, 0, 0, 1},
            {1, 1, 0, 0, 1}};
        Console.WriteLine(RottenFruit(arr, 5, 5));
        Console.WriteLine(RottenFruit2(arr, 5, 5));
    }

    // 3
    // 3

    private static void StepsOfKnightUtil(int size, int currCol, int currRow, int[,] traversed, int dist)
    {
        int[,] dir = new int[,]
    {{-2, -1}, {-2, 1}, {2, -1}, {2, 1}, {-1, -2}, {1, -2}, {-1, 2}, {1, 2}};
        int x, y;
        for (int i = 0; i < 8; i++)
        {
            x = currCol + dir[i, 0];
            y = currRow + dir[i, 1];
            if (x >= 0 && x < size && y >= 0 && y < size && traversed[x, y] > dist + 1)
            {
                traversed[x, y] = dist + 1;
                StepsOfKnightUtil(size, x, y, traversed, dist + 1);
            }
        }
    }

    public static int StepsOfKnight(int size, int srcX, int srcY, int dstX, int dstY)
    {
        int[,] traversed = new int[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                traversed[i, j] = int.MaxValue;
            }
        }
        traversed[srcX - 1, srcY - 1] = 0;
        StepsOfKnightUtil(size, srcX - 1, srcY - 1, traversed, 0);
        return traversed[dstX - 1, dstY - 1];
    }

    private class Knight
    {
        internal int x, y;
        internal int cost;
        internal Knight(int a, int b, int c)
        {
            x = a;
            y = b;
            cost = c;
        }
    }

    public static int StepsOfKnight2(int size, int srcX, int srcY, int dstX, int dstY)
    {
        int[,] traversed = new int[size, size];
        int[,] dir = new int[,]
    {{-2, -1}, {-2, 1}, {2, -1}, {2, 1}, {-1, -2}, {1, -2}, {-1, 2}, {1, 2}};
        Queue<Knight> que = new Queue<Knight>();

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                traversed[i, j] = int.MaxValue;
            }
        }
        que.Enqueue(new Knight(srcX - 1, srcY - 1, 0));
        traversed[srcX - 1, srcY - 1] = 0;

        int x, y, cost;
        Knight temp;
        while (que.Count > 0)
        {
            temp = que.Peek();
            que.Dequeue();
            for (int i = 0; i < 8; i++)
            {
                x = temp.x + dir[i, 0];
                y = temp.y + dir[i, 1];
                cost = temp.cost + 1;
                if (x >= 0 && x < size && y >= 0 && y < size && traversed[x, y] > cost)
                {
                    que.Enqueue(new Knight(x, y, cost));
                    traversed[x, y] = cost;
                }
            }
        }
        return traversed[dstX - 1, dstY - 1];
    }

    // Testing code.
    public static void Main8()
    {
        Console.WriteLine(StepsOfKnight(20, 10, 10, 20, 20));
        Console.WriteLine(StepsOfKnight2(20, 10, 10, 20, 20));
    }

    // 8
    // 8

    private static void DistNearestFillUtil(int[,] arr, int maxCol, int maxRow, int currCol, int currRow, int[,] traversed, int dist)
    {
        int x, y;
        int[,] dir = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
        for (int i = 0; i < 4; i++)
        {
            x = currCol + dir[i, 0];
            y = currRow + dir[i, 1];
            if (x >= 0 && x < maxCol && y >= 0 && y < maxRow && traversed[x, y] > dist + 1)
            {
                traversed[x, y] = dist + 1;
                DistNearestFillUtil(arr, maxCol, maxRow, x, y, traversed, dist + 1);
            }
        }
    }

    public static void DistNearestFill(int[,] arr, int maxCol, int maxRow)
    {
        int[,] traversed = new int[maxCol, maxRow];
        for (int i = 0; i < maxCol; i++)
        {
            for (int j = 0; j < maxRow; j++)
            {
                traversed[i, j] = int.MaxValue;
            }
        }

        for (int i = 0; i < maxCol; i++)
        {
            for (int j = 0; j < maxRow; j++)
            {
                if (arr[i, j] == 1)
                {
                    traversed[i, j] = 0;
                    DistNearestFillUtil(arr, maxCol, maxRow, i, j, traversed, 0);
                }
            }
        }

        for (int i = 0; i < maxCol; i++)
        {
            for (int j = 0; j < maxRow; j++)
            {
                Console.Write(traversed[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private class Node
    {
        internal int x, y;
        internal int dist;
        internal Node(int a, int b, int d)
        {
            x = a;
            y = b;
            dist = d;
        }
    }

    public static void DistNearestFill2(int[,] arr, int maxCol, int maxRow)
    {
        int[,] traversed = new int[maxCol, maxRow];
        int[,] dir = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
        Queue<Node> que = new Queue<Node>();

        for (int i = 0; i < maxCol; i++)
        {
            for (int j = 0; j < maxRow; j++)
            {
                traversed[i, j] = int.MaxValue;
                if (arr[i, j] == 1)
                {
                    que.Enqueue(new Node(i, j, 0));
                    traversed[i, j] = 0;
                }
            }
        }
        int x, y, dist;
        Node temp;
        while (que.Count > 0)
        {
            temp = que.Peek();
            que.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                x = temp.x + dir[i, 0];
                y = temp.y + dir[i, 1];
                dist = temp.dist + 1;
                if (x >= 0 && x < maxCol && y >= 0 && y < maxRow && traversed[x, y] > dist)
                {
                    que.Enqueue(new Node(x, y, dist));
                    traversed[x, y] = dist;
                }
            }
        }
        for (int i = 0; i < maxCol; i++)
        {
            for (int j = 0; j < maxRow; j++)
            {
                Console.Write(traversed[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // Testing code.
    public static void Main9()
    {
        int[,] arr = new int[,]
    {{1, 0, 1, 1, 0},
     {1, 1, 0, 1, 0},
     {0, 0, 0, 0, 1},
     {0, 0, 0, 0, 1},
     {0, 0, 0, 0, 1}};
        DistNearestFill(arr, 5, 5);
        DistNearestFill2(arr, 5, 5);
    }

    /*
    0 1 0 0 1 
    0 0 1 0 1 
    1 1 2 1 0 
    2 2 2 1 0 
    3 3 2 1 0 

    0 1 0 0 1 
    0 0 1 0 1 
    1 1 2 1 0     
    2 2 2 1 0 
    3 3 2 1 0 
    */

    private static int FindLargestIslandUtil(int[,] arr, int maxCol, int maxRow, int currCol, int currRow, bool[,] traversed)
    {
        int[,] dir = new int[,]
    {{-1, -1}, {-1, 0}, {-1, 1}, {0, -1}, {0, 1}, {1, -1}, {1, 0}, {1, 1}};
        int x, y, sum = 1;
        for (int i = 0; i < 8; i++)
        {
            x = currCol + dir[i, 0];
            y = currRow + dir[i, 1];
            if (x >= 0 && x < maxCol && y >= 0 && y < maxRow && traversed[x, y] == false && arr[x, y] == 1)
            {
                traversed[x, y] = true;
                sum += FindLargestIslandUtil(arr, maxCol, maxRow, x, y, traversed);
            }
        }
        return sum;
    }

    public static int FindLargestIsland(int[,] arr, int maxCol, int maxRow)
    {
        int maxVal = 0;
        int currVal = 0;
        bool[,] traversed = new bool[maxCol, maxRow];
        for (int i = 0; i < maxCol; i++)
        {
            for (int j = 0; j < maxRow; j++)
            {
                traversed[i, j] = false;
            }
        }

        for (int i = 0; i < maxCol; i++)
        {
            for (int j = 0; j < maxRow; j++)
            {
                if (arr[i, j] == 1)
                {
                    traversed[i, j] = true;
                    currVal = FindLargestIslandUtil(arr, maxCol, maxRow, i, j, traversed);
                    if (currVal > maxVal)
                    {
                        maxVal = currVal;
                    }
                }
            }
        }
        return maxVal;
    }

    // Testing code.
    public static void Main10()
    {
        int[,] arr = new int[,]
            {{1, 0, 1, 1, 0},
             {1, 0, 0, 1, 0},
             {0, 1, 1, 1, 1},
             {0, 1, 0, 0, 0},
             {1, 1, 0, 0, 1}};
        Console.WriteLine("Largest Island : " + FindLargestIsland(arr, 5, 5));
    }

    // Largest Island : 12

    public static void ReverseStack(Stack<int> stk)
    {
        Queue<int> que = new Queue<int>();
        while (stk.Count > 0)
        {
            que.Enqueue(stk.Peek());
            stk.Pop();
        }
        while (que.Count > 0)
        {
            stk.Push(que.Peek());
            que.Dequeue();
        }
    }

    public static void ReverseQueue(Queue<int> que)
    {
        Stack<int> stk = new Stack<int>();
        while (que.Count > 0)
        {
            stk.Push(que.Peek());
            que.Dequeue();
        }
        while (stk.Count > 0)
        {
            que.Enqueue(stk.Peek());
            stk.Pop();
        }
    }

    // Testing code.
    public static void Main11()
    {
        Stack<int> stk = new Stack<int>();
        for (int i = 0; i < 5; i++)
        {
            stk.Push(i);
        }
        foreach (var ele in stk)
            Console.Write(ele + " ");
        Console.WriteLine();
        ReverseStack(stk);
        foreach (var ele in stk)
            Console.Write(ele + " ");
        Console.WriteLine();

        Queue<int> que = new Queue<int>();
        for (int i = 0; i < 5; i++)
        {
            que.Enqueue(i);
        }
        foreach (var ele in que)
            Console.Write(ele + " ");
        Console.WriteLine();
        ReverseQueue(que);
        foreach (var ele in que)
            Console.Write(ele + " ");
        Console.WriteLine();
    }

    /*
    4 3 2 1 0 
    0 1 2 3 4 
    0 1 2 3 4 
    4 3 2 1 0 
    */

    public static int Josephus(int n, int k)
    {
        Queue<int> que = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            que.Enqueue(i + 1);
        }

        while (que.Count > 1)
        {
            for (int i = 0; i < k - 1; i++)
            {
                que.Enqueue(que.Peek());
                que.Dequeue();
            }
            que.Dequeue(); // Kth person executed.
        }
        return que.Peek();
    }

    // Testing code.
    public static void Main12()
    {
        Console.WriteLine("Position : " + Josephus(11, 5));
    }
    /*
    Position : 8
    */
    public static void Main(string[] args)
    {
        Main1();
        Main2();
        Main3();
        Main4();
        Main5();
        Main6();
        Main7();
        Main8();
        Main9();
        Main10();
        Main11();
        Main12();
    }
}