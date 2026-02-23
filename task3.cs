using System;

struct ValuePoint
{
    public int X { get; set; }
}

class RefPoint
{
    public int X { get; set; }
}

class Student
{
    public string Name { get; set; }
}

class Car
{
    public string Model { get; set; }
}

class Book
{
    public void Read()
    {
        Console.WriteLine("Reading book...");
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1: Modify Me (Value vs Reference)");
            Console.WriteLine("2: Identity Crisis (Reference Equality)");
            Console.WriteLine("3: Swap Mystery (ref)");
            Console.WriteLine("4: Shallow Copy vs Assignment");
            Console.WriteLine("5: Null Reference Trap");
            Console.WriteLine("0: Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            if (choice == "0") break;

            switch (choice)
            {
                case "1": Task1(); break;
                case "2": Task2(); break;
                case "3": Task3(); break;
                case "4": Task4(); break;
                case "5": Task5(); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
    static void Modify(ValuePoint vp, RefPoint rp)
    {
        vp.X = 100;
        rp.X = 100;
    }

    static void Task1()
    {
        ValuePoint vp = new ValuePoint { X = 10 };
        RefPoint rp = new RefPoint { X = 10 };

        Modify(vp, rp);

        Console.WriteLine("ValuePoint: " + vp.X);
        Console.WriteLine("RefPoint: " + rp.X);
    }

    static void Task2()
    {
        Student s1 = new Student { Name = "Ali" };
        Student s2 = new Student { Name = "Ali" };
        Student s3 = s1;

        Console.WriteLine("s1 == s2 ? " + (s1 == s2));
        Console.WriteLine("s1 == s3 ? " + (s1 == s3));
    }

    static void Swap(int a, int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void Task3()
    {
        int x = 5, y = 9;

        Swap(x, y);
        Console.WriteLine($"After Swaping x and y: x={x}, y={y}");

        Swap(ref x, ref y);
        Console.WriteLine($"After Swaping ref x and ref y: x={x}, y={y}");
    }

    static void Task4()
    {
        Car car1 = new Car { Model = "Toyota" };
        Car car2 = car1;
        car2.Model = "Tesla";

        Console.WriteLine("Car 1 model: " + car1.Model);
        Console.WriteLine("Car 2 model: " + car2.Model);
    }

    static void Task5()
    {
        Book myBook = null;

        try
        {
            myBook.Read();
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("NULL.");
        }
        myBook = new Book();
        myBook.Read();
    }
}