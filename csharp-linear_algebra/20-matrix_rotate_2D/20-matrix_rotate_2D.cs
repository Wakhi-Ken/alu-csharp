using System;

public class MatrixMath
{
    /// <summary>
    /// Rotates a 2x2 matrix by a given angle in radians.
    /// Each column is treated as a vector (x, y) and rotated.
    /// </summary>
    /// <param name="matrix">The 2x2 matrix to rotate.</param>
    /// <param name="angle">The rotation angle in radians.</param>
    /// <returns>
    /// The resulting rotated 2x2 matrix.
    /// If the matrix is not 2x2, returns a matrix containing -1.
    /// </returns>
    public static double[,] Rotate2D(double[,] matrix, double angle)
    {
        if (matrix == null || matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
            return new double[,] { { -1 } };

        double cos = Math.Cos(angle);
        double sin = Math.Sin(angle);

        double[,] result = new double[2, 2];

        // Rotate each vector (column)
        result[0, 0] = Math.Round(matrix[0, 0] * cos - matrix[1, 0] * sin, 2);
        result[1, 0] = Math.Round(matrix[0, 0] * sin + matrix[1, 0] * cos, 2);

        result[0, 1] = Math.Round(matrix[0, 1] * cos - matrix[1, 1] * sin, 2);
        result[1, 1] = Math.Round(matrix[0, 1] * sin + matrix[1, 1] * cos, 2);

        return result;
    }
}
