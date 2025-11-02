using NUnit.Framework;
using MyMath;

namespace MyMath.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="Operations"/> class.
    /// </summary>
    public class OperationsTests
    {
        /// <summary>
        /// Tests that adding two positive integers returns the correct sum.
        /// </summary>
        [Test]
        public void Add_PositiveIntegers_ReturnsSum()
        {
            Assert.AreEqual(5, Operations.Add(2, 3));
        }

        /// <summary>
        /// Tests that adding two negative integers returns the correct sum.
        /// </summary>
        [Test]
        public void Add_NegativeIntegers_ReturnsSum()
        {
            Assert.AreEqual(-5, Operations.Add(-2, -3));
        }

        /// <summary>
        /// Tests that adding a positive and a negative integer returns the correct sum.
        /// </summary>
        [Test]
        public void Add_PositiveAndNegative_ReturnsSum()
        {
            Assert.AreEqual(1, Operations.Add(3, -2));
        }

        /// <summary>
        /// Tests that adding zero to a number returns the same number.
        /// </summary>
        [Test]
        public void Add_NumberAndZero_ReturnsSameNumber()
        {
            Assert.AreEqual(7, Operations.Add(7, 0));
        }

        /// <summary>
        /// Tests that adding zero to zero returns zero.
        /// </summary>
        [Test]
        public void Add_ZeroAndZero_ReturnsZero()
        {
            Assert.AreEqual(0, Operations.Add(0, 0));
        }
    }
}
