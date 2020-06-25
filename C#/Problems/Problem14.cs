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
    class Problem14
    {
        public static void Main14()
        {
            var testNum = new string[]
            {
                "a","b"
            };

            var prefix = LongestCommonPrefix(testNum);
            Console.WriteLine(prefix);
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0) return "";
            if (strs.Length == 1) return strs[0];

            var minStrLength = strs.Min(e => e.Length);
            var str0 = strs[0].AsSpan();

            int strsLen = strs.Length;

            var right = minStrLength;
            var left = 0;

            while (left < right)
            {
                var mid = (left + right) / 2+1;

                var result = IsEqual(str0, strs, left, mid, strsLen);
                if (result)
                {
                    left = mid;
                }
                else
                {
                    right = mid-1;
                }
            }

            var prefix = str0.Slice(0, (right + left) / 2).ToString();

            return prefix;
        }

        private static bool IsEqual(ReadOnlySpan<char> str0, string[] strs, 
            int left, int right,
            int strsLen)
        {
            var curStrLength = right - left;
            var curStr0 = str0.Slice(left, curStrLength);
            
            //遍历所有字符串数组
            for (int i = 1; i < strsLen; i++)
            {
                var curStr = strs[i];
                //遍历字符串中的字符
                for (int j = 0; j < curStrLength; j++)
                {
                    if (curStr0[j] != curStr[j + left])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
