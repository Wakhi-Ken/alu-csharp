using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Text
{
    /// <summary>
    /// Provides string-related utilities.
    /// </summary>
    public class Str
    {
        /// <summary>
        /// Determines if a string is a palindrome.
        /// Ignores case, spaces, and punctuation.
        /// </summary>
        /// <param name="s">Input string</param>
        /// <returns>True if palindrome, False otherwise</returns>
        public static bool IsPalindrome(string s)
        {
            if (s == null) return false;

            // Remove non-alphanumeric characters and convert to lower case
            string cleaned = Regex.Replace(s, @"[^a-zA-Z0-9]", "").ToLower();

            int left = 0;
            int right = cleaned.Length - 1;

            while (left < right)
            {
                if (cleaned[left] != cleaned[right])
                    return false;
                left++;
                right--;
            }

            return true;
        }
    }
}
