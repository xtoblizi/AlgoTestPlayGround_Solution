using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.ProgrammingTestsAndSolutions
{
    public class ArrayTestsandLearns
    {
        public static int[] SortedArraySquares(int[] nums)
        {
            var sortedarray = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = (nums[i] * nums[i]);
            }
            Array.Sort(nums);
            return nums;
        }


        #region  Duplicate Array Elements of value zero
        /// <summary>
        /// Given a fixed length array arr of integers, duplicate each occurrence of zero, shifting the remaining elements to the right.Note that elements beyond the length of the original array are not written.
        /// Do the above modifications to the input array in place, do not return anything from your function.
        /// 
        /// Input: [1,0,2,3,0,4,5,0]
        /// Output: null
        ///Explanation: After calling your function, the input array is modified to: [1,0,0,2,3,0,0,4]
        /// </summary>
        #endregion
        public static int[] Duplicate(int[] arr)
        {
            //int[] narr = new int[arr.Length];
            //int length = 0;

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    narr[length] = arr[i];

            //    if (arr[i]== 0)
            //    {
            //        narr[length + 1] = 0;
            //        length++;
            //    }
            //    if (length == arr.Length - 1)
            //        break;

            //    length++;
            //}

            ////arr = new int[narr.Length];
            //arr = narr;

            //return arr;
            var jumpcount = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == 0)
                {
                    jumpcount++;
                    for (int j = arr.Length - 1; j > i; j--)
                    {
                        arr[j] = arr[j - 1];
                    }
                    //i++;
                }
                if (jumpcount == arr.Length)
                    break;

                jumpcount++;
            }

            return arr;
        }

        public static int maxSubArraySumCount(int[] blocks)
        {
            #region Initializations
            int size = blocks.Length;
            int current_max = 0, maxsofar = 0;
            int maxcount = 1;
            int current_count = 1;
            int forwardposition = 0;
            
            int oppsite_current_max = 0, opposite_maxsofar = 0;
            int opposite_maxcount = 1;
            int opposite_current_count = 1;
            int backwardposition = 0;
            #endregion

            #region sol
            var lastindex = size - 1;
            for (int i = 0; i < size; i++)
            {
                // initiate tranversal from the front
                if(i != lastindex)
                {
                    if (blocks[i] <= blocks[i + 1])
                    {
                        current_max = current_max + (blocks[i] + blocks[i + 1]);
                        current_count++;
                    }
                    else
                    {
                        forwardposition = i;
                        current_max = 0;
                        current_count = 1;
                        
                    }
                }

                if (current_max > maxsofar)
                {
                    maxsofar = current_max;
                    maxcount = current_count; 
                }

                // traverse from the back
                if (i != lastindex)
                {
                    if (blocks[lastindex - i] <= blocks[lastindex - (i + 1)])
                    {
                        oppsite_current_max = oppsite_current_max + (blocks[lastindex - i] + blocks[lastindex - (i + 1)]);
                        opposite_current_count++;
                    }
                    else
                    {
                        backwardposition = lastindex - i;
                   
                        oppsite_current_max = 0;
                        current_count = 1;
                       
                    }

                    if (oppsite_current_max > opposite_maxsofar)
                    {
                        opposite_maxsofar = oppsite_current_max;
                        opposite_maxcount = opposite_current_count;
                    }
                }
            }

            var max = Math.Max(maxcount, opposite_maxcount);
            return opposite_maxsofar > maxsofar ? opposite_maxcount : maxcount;
            #endregion
        }

        public static int[] MergeSortedArray(int[] s1,int[] s2)
        {
            if (s2.Length == 0)
                return s1;

            var s1indexLength = s1.Length - s2.Length;
            // s1 current pointer
            int k = 0;
            int lastpointer = 0;
            int i = 0;
            for (int n = 0; n < s2.Length; n++)
            {
                for (i= lastpointer; i < s1.Length; i++)
                {
                    if (s2[n] < s1[i])
                    {
                        for (int j = s1indexLength; j > i; j--)
                            s1[j] = s1[j - 1];

                        s1[i] = s2[n];
                        s1indexLength++;
                        lastpointer = i;
                        break;
                    }
                    
                }
            }
           

            return s1;
        }
        /// <summary>
        /// sort an Array 
        /// case : int[] arr = { -7, -3, 2, 3, 11, 12, 3, -45, 3, 1 };
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] SortAnArray(int[] arr)
        {
            var temp = 0;
            var j = 0;
          
            for (int i = 0; i < arr.Length; i++)
            {
                temp = 0;
                var smaller = arr[i];
                for (j = i; j < arr.Length; j++)
                {
                    if(arr[j] < arr[i])
                    {
                        temp = arr[i];
                        arr[i] = Math.Min(arr[i], arr[j]);                      
                        arr[j] = arr[i] == arr[j] ? temp : arr[j];
                    }
                }
            }

            return arr;
        }

        /// <summary>
        /// Fastest and most optimized
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] MergeandSortTwoArraysOption1(int[] nums1, int m, int[] nums2, int n)
        {
            var first = m - 1; var second = n - 1;
            for (int i = nums1.Length - 1; i >= 0; i--)
            {

                if (second < 0)
                    break;

                if (first >= 0 && nums1[first] > nums2[second])
                {
                    nums1[i] = nums1[first];
                    first--;
                }
                else
                {
                    nums1[i] = nums2[second];
                    second--;
                }
            }

            return nums1;
        }

        /// <summary>
        /// Also fast and optimized with minimal memory usage
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] MergeandSortTwoArraysOption2(int[] nums1, int m, int[] nums2, int n)
        {
            //merge the array
            var last = (m + n) - 1;
            while(m>0 && n > 0)
            {
                if(nums1[m-1] > nums2[n - 1])
                {
                    nums1[last] = nums1[m - 1];
                    m--;
                }else
                {
                    nums1[last] = nums2[n - 1];
                    n--;
                }
                last--;
            }
            while (n > 0)
            {
                nums1[last] = nums2[n - 1];
                n--; last--;
            }

            return nums1;
        } 
        
        

        /// <summary>
        /// less faster than above
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] MergeAndSortOption3(int[] nums1, int m, int[] nums2, int n)
        {
          //merge the array
            for (int i = 0; i <n; i++)
            {
                nums1[m] = nums2[i];
                m++;
            }

            var temp = 0;
            var j = 0;
            for (int i = 0; i < nums1.Length; i++)
            {
                temp = 0;
                var smaller = nums1[i];
                for (j = i; j < nums1.Length; j++)
                {
                    if (nums1[j] < nums1[i])
                    {
                        temp = nums1[i];
                        nums1[i] = Math.Min(nums1[i], nums1[j]);
                        nums1[j] = nums1[i] == nums1[j] ? temp : nums1[j];
                    }
                }
            }

            return nums1;
        }
    }
}
