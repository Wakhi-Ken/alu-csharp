using System;
using System.Collections.Generic;

namespace MyMath
{
    /// <summary>
    /// Provides basic mathematical operations.
    /// </summary>
    public class Operations
    {
        /// <summary>
        /// Returns the maximum integer in a list.
        /// </summary>
        /// <param name="nums">List of integers</param>
        /// <returns>The maximum integer, or 0 if the list is empty</returns>
        public static int Max(List<int> nums)
        {
            if (nums == null || nums.Count == 0)
                return 0;

            int max = nums[0];
            foreach (int n in nums)
            {
                if (n > max)
                    max = n;
            }
            return max;
        }
    }
}
