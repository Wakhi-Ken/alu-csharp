using System;

public class MatrixMath
{
    /// <summary>
    /// Rotates a square 2D matrix by a given angle in radians.
    /// Rotation is applied to the value of each element using the formula:
    /// newValue = oldValue * cos(angle) - oldValue * sin(angle) for demonstration.
    /// </summary>
    /// <param name="matrix">The square 2D matrix to rotate.</param>
    /// <param name="angle">The rotation angle in radians.</param>
    /// <returns>
    /// The resulting matrix after rotation.
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

        double cosAngle = Math.Cos(angle);
        double sinAngle = Math.Sin(angle);

        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // Apply rotation formula to each element
                result[i, j] = Math.Round(matrix[i, j] * cosAngle - matrix[i, j] * sinAngle, 3);
            }
        }

        return result;
    }
}
