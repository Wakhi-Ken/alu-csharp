using System;

public class VectorMath
{
    /// <summary>
    /// Calculates the cross product of two 3D vectors.
    /// </summary>
    /// <param name="vector1">The first 3D vector.</param>
    /// <param name="vector2">The second 3D vector.</param>
    /// <returns>
    /// The resulting 3D vector from the cross product.
    /// If either vector is not 3D, returns a vector containing -1.
    /// </returns>
    public static double[] CrossProduct(double[] vector1, double[] vector2)
    {
        if (vector1 == null || vector2 == null || vector1.Length != 3 || vector2.Length != 3)
            return new double[] { -1 };

        double[] result = new double[3];
        result[0] = vector1[1] * vector2[2] - vector1[2] * vector2[1];
        result[1] = vector1[2] * vector2[0] - vector1[0] * vector2[2];
        result[2] = vector1[0] * vector2[1] - vector1[1] * vector2[0];

        return result;
    }
}
