using System;
using System.Collections.Generic;

class LList
{
    public static void Delete(LinkedList<int> myLList, int index)
    {
        if (index < 0 || index >= myLList.Count)
            return; // invalid index

        LinkedListNode<int> current = myLList.First;
        int i = 0;

        while (current != null && i < index)
        {
            current = current.Next;
            i++;
        }

        if (current != null)
            myLList.Remove(current);
    }
}