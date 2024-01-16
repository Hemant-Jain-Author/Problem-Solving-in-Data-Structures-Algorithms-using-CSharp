using System;
class FenWickTree{
    int size;
    float[] sum;

    public FenWickTree(float[] input, int n)
    {
        size = n;
        sum = new float[size+1];
        for(int i =0;i<n;i++)
        {
            add(i, input[i]);
        }
    }

    public void add(int index, float val)  
    {  
        index += 1;
        while(index <= size)  
        {  
            sum[index] += val;
            index += index & (-index);  // Parent is first set bit grater then the index.    
        }  
    }

    public float getPrefixSum(int index)  
    {  
        float total = 0;
        index += 1;
        while(index>0)  
        {  
            total += sum[index];  
            index -= index & (-index);  
        }  
        return total;  
    }
}

class InventoryManager{
    FenWickTree tree;

    public InventoryManager(int size){

        float[] arr = new float[size];
        tree = new FenWickTree(arr, size);
    }

    public void AddSupply(int bucket, float delta){
        tree.add(bucket, delta);
    }

    public void AddDemand(int bucket, float delta){
        tree.add(bucket, -1*delta);
    }

    public float GetInventory(int bucket){
        return tree.getPrefixSum(bucket);
    }
}

class Program
{
	
    // Testing code.
    static void Main(string[] args)
    {
        InventoryManager im = new InventoryManager(10);
        im.AddSupply(2, 50);
        
        Console.WriteLine(im.GetInventory(6));  
        im.AddDemand(3, 25);
        Console.WriteLine(im.GetInventory(6));  
        im.AddDemand(2, 30);
        Console.WriteLine(im.GetInventory(6)); 
    }
}
/*
  static void Main(string[] args)
    {
        int []input = {2, 1, 1, 3, 2, 3, 4, 5, 6, 7, 8, 9};  
        int size = input.Length;  
        FenWickTree tree = new FenWickTree(input, size);  

        Console.WriteLine("Sum of elements in arr[0..5] is "+ tree.getSufixSum(5));  
          
        tree.add(3, 6);  
  
        Console.WriteLine("Sum of elements in arr[0..5] after update is " + tree.getSufixSum(5));
        tree.remove(3, 6);
        Console.WriteLine("Sum of elements in arr[0..5] after update is " + tree.getSufixSum(5));

    }
    static void Main(string[] args)
    {
        float []input = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};  
        int size = input.Length;  
        FenWickTree tree = new FenWickTree(input, size);  
        tree.add(2, 50);  
        Console.WriteLine(tree.getPrefixSum(6));  
        tree.remove(3, 25);
        Console.WriteLine(tree.getPrefixSum(6));  
        tree.remove(2, 30);
        Console.WriteLine(tree.getPrefixSum(6)); 
    } */
/* 
     public void remove(int index, float val)  
    {
        add(index , -1*val);
    } */ 


