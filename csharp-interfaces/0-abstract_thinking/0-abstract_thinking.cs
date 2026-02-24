using System;

public abstract class Base
{
    // Initialize to avoid CS8618 warning
    public string name { get; set; } = "";

    public override string ToString()
    {
        return $"{name} is a {GetType().Name}";
    }
}