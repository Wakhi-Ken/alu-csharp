using System;

/// <summary>
/// Represents a square shape, inheriting from Rectangle.
/// </summary>
class Square : Rectangle
{
    private int size;

    /// <summary>
    /// Gets or sets the size of the square sides.
    /// Setting the size updates both Width and Height.
    /// </summary>
    /// <exception cref="ArgumentException">
    /// Thrown when value is less than 0.
    /// </exception>
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

    /// <summary>
    /// Returns a string representation of the square.
    /// </summary>
    public override string ToString()
    {
        return $"[Square] {size} / {size}";
    }
}
