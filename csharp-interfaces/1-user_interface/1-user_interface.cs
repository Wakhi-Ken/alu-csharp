using System;

public interface IInteractive
{
    void Interact();
}

public interface IBreakable
{
    int durability { get; set; }
    void Break();
}

public interface ICollectable
{
    bool isCollected { get; set; }
    void Collect();
}

public class TestObject : Base, IInteractive, IBreakable, ICollectable
{
    // IBreakable property
    public int durability { get; set; }

    // ICollectable property
    public bool isCollected { get; set; }

    // IInteractive method
    public void Interact()
    {
        // Not implemented
    }

    // IBreakable method
    public void Break()
    {
        // Not implemented
    }

    // ICollectable method
    public void Collect()
    {
        // Not implemented
    }
}