using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    class Problem10
    {
        //public static void Main9()
        //{
        //    var nums = new List<int>()
        //    {
        //        11,121,136,-45
        //    };
        //    foreach (var num in nums)
        //    {
        //        var result = IsMatch(num);
        //        Console.WriteLine($"{num}:{result}");
        //    }
        //}

        //public static bool IsMatch(string s, string p)
        //{
        //    if (string.IsNullOrWhiteSpace(p))
        //    {
        //        return string.IsNullOrWhiteSpace(s);
        //    }
        //    if (p == ".*")
        //    {
        //        return true;
        //    }

        //    if (string.IsNullOrWhiteSpace(s))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        var sLen = s.Length;
        //        var pCharIndex = p.Length - 1;
        //        var curPChar = p[pCharIndex];
        //        var result = false;
        //        var flag = true;
        //        for (int i = sLen - 1; i >= 0; i--)
        //        {
        //            var sChar = s[i];
        //            if (curPChar != '*')
        //            {
        //                result = CharMatch(sChar, curPChar);
        //                curPChar = p[--pCharIndex];
        //            }
        //            else
        //            {

        //            }
        //        }

        //    }
        //}

        //public static bool CharMatch(char txt, char p, bool must = true)
        //{
        //    if (p == '.') return true;
        //    return txt == p;
        //}
    }
}
