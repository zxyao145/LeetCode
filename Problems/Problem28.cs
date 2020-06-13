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
    /// 28. 实现 strStr()
    /// 执行用时 : 80 ms , 在所有 C# 提交中击败了 97.47% 的用户
    /// 内存消耗 : 22.4 MB , 在所有 C# 提交中击败了 100.00% 的用户
    /// </summary>
    class Problem28
    {
        public static void MainFunc()
        {
            var p  = new Problem28();

            var haystack = "";
            var needle = "";

            Console.WriteLine(p.StrStr(haystack,needle));

        }

        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrWhiteSpace(needle))
            {
                return 0;
            }

            if (string.IsNullOrWhiteSpace(haystack))
            {
                return -1;
            }

            int haystackLength = haystack.Length;
            int needleLength = needle.Length;
            if (needleLength > haystackLength)
            {
                return -1;
            }

            for (int i = 0; i < haystackLength - needleLength + 1; i++)
            {
                if (haystack[i] != needle[0])
                {
                    continue;
                }
                else
                {
                    int k = 1;
                    for (; k < needleLength; k++)
                    {
                        if (haystack[i + k] != needle[k])
                        {
                            break;
                        }
                    }

                    if (k == needleLength)
                    {
                        return i;
                    }
                }
            }


            return -1;
        }
    }
}
