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
    /// 25. K 个一组翻转链表
    /// 执行用时 : 108 ms, 在所有 C# 提交中击败了 95.12% 的用户
    /// 内存消耗 : 26.5 MB, 在所有 C# 提交中击败了 100.00% 的用户
    /// </summary>
    class Problem25
    {
        public static void MainFunc()
        {
            var p = new Problem25();

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
            var r = p.ReverseKGroup(list,3);

            while (r != null)
            {
                Console.WriteLine(r.val);
                r = r.next;
            }
        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null)
            {
                return null;
            }
            if (k < 2)
            {
                return head;
            }

            Stack<ListNode> nodes= new Stack<ListNode>();
            var originHead = head;
            while (head != null)
            {
                nodes.Push(head);
                head = head.next;
                if (nodes.Count == k)
                {
                    break;
                }
            }

            ListNode result = null;
            var newHead = new ListNode(-10);
            if (nodes.Count == k)
            {
                while (nodes.Count > 0)
                {
                    if (result == null)
                    {
                        result = nodes.Pop();
                        newHead = result;
                    }
                    else
                    {
                        result.next = nodes.Pop();
                        result = result.next;
                    }
                }
                result.next = ReverseKGroup(head, k);
                return newHead;
            }
            else
            {
                return originHead;
            }
        }
    }
}
