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
    /// 26. 删除排序数组中的重复项
    /// 执行用时 : 288 ms , 在所有 C# 提交中击败了 90.00% 的用户 
    /// 内存消耗 : 33.4 MB , 在所有 C# 提交中击败了 11.11% 的用户
    /// </summary>
    class Problem26
    {
        public static void MainFunc()
        {
            var p = new Problem26();
            int[] nums = new[]
            {
                1,1, 2
            };
            var r = p.RemoveDuplicates(nums);
            Console.WriteLine(string.Join(',', r));
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            int x = 0;
            for (var y = 1; y < nums.Length; y++)
            {
                if (nums[y] != nums[x])
                {
                    if (x != y - 1)
                    {
                        x += 1;
                        nums[x] = nums[y];
                    }
                    else
                    {
                        x += 1;
                    }
                }
            }
            return x + 1;
        }
    }
}
