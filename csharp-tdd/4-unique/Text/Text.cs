using System;
using System.Collections.Generic;

namespace Text
{
    /// <summary>
    /// Provides string-related utilities.
    /// </summary>
    public class Str
    {
        /// <summary>
        /// Returns the index of the first non-repeating character in a string.
        /// </summary>
        /// <param name="s">Input string (lowercase letters only)</param>
        /// <returns>Index of first non-repeating character, or -1 if none</returns>
        public static int UniqueChar(string s)
        {
            if (string.IsNullOrEmpty(s)) return -1;

            Dictionary<char, int> counts = new();

            // Count occurrences
            foreach (char c in s)
            {
                if (counts.ContainsKey(c))
                    counts[c]++;
                else
                    counts[c] = 1;
            }

            // Find first character with count 1
            for (int i = 0; i < s.Length; i++)
            {
                if (counts[s[i]] == 1)
                    return i;
            }

            return -1;
        }
    }
}
