using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    /// 7. 整数反转
    /// </summary>
    class Problem7
    {
        #region 7. 整数反转

        static void Main7Test()
        {
            int intMin = -12300;

            Main7(intMin);
        }

        static int Main7(int x)
        {
            int result = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;
                //-2147483648~2147483647
                if (result > int.MaxValue / 10
                    || (result == int.MaxValue / 10 && pop > 7))
                {
                    return 0;
                }

                if (result < int.MinValue / 10
                    || (result == int.MinValue / 10 && pop < -8))
                {
                    return 0;
                }
                result = result * 10 + pop;
            }

            return result;
        }

        #endregion
    }
}
