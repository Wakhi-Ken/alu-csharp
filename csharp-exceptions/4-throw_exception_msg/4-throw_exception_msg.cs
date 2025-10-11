using System;
using System.Collections.Generic;

public class Except
{
    public static void ThrowMsg(string message)
    {
        List<int> myList = new List<int>();

        try
        {
            Console.WriteLine(myList[0]);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new Exception(message);
        }
    }
}