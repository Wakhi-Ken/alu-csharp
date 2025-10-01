using System;
using System.Collections.Generic;

class LList
{
    public static LinkedListNode<int> Insert(LinkedList<int> myLList, int n)
    {
        // If the list is empty or n should be at the beginning
        if (myLList.Count == 0 || n <= myLList.First.Value)
            return myLList.AddFirst(n);

        LinkedListNode<int> current = myLList.First;

        // Traverse the list to find the correct position
        while (current.Next != null && current.Next.Value < n)
        {
            current = current.Next;
        }

        // Insert after current
        return myLList.AddAfter(current, n);
    }
}