using System;
using System.Collections;
using System.Collections.Generic;
class FixedSizeList<T>
{
    private T[] items;
    private int count;
    public FixedSizeList(int capacity)
    {
        if (capacity <= 0) throw new Exception("Capacity must be greater than 0");
        items = new T[capacity];
        count = 0;
    }
    public void Add(T value)
    {
        if (count == items.Length)
            throw new Exception("List is full");
        items[count] = value;
        count++;
    }
    public T Get(int index)
    {
        if (index < 0 || index >= count)
            throw new Exception("Invalid index");
        return items[index];
    }
}
class task
{
    //1
    static void ReverseArrayList(ArrayList list)
    {
        int left = 0;
        int right = list.Count - 1;
        while (left < right)
        {
            object temp = list[left];
            list[left] = list[right];
            list[right] = temp;
            left++;
            right--;
        }
    }

    //2
    static List<int> EvenNumbers(List<int> numbers)
    {
        List<int> result = new List<int>();
        foreach (int n in numbers)
        {
            if (n % 2 == 0)
                result.Add(n);
        }
        return result;
    }
    static void PrintArrayList(ArrayList list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i]);
            if (i != list.Count - 1) Console.Write(", ");
        }
        Console.WriteLine();
    }
    static void PrintIntList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i]);
            if (i != list.Count - 1) Console.Write(", ");
        }
        Console.WriteLine();
    }
    static void Main()
    {
        //1
        ArrayList a = new ArrayList { 1, 2, 3, 4, "A", "B" };
        Console.WriteLine("Before Reverse:");
        PrintArrayList(a);
        ReverseArrayList(a);
        Console.WriteLine("After Reverse:");
        PrintArrayList(a);

        //2
        List<int> nums = new List<int> { 1, 2, 3, 4, 10, 11, 12 };
        Console.WriteLine("\nOriginal List:");
        PrintIntList(nums);
        List<int> evens = EvenNumbers(nums);
        Console.WriteLine("Even Numbers List:");
        PrintIntList(evens);

        //3
        Console.WriteLine("\nFixedSizeList Demo:");
        FixedSizeList<string> fs = new FixedSizeList<string>(2);
        fs.Add("Hello");
        fs.Add("World");
        Console.WriteLine(fs.Get(0));
        Console.WriteLine(fs.Get(1));
    }
}