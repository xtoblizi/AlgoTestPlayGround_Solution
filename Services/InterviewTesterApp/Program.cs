using System;
using System.Linq;

namespace InterviewTesterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] givenArr = new int[] { 1, 3, 5, 5, 6, 10 };

            //Console.WriteLine("The highest binary gap for the numbre provided is {0}",
            //    InterviewQuestionSolutions.ArrayRotationAlgorithm(givenArr,2));
            var result = InterviewQuestionSolutions.ArrayRotationAlgorithm(givenArr, 2);
            for (int i = 0; i < result.Length -1; i++)
            {
                Console.WriteLine(i);
            }
           

            Console.ReadLine();
        }
    }
    public static class InterviewQuestionSolutions  {

        /// <summary>
        /// Function to calculate the greatest binary gap
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int HighestBinaryGap(int N)
        {
            string binaryString = Convert.ToString(N,2);

            var processedBinaryString = binaryString.Substring(0,binaryString.LastIndexOf('1')+1);

            var splittedValue = processedBinaryString.Split('1');

            string greaterGap = splittedValue[0];
            for (int i = 0; i < splittedValue.Length -1; i++)
            {
                if(splittedValue[i].Length > greaterGap.Length)
                {
                    greaterGap = splittedValue[i];
                }
                
            }
            return greaterGap.Length;
        }



        public static int[] ArrayRotationAlgorithm(int [] arr, int ktimes)
        {
            try
            {
                int[] givenArr = new int[] { 1, 3, 5, 5, 6, 10 };
                int[] expectedResult = new int[] { 10, 1, 3, 5, 5, 6 };
                int[] expectedResult2 = new int[] { 6, 10, 1, 3, 5, 5 };

                int ntimes = 2;
                int[] arrayname;


                for (int i = 0; i < ntimes; i++)
                {
                    string arraname = $"last{i}";
                    int[] arrayname = new int[givenArr.Length];
                    arrayname[0] = givenArr[givenArr.Length - 1];

                    for (int k = 1; k <= givenArr.Length -1; k++)
                    {
                        arrayname[k] = givenArr[k-1];
                    }
                    givenArr = arrayname;
                }

                return arrayname;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        
        /// <summary>
        /// Using two dimensional array tp properly figure the max size and to purchase canoopies in places to cover 
        /// N house int an estate
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int IntervalCalc()
        {
            int[,] arr = new int[8, 8];
            int[] A = new int[8];
            int[] B = new int[8];

            A[0] = 1;    A[1] = 12;    A[2] = 42;
            A[3] = 70;   A[4] = 36;    A[5] = -4;
            A[6] = 43;    A[7] = 15;

            B[0] = 5;   B[1] = 15;    B[2] = 44;
            B[3] = 72;   B[4] = 36;    B[5] = 2;
            B[6] = 69;    B[7] = 24;

            int[][] x = new int[8][];

            for (int i = 0; i < x.Length; i++)
            {
                x[i] = new int[] { A[i], B[i] };
                Console.WriteLine($"{x[i][0]} {x[i][1]}" );
            }

            int[] x1 = new int[] { 1, 5 };
            int[] x2 = new int[] { 12, 15 };
            int[] x3 = new int[] { 42, 44 };
            int[] x4 = new int[] { 70, 72 };
            int[] x5 = new int[] { 36, 36 };
            int[] x6 = new int[] { -4, 2 };
            int[] x7 = new int[] { 43, 69 };
            int[] x8 = new int[] { 15, 24 };

          var instersect = Find_Common_Elements(x1, x2);


            var result = from i in Enumerable.Range(0, x.Length)
                         from j in Enumerable.Range(0, x[i].Length)
                         orderby x[i][j]
                         select new { i, j };

            var r = result.FirstOrDefault();

            return 2;

           //# maximum height * number of buildings
           //    long single_banner = Math.) * len(H)
           //        smallest_area = single_banner
           //        # 2 banner
           //        for i in range(1, len(H)):
           //            double_banner = (max(H[0:i]) * len(H[0:i])) + (max(H[i:]) * len(H[i:]))
           //            if  double_banner < smallest_area:
           //                smallest_area = double_banner
           //        return smallest_area
           //     if(splittedValue[i].Length > greaterGap.Length)
           //     {
           //         greaterGap = splittedValue[i];
           //     }

            // }
            // return greaterGap.Length;
        }

        public static int[] Find_Common_Elements(int[] p1, int[] p2)
        {
            var point1 = p1[0] < p2[0] ? p1[0] : p2[0];
            var point2 = p1[1] > p2[1] ? p1[1] : p2[1];

            var result = new int[] { point1, point2 };
            return result;
        }
    }
}
