using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1: Value type by value vs by reference");
            Console.WriteLine("2: Reference type by value vs by reference");
            Console.WriteLine("3: Function: sum & subtract");
            Console.WriteLine("4: Sum of digits");
            Console.WriteLine("5: IsPrime");
            Console.WriteLine("6: MinMaxArray");
            Console.WriteLine("7: Factorial");
            Console.WriteLine("8: ChangeChar");
            Console.WriteLine("9: Second largest in array");
            Console.WriteLine("10: Longest distance between equal values");
            Console.WriteLine("18: Copying array to another");
            Console.WriteLine("19: Printing array in reverse");
            Console.WriteLine("0: Exit");
            Console.Write("Enter your choice: ");

            string C = Console.ReadLine();
            if (C == "0") break;

            switch (C)
            {
                case "1": VvsR(); break;
                case "2": RVvsRR(); break;
                case "3": sum_subtract(); break;
                case "4": sumation(); break;
                case "5": prime(); break;
                case "6": MMarray(); break;
                case "7": factorial(); break;
                case "8": Cchar(); break;
                case "9": scndlargest(); break;
                case "10": longest_distance(); break;
                case "18": copyA(); break;
                case "19": reverseA(); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    //1
    static void valueincr(int x) { x++; }
    static void referenceincr(ref int x) { x++; }

    static void VvsR()
    {
        int a = 10;
        valueincr(a);
        Console.WriteLine("After Incrementing by the value a= " + a);

        referenceincr(ref a);
        Console.WriteLine("After Incrementing by reference a= " + a);
        Console.WriteLine(" ");
    }

    //2
    class Box { public int Value; }

    static void ChangeValue(Box b) { b.Value = 999; }
    static void reassign(Box b) { b = new Box { Value = 50 }; }
    static void referencereassign(ref Box b) { b = new Box { Value = 50 }; }

    static void RVvsRR()
    {
        Box b = new Box { Value = 10 };

        ChangeValue(b);
        Console.WriteLine("After changing value= " + b.Value);

        reassign(b);
        Console.WriteLine("After reassigning= " + b.Value);

        referencereassign(ref b);
        Console.WriteLine("After reference reassigning= " + b.Value);
        Console.WriteLine(" ");
    }

    //3
    static void sum_subtract()
    {
        Console.Write("Enter a: "); int a = int.Parse(Console.ReadLine());
        Console.Write("Enter b: "); int b = int.Parse(Console.ReadLine());
        Console.Write("Enter c: "); int c = int.Parse(Console.ReadLine());
        Console.Write("Enter d: "); int d = int.Parse(Console.ReadLine());
        int sum = a + b;
        int sub = c - d;

        Console.WriteLine("Sum= " + sum);
        Console.WriteLine("Difference= " + sub);
        Console.WriteLine(" ");
    }

    //4
    static void sumation()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        int temp = n;
        if (temp < 0)
        {
            temp = -temp;
        }
        int sum = 0;
        while (temp > 0)
        {
            sum += temp % 10;
            temp /= 10;
        }

        Console.WriteLine("The sum of the values of the number " + n + " is: " + sum);
        Console.WriteLine(" ");
    }

    //5
    static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        for (int i = 3; i * i <= n; i += 2)
            if (n % i == 0) return false;

        return true;
    }

    static void prime()
    {
        Console.Write("Enter integer: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(IsPrime(n) ? "Prime" : "Not prime");
        Console.WriteLine(" ");
    }

    //6
    static void MinMaxArray(int[] arr, ref int min, ref int max)
    {
        min = arr[0];
        max = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min) min = arr[i];
            if (arr[i] > max) max = arr[i];
        }
    }

    static void MMarray()
    {
        int[] arr = ReadIntArray();
        int min = 0, max = 0;

        MinMaxArray(arr, ref min, ref max);

        Console.WriteLine("Minimum = " + min);
        Console.WriteLine("Maximum = " + max);
        Console.WriteLine(" ");
    }

    //7
    static long Factorial(int n)
    {
        if (n < 0) return -1;
        long result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;
        return result;
    }

    static void factorial()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        long f = Factorial(n);
        if (f < 0) Console.WriteLine("Factorial not defined for negative numbers.");
        else Console.WriteLine("Factorial = " + f);
        Console.WriteLine(" ");
    }

    //8
    static string ChangeChar(string s, int position, char newChar)
    {
        if (string.IsNullOrEmpty(s)) return s;
        if (position < 0 || position >= s.Length) return s;

        char[] chars = s.ToCharArray();
        chars[position] = newChar;
        return new string(chars);
    }

    static void Cchar()
    {
        Console.Write("Enter string: ");
        string s = Console.ReadLine();

        Console.Write("Position (0-based): ");
        int pos = int.Parse(Console.ReadLine());

        Console.Write("New character: ");
        string input = Console.ReadLine();
        char ch = input.Length > 0 ? input[0] : 'X';

        Console.WriteLine("Result: " + ChangeChar(s, pos, ch));
        Console.WriteLine(" ");
    }

    //9
    static void scndlargest()
    {
        int[] arr = ReadIntArray();
        if (arr.Length < 2)
        {
            Console.WriteLine("Need at least 2 elements.");
            return;
        }

        int largest = int.MinValue;
        int second = int.MinValue;

        foreach (int x in arr)
        {
            if (x > largest)
            {
                second = largest;
                largest = x;
            }
            else if (x > second && x < largest)
            {
                second = x;
            }
        }

        if (second == int.MinValue)
            Console.WriteLine("No second largest found.");
        else
            Console.WriteLine("Second largest= " + second);
        Console.WriteLine(" ");
    }

    //10
    static void longest_distance()
    {
        int[] arr = ReadIntArray();
        int best = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = arr.Length - 1; j > i; j--)
            {
                if (arr[i] == arr[j])
                {
                    int distance = j - i - 1;
                    if (distance > best) best = distance;
                    break;
                }
            }
        }

        Console.WriteLine("Longest distance= " + best);
    }

    //18
    static void copyA()
    {
        Console.Write("Rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Cols: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] a = new int[rows, cols];
        int[,] b = new int[rows, cols];

        Console.WriteLine("Enter elements for first array:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"a[{i},{j}] = ");
                a[i, j] = int.Parse(Console.ReadLine());
            }
        }

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                b[i, j] = a[i, j];

        Console.WriteLine(" Second array (copied):");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write(b[i, j] + " ");
            Console.WriteLine();
        }
    }

    //19
    static void reverseA()
    {
        int[] arr = ReadIntArray();
        Console.WriteLine("Reverse order:");

        for (int i = arr.Length - 1; i >= 0; i--)
            Console.Write(arr[i] +" ");

        Console.WriteLine();
    }

    static int[] ReadIntArray()
    {
        Console.Write("Array size: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"arr[{i}] = ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        return arr;
    }
}