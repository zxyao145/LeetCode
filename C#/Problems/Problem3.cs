using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    /// 3.无重复字符的最长子串 
    /// </summary>
    class Problem3
    {
        #region 3.无重复字符的最长子串 
        public static void LengthOfLongestSubstringMain()
        {
            var str = "kwweqw";
            Console.WriteLine(LengthOfLongestSubstring_ByDict(str));
        }

        public static int LengthOfLongestSubstring(string s)
        {
            var maxLength = 0;
            var searchStr = s;
            var curSearchStartIndex = 0;
            List<char> searchResultChars = new List<char>();

            for (int i = 0; i < searchStr.Length; i++)
            {
                var curChar = searchStr[i];
                if (!searchResultChars.Contains(curChar))
                {
                    searchResultChars.Add(curChar);
                }
                else
                {
                    var chongfuIndex = curSearchStartIndex + searchResultChars.IndexOf(curChar);
                    if ((s.Length - chongfuIndex + 1) < maxLength)
                    {
                        break;
                    }
                    else
                    {
                        maxLength =
                            maxLength > searchResultChars.Count
                            ? maxLength : searchResultChars.Count;
                        searchResultChars.Clear();
                        curSearchStartIndex = chongfuIndex + 1;
                        searchStr = s.Substring(curSearchStartIndex);
                        i = -1;
                    }
                }
            }
            maxLength =
                maxLength > searchResultChars.Count
                    ? maxLength : searchResultChars.Count;
            return maxLength;
        }


        public static int LengthOfLongestSubstring_By滑动窗口(string s)
        {
            int n = s.Length;
            List<char> set = new List<char>();
            int ans = 0, i = 0, j = 0;
            while (i < n && j < n)
            {
                // try to extend the range [i, j]

                if (!set.Contains(s[j]))
                {
                    set.Add(s[j++]);//等价于 set.Add(s[j]); j += 1;
                    ans = Math.Max(ans, j - i);
                }
                else
                {
                    set.Remove(s[i++]);
                }
            }
            return ans;
        }

        public static int LengthOfLongestSubstring_ByDict(string s)
        {
            int sLength = s.Length, maxLength = 0;
            var dict = new Dictionary<char, int>();
            for (int j = 0, i = 0; j < sLength; j++)
            {
                if (dict.ContainsKey(s[j]))
                {
                    i = Math.Max(dict[s[j]], i);
                    dict[s[j]] = j + 1;
                }
                else
                {
                    dict.Add(s[j], j + 1);
                }
                maxLength = Math.Max(maxLength, j - i + 1);
            }
            return maxLength;
        }

        #endregion
    }
}
