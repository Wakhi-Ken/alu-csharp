using System;
using System.Collections.Generic;

public class List
{
    public static int MaxInteger(List<int> myList)
    {
        if (myList == null || myList.Count == 0)
        {
            Console.WriteLine("List is empty or null");
            return 0; // or throw an exception based on requirements
        }

        int max = myList[0];

        foreach (int num in myList)
        {
            if (num > max)
                max = num;
        }

        return max;
    }
}