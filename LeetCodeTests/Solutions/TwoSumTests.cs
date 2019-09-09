using LeetCode.Solutions;
using NUnit.Framework;
using System;
using System.Collections;

namespace Tests
{
    public class TwoSumTests
    {
        [Test, TestCaseSource(typeof(TwoSumInput), "TestCases")]
        public int[] GetTwoNumbersThatAddToTargetTest(int[] numbers, int target)
        {
            return TwoSum.GetTwoNumbersThatAddToTarget(numbers, target);
        }

        [Test]
        public void GetTwoNumbersThatAddToTargetNullExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => TwoSum.GetTwoNumbersThatAddToTarget(null, 0));
        }
    }

    public class TwoSumInput {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new int[] { 2, 7, 11, 15 }, 9)
                    .Returns(new int[] { 0, 1 });
                yield return new TestCaseData(new int[] { }, 0)
                    .Returns(null);
            }
        }
    }
}