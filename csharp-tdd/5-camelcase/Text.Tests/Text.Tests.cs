using NUnit.Framework;
using Text;

namespace Text.Tests
{
    /// <summary>
    /// Tests for the <see cref="Str"/> class.
    /// </summary>
    [TestFixture]
    public class StrTests
    {
        [Test]
        public void CamelCase_SingleWord_ReturnsOne()
        {
            Assert.AreEqual(1, Str.CamelCase("hello"));
        }

        [Test]
        public void CamelCase_MultipleWords_ReturnsCorrectCount()
        {
            Assert.AreEqual(2, Str.CamelCase("helloWorld"));
            Assert.AreEqual(3, Str.CamelCase("oneTwoThree"));
        }

        [Test]
        public void CamelCase_EmptyString_ReturnsZero()
        {
            Assert.AreEqual(0, Str.CamelCase(""));
        }

        [Test]
        public void CamelCase_AllLowercase_ReturnsOne()
        {
            Assert.AreEqual(1, Str.CamelCase("lowercase"));
        }

        [Test]
        public void CamelCase_FirstLetterUppercase_CountsCorrectly()
        {
            Assert.AreEqual(3, Str.CamelCase("CamelCaseTest"));
        }
    }
}
