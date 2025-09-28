using System;

public class Array
{
    public static void ReplaceElement(int[] array, int index, int newValue)
    {
        if (array == null)
        {
            Console.WriteLine("Array is null");
            return;
        }

        if (index < 0 || index >= array.Length)
        {
            Console.WriteLine("Index out of range");
            return;
        }

        array[index] = newValue;
    }
}