using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    ///  5.最长回文子串
    /// </summary>
    class Problem5
    {
        #region 5.最长回文子串

        static void Main5Test()
        {
            var str = "aaaa";

            Console.WriteLine(Main5_2(str));


        }

        static string Main5_2(string s)
        {
            if (string.IsNullOrEmpty(s) || s == string.Empty)
            {
                return "";
            }
            var length = s.Length;


            int start = 0, subLen = 0;
            for (int i = 0; i < length; i++)
            {
                int len1 = ExpandFromCenter(s, i, i);
                int len2 = ExpandFromCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > subLen)
                {
                    start = i - (len - 1) / 2;
                    subLen = len;
                }
            }

            return s.Substring(start, subLen);

        }

        static int ExpandFromCenter(string str, int left, int right)
        {
            var strLength = str.Length;
            while (left > -1 && right < strLength
                           && str[left] == str[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }

        /// <summary>
        /// 暴力破解
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string Main5(string s)
        {
            var strLength = s.Length;
            var maxHuiWen = "";
            for (int i = 0; i < strLength; i++)
            {
                var curCh = s[i];
                var curEndJList = new List<int>();
                for (int j = strLength - 1; j >= i; j--)
                {
                    var backCh = s[j];
                    if (backCh == curCh)
                    {
                        curEndJList.Add(j);
                    }
                }

                if (curEndJList.Count > 0)
                {
                    foreach (var curEndJ in curEndJList)
                    {
                        var curStr = s.Substring(i, curEndJ - i + 1);
                        var isHuiWen = IsHuiWen(curStr);
                        if (isHuiWen && maxHuiWen.Length < curStr.Length)
                        {
                            maxHuiWen = curStr;
                        }
                    }
                }
            }

            return maxHuiWen;
        }

        static bool IsHuiWen(string str)
        {
            var length = str.Length - 1;
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[length - i])
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
