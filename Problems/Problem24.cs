using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static LeetCode.Problems.Problem2;

namespace LeetCode.Problems
{
    /// <summary>
    /// 24. 两两交换链表中的节点
    /// </summary>
    class Problem24
    {
        public static void MainFunc()
        {
            var p = new Problem24();

            ListNode list = new ListNode(2)
            {
                next = new ListNode(5)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(6)
                            {
                                next = new ListNode(2)
                                {
                                    next = new ListNode(2)
                                }
                            }
                        }
                    }
                }
            };
            var r = p.SwapPairs(list);

            while (r != null)
            {
                Console.WriteLine(r.val);
                r = r.next;
            }
        }

        public ListNode SwapPairs(ListNode head)
        {
            ListNode grand = null;
            ListNode prev = null;
            bool isFirst = true;
            ListNode cur = head;
            while (cur != null)
            {
                if (prev == null)
                {
                    prev = cur;
                }
                else
                {
                    var temp = cur.next;
                    cur.next = prev;
                    prev.next = temp;
                    if (grand != null)
                    {
                        grand.next = cur;
                    }
                    grand = prev;
                    if (isFirst)
                    {
                        head = cur;
                        isFirst = false;
                    }

                    cur = prev;
                    prev = null;
                }

                cur = cur.next;
            }

            return head;
        }
    }
}
