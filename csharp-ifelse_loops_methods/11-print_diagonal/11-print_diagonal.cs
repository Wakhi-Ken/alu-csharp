using System;

public class PrintLine
{
    public static void PrintDiagonal(int d)
    {
        if (d > 0)
        {
            for (int i = 0; i < d; i++)
            {
                for (int l = 0; l < i; l++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine('\\');
            }
        }
        else
        {
            Console.WriteLine();
        }
    }
}