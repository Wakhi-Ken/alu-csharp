using System;
using System.Collections.Generic;

public class MyQueue
{
    public static void Info(Queue<string> aQueue, string search1, string search2)
    {
        if (aQueue == null) return; // null-safety

        int count = aQueue.Count;
        Queue<string> tempQueue = new Queue<string>();

        for (int i = 0; i < count; i++)
        {
            string item = aQueue.Dequeue();

            if (item == search1 || item == search2)
            {
                Console.WriteLine($"Found: {item}");
            }

            tempQueue.Enqueue(item);
        }

        // Restore original queue
        while (tempQueue.Count > 0)
        {
            aQueue.Enqueue(tempQueue.Dequeue());
        }
    }
}