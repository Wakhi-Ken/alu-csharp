using System;
using System.Collections.Generic;

public class MyStack
{
    public static Stack<string> Info(Stack<string> aStack, string newItem, string search)
    {
        // Print number of items
        Console.WriteLine("Number of items: " + aStack.Count);

        // Print top item or empty message
        if (aStack.Count > 0)
        {
            Console.WriteLine("Top item: " + aStack.Peek());
        }
        else
        {
            Console.WriteLine("Stack is empty");
        }

        // Check if stack contains search
        bool contains = aStack.Contains(search);
        Console.WriteLine($"Stack contains \"{search}\": {contains}");

        if (contains)
        {
            // Pop once and store
            string popped = aStack.Pop();

            // Keep popping until we removed search
            while (popped != search && aStack.Count > 0)
            {
                popped = aStack.Pop();
            }
        }

        // Push new item
        aStack.Push(newItem);

        return aStack;
    }
}
