using System;

public class Line
{
    public static void PrintLine(int l)
    {
        if (l > 0)
        {
            for (int i = 0; i < l; i++)
            {
                Console.Write('_');
            }
        }
        Console.WriteLine();
    }
}