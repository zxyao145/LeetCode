using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    class Problem11
    {
        public static void Main11()
        {
            var h = new int[] {10, 14, 10, 4, 10, 2, 6, 1, 6, 12};

            Console.WriteLine(MaxArea(h));

        }

        public static int MaxArea(int[] height)
        {
            var length = height.Length;
            var left = 0;
            var right = length - 1;

            var maxArea = 0;
            while (left < right)
            {
                var leftH = height[left];
                var rightH = height[right];
                var curArea = (right - left) * Math.Min(leftH, rightH);
                maxArea = Math.Max(curArea, maxArea);
                if (leftH < rightH)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return maxArea;
        }

    }
}
