using NUnit.Framework;
using MyMath;
using System.Collections.Generic;

namespace MyMath.Tests
{
    /// <summary>
    /// Tests for <see cref="Operations"/> class.
    /// </summary>
    [TestFixture]
    public class OperationsTests
    {
        /// <summary>
        /// Returns the maximum integer in a list of positive numbers.
        /// </summary>
        [Test]
        public void Max_PositiveNumbers_ReturnsMax()
        {
            List<int> nums = new() { 1, 5, 3, 2 };
            int result = Operations.Max(nums);
            Assert.AreEqual(5, result);
        }

        /// <summary>
        /// Returns the maximum integer in a list containing negative numbers.
        /// </summary>
        [Test]
        public void Max_NegativeNumbers_ReturnsMax()
        {
            List<int> nums = new() { -2, -5, -1 };
            int result = Operations.Max(nums);
            Assert.AreEqual(-1, result);
        }

        /// <summary>
        /// Returns 0 if the list is empty.
        /// </summary>
        [Test]
        public void Max_EmptyList_ReturnsZero()
        {
            List<int> nums = new();
            int result = Operations.Max(nums);
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Returns the maximum integer in a list with mixed positive and negative numbers.
        /// </summary>
        [Test]
        public void Max_MixedNumbers_ReturnsMax()
        {
            List<int> nums = new() { -1, 0, 5, -3 };
            int result = Operations.Max(nums);
            Assert.AreEqual(5, result);
        }
    }
}
