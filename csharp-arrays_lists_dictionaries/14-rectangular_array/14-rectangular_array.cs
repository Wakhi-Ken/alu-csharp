using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] array = new int[5, 5]; // 5x5 array, all elements default to 0

        array[2, 2] = 1; // Set the middle element to 1

        // Print the array
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}