using System;
using System.Collections.Generic;

public class Heap<T> where T : IComparable<T>
{
    private int size; // Number of elements in Heap
    private T[] arr; // The Heap array
    private bool isMinHeap;

    public Heap(bool isMin = true)
    {
        int CAPACITY = 32;
        arr = new T[CAPACITY];
        size = 0;
        isMinHeap = isMin;
    }

    public Heap(T[] array, bool isMin = true)
    {
        size = array.Length;
        arr = array;
        isMinHeap = isMin;
        // Build Heap operation over array
        for (int i = (size / 2); i >= 0; i--)
        {
            PercolateDown(i);
        }
    }

    // Other Methods.
    private bool Compare(T[] arr, int first, int second)
    {
        if (isMinHeap)
            return arr[first].CompareTo(arr[second]) > 0;
        else
            return arr[first].CompareTo(arr[second]) < 0;
    }

    private void PercolateDown(int parent)
    {
        int lChild = 2 * parent + 1;
        int rChild = lChild + 1;
        int child = -1;

        if (lChild < size)
            child = lChild;

        if (rChild < size && Compare(arr, lChild, rChild))
            child = rChild;

        if (child != -1 && Compare(arr, parent, child))
        {
            T temp = arr[parent];
            arr[parent] = arr[child];
            arr[child] = temp;
            PercolateDown(child);
        }
    }

    private void PercolateUp(int child)
    {
        int parent = (child - 1) / 2;
        if (parent >= 0 && Compare(arr, parent, child))
        {
            T temp = arr[child];
            arr[child] = arr[parent];
            arr[parent] = temp;
            PercolateUp(parent);
        }
    }

    public void Enqueue(T value)
    {
        if (size == arr.Length)
            DoubleSize();

        arr[size++] = value;
        PercolateUp(size - 1);
    }

    private void DoubleSize()
    {
        T[] old = arr;
        arr = new T[old.Length * 2];
        Array.Copy(old, 0, arr, 0, size);
    }

    public T Dequeue()
    {
        if (size == 0)
        {
            throw new System.InvalidOperationException();
        }

        T value = arr[0];
        arr[0] = arr[size - 1];
        size--;
        PercolateDown(0);
        return value;
    }

    public void Print()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    public bool IsEmpty()
    {
        return (size == 0);
    }

    public int Size()
    {
        return size;
    }

    public T Peek()
    {
        if (size == 0)
        {
            throw new System.InvalidOperationException();
        }
        return arr[0];
    }

    public static void HeapSort(int[] array, bool inc)
    {
        // Create max heap for increasing order sorting.
        Heap<int> hp = new Heap<int>(array, !inc);
        for (int i = 0; i < array.Length; i++)
        {
            array[array.Length - i - 1] = hp.Dequeue();
        }
    }
}

public class HeapEx
{
    public static void Main1()
    {
        Heap<int> hp = new Heap<int>(true);
        hp.Enqueue(1);
        hp.Enqueue(6);
        hp.Enqueue(5);
        hp.Enqueue(7);
        hp.Enqueue(3);
        hp.Enqueue(4);
        hp.Enqueue(2);
        hp.Print();
        while (!hp.IsEmpty())
            Console.Write(hp.Dequeue() + " ");
        Console.WriteLine();
    }

    public static void Main2()
    {
        int[] a2 = new int[] { 1, 9, 6, 7, 8, 2, 4, 5, 3 };
        Heap<int>.HeapSort(a2, true);
        for (int i = 0; i < a2.Length; i++)
            Console.Write(a2[i] + " ");
        Console.WriteLine();

        int[] a3 = new int[] { 1, 9, 6, 7, 8, 2, 4, 5, 3 };
        Heap<int>.HeapSort(a3, false);
        for (int i = 0; i < a3.Length; i++)
            Console.Write(a3[i] + " ");
        Console.WriteLine();
    }

    public static int KthSmallest(int[] arr, int size, int k)
    {
        Array.Sort(arr);
        return arr[k - 1];
    }

