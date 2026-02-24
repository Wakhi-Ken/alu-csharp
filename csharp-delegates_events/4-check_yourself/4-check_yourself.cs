using System;

public delegate float CalculateModifier(float baseValue, Modifier modifier);

public enum Modifier
{
    Base,
    Weak,
    Strong
}

/* =========================
   CURRENT HP EVENT ARGS
   ========================= */
public class CurrentHPArgs : EventArgs
{
    public float currentHp { get; }

    public CurrentHPArgs(float newHp)
    {
        currentHp = newHp;
    }
}

/* =========================
   PLAYER CLASS
   ========================= */
public class Player
{
    private string name;
    private float maxHp;
    private float hp;
    private string status { get; set; }

    public event EventHandler<CurrentHPArgs>? HPCheck;

    /* -------- CONSTRUCTOR -------- */
    public Player(string name = "Player")
    {
        this.name = name;

        maxHp = 100f;
        hp = maxHp;

        status = $"{name} is ready to go!";

        HPCheck += CheckStatus;
    }

    /* -------- PRINT HEALTH -------- */
    public void PrintHealth()
    {
        Console.WriteLine($"{name} has {hp} / {maxHp} health");
    }

    /* -------- TAKE DAMAGE -------- */
    public void TakeDamage(float damage)
    {
        if (damage < 0)
            damage = 0;

        Console.WriteLine($"{name} takes {damage} damage!");

        hp -= damage;
        ValidateHP();
    }

    /* -------- HEAL DAMAGE -------- */
    public void HealDamage(float heal)
    {
        if (heal < 0)
            heal = 0;

        Console.WriteLine($"{name} heals {heal} HP!");

        hp += heal;
        ValidateHP();
    }

    /* -------- VALIDATE HP -------- */
    private void ValidateHP()
    {
        if (hp < 0)
            hp = 0;

        if (hp > maxHp)
            hp = maxHp;

        HPCheck?.Invoke(this, new CurrentHPArgs(hp));
    }

    /* -------- CHECK STATUS -------- */
    private void CheckStatus(object? sender, CurrentHPArgs e)
    {
        float currentHp = e.currentHp;

        if (currentHp == maxHp)
            status = $"{name} is in perfect health!";
        else if (currentHp >= maxHp / 2 && currentHp < maxHp)
            status = $"{name} is doing well!";
        else if (currentHp >= maxHp / 4 && currentHp < maxHp / 2)
            status = $"{name} isn't doing too great...";
        else if (currentHp > 0 && currentHp < maxHp / 4)
            status = $"{name} needs help!";
        else if (currentHp == 0)
            status = $"{name} is knocked out!";

        Console.WriteLine(status);
    }

    /* -------- APPLY MODIFIER -------- */
    public float ApplyModifier(float baseValue, Modifier modifier)
    {
        switch (modifier)
        {
            case Modifier.Weak:
                return baseValue * 0.5f;
            case Modifier.Strong:
                return baseValue * 1.5f;
            default:
                return baseValue;
        }
    }
}