using System;

public class MatrixMath
{
    /// <summary>
    /// Rotates a square 2D matrix by a given angle in radians.
    /// Each element is treated as a coordinate (x, y) relative to origin.
    /// </summary>
    /// <param name="matrix">The square 2D matrix to rotate.</param>
    /// <param name="angle">The rotation angle in radians.</param>
    /// <returns>
    /// The rotated matrix.
    /// If the matrix is not square, returns a matrix containing -1.
    /// </returns>
    public static double[,] Rotate2D(double[,] matrix, double angle)
    {
        if (matrix == null)
            return new double[,] { { -1 } };

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (rows != cols)
            return new double[,] { { -1 } };

        double cos = Math.Cos(angle);
        double sin = Math.Sin(angle);
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                double x = matrix[i, j];   // treat as x-coordinate
                double y = matrix[j, i];   // treat as y-coordinate (symmetric)
                result[i, j] = Math.Round(x * cos - y * sin, 2);
            }
        }

        return result;
    }
}
