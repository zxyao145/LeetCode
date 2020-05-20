using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    /// 最长公共前缀
    /// </summary>
    class Problem18
    {
        public static void MainFunc()
        {
            int target = 2;
            var nums = new int[]
            {
                2,1,0,-1
            };
            
            var result = FourSum(nums, target);

            var resultStr =
                string.Join("\r\n", result.Select(e => string.Join(",", e)));
                
            Console.WriteLine(string.Join(",", resultStr));
        }

        public static IList<IList<int>> FourSum(int[] nums, int target)
        {

            IList<IList<int>> resultList = new List<IList<int>>();
            int length = nums.Length;
            if (length < 4)
            {
                return resultList;
            }
            var maxIndex = length - 1;
            Array.Sort(nums);
            var lastVal = nums[maxIndex];

            for (int i = 0; i < length - 3; i++)
            {
                var valI = nums[i];
                if (i > 0 && valI == nums[i-1])
                {
                    continue;
                }

                var startJ = i + 1;
                for (int j = startJ; j < length - 2;j++ )
                {
                    var valJ = nums[j];
                    if (startJ != j && valJ == nums[j - 1])
                    {
                        continue;
                    }

                    var startK = j + 1;
                    for (int k = startK; k < length - 1; k++)
                    {
                        var valK = nums[k];

                        if (startK != k && valK == nums[k - 1])
                        {
                            continue;
                        }

                        var remainderVal = target - valI - valJ - valK;
                        var l = maxIndex;
                        if (lastVal < remainderVal)
                        {
                            continue;
                        }
                        while (l > k)
                        {
                            var valL = nums[l];
                            if (valL == remainderVal)
                            {
                                resultList.Add(new List<int>()
                                {
                                    valI,valJ, valK,valL
                                });
                                break;
                            }

                            l--;
                        }

                    }

                }
            }


            return resultList;
        }
    }
}
