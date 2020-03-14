using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    /// <summary>
    /// 8.字符串转换整数 (atoi)
    /// </summary>
    class Problem8
    {
        public static void Main8()
        {
            //int.MinValue: -2147483648
            //int.MaxValue:  2147483647

            var a = "-2147483648";
            var b = "-2147483649";
            var c = "2147483647";
            var d = "2147483648";
            var e = "  0000000000012345678";
            var strArr = new List<string>()
            {
                a,b,c,d,e
            };

            foreach (var str in strArr)
            {
                var returnVal = MyAtoi("-2147483647");
                Console.WriteLine($"{str}:{returnVal}");
            }
        }

        public static int MyAtoi(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            var chars = str.ToArray();
            var sb = new StringBuilder();
            var strLen = chars.Length;
            //用于判断空格、+、-是否存在于0之后，类似000+1、000 122、000-555等之类的字符
            bool existZero = false;
            for (int i = 0; i < strLen; i++)
            {
                var curChar = chars[i];
                if (curChar == ' ' && !existZero)
                {
                    if (sb.Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else if ((curChar == '+' || curChar == '-') && !existZero)
                {
                    if (sb.Length == 0)
                    {
                        sb.Append(curChar);
                    }
                    else
                    {
                        break;
                    }
                }
                else if (curChar == 48)
                {
                    if (sb.Length == 0)
                    {
                        existZero = true;
                        continue;
                    }
                    else if(sb.Length == 1 && (sb[0] == '+' || sb[0] == '-'))
                    {
                        continue;
                    }
                    else
                    {
                        sb.Append(curChar);
                    }
                }
                else if (curChar > 48 && curChar < 58)
                {
                    sb.Append(curChar);
                }
                else
                {
                    break;
                }
            }

            if (sb.Length == 0)
            {
                return 0;
            }
            else
            {
                var minValChar = int.MinValue.ToString().ToArray();
                var minValCharLen = minValChar.Length;

                var maxValChar = int.MaxValue.ToString().ToArray();
                var maxValCharLen = maxValChar.Length;

                //负数
                if (sb[0] == '-')
                {
                    if (sb.Length == 1)
                    {
                        return 0;
                    }
                    else if(sb.Length < minValCharLen)
                    {
                        return int.Parse(sb.ToString());
                    }
                    else if (sb.Length > minValCharLen)
                    {
                        return int.MinValue;
                    }
                    else
                    {
                        for (int i = 1; i < minValCharLen; i++)
                        {
                            if (sb[i] < minValChar[i])
                            {
                                break;
                            }
                            else if (sb[i] == minValChar[i])
                            {
                                continue;
                            }
                            else // sb[i] > minValChar[i]
                            {
                                return int.MinValue;
                            }
                        }
                        return int.Parse(sb.ToString());
                    }
                }
                //整数
                else
                {
                    if (sb[0] == '+')
                    {
                        sb.Remove(0, 1);
                    }

                    if (sb.Length == 0)
                    {
                        return 0;
                    }
                    else if(sb.Length < maxValCharLen)
                    {
                        return int.Parse(sb.ToString());
                    }
                    else if (sb.Length > maxValCharLen)
                    {
                        return int.MaxValue;
                    }
                    else
                    {
                        for (int i = 0; i < maxValCharLen; i++)
                        {
                            if (sb[i] < maxValChar[i])
                            {
                                break;
                            }
                            else if(sb[i] == maxValChar[i])
                            {
                                continue;
                            }
                            else // sb[i] > maxValChar[i]
                            {
                                return int.MaxValue;
                            }
                        }
                        return int.Parse(sb.ToString());
                    }
                }

            }
        }
    }
}
