using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Solutions
{
    public static class LongestSubstringWithoutRepeatingCharacters
    {
        public static int LengthOfLongestSubstring(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            var longestLength = 0;
            var curLength = 0;
            var startPos = 0;
            var dictChars = new Dictionary<char, int>();
            var chars = s.ToCharArray();

            for (int i = 0; i < s.Length; i++)
            {
                var curChar = chars[i];
                if (dictChars.ContainsKey(curChar))
                {
                    if (dictChars[curChar] >= startPos)
                    {
                        curLength = i - dictChars[curChar] - 1;
                        startPos = dictChars[curChar] + 1;
                    }
                    dictChars[curChar] = i;
                }
                else
                {
                    dictChars.Add(curChar, i);
                }
                curLength++;
                longestLength = Math.Max(curLength, longestLength);
            }

            return longestLength;
        }
    }
}