    public static int KthSmallest2(int[] arr, int size, int k)
    {
        Heap<int> hp = new Heap<int>();
        for (int i = 0; i < size; i++)
            hp.Enqueue(arr[i]);

        for (int i = 0; i < k - 1; i++)
            hp.Dequeue();

        return hp.Peek();
    }

    public static int KthSmallest3(int[] arr, int size, int k)
    {
        Heap<int> hp = new Heap<int>(false);
        for (int i = 0; i < size; i++)
        {
            if (i < k)
            {
                hp.Enqueue(arr[i]);
            }
            else
            {
                if (hp.Peek() > arr[i])
                {
                    hp.Enqueue(arr[i]);
                    hp.Dequeue();
                }
            }
        }
        return hp.Peek();
    }

    public static int KthLargest(int[] arr, int size, int k)
    {
        int value = 0;
        Heap<int> hp = new Heap<int>(false);
        for (int i = 0; i < size; i++)
            hp.Enqueue(arr[i]);

        for (int i = 0; i < k; i++)
            value = hp.Dequeue();

        return value;
    }
    // Testing code.
    public static void Main3()
    {
        int[] arr = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
        Console.WriteLine("Kth Smallest :: " + KthSmallest(arr, arr.Length, 3));
        int[] arr2 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
        Console.WriteLine("Kth Smallest :: " + KthSmallest2(arr2, arr2.Length, 3));
        int[] arr3 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
        Console.WriteLine("Kth Smallest :: " + KthSmallest3(arr3, arr3.Length, 3));
        int[] arr4 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
        Console.WriteLine("Kth Largest :: " + KthLargest(arr4, arr4.Length, 3));
    }

    /*
    Kth Smallest :: 5
    Kth Smallest :: 5
    Kth Smallest :: 5
    Kth Largest :: 7
    */
    public static bool IsMinHeap(int[] arr, int size)
    {
        int lchild, rchild;
        // last element index size - 1
        for (int parent = 0; parent < (size / 2 + 1); parent++)
        {
            lchild = parent * 2 + 1;
            rchild = parent * 2 + 2;
            // heap property check.
            if (((lchild < size) && (arr[parent] > arr[lchild])) || ((rchild < size) && (arr[parent] > arr[rchild])))
                return false;
        }
        return true;
    }

    public static bool IsMaxHeap(int[] arr, int size)
    {
        int lchild, rchild;
        // last element index size - 1
        for (int parent = 0; parent < (size / 2 + 1); parent++)
        {
            lchild = parent * 2 + 1;
            rchild = lchild + 1;
            // heap property check.
            if (((lchild < size) && (arr[parent] < arr[lchild])) || ((rchild < size) && (arr[parent] < arr[rchild])))
                return false;
        }
        return true;
    }

    // Testing code.
    public static void Main4()
    {
        int[] arr3 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
        Console.WriteLine("IsMaxHeap :: " + IsMaxHeap(arr3, arr3.Length));
        int[] arr4 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        Console.WriteLine("IsMinHeap :: " + IsMinHeap(arr4, arr4.Length));
    }

    /*
    IsMaxHeap :: True
    IsMinHeap :: True    
    */

    public static int KSmallestProduct(int[] arr, int size, int k)
    {
        Array.Sort(arr);
        int product = 1;
        for (int i = 0; i < k; i++)
            product *= arr[i];

        return product;
    }

    public static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static void QuickSelectUtil(int[] arr, int lower, int upper, int k)
    {
        if (upper <= lower)
            return;

        int pivot = arr[lower];
        int start = lower;
        int stop = upper;

        while (lower < upper)
        {
            while (lower < upper && arr[lower] <= pivot)
            {
                lower++;
            }
            while (lower <= upper && arr[upper] > pivot)
            {
                upper--;
            }
            if (lower < upper)
            {
                Swap(arr, upper, lower);
            }
        }

        Swap(arr, upper, start); // upper is the pivot position
        if (k < upper)
            QuickSelectUtil(arr, start, upper - 1, k); // pivot -1 is the upper for left sub array.
        if (k > upper)
            QuickSelectUtil(arr, upper + 1, stop, k); // pivot + 1 is the lower for right sub array.
    }

