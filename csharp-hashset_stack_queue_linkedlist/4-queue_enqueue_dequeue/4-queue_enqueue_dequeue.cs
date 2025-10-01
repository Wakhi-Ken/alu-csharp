using System;
using System.Collections.Generic;

class MyQueue
{
    public static Queue<string> Info(Queue<string> aQueue, string newItem, string search)
    {
        // If empty
        if (aQueue.Count == 0)
        {
            Console.WriteLine("Queue is empty");
        }
        else
        {
            Console.WriteLine($"Number of items: {aQueue.Count}");
            Console.WriteLine($"First item: {aQueue.Peek()}");
        }

        // Add the new item
        aQueue.Enqueue(newItem);

        // Check if contains
        bool contains = aQueue.Contains(search);
        Console.WriteLine($"Queue contains \"{search}\": {contains}");

        // If contains, remove all items up to and including 'search'
        if (contains)
        {
            Queue<string> temp = new Queue<string>();

            // Use Dequeue() only once, but loop over original queue
            string[] arr = aQueue.ToArray();
            bool found = false;

            foreach (string item in arr)
            {
                if (!found)
                {
                    if (item == search)
                        found = true; // stop skipping after search
                }
                else
                {
                    temp.Enqueue(item);
                }
            }

            aQueue.Clear();
            foreach (var item in temp)
                aQueue.Enqueue(item);
        }

        return aQueue;
    }
}
