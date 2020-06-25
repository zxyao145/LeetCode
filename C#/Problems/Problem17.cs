using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    /// 最长公共前缀
    /// </summary>
    class Problem17
    {
        public static void Main17()
        {
            var result = LetterCombinations("23");
            Console.WriteLine(string.Join(",",result));
        }

        public static IList<string> LetterCombinations(string digits)
        {
            if(digits.Length == 0) return new List<string>();
            var numToChar = new Dictionary<char,List<char>>()
            {
                {'1',new List<char>() },
                {'2', new List<char>() {'a', 'b', 'c'}},
                {'3',new List<char>() {'d', 'e', 'f'} },
                {'4',new List<char>() {'g', 'h', 'i'} },
                {'5',new List<char>() {'j', 'k', 'l'} },
                {'6',new List<char>() {'m', 'n', 'o'} },
                {'7',new List<char>() {'p', 'q', 'r', 's'} },
                {'8',new List<char>() { 't', 'u', 'v'} },
                {'9',new List<char>() { 'w', 'x', 'y', 'z' } }
            };

            var charArr = digits.AsSpan();
            List<string> output = new List<string>();
            DeepSearch("", charArr, numToChar, output);

            return output;
        }

        private static void DeepSearch
        (string curStr, ReadOnlySpan<char> chars,
            Dictionary<char, List<char>> numToChar,
            List<string> output
        )
        {
            if (chars.Length == 0)
            {
                output.Add(curStr);
                return;
            }
            else
            {
                var curFirst = chars[0];

                var numChars = numToChar[curFirst];

                foreach (var numChar in numChars)
                {
                    DeepSearch(curStr + numChar, chars.Slice(1), numToChar, output);
                }
            }
        }
    }
}
