using System;

public class VectorMath
{
    /// <summary>
    /// Multiplies a vector by a scalar and returns the resulting vector.
    /// </summary>
    /// <param name="vector">The vector to multiply (2D or 3D).</param>
    /// <param name="scalar">The scalar value to multiply the vector by.</param>
    /// <returns>
    /// The resulting vector after multiplication. 
    /// If the vector is not 2D or 3D, returns a vector containing -1.
    /// </returns>
    public static double[] Multiply(double[] vector, double scalar)
    {
        if (vector == null || (vector.Length != 2 && vector.Length != 3))
            return new double[] { -1 };

        double[] result = new double[vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            result[i] = vector[i] * scalar;
        }

        return result;
    }
}
