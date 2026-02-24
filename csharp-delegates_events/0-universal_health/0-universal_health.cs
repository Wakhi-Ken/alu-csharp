using System;

public class Player
{
    // Private fields to prevent direct access
    private string name;
    private float maxHp;
    private float hp;

    // Constructor
    public Player(string name = "Player", float maxHp = 100f)
    {
        if (maxHp <= 0f)
        {
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
            maxHp = 100f;
        }

        this.name = name;
        this.maxHp = maxHp;
        this.hp = maxHp;
    }

    // PrintHealth method
    public void PrintHealth()
    {
        Console.WriteLine($"{name} has {hp} / {maxHp} health");
    }
}