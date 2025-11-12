using System;

public class VectorMath
{
    /// <summary>
    /// Adds two vectors and returns the resulting vector.
    /// </summary>
    /// <param name="vector1">The first vector (2D or 3D).</param>
    /// <param name="vector2">The second vector (2D or 3D).</param>
    /// <returns>
    /// The resulting vector after addition. 
    /// If any vector is not 2D or 3D, or if the vectors are not the same size, returns a vector containing -1.
    /// </returns>
    public static double[] Add(double[] vector1, double[] vector2)
    {
        if (vector1 == null || vector2 == null)
            return new double[] { -1 };

        if ((vector1.Length != 2 && vector1.Length != 3) ||
            (vector2.Length != 2 && vector2.Length != 3) ||
            vector1.Length != vector2.Length)
        {
            return new double[] { -1 };
        }

        double[] result = new double[vector1.Length];
        for (int i = 0; i < vector1.Length; i++)
        {
            result[i] = vector1[i] + vector2[i];
        }

        return result;
    }
}
