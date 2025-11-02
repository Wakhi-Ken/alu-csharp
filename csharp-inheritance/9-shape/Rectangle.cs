using System;

/// <summary>
/// Represents a rectangle shape.
/// </summary>
class Rectangle : Shape
{
    /// <summary>
    /// Gets or sets the width of the rectangle.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the rectangle.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Calculates the area of the rectangle.
    /// </summary>
    public override int Area()
    {
        return Width * Height;
    }

    /// <summary>
    /// Returns a string representation of the rectangle.
    /// </summary>
    public override string ToString()
    {
        return $"[Rectangle] {Width} / {Height}";
    }
}
