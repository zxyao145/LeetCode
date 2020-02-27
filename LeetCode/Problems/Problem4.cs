using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    /// 4.寻找两个有序数组的中位数
    /// </summary>
    class Problem4
    {
        #region 4.寻找两个有序数组的中位数

        static void Main4Test()
        {
            var num1 = new List<int>();
            var num2 = new List<int>();
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                num1.Add(random.Next(0, 30));
            }
            for (int i = 0; i < 8; i++)
            {
                num2.Add(random.Next(0, 30));
            }

            var num1Arr = num1.OrderBy(e => e).ToArray();
            var num2Arr = num2.OrderBy(e => e).ToArray();


            var mid = Main4(num1Arr, num2Arr);
            Console.WriteLine(string.Join(",", num1Arr));
            Console.WriteLine(string.Join(",", num2Arr));
            Console.WriteLine(mid);
        }

        static double Main4(int[] num1, int[] num2)
        {
            int m = num1.Length;
            int n = num2.Length;
            int len = m + n;

            int left = (n + m + 1) / 2;
            int right = (n + m + 2) / 2;
            if ((len & 1) == 0)
            {
                //将偶数和奇数的情况合并，如果是奇数，会求两次同样的 k 。
                return (GetKth(num1, 0, n - 1,
                            num2, 0, m - 1, left)
                        + GetKth(num1, 0, n - 1,
                            num2, 0, m - 1, right)) * 0.5;
            }

            return GetKth(num1, 0, n - 1,
                num2, 0, m - 1, left);


        }

        private static int GetKth(int[] num1, int start1, int end1,
            int[] num2, int start2, int end2,
            int k)
        {
            int len1 = end1 - start1 + 1;
            int len2 = end2 - start2 + 1;
            //让 len1 的长度小于 len2，这样就能保证如果有数组空了，一定是 len1 
            if (len1 > len2)
                return GetKth(num2, start2, end2, num1, start1, end1, k);
            if (len1 == 0)
                return num2[start2 + k - 1];

            if (k == 1)
                return Math.Min(num1[start1], num2[start2]);

            int i = start1 + Math.Min(len1, k / 2) - 1;
            int j = start2 + Math.Min(len2, k / 2) - 1;

            if (num1[i] > num2[j])
            {
                return GetKth(num1, start1, end1, num2, j + 1, end2,
                    k - (j - start2 + 1));
            }
            else
            {
                return GetKth(num1, i + 1, end1,
                    num2, start2, end2, k - (i - start1 + 1));
            }
        }

        #endregion


    }
}
