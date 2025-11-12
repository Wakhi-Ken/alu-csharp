using System;

public class MatrixMath
{
    /// <summary>
    /// Calculates the inverse of a 2x2 matrix.
    /// </summary>
    /// <param name="matrix">The 2x2 matrix to invert.</param>
    /// <returns>
    /// The inverse of the matrix.
    /// If the matrix is not 2x2 or non-invertible, returns a matrix containing -1.
    /// </returns>
    public static double[,] Inverse2D(double[,] matrix)
    {
        if (matrix == null || matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
            return new double[,] { { -1 } };

        double a = matrix[0, 0];
        double b = matrix[0, 1];
        double c = matrix[1, 0];
        double d = matrix[1, 1];

        double det = a * d - b * c;

        if (det == 0)
            return new double[,] { { -1 } };

        double invDet = 1.0 / det;

        double[,] inverse = new double[2, 2];
        inverse[0, 0] =  d * invDet;
        inverse[0, 1] = -b * invDet;
        inverse[1, 0] = -c * invDet;
        inverse[1, 1] =  a * invDet;

        return inverse;
    }
}
