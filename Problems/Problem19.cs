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
    /// 最长公共前缀
    /// </summary>
    class Problem19
    {
        public static void MainFunc()
        {
            var head = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                        }
                    }
                }
            };


            head = RemoveNthFromEnd(head,2);

            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }

            Console.WriteLine("Finished");
        }

        public static Problem2.ListNode RemoveNthFromEnd(Problem2.ListNode head, int n)
        {
            max = 1;
            target = n;
            Dfs(head);
            if (max - target == 0)
            {
                return head.next;
            }
            return head;
        }

        private static int max = 1;
        private static int target = 0;

        private static ListNode nextNode;

        public static void Dfs(ListNode head)
        {
            var cur = max;

            if (head.next != null)
            {
                max += 1;
                Dfs(head.next);
            }

            if (cur == max - target + 2)
            {
                nextNode = head;
            }

            if (cur == max - target)
            {
                head.next = nextNode;
            }
        }

    }
}
