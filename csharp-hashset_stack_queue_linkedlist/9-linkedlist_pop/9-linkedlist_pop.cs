using System;
using System.Collections.Generic;

class LList
{
    // Method that deletes the head node and returns its value
    public static int Pop(LinkedList<int> myLList)
    {
        // Check if the list is empty
        if (myLList.First == null)
            return 0;

        // Store the value of the head node
        int value = myLList.First.Value;

        // Remove the head node
        myLList.RemoveFirst();

        return value;
    }
}
