using System;
using System.Collections.Generic;

public class MyStack
{
    public static void Info(Stack<string> stack, string search1, string search2)
    {
        if (stack == null) return; // null-safety

        Stack<string> tempStack = new Stack<string>();
        bool foundSearch1 = false;
        bool foundSearch2 = false;

        while (stack.Count > 0)
        {
            string item = stack.Pop();
            if (item == search1)
                foundSearch1 = true;
            if (item == search2)
                foundSearch2 = true;
            tempStack.Push(item);
        }

        while (tempStack.Count > 0)
        {
            stack.Push(tempStack.Pop());
        }

        Console.WriteLine($"Found '{search1}': {foundSearch1}");
        Console.WriteLine($"Found '{search2}': {foundSearch2}");
    }
}   