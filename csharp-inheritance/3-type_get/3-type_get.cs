using System;
using System.Reflection;

public class Obj
{
    public static void Print(object myObj)
    {
        Type type = myObj.GetType();

        Console.WriteLine($"{type.Name} Properties:");
        foreach (PropertyInfo prop in type.GetProperties())
        {
            Console.WriteLine(prop.Name);
        }

        Console.WriteLine($"{type.Name} Methods:");
        foreach (MethodInfo method in type.GetMethods())
        {
            Console.WriteLine(method.Name);
        }
    }
}
