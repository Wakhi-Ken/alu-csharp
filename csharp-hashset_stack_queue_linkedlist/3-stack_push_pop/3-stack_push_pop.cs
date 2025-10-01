using System;
using System.Collections.Generic;

class MyStack
{
    public static Stack<string> Info(Stack<string> aStack, string newItem, string search)
    {
        // Print number of items
        Console.WriteLine($"Number of items: {aStack.Count}");

        // Check if stack is empty
        if (aStack.Count == 0)
        {
            Console.WriteLine("Stack is empty");
        }
        else
        {
            // Print top item without removing
            Console.WriteLine($"Top item: {aStack.Peek()}");
        }

        // Print whether stack contains the search
        bool contains = aStack.Contains(search);
        Console.WriteLine($"Stack contains \"{search}\": {contains}");

        // Only if stack contains search, we must remove up to and including search
        if (contains)
        {
            // Convert stack to array (top element first)
            string[] arr = aStack.ToArray();

            // Find index of search in array
            int index = Array.IndexOf(arr, search);

            // Rebuild the stack by skipping elements up to and including search
            Stack<string> newStack = new Stack<string>();
            for (int i = arr.Length - 1; i > index; i--)
            {
                newStack.Push(arr[i]);
            }

            aStack = newStack; // Replace the old stack
        }

        // Add the new item
        aStack.Push(newItem);

        return aStack;
    }
}
