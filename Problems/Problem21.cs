using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCode.Problems.Problem2;

namespace LeetCode.Problems
{
    /// <summary>
    /// 21. 合并两个有序链表
    /// </summary>
    class Problem21
    {
        public static void MainFunc()
        {
            var p = new Problem21();

            var l1 = new ListNode(-9)
            {
                next = new ListNode(3)
            };
            var l2 = new ListNode(5)
            {
                next = new ListNode(7)
            };

            var head = p.MergeTwoLists(l1, l2);
            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }

            if (l2 == null)
            {
                return l1;
            }

            ListNode result;
            if (l1.val > l2.val)
            {
                result = l2;
                l2 = l2.next;
            }
            else
            {
                result = l1;
                l1 = l1.next;
            }

            var head = result;
            
            while (l1 != null && l2 != null)
            {
                if (l1.val > l2.val)
                {
                    result.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    result.next = l1;
                    l1 = l1.next;
                }

                result = result.next;
            }

            if (l1 == null)
            {
                while (l2 != null)
                {
                    result.next = l2;
                    l2 = l2.next;
                    result = result.next;
                }
            }
            if (l2 == null)
            {
                while (l1 != null)
                {
                    result.next = l1;
                    l1 = l1.next;
                    result = result.next;
                }
            }

            return head;
        }
    }
}
