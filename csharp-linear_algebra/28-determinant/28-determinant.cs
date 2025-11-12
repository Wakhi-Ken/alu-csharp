using System;

public class MatrixMath
{
    /// <summary>
    /// Calculates the determinant of a 2x2 or 3x3 matrix.
    /// </summary>
    /// <param name="matrix">The matrix to calculate the determinant of.</param>
    /// <returns>
    /// The determinant of the matrix.
    /// If the matrix is not 2x2 or 3x3, returns -1.
    /// </returns>
    public static double Determinant(double[,] matrix)
    {
        if (matrix == null)
            return -1;

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (rows != cols || (rows != 2 && rows != 3))
            return -1;

        if (rows == 2)
        {
            // 2x2 determinant: ad - bc
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }
        else // 3x3
        {
            double a = matrix[0, 0], b = matrix[0, 1], c = matrix[0, 2];
            double d = matrix[1, 0], e = matrix[1, 1], f = matrix[1, 2];
            double g = matrix[2, 0], h = matrix[2, 1], i = matrix[2, 2];

            // 3x3 determinant formula
            return a * (e * i - f * h) 
                 - b * (d * i - f * g) 
                 + c * (d * h - e * g);
        }
    }
}
