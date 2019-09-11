using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Solutions
{
    public static class AddTwoNumbers
    {
        public static ListNode ReverseAndAddNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
            {
                throw new ArgumentNullException();
            }

            ListNode curNode = null;
            var sum = CalculateSum(l1, l2, 0);
            var resultNode = curNode = CreateNextNode(sum);
            int carryOver = CalculateCarryOver(curNode, sum);
            MoveToNextNode(ref l1, ref l2);
            while ((l1 != null || l2 != null) || carryOver != 0)
            {
                sum = CalculateSum(l1, l2, carryOver);
                curNode.next = CreateNextNode(sum);
                curNode = curNode.next;
                carryOver = CalculateCarryOver(curNode, sum);
                MoveToNextNode(ref l1, ref l2);
            }

            return resultNode;
        }

        private static void MoveToNextNode(ref ListNode l1, ref ListNode l2)
        {
            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
        }

        private static int CalculateCarryOver(ListNode curNode, int sum)
        {
            return (sum - curNode.val) / 10;
        }

        private static int CalculateSum(ListNode l1, ListNode l2, int carryOver)
        {
            int sum = carryOver;
            if (l1 != null)
            {
                sum += l1.val;
            }
            if (l2 != null)
            {
                sum += l2.val;
            }

            return sum;
        }

        private static ListNode CreateNextNode(int sum)
        {
            return new ListNode(sum % 10);
        }
    }

    public class ListNode
    {
        public int val { get; set; }
        public ListNode next { get; set; }
        public ListNode(int x) { val = x; }
    }

}
