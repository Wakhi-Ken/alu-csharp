using System;
using System.Collections.Generic;

public class Except
{
    public static void Throw()
    {
        List<int> myList = new List<int>();

        try
        {
            Console.WriteLine(myList[0]);
        }
        catch (ArgumentOutOfRangeException e)
        {
            throw e;
        }
    }
}