using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    /// 罗马数字转int
    /// </summary>
    class Problem13
    {
        public static void Main13()
        {
            var testNum = new string[]
            {
                "III","IV","MCMXCIV"
            };

            foreach (var i in testNum)
            {
                Console.WriteLine(RomanToInt(i));
            }
        }

        public static int RomanToInt(string s)
        {
            var numToRomanMap = new Dictionary<char, int>()
            {
                {'M',1000},
                {'D',500},
                {'C',100},
                {'L',50},
                {'X',10},
                {'V',5},
                {'I',1}
            };

            var charArray = s.AsSpan();
            var charLen = charArray.Length;
            var val = 0;
            for (int i = 0; i < charLen; i++)
            {
                var curCh = charArray[i];
                var curNum = numToRomanMap[curCh];
                if (i + 1 < charLen)
                {
                    var nextChar = charArray[i + 1];
                    var nextNum = numToRomanMap[nextChar];
                    if (nextNum == curNum * 5 || nextNum == curNum * 10)
                    {
                        val += (nextNum - curNum);
                        i += 1;
                        continue;
                    }
                }
                val += curNum;
            }

            return val;
        }
    }
}
