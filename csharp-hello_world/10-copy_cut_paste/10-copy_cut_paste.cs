using System;

class Program
{
        static void Main(string[] args)
        {
		string word = "Holberton";
		Console.WriteLine("First 3 letters: {0}", word.Substring(0, 3));
		Console.WriteLine("Last 2 letters: {0}", word.Substring(word.Length - 2, 2));
		Console.WriteLine("Middle word: {0}", word.Substring(1, word.Length - 2));
        }
}
