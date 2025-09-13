using System;

class Program
{
    static void Main(string[] args)
    {
        Random rndm = new Random();
        int number = rndm.Next(-10000, 10000);

        int lastDigit = Math.Abs(number % 10);

        string output = $"The last digit of {number} is {number % 10} and ";

        if (lastDigit > 5)
        {
            output += "is greater than 5";
        }
        else if (lastDigit == 0)
        {
            output += "is 0";
        }
        else
        {
            output += "is less than 6 and not 0";
        }
        Console.WriteLine(output);
        
    }
}