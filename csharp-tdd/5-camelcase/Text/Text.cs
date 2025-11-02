using System;

namespace Text
{
    /// <summary>
    /// Provides string-related utilities.
    /// </summary>
    public class Str
    {
        /// <summary>
        /// Counts the number of words in a camelCase string.
        /// Each word begins with a capital letter except the first word.
        /// </summary>
        /// <param name="s">Input string in camelCase</param>
        /// <returns>Number of words in the string</returns>
        public static int CamelCase(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int count = 1; // first word always counts

            // Start from index 1 to avoid counting the first letter twice
            for (int i = 1; i < s.Length; i++)
            {
                if (char.IsUpper(s[i]))
                    count++;
            }

            return count;
        }
    }
}
