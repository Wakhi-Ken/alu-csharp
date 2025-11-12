using System;

public class MatrixMath
{
    /// <summary>
    /// Transposes a given matrix and returns the resulting matrix.
    /// </summary>
    /// <param name="matrix">The matrix to transpose.</param>
    /// <returns>
    /// The transposed matrix.
    /// If the input matrix is empty, returns an empty matrix.
    /// </returns>
    public static double[,] Transpose(double[,] matrix)
    {
        if (matrix == null || matrix.Length == 0)
            return new double[0, 0];

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        double[,] result = new double[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[j, i] = matrix[i, j];
            }
        }

        return result;
    }
}
