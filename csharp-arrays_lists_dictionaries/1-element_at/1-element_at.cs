using System;

public class Array
{
    public static int elementAt(int[] array, int index)
    {
        if (array == null)
        {
            Console.WriteLine("Array is null");
            return -1;
        }

        if (index < 0 || index >= array.Length)
        {
            Console.WriteLine("Index out of range");
            return -1;
        }

        return array[index];
    }
}