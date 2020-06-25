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
    class Problem15
    {
        public static void Main15()
        {
            var testNum = new []
            {
                0,0,0,0
            };

            var result = ThreeSum(testNum);

            var strList =
                result.Select(e => string.Join(",", e));

            Console.WriteLine(string.Join("\n", strList));
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var orderNum = nums.OrderBy(e => e).ToArray();
            var numLen = orderNum.Length;

            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < numLen; i++)
            {
                var num1 = orderNum[i];
                if (num1 > 0)
                {
                    break;
                }
                if ( i > 0 && num1  == orderNum[i-1])
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
                    if (curSum == 0)
                    {
                        result.Add(new List<int>()
                        {
                            num1,num2,num3
                        });

                        while (l + 1 < numLen && orderNum[l] == orderNum[l + 1])
                        {
                            l += 1;
                        }
                        while (r - 1 > 0 && orderNum[r] == orderNum[r - 1])
                        {
                            r -= 1;
                        }
                        l += 1;
                        r -= 1;
                    }
                    else if(curSum<0)
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
            }

            return result;
        }


    }
}
