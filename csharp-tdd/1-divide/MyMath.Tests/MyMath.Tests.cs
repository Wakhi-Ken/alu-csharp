using NUnit.Framework;
using MyMath;

namespace MyMath.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="Matrix"/> class.
    /// </summary>
    [TestFixture]
    public class MatrixTests
    {
        /// <summary>
        /// Tests that dividing a matrix with positive integers
        /// by a positive number returns the expected result.
        /// </summary>
        [Test]
        public void Divide_PositiveMatrix_ReturnsCorrectResult()
        {
            int[,] mat = { { 4, 8 }, { 6, 12 } };
            int[,] expected = { { 2, 4 }, { 3, 6 } };

            int[,] result = Matrix.Divide(mat, 2);

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests that dividing a matrix by zero prints
        /// a message and returns <c>null</c>.
        /// </summary>
        [Test]
        public void Divide_ByZero_PrintsMessageAndReturnsNull()
        {
            int[,] mat = { { 1, 2 }, { 3, 4 } };

            int[,] result = Matrix.Divide(mat, 0);

            Assert.IsNull(result);
        }

        /// <summary>
        /// Tests that passing a <c>null</c> matrix returns <c>null</c>.
        /// </summary>
        [Test]
        public void Divide_NullMatrix_ReturnsNull()
        {
            int[,] mat = null;

            int[,] result = Matrix.Divide(mat, 2);

            Assert.IsNull(result);
        }
    }
}
