using System;

public class Array
{
    public static int[] CreatePrint(int size)
    {
        if (size < 0)
        {
            Console.WriteLine("Size cannot be negative");
            return null;
        }

        if (size == 0)
        {
            Console.WriteLine();
            return new int[0];
        }

        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = i;
            Console.Write(i);
            if (i < size - 1)
                Console.Write(" ");
        }
        Console.WriteLine();
        return arr;
    }
}