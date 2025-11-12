using System;

public class VectorMath
{
    public static double Magnitude(double[] vector)
    {
        if (vector == null || (vector.Length != 2 && vector.Length != 3))
            return -1;

        double sumSquares = 0;
        foreach (double component in vector)
        {
            sumSquares += component * component;
        }

        double length = Math.Sqrt(sumSquares);
        return Math.Round(length, 2);
    }
}
