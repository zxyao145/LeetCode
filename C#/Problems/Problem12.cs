using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    /// int转罗马
    /// </summary>
    class Problem12
    {
        public static void Main12()
        {
            var testNum = new int[]
            {
                3, 4, 9, 58, 1994
            };

            foreach (var i in testNum)
            {
                Console.WriteLine(IntToRoman(i));
            }
        }

        public static string IntToRoman(int num)
        {
            if (num < 1 || num > 3999)
            {
                return "";
            }

            var numToRomanMap = new Dictionary<int,string>()
            {
                {1000,"M"},
                {900,"CM"},

                {500,"D"},
                {400,"CD"},

                {100,"C"},
                {90,"XC"},

                {50,"L"},
                {40,"XL"},

                {10,"X"},
                {9,"IX"},

                {5,"V"},
                {4,"IV"},
                
                {1,"I"}
            };

            var sb = new StringBuilder();

            foreach (var splitNumDict in numToRomanMap)
            {
                var splitNum = splitNumDict.Key;
                var romanNumVal = splitNumDict.Value;

                while (num >= splitNum)
                {
                    sb.Append(romanNumVal);
                    num -= splitNum;
                }

            }
            
            return sb.ToString();
        }
    }
}
