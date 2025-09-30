using System;
using System.Collections.Generic;

public class List
{
    public static List<int> DifferentElements(List<int> list1, List<int> list2)
    {
        if (list1 == null || list2 == null) return new List<int>(); // null-safety

        HashSet<int> set1 = new HashSet<int>(list1);
        HashSet<int> differentElements = new HashSet<int>(set1);

        foreach (int number in list2)
        {
            if (differentElements.Contains(number))
            {
                differentElements.Remove(number);
            }
            else
            {
                differentElements.Add(number);
            }
        }

        return new List<int>(differentElements);
    }
}