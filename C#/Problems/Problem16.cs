using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    /// 最长公共前缀
    /// </summary>
    class Problem16
    {
        public static void Main16()
        {
            var testNum = new []
            {
                1, 2, 4, 8, 16, 32, 64, 128
            };

            var result = ThreeSumClosest(testNum,82);
            Console.WriteLine(result);
        }

        public static int ThreeSumClosest(int[] nums, int target)
        {
            var numLen = nums.Length;
            if (numLen < 4)
            {
                return nums.Sum();
            }
            var orderNum = nums.OrderBy(e => e).ToArray();

            int result = nums[0]+ nums[1]+ nums[2];
            var lastAbsDiff = Math.Abs(result - target);

            for (int i = 0; i < numLen; i++)
            {
                var num1 = orderNum[i];
                if (i > 0 && num1 == orderNum[i - 1])
                {
                    continue;
                }

                var l = i + 1;
                var r = numLen - 1;

                while (l < r)
                {
                    var num2 = orderNum[l];
                    var num3 = orderNum[r];

                    var curSum = num1 + num2 + num3;

                    var absDiff = Math.Abs(curSum - target);
                    if (absDiff == 0) return curSum;
                    else if (absDiff < lastAbsDiff)
                    {
                        result = curSum;
                        lastAbsDiff = absDiff;
                    }
                    else if(curSum < target)
                    {
                        l += 1;
                        while (l + 1 < numLen && orderNum[l] == orderNum[l + 1])
                        {
                            l += 1;
                        }
                    }
                    else if (curSum > target)
                    {
                        r -= 1;
                        while (r - 1 > 0 && orderNum[r] == orderNum[r - 1])
                        {
                            r -= 1;
                        }
                    }

                }
            }

            return result;
        }

    }
}
