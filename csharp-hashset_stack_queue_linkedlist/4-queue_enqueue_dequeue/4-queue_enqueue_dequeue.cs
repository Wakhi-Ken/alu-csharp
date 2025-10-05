using System;
using System.Collections.Generic;

class MyQueue
{
    public static Queue<string> Info(Queue<string> aQueue, string newItem, string search)
    {
        // 1. Print number of items
        Console.WriteLine("Number of items: " + aQueue.Count);

        // 2. Print first item or empty message
        if (aQueue.Count > 0)
            Console.WriteLine("First item: " + aQueue.Peek());
        else
            Console.WriteLine("Queue is empty");

        // 3. Add new item
        aQueue.Enqueue(newItem);

        // 4. Print if queue contains search
        bool contains = aQueue.Contains(search);
        Console.WriteLine($"Queue contains \"{search}\": {contains}");

        // 5. If contains, remove items up to and including search
        if (contains)
        {
            Queue<string> temp = new Queue<string>();

            string dequeued;
            do
            {
                dequeued = aQueue.Dequeue();  // allowed once per loop
            }
            while (dequeued != search);
        }

        return aQueue;
    }
}

