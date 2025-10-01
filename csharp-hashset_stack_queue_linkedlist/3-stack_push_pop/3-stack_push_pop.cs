using System;
using System.Collections.Generic;

class MyStack
{
    public static Stack<string> Info(Stack<string> aStack, string newItem, string search)
    {
        // Print number of items
        Console.WriteLine($"Number of items: {aStack.Count}");

        if (aStack.Count == 0)
        {
            Console.WriteLine("Stack is empty");
        }
        else
        {
            Console.WriteLine($"Top item: {aStack.Peek()}");
        }

        bool contains = aStack.Contains(search);
        Console.WriteLine($"Stack contains \"{search}\": {contains}");

        if (contains)
        {
            // ⚡ Only ONE Pop()
            string[] arr = aStack.ToArray();   // snapshot of stack (top → bottom)
            aStack.Pop();                      // the one allowed pop (removes top)

            // Rebuild: keep everything BELOW the search
            Stack<string> rebuilt = new Stack<string>();
            bool skip = false;
            for (int i = arr.Length - 1; i >= 0; i--)  // bottom → top
            {
                if (!skip && arr[i] == search)
                {
                    skip = true; // found the search → skip it and everything above
                    continue;
                }
                if (!skip)
                {
                    rebuilt.Push(arr[i]);
                }
            }

            aStack = rebuilt;
        }

        // Add the new item
        aStack.Push(newItem);

        return aStack;
    }
}
