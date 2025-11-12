using System;

public class MatrixMath
{
    /// <summary>
    /// Shears a square 2D matrix by a given shear factor in either X or Y direction.
    /// </summary>
    /// <param name="matrix">The square 2D matrix to shear.</param>
    /// <param name="direction">'x' for X direction, 'y' for Y direction.</param>
    /// <param name="factor">The shear factor.</param>
    /// <returns>
    /// The resulting sheared matrix.
    /// If the matrix is not square or the direction is invalid, returns a matrix containing -1.
    /// </returns>
    public static double[,] Shear2D(double[,] matrix, char direction, double factor)
    {
        if (matrix == null)
            return new double[,] { { -1 } };

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (rows != cols)
            return new double[,] { { -1 } };

        if (direction != 'x' && direction != 'y')
            return new double[,] { { -1 } };

        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (direction == 'x')
                {
                    // Shear in X direction: newValue = original + factor * rowIndex
                    result[i, j] = matrix[i, j] + factor * i;
                }
                else // direction == 'y'
                {
                    // Shear in Y direction: newValue = original + factor * colIndex
                    result[i, j] = matrix[i, j] + factor * j;
                }
            }
        }

        return result;
    }
}
