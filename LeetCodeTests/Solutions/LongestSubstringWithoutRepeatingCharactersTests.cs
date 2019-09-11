using LeetCode.Solutions;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class LongestSubsringWithoutRepeatingCharactersTests
    {
        [Test, TestCaseSource(typeof(LongestStringWithoutRepeatingCharactersInput), "TestCases")]
        public int LongestSubstringWithoutRepeatingCharactersTest(string s)
        {
            return LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring(s);
        }

        [Test]
        public void LongestSubstringWithoutRepeatingCharactersTest()
        {
            Assert.Throws<ArgumentNullException>(() => LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring(null));
        }
    }

    public class LongestStringWithoutRepeatingCharactersInput
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("abcabcbb").Returns(3);
                yield return new TestCaseData("aabaab!bb").Returns(3);
            }
        }
    }
}
