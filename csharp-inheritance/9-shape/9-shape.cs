using System;

public class Square : Rectangle
{
    private int size;

    public int Size
    {
        get { return size; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Size must be greater than or equal to 0");
            size = value;
            Width = value;
            Height = value;
        }
    }

    public override string ToString()
    {
        return $"[Square] {size} / {size}";
    }
}
