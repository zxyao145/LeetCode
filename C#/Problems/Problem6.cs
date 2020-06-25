using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    /// 6. Z 字形变换
    /// </summary>
    class Problem6
    {
        #region 6. Z 字形变换

        static void Main6Test()
        {
            var str = "LEETCODEISHIRING";
            var numRows = 4;
            var res = Main6(str, numRows);
            Console.WriteLine(res);

        }


        static string Main6(string s, int numRows)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }
            if (numRows == 1)
            {
                return s;
            }
            //else

            var rowCycle = numRows - 1;

            //用于计算字符所在列
            var colCycle = numRows + numRows - 2;
            int[] colIndexOffset = new int[colCycle];
            var colOffset = 1;
            //用于计算字符所在行
            int[] rowIndexOffset = new int[colCycle];
            var rowOffset = 0;
            var forward = true;
            //字符行列号的偏移
            for (int i = 0; i < colCycle; i++)
            {
                rowIndexOffset[i] = rowOffset;
                if (forward)
                {
                    if (rowOffset == numRows - 1)
                    {
                        rowOffset--;
                        forward = false;
                    }
                    else
                    {
                        rowOffset++;
                    }
                }
                else
                {
                    rowOffset--;
                }

                if (i < numRows)
                {
                    colIndexOffset[i] = 0;
                }
                else
                {
                    colIndexOffset[i] = colOffset++;
                }
            }

            var colNum =
                GetColIndex(s.Length - 1, colCycle, rowCycle, colIndexOffset, out _) + 1;

            int[,] result = new int[numRows, colNum];


            for (int i = 0; i < s.Length; i++)
            {
                //列索引
                var colIndex = GetColIndex(i, colCycle, rowCycle, colIndexOffset,
                    out var cycleIndexItemIndex);

                //行索引
                var rowIndex = rowIndexOffset[cycleIndexItemIndex];

                result[rowIndex, colIndex] = i;
            }

            var sb = new StringBuilder(s.Length);

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < colNum; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        sb.Append(s[0]);
                        continue;
                    }
                    //else
                    var chIndex = result[i, j];
                    if (chIndex != 0)
                    {
                        sb.Append(s[chIndex]);
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numOfStr">字符在字符串的位置，从0开始</param>
        /// <param name="cycle"></param>
        /// <param name="rowCycle"></param>
        /// <param name="indexOffsets"></param>
        /// <param name="offsetIndex"></param>
        /// <returns></returns>
        static int GetColIndex(int numOfStr,
            int cycle,
            int rowCycle,
            int[] indexOffsets, out int offsetIndex)
        {
            //计算前面有几个整周期
            var zhouQi = numOfStr / cycle;
            //计算在周期中的偏移索引
            offsetIndex = (numOfStr) % cycle;

            var result = zhouQi * rowCycle
                         + indexOffsets[offsetIndex];
            return result;
        }


        #endregion
    }
}
