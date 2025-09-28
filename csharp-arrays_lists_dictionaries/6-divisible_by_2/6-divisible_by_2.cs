using System;
using System.Collections.Generic;

public class List
{
    public static List<bool> DivisibleBy2(List<int> myList)
    {
        List<bool> result = new List<bool>();

        foreach (int number in myList)
        {
            if (number % 2 == 0)
                result.Add(true);
            else
                result.Add(false);
        }

        return result;
    }
}