using System;

class Program
{
    static void Main()
    {
        for (int i = 0; i < 100; i++)
        {
         if (i < 99)
         Console.Write(", ");
         Console.Write($"{i:D2}");
        }
    }
}