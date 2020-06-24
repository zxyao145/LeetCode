using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    /// 正则表达式匹配
    /// 执行用时：76 ms, 在所有 C# 提交中击败了100.00%的用户
    /// 内存消耗：24.4 MB, 在所有 C# 提交中击败了100.00%的用户
    /// </summary>
    class Problem10
    {
        public static void Main10Test()
        {
            var str = "";
            var p = ".*";

            Console.WriteLine(IsMatch(str, p));

        }

        public static bool IsMatch(string s, string p)
        {
            if(string.IsNullOrWhiteSpace(s) && string.IsNullOrWhiteSpace(p))
            {
                return true;
            }
            else 
            {

                var sLen = s.Length;
                var pLen = p.Length;

                char[,] status = new char[sLen+1, pLen+1];
                //两个字符串都为空
                status[0, 0] = 't';
                for (int i = 0; i <= sLen; ++i)
                {
                    for (int j = 1; j <= pLen; ++j)
                    {
                        if (p[j - 1] == '*')
                        {
                            status[i,j] = status[i,j - 2];
                            if (Matches(s, p, i, j - 1))
                            {
                                status[i,j] 
                                    = status[i, j] == 't'
                                    ? status[i, j]
                                    : status[i-1,j];
                            }
                        }
                        else
                        {
                            if (Matches(s, p, i, j))
                            {
                                status[i,j] = status[i-1, j-1];
                            }
                        }
                    }
                }

                return status[sLen, pLen] == 't';
            }
        }


        public static bool Matches(string s, string p, int i, int j)
        {
            if (i == 0)
            {
                return false;
            }
            if (p[j - 1] == '.')
            {
                return true;
            }
            return s[i - 1] == p[j - 1];
        }
    }
}
