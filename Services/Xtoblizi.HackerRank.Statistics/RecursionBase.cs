using System;
using System.Collections.Generic;
using System.Text;

namespace Xtoblizi.HackerRank.Statistics
{
    public class RecursionBase
    {
        public static int factorial (int n)
        {
            Console.WriteLine(n);
            if (n == 1)
            {
                return 1;
            }
            else
            {
                var result = n * factorial(n - 1);
                Console.WriteLine(result);
                return result;
            }
        }

        public static long power(int n, int p)
        {
            if (p != 0)
            {
                return (n * power(n, p - 1));
            }
            return 1;
        }

        /// <summary>
        /// Note 
        /// </summary>
        /// <param name="strg"></param>
        /// <param name="lastsubstringIndex"> Note This is the value of the strg.Length -1</param>
        /// <returns></returns>
        public static string ReverseAString(string strg,int stringLenth)
        {
            //var ouputstring = string.Empty;
            //var currentIndex = stringLenth-1;
            //if(stringLenth > 0)
            //{
            //    //ouputstring = ouputstring + strg.Substring(stringLenth -1);
            //    ouputstring = ouputstring + strg.Substring(currentIndex);
            //    ReverseAString(strg, stringLenth - 1);

            //}
            //return ouputstring;
            if (strg.Length == 1)
            {
                return strg;
            }
            var firstLetter = strg[0];
            var nsub = strg.Substring(1);
            return ReverseAString(nsub,0) + firstLetter;


        }

        public static int length(string str)
        {
            if (str == null || str == "")
                return 0;
            else
            {
                var k = str;
                Console.WriteLine(k);
                return length(str.Substring(1)) + 2;
            }
        }
        /// <summary>
        /// return the value of xEy i.e the exponential value of x raised to power of y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static long pow(int x, int y)
        {
            // base case: when y is of value 1

            if (y == 0)
                return 1;
            else
            {
                return x * (pow(x, y - 1));
            }

        }
        /// <summary>
        /// function to find the highest common divisor. using Euclids principle
        /// divide the greatest by the smallest and get the reminder
        /// </summary>
        /// <param name="h"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static long HCD(long h, long l)
        {
            if (l == 0)
                return h;

            var k = h % l;
            return HCD(l, k);
        }

    }
}
