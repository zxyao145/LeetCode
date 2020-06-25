using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static LeetCode.Problems.Problem2;

namespace LeetCode.Problems
{
    /// <summary>
    /// 27. 移除元素
    /// 执行用时 : 300 ms , 在所有 C# 提交中击败了 25.55% 的用户
    /// 内存消耗 : 30 MB , 在所有 C# 提交中击败了 20.00% 的用户
    /// </summary>
    class Problem27
    {
        public static void MainFunc()
        {
            var p = new Problem27();
            int[] nums = new[]
            {
                0, 4, 4, 0, 4, 4, 4, 0, 2
            };
            var r = p.RemoveElement(nums, 4);
            Console.WriteLine(r);
            Console.WriteLine(string.Join(',', nums));
        }

        public int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            int y = nums.Length - 1;
            while (y > -1 && nums[y] == val)
            {
                y--;
            }
            

            if (y < 0)
            {
                return 0;
            }

            int i = 0;
            for (; i <= y; i++)
            {
                if (nums[i] == val)
                {
                    nums[i] = nums[y];
                    y--;
                    while (y > -1 && nums[y] == val)
                    {
                        y--;
                    }
                }
            }

            return y + 1;
        }
    }
}
