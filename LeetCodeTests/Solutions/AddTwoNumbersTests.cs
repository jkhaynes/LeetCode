using LeetCode.Solutions;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class AddTwoNumbersTests
    {
        AddTwoNumbers _addTwoNumbers = new AddTwoNumbers();

        [Test, TestCaseSource(typeof(AddTwoNumbersInput), "TestCases")]
        public void ReverseAndAddNumbersTest(ListNode l1, ListNode l2, ListNode expected)
        {
            Assert.That(expected, Is.EqualTo(_addTwoNumbers.ReverseAndAddNumbers(l1, l2)).Using(new LinkedListComparer()));
        }

        [Test]
        public void ReverseAndAddNumbersArgumentNullExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => _addTwoNumbers.ReverseAndAddNumbers(null, null));
        }
    }

    public class AddTwoNumbersInput
    {

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(BuildListNode("243"), BuildListNode("564"), BuildListNode("708"));
                yield return new TestCaseData(BuildListNode("5"), BuildListNode("5"), BuildListNode("01"));
                yield return new TestCaseData(BuildListNode("18"), BuildListNode("0"), BuildListNode("18"));
            }
        }

        private static ListNode BuildListNode(string numberToBuild)
        {
            char[] numArray = numberToBuild.ToCharArray();

            var firstListNode = new ListNode((int)numArray[0] - 48);
            var curListNode = firstListNode;
            foreach (int num in numArray.Skip(1))
            {
                var tempListNode = new ListNode((int)num - 48);
                curListNode.next = tempListNode;
                curListNode = tempListNode;
            }

            return firstListNode;
        }
    }

    public class LinkedListComparer : IComparer
    {
        int IComparer.Compare(object o1, object o2)
        {
            var l1 = o1 as ListNode;
            var l2 = o2 as ListNode;
            while(l1 != null && l2 != null)
            {
                if(l1.val != l2.val)
                {
                    return -1;
                }
                l1 = l1.next;
                l2 = l2.next;
            }

            if (l1 != null || l2 != null)
            {
                return -1;
            } else
            {
                return 0;
            }
        }
    }
}