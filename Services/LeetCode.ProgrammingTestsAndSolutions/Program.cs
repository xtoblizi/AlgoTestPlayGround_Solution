using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode.ProgrammingTestsAndSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] arr = { -7, -3, 2, 3, 11, 12, 3, -45, 3, 1 };
            // int[] result = new int[4];

            var sortedArray = ArrayTestsandLearns.SortAnArray(arr);

            int[] arr1 = { 2, 3, 4, 0, 0, 0 };
            int[] arr2 = { 1, 5, 6 };

      //      var mergedandSortedOnce = ArrayTestsandLearns.MergeandSortTwoArrays(arr1, 3, arr2, 3);


            var result = ArrayTestsandLearns.SortedArraySquares(arr);
            Console.WriteLine(result.ToString());

            int[] testcase1 = { 1, 0, 2, 3, 0, 4, 5, 0 };
            var duplicatedZeros = ArrayTestsandLearns.Duplicate(testcase1);

            int[] nums1 = { 1, 2, 3, 0, 0, 0 }; int[] nums2 = { 2, 5, 6 };

           // int[] arrmax = { 2, 6, 8, 5 };
            int[] arrmax = { 1, 1 };
            var macount = ArrayTestsandLearns.maxSubArraySumCount(arrmax);

            Console.WriteLine($"The max count is {macount}");

            var mergeArray = ArrayTestsandLearns.MergeSortedArray(nums1, nums2);

            foreach (var item in mergeArray)
                Console.WriteLine(item);

            Stack st = new Stack();
            st.Push(1);
            st.Push(1.1);
            st.Push('Z');
            st.Push("Hello");

            foreach (var item in st)
            {
                Console.WriteLine(item);
            }


            
        }
    }
}
