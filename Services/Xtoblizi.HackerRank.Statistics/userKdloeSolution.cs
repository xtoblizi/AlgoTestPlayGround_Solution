using System;
using System.Collections.Generic;
using System.Text;

namespace Xtoblizi.HackerRank.Statistics
{
    public static class userKdloeSolution
    {
        private static double getMean(int[] numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return (double)sum / numbers.Length;
        }

        private static double getMedian(int[] numbers)
        {
            Array.Sort(numbers);
            int middle = (int)Math.Floor((double)numbers.Length / 2);
            if (numbers.Length % 2 == 0)
            {
                //even length
                return (double)(numbers[middle] + numbers[middle - 1]) / 2;
            }
            else
            {
                //odd length
                return (double)numbers[middle];
            }
        }
        private static int getMode(int[] numbers)
        {
            int mode = 0;
            int modeCount = 0;

            int current = 0;
            int currentCount = 0;
            Array.Sort(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];

                if (current == 0)
                {
                    current = num;
                }
                if (num == current)
                {
                    currentCount++;
                }
                else
                {
                    current = num;
                    currentCount = 1;
                }

                if (currentCount > modeCount || modeCount == 0)
                {
                    mode = current;
                    modeCount = currentCount;
                }
            }

            return mode;
        }

    }
}
