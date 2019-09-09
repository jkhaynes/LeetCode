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
            var sum = l1.val + l2.val;
            var resultNode = curNode = new ListNode(sum % 10);
            int carryOver = (sum - curNode.val) / 10;
            l1 = l1.next;
            l2 = l2.next;
            while ((l1 != null || l2 != null) || carryOver != 0)
            {
                sum = carryOver;
                if(l1 != null)
                {
                    sum += l1.val;
                }
                if(l2 != null)
                {
                    sum += l2.val;
                }

                curNode.next = new ListNode(sum % 10);
                curNode = curNode.next;
                carryOver = (sum - curNode.val) / 10;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            return resultNode;
        }

        //private static int CalculateNextNodesNumber(ListNode l1, ListNode l2, int carryover)
        //{

        //}
    }

    public class ListNode
    {
        public int val { get; set; }
        public ListNode next { get; set; }
        public ListNode(int x) { val = x; }
    }

}
