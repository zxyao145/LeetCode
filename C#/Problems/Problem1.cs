using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    /// 1.两数之和
    /// </summary>
    class Problem1
    {
        #region 1.两数之和
        static void TwoSumMain()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;
            var result = TwoSum(nums, target);

            Console.WriteLine(result[0]);
            Console.WriteLine(result[1]);

        }
        /// <summary>
        /// 两数之和
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        static int[] TwoSum(int[] nums, int target)
        {
            var numsLength = nums.Length;
            for (int i = 0; i < numsLength; i++)
            {
                var curNum = nums[i];
                var anotherVal = target - curNum;

                var anotherIndex = -1;

                for (int j = i + 1; j < numsLength; j++)
                {
                    if (nums[j] == anotherVal)
                    {
                        anotherIndex = j;
                        break;
                    }
                }

                if (anotherIndex == -1) continue;
                var result = new int[2];
                result[0] = i;
                result[1] = anotherIndex;
                return result;
            }
            return new int[]{
                -1,-1
            };
        }
        #endregion
    }
}
