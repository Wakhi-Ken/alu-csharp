using System;
using System.Collections.Generic;

public class MyStack
{
    public static Stack<string> Info(Stack<string> aStack, string newItem, string search)
    {
        if (aStack == null)
            aStack = new Stack<string>();

        // Number of items
        Console.WriteLine($"Number of items: {aStack.Count}");

        // Top item
        string? topItem = aStack.Count > 0 ? aStack.Peek() : null;
        Console.WriteLine(topItem != null ? $"Top item: {topItem}" : "Stack is empty");

        // Check if contains search item
        bool containsSearch = aStack.Contains(search);
        Console.WriteLine($"Stack contains \"{search}\": {containsSearch}");

        // Remove items up to and including search
        if (containsSearch)
        {
            Stack<string> tempStack = new Stack<string>();
            bool found = false;

            while (aStack.Count > 0)
            {
                string item = aStack.Pop();
                if (item == search)
                {
                    found = true;
                    break;
                }
                else
                {
                    tempStack.Push(item);
                }
            }

            while (tempStack.Count > 0)
            {
                aStack.Push(tempStack.Pop());
            }
        }

        // Add new item
        aStack.Push(newItem);

        return aStack;
    }
}