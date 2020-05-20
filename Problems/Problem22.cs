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
    /// 22. 括号生成
    /// </summary>
    class Problem22
    {
        public static void MainFunc()
        {
            var p = new Problem22();
            var r = p.GenerateParenthesis(2);

            foreach (var item in r)
            {
                Console.WriteLine(item);
            }

        }

        public IList<string> GenerateParenthesis(int n)
        {
            _n = n;
            _result = new List<string>();
            if (n == 0)
            {
                return _result;
            }

            Generate(0, 0,"");
            return _result;
        }

        private int _n;
        private List<string> _result;
        public void Generate(int left,int right, string str)
        {
            if (left == _n && right == _n) 
            {
                _result.Add(str);
                return;
            }

            if (left < right)
            {
                return;
            }
            
            if (left < _n)
            {
                Generate(left + 1, right, str + "(");
            }
            if (right < _n)
            {
                Generate(left, right + 1, str + ")");
            }
        }

    }
}
