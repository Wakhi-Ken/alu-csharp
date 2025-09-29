using System;
using System.Collections.Generic;

public class List
{
    public static int Sum(List<int> myList)
    {
        if (myList == null) return 0; // null-safety

        HashSet<int> uniqueNumbers = new HashSet<int>();
        int sum = 0;

        foreach (int number in myList)
        {
            if (!uniqueNumbers.Contains(number))
            {
                uniqueNumbers.Add(number);
                sum += number;
            }
        }

        return sum;
    }
}

