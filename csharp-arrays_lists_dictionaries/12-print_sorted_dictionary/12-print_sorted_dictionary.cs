using System;
using System.Collections.Generic;

public class Dictionary
{
    public static void PrintSorted(Dictionary<string, string> myDict)
    {
        // Extract keys into a list
        List<string> keys = new List<string>(myDict.Keys);

        // Sort the keys
        keys.Sort();

        // Print each key-value pair in sorted order
        foreach (string key in keys)
        {
            Console.WriteLine($"{key}: {myDict[key]}");
        }
    }
}
