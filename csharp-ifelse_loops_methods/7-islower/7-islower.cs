using System;

public class Character
{
    public static bool IsLower(char c)
    {
        return c >= 'a' && c <= 'z';
    }

    public static void Main()
    {
        Console.WriteLine(IsLower('a')); // True
        Console.WriteLine(IsLower('Z')); // False
        Console.WriteLine(IsLower('g')); // True
        Console.WriteLine(IsLower('1')); // False
    }
}