    public static int KSmallestProduct3(int[] arr, int size, int k)
    {
        QuickSelectUtil(arr, 0, size - 1, k);
        int product = 1;
        for (int i = 0; i < k; i++)
            product *= arr[i];
        return product;
    }

    public static int KSmallestProduct2(int[] arr, int size, int k)
    {
        Heap<int> hp = new Heap<int>();
        int i = 0;
        int product = 1;
        for (i = 0; i < size; i++)
        {
            hp.Enqueue(arr[i]);
        }
        i = 0;
        while (i < size && i < k)
        {
            product *= hp.Dequeue();
            i += 1;
        }
        return product;
    }

    public static int KSmallestProduct4(int[] arr, int size, int k)
    {
        Heap<int> hp = new Heap<int>(false);
        for (int i = 0; i < size; i++)
        {
            if (i < k)
                hp.Enqueue(arr[i]);
            else
            {
                if (hp.Peek() > arr[i])
                {
                    hp.Enqueue(arr[i]);
                    hp.Dequeue();
                }
            }
        }
        int product = 1;
        for (int i = 0; i < k; i++)
            product *= hp.Dequeue();
        return product;
    }

    // Testing code.
    public static void Main5()
    {
        int[] arr = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
        Console.WriteLine("Kth Smallest product:: " + KSmallestProduct(arr, 8, 3));
        int[] arr2 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
        Console.WriteLine("Kth Smallest product:: " + KSmallestProduct2(arr2, 8, 3));
        int[] arr3 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
        Console.WriteLine("Kth Smallest product:: " + KSmallestProduct3(arr3, 8, 3));
        int[] arr4 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
        Console.WriteLine("Kth Smallest product:: " + KSmallestProduct4(arr4, 8, 3));
    }

    /*
    Kth Smallest product:: 10 
    Kth Smallest product:: 10 
    Kth Smallest product:: 10
    Kth Smallest product:: 10
    */

    public static void PrintLargerHalf(int[] arr, int size)
    {
        Array.Sort(arr);
        for (int i = size / 2; i < size; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }

    public static void PrintLargerHalf2(int[] arr, int size)
    {
        Heap<int> hp = new Heap<int>();
        for (int i = 0; i < size; i++)
            hp.Enqueue(arr[i]);

        for (int i = 0; i < size / 2; i++)
            hp.Dequeue();

        hp.Print();
    }

    public static void PrintLargerHalf3(int[] arr, int size)
    {
        QuickSelectUtil(arr, 0, size - 1, size / 2);
        for (int i = size / 2; i < size; i++)
            Console.Write(arr[i] + " ");

        Console.WriteLine();
    }

    // Testing code.
    public static void Main6()
    {
        int[] arr = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
        PrintLargerHalf(arr, 8);
        int[] arr2 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
        PrintLargerHalf2(arr2, 8);
        int[] arr3 = new int[] { 8, 7, 6, 5, 7, 5, 2, 1 };
        PrintLargerHalf3(arr3, 8);
    }

    /*
    6 7 7 8 
    6 7 7 8 
    6 7 7 8
    */

    public static void SortK(int[] arr, int size, int k)
    {
        Heap<int> hp = new Heap<int>();
        int i = 0;
        for (i = 0; i < k; i++)
        {
            hp.Enqueue(arr[i]);
        }

        int[] output = new int[size];
        int index = 0;

        for (i = k; i < size; i++)
        {
            output[index++] = hp.Dequeue();
            hp.Enqueue(arr[i]);
        }

        while (hp.Size() > 0)
        {
            output[index++] = hp.Dequeue();
        }

        for (i = 0; i < size; i++)
        {
            arr[i] = output[i];
        }
    }

    // Testing Code
    public static void Main7()
    {
        int k = 3;
        int[] arr = new int[] { 1, 5, 4, 10, 50, 9 };
        int size = arr.Length;
        SortK(arr, size, k);
        for (int i = 0; i < size; i++)
            Console.Write(arr[i] + " ");
    }
    /*
    1 4 5 9 10 50 
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

    }
}
