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
        public void IsPalindrome_Racecar_ReturnsTrue()
        {
            Assert.IsTrue(Str.IsPalindrome("Racecar"));
        }

        [Test]
        public void IsPalindrome_Level_ReturnsTrue()
        {
            Assert.IsTrue(Str.IsPalindrome("level"));
        }

        [Test]
        public void IsPalindrome_PhraseWithSpacesAndPunctuation_ReturnsTrue()
        {
            string s = "A man, a plan, a canal: Panama.";
            Assert.IsTrue(Str.IsPalindrome(s));
        }

        [Test]
        public void IsPalindrome_EmptyString_ReturnsTrue()
        {
            Assert.IsTrue(Str.IsPalindrome(""));
        }

        [Test]
        public void IsPalindrome_NonPalindrome_ReturnsFalse()
        {
            Assert.IsFalse(Str.IsPalindrome("hello"));
        }
    }
}
