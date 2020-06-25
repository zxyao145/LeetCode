using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCode.Problems.Problem2;

namespace LeetCode.Problems
{
    /// <summary>
    /// 20. 有效的括号
    /// </summary>
    class Problem20
    {
        public static void MainFunc()
        {

            Console.WriteLine($"{IsValid("]")}:\t");
            Console.WriteLine($"{IsValid("(111)")}:\t(111)");
            Console.WriteLine($"{IsValid("()[]{}")}:\t()[]{{}}");
            Console.WriteLine($"{IsValid("(]")}:\t(]");

        }

        public static bool IsValid(string s)
        {
            var span = s.AsSpan();

            Stack<char> charStack =new Stack<char>();

            var length = span.Length;

            //'(':40,   ')':41
            //'[':91,   ']':93,
            //'{':123,  '}':125
            for (int i = 0; i < length; i++)
            {
                var ch = span[i];
                if (ch == 40 || ch == 91 || ch == 123)
                {
                    charStack.Push(ch);
                }
                else if (ch == 41)
                {
                    if (charStack.Count == 0)
                    {
                        return false;
                    }
                    var left = charStack.Pop();
                    if (left != 40)
                    {
                        return false;
                    }
                }
                else if (ch == 93 || ch == 125)
                {
                    if (charStack.Count == 0)
                    {
                        return false;
                    }
                    var left = charStack.Pop();
                    if (left != ch -2)
                    {
                        return false;
                    }
                }
            }
            
            return charStack.Count == 0;
        }
    }
}
