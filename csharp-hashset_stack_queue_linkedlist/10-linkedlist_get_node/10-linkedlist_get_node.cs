using System;
using System.Collections.Generic;

class LList
{
    public static int GetNode(LinkedList<int> myLList, int n)
    {
        if (n < 0)
            return 0;

        int index = 0;
        foreach (int value in myLList)
        {
            if (index == n)
                return value;
            index++;
        }

        return 0; // node doesn't exist
    }
}