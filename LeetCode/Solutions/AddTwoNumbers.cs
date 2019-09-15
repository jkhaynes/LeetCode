using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Solutions
{
    public class AddTwoNumbers
    {
        ListNode _l1;
        ListNode _l2;

        public ListNode ReverseAndAddNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
            {
                throw new ArgumentNullException();
            } else
            {
                _l1 = l1;
                _l2 = l2;
            }

            ListNode curNode = null;
            var sum = CalculateSum(_l1, _l2, 0);
            var resultNode = curNode = CreateNextNode(sum);
            int carryOver = CalculateCarryOver(curNode, sum);
            MoveToNextNode();
            while ((_l1 != null || _l2 != null) || carryOver != 0)
            {
                sum = CalculateSum(_l1, _l2, carryOver);
                curNode.next = CreateNextNode(sum);
                curNode = curNode.next;
                carryOver = CalculateCarryOver(curNode, sum);
                MoveToNextNode();
            }

            return resultNode;
        }

        private void MoveToNextNode()
        {
            if (_l1 != null) _l1 = _l1.next;
            if (_l2 != null) _l2 = _l2.next;
        }

        private int CalculateCarryOver(ListNode curNode, int sum)
        {
            return (sum - curNode.val) / 10;
        }

        private int CalculateSum(ListNode l1, ListNode l2, int carryOver)
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

        private ListNode CreateNextNode(int sum)
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
