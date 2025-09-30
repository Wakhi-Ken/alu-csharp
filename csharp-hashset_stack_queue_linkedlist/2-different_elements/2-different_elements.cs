using System;
using System.Collections.Generic;

public class List
{
    public static List<int> DifferentElements(List<int> list1, List<int> list2)
    {
        List<int> result = new List<int>();

        // Add elements from list1 not in list2
        foreach (int item in list1)
        {
            if (!list2.Contains(item))
                result.Add(item);
        }

        // Add elements from list2 not in list1
        foreach (int item in list2)
        {
            if (!list1.Contains(item))
                result.Add(item);
        }

        // Sort result before returning
        result.Sort();

        return result;
    }
}