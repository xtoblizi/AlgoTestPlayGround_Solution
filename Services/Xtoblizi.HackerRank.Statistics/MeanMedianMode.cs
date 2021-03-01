using System;
using System.Collections.Generic;
using System.Linq;

namespace Xtoblizi.HackerRank.Statistics
{
    public class MeanMedianMode
    {
        /**
     *  
        For a given series ;
        The first line contains an integer, , the number of elements in the array.
        The second line contains  space-separated integers that describe the array's elements.

        Constraints
        1. 10<= x >= 2500
        2. 0 < x[i] <= 10E5 (note E: stands for exponential. note: where x[i] is the ith element of the array)

        Write a program to the results in the following Output Format Below

        Print 3 lines of output in the following order:

        1. Print the mean on the first line to a scale of  decimal place (i.e., , ).
        2. Print the median on a new line, to a scale of  decimal place (i.e., , ).
        3. Print the mode on a new line. If more than one such value exists, print the numerically smallest one.
    
        A sample input would be :
        10
        64630 11735 14216 99233 14470 4978 73429 38120 51135 67060

        And Ouput would be 43900.6 , 44627.5 , 4978
     * 
     */

        public  (double mean, double median, double mode) ReturnStats(int n, int[] series)
        {
            var mean = ReturnMean(n, series);
            var median = ReturnMedian(n, series);
            var mode = ReturnMode(n, series);

            (double mean, double median, double mode) results = (mean, median, mode);

            return results;
        }

        /// <summary>
        /// Calculate and reutrn the mean of a series
        /// </summary>
        /// <param name="n"></param>
        /// <param name="series"></param>
        /// <returns></returns>
        private   double ReturnMean(int n, int[] series)
        {
            try
            {
                if (n == 0)
                    throw new ArgumentNullException("The size of the series cannot be empty");

                var sum = series.Sum();
                var result = (double)sum / n;
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Return the middle number of a series
        /// </summary>
        /// <param name="n"></param>
        /// <param name="series"></param>
        /// <returns></returns>
        private  double ReturnMedian(int n, int[] series)
        {
            try
            {
                if (n == 0)
                    throw new ArgumentNullException("The size of the series cannot be empty");
                double middlen = 0;
                int middle = (int)Math.Floor((double)series.Length/2);
                Array.Sort(series);
                if (n % 2 == 0)
                {
                    var middle1 = series[middle - 1];
                    var middle2 = series[middle];
                    var nmiddle = (middle1 + middle2 );
                    middlen = (double)nmiddle / 2;
                }
                else
                {
                    middlen = series[middle];
                }

                return middlen;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Return the mode of a series .I.E The most occuring element in an array
        /// </summary>
        /// <param name="n"></param>
        /// <param name="series"></param>
        /// <returns></returns>
        private  double ReturnMode(int n, int[] series)
        {
            try
            {
                Dictionary<int, int> elementFrequencyPair = new Dictionary<int, int>();
                for (int i = 0; i < n; i++)
                {
                    var key = series[i];
                    if (elementFrequencyPair.ContainsKey(key))
                        elementFrequencyPair[key] = elementFrequencyPair[key] + 1;
                    else
                        elementFrequencyPair.Add(key, 1);
                }

                var ordered = elementFrequencyPair.OrderBy(x => x.Key)
                    .ToDictionary(d => d.Key, d => d.Value);

                var result = ordered.FirstOrDefault().Key;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
