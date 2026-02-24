using System;

// Delegate prototype
public delegate void CalculateHealth(float amount);

public class Player
{
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

    // Print health
    public void PrintHealth()
    {
        Console.WriteLine($"{name} has {hp} / {maxHp} health");
    }

    // Validate new HP
    public void ValidateHP(float newHp)
    {
        if (newHp < 0f)
            hp = 0f;
        else if (newHp > maxHp)
            hp = maxHp;
        else
            hp = newHp;
    }

    // Take damage
    public void TakeDamage(float damage)
    {
        if (damage < 0f)
            damage = 0f;

        Console.WriteLine($"{name} takes {damage} damage!");
        float newHp = hp - damage;
        ValidateHP(newHp);
    }

    // Heal damage
    public void HealDamage(float heal)
    {
        if (heal < 0f)
            heal = 0f;

        Console.WriteLine($"{name} heals {heal} HP!");
        float newHp = hp + heal;
        ValidateHP(newHp);
    }
}