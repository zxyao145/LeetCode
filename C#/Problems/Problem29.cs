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
    /// 29. 两数相除
    /// 执行用时：1744 ms, 在所有 C# 提交中击败了5.26%的用户
    /// 内存消耗：14.7 MB, 在所有 C# 提交中击败了100.00%的用户
    /// </summary>
    class Problem29
    {
        public static void MainFunc()
        {
            var p  = new Problem29();

            var dividend = -8;
            var divisor = 2;

            Console.WriteLine(p.Divide(dividend, divisor));

        }


        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }

            if (dividend == 0)
            {
                return 0;
            }

            if (divisor == 1)
            {
                return dividend;
            }
            else if (divisor == -1)
            {
                if (dividend > int.MinValue)
                {
                    return -dividend;
                }
                else
                {
                    return int.MaxValue;
                }
            }

            long dividendLong = dividend;
            dividendLong = dividendLong < 0 
                        ? -dividendLong
                        : dividendLong;

            long divisorLong = divisor;
            divisorLong = divisorLong < 0 ? -divisorLong : divisorLong;
            if (dividendLong < divisorLong)
            {
                return 0;
            }

            bool isPositive = !((dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0));

            int result = 1;
            long tempDivisorLong = divisorLong;
            while (dividendLong >= tempDivisorLong)
            {
                tempDivisorLong <<= 1;
                if (dividendLong >= tempDivisorLong)
                {
                    result <<= 1;
                }
            }

            dividendLong -= tempDivisorLong >> 1;
            while (dividendLong >= divisorLong)
            {
                result += 1;
                dividendLong -= divisorLong;
            }

            return isPositive ? result : -result;
        }
    }
}
