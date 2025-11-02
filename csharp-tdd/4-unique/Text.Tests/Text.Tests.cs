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
        public void UniqueChar_FirstUnique_ReturnsCorrectIndex()
        {
            Assert.AreEqual(0, Str.UniqueChar("leetcode")); // 'l'
            Assert.AreEqual(2, Str.UniqueChar("loveleetcode")); // 'v'
        }

        [Test]
        public void UniqueChar_NoUnique_ReturnsMinusOne()
        {
            Assert.AreEqual(-1, Str.UniqueChar("aabbcc"));
        }

        [Test]
        public void UniqueChar_EmptyString_ReturnsMinusOne()
        {
            Assert.AreEqual(-1, Str.UniqueChar(""));
        }

        [Test]
        public void UniqueChar_AllUnique_ReturnsFirstIndex()
        {
            Assert.AreEqual(0, Str.UniqueChar("abcde"));
        }
    }
}
