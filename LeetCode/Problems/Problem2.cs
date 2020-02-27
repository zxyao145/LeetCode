using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    /// 2.两数相加
    /// </summary>
    class Problem2
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }


        static void AddTwoNumbersMain()
        {
            var l1 = new ListNode(5);
            var l2 = new ListNode(5);
            var result = AddTwoNumbers(l1, l2);
            while (result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }
        }

        /// <summary>
        /// 两数相加
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            var jinwei = 0;
            var resultTemp = result;

            while (l1 != null || l2 != null)
            {
                var first = l1?.val ?? 0;
                var second = l2?.val ?? 0;
                var curVal = first + second + jinwei;

                if (curVal < 10)
                {
                    resultTemp.next = new ListNode(curVal);
                    jinwei = 0;
                }
                else
                {
                    resultTemp.next = new ListNode(curVal - 10);
                    jinwei = 1;
                }
                resultTemp = resultTemp.next;

                l1 = l1?.next;
                l2 = l2?.next;
            }

            if (jinwei == 1)
            {
                resultTemp.next = new ListNode(1);
            }

            return result.next;
        }

    }
}
