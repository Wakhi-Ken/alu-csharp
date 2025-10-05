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
        if (aStack.Count > 0)
            Console.WriteLine($"Top item: {aStack.Peek()}");
        else
            Console.WriteLine("Stack is empty");

        // Check if contains search item
        bool containsSearch = aStack.Contains(search);
        Console.WriteLine($"Stack contains \"{search}\": {containsSearch}");

        // Remove items up to and including search without using Pop in a loop
        if (containsSearch)
        {
            // Enumerate items from top to bottom without mutating the original stack
            List<string> itemsTopToBottom = new List<string>(aStack);
            int idx = itemsTopToBottom.IndexOf(search);

            // Keep only items that are below the searched element
            List<string> keep = new List<string>();
            if (idx >= 0)
            {
                for (int i = idx + 1; i < itemsTopToBottom.Count; i++)
                    keep.Add(itemsTopToBottom[i]);
            }
            else
            {
                keep = itemsTopToBottom;
            }

            // Rebuild the original stack with the kept items
            aStack.Clear();
            for (int i = keep.Count - 1; i >= 0; i--)
                aStack.Push(keep[i]);
        }

        // Add new item
        aStack.Push(newItem);

        return aStack;
    }
}


