using NUnit.Framework;
using MyMath;

namespace MyMath.Tests
{
    public class OperationsTests
    {
        [Test]
        public void Add_TwoNumbers_ReturnsSum()
        {
            int result = Operations.Add(2, 3);
            Assert.AreEqual(5, result);
        }
    }
}
