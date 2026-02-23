using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1: Temperature (ternary): Cold/Hot/Good");
            Console.WriteLine("2: Divisible by 3 and 4");
            Console.WriteLine("3: Negative or Positive");
            Console.WriteLine("4: Max & Min of 3 integers");
            Console.WriteLine("5: Month number -> days");
            Console.WriteLine("6: Vowel or Consonant");
            Console.WriteLine("0: Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();
            if (choice == "0") break;

            switch (choice)
            {
                case "1": temp(); break;
                case "2": div(); break;
                case "3": neg(); break;
                case "4": maxmin(); break;
                case "5": month(); break;
                case "6": vowel(); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void temp()
    {
        Console.Write("Enter temperature: ");
        int t = int.Parse(Console.ReadLine());

        string result = (t < 10) ? "Just Cold"
                      : (t > 30) ? "Just Hot"
                      : "Just Good";
        Console.WriteLine(result);
    }

    static void div()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine((n % 3 == 0 && n % 4 == 0) ? "Yes" : "No");
    }

    static void neg()
    {
        Console.Write("Enter integer: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(n < 0 ? "negative" : "positive");
    }

    static void maxmin()
    {
        Console.Write("Enter first: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter second: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter third: ");
        int c = int.Parse(Console.ReadLine());

        int max = a;
        if (b > max) max = b;
        if (c > max) max = c;
        int min = a;
        if (b < min) min = b;
        if (c < min) min = c;

        Console.WriteLine("max element = " + max);
        Console.WriteLine("min element = " + min);
    }

    static void month()
    {
        Console.Write("Month Number (1-12): ");
        int m = int.Parse(Console.ReadLine());

        int days =
            (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12) ? 31 :
            (m == 4 || m == 6 || m == 9 || m == 11) ? 30 :
            (m == 2) ? 28 : 0;

        if (days == 0) Console.WriteLine("Invalid month!");
        else Console.WriteLine("Days in Month: " + days);
    }

    static void vowel()
    {
        Console.Write("Enter a character: ");
        string s = Console.ReadLine();

        if (s.Length == 0)
        {
            Console.WriteLine("Invalid input");
            return;
        }

        char ch = char.ToLower(s[0]);
        bool isVowel = (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u');
        Console.WriteLine(isVowel ? "vowel" : "consonant");
    }
}