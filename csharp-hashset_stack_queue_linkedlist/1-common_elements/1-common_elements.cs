using System;
using System.Collections.Generic;

public class List
{
    public static List<int> CommonElements(List<int> list1, List<int> list2)
    {
        if (list1 == null || list2 == null) return new List<int>(); // null-safety

        HashSet<int> set1 = new HashSet<int>(list1);
        HashSet<int> commonElements = new HashSet<int>();

        foreach (int number in list2)
        {
            if (set1.Contains(number))
            {
                commonElements.Add(number);
            }
        }

        return new List<int>(commonElements);
    }
}   