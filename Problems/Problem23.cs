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
    /// 23. 合并K个排序链表
    /// </summary>
    class Problem23
    {
        public static void MainFunc()
        {
            var p = new Problem23();
            //[[-10,-9,-9,-3,-1,-1,0],[-5],[4],[-8],[],
            //[-9,-6,-5,-4,-2,2,3],[-3,-3,-2,-1,0]]
            ListNode[] list = new ListNode[]
            {
                new ListNode(-10)
                {
                    next = new ListNode(-9)
                    {
                        next = new ListNode(-9)
                        {
                            next = new ListNode(-3)
                            {
                                next = new ListNode(-1)
                                {
                                    next = new ListNode(-1)
                                    {
                                        next = new ListNode(0)
                                    }
                                }
                            }
                        }
                    }
                },
                new ListNode(-5),
                new ListNode(4),
                new ListNode(-8),
                null,
                new ListNode(-9)
                {
                    next = new ListNode(-6)
                    {
                        next = new ListNode(-5)
                        {
                            next = new ListNode(-4)
                            {
                                next = new ListNode(-2)
                                {
                                    next = new ListNode(2)
                                    {
                                        next = new ListNode(3)
                                    }
                                }
                            }
                        }
                    }
                },

                new ListNode(-3)
                {
                    next = new ListNode(-3)
                    {
                        next = new ListNode(-2)
                        {
                            next = new ListNode(-1)
                            {
                                next = new ListNode(0)
                            }
                        }
                    }
                }, 
            };
            var r = p.MergeKLists(list);

            while (r != null)
            {
                Console.WriteLine(r.val);
                r = r.next;
            }
        }
        
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
            {
                return null;
            }
            return Merge(lists, 0, lists.Length - 1);
        }


        public ListNode Merge(ListNode[] lists, int left, int right)
        {
            if (left == right)
            {
                return lists[left];
            }

            if (left > right)
            {
                return null;
            }
            else if ((right - left) == 1)
            {
                return MergeTwoLists(lists[left], lists[right]);
            }
            else
            {
                //be careful ‘>>’ is low than +
                var mid = left + ((right - left) >> 1);
                var leftList = Merge(lists, left, mid);
                var rightList = Merge(lists, mid + 1, right);
                return MergeTwoLists(leftList, rightList);
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
