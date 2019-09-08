using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Solutions
{
    public static class TwoSum
    {
        public static int[] GetTwoNumbersThatAddToTarget(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (dict.ContainsKey(complement))
                {
                    return new int[] { dict[complement], i };
                }
                else if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
            }
            return null;
        }
    }
}
