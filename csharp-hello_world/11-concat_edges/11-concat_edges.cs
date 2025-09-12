class Program
{
    static void Main(string[] args)
    {
        string str = "C# (pronounced \"See Sharp\") is a simple, modern, object-oriented, and type-safe programming language. C# has its roots in the C family of languages and will be immediately familiar to C, C++, Java, and JavaScript programmers.";
        string result = str.Substring(49, 15); // Extract "object-oriented
        string Prog = str.Substring(79, 12); // Extract "programming"
        string language = str.Substring(0, 2); // Extract "C#"
        Console.WriteLine($"{result} {Prog} in {language}");
    }
}