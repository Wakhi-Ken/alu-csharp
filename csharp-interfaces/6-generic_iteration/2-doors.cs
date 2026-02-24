using System;

public class Door : Base, IInteractive
{
    // Constructor with optional parameter
    public Door(string name = "Door")
    {
        this.name = name;
    }

    // Implement Interact
    public void Interact()
    {
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}