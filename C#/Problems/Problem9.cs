using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    /// 9. 回文数
    /// </summary>
    class Problem9
    {
        public static void Main9()
        {
            var nums = new List<int>()
            {
                11,121,136,-45
            };
            foreach (var num in nums)
            {
                var result = IsPalindrome(num);
                Console.WriteLine($"{num}:{result}");
            }
        }

        public static bool IsPalindrome(int x)
        {
            if (x == 0)
            {
                return true;
            }
            else if (x < 0 || x % 10 == 0)
            {
                return false;
            }
            else
            {
                var length = x.ToString().Length-1;
                var originalNum = x;

                var newNum = 0;
                for (int i = 0; i <= length; i++)
                {
                    var lastNum = x % 10;
                    x /= 10;
                    newNum += lastNum * (int)(Math.Pow(10, length - i));
                }

                return newNum == originalNum;
            }
        }
    }
}
