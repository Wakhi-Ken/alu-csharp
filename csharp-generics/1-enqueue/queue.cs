using System;

public class Program
{
    public static void Main()
    {
        Queue<int> q = new Queue<int>();
        
        q.Enqueue(42);
        Console.WriteLine("Number of nodes in queue: " + q.Count());

        q.Enqueue(99);
        Console.WriteLine("Number of nodes in queue: " + q.Count());
        
        // Example of a large queue
        Queue<int> bigQ = new Queue<int>();
        for (int i = 0; i < 3207716; i++)
        {
            bigQ.Enqueue(i);
        }
        Console.WriteLine("Number of nodes in queue: " + bigQ.Count());
    }
}
