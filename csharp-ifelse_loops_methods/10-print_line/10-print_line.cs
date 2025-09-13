using System;

public class Line
{
    public static void PrintLine(int n)
    {
        if (n > 0)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write('_');
            }
        }
        Console.WriteLine();
    }
}