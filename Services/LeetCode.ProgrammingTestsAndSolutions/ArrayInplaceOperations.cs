using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Programming.Array
{
	public class ArrayInplaceOperations
	{

		/// <summary>
		/// Given an array arr, replace every element in that array with the greatest element among the elements to 
		/// its right, and replace the last element with -1.
		//  Exmaple : Input: arr = [17,18,5,4,6,1]
		//  Output: [18,6,6,6,1,-1]
		/// After doing so, return the array
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		public static int[] ReplaceElements(int[] arr)
		{
			HashSet<int> arrHash = new HashSet<int>(arr);
			for (int i = 0; i < arr.Length; i++)
			{
				if (i == arr.Length - 1)
				{
					arr[i] = -1;
					break;
				}

				if (arrHash.Any())
				{
					if (arrHash.Contains(arr[i]))
					{
						arr[i] = arrHash.Max();
						arrHash.Remove(arr[i]);
					}
					else
					{
						arr[i] = Math.Max(arr[i], arrHash.Max());
					}
				}
			}

			return arr;
		}

		/// <summary>
		/// Given an array A of non-negative integers, return an array consisting of all the even elements of A,
		/// Followed by all the odd elements of A.
		//  You may return any answer array that satisfies this condition.
		//  Input: [3,1,2,4]
		//  Output: [2,4,3,1]
		//  The outputs[4, 2, 3, 1], [2, 4, 1, 3], and[4, 2, 1, 3] would also be accepted.
		/// </summary>
		/// <param name="A"></param>
		/// <returns></returns>
		public static int[] SortArrayByParity(int[] A)
		{
			int evenIndex = 0;
			int tempVal = 0;
			//int nextValueIndex = 0;

			for (int i = 0; i < A.Length; i++)
			{
				if(A[i] % 2 == 0)
				{
					tempVal = A[evenIndex];
					A[evenIndex] = A[i];
					A[i] = tempVal;
					evenIndex++;
				}
			}
			return A;
		}

		public static  int HeightChecker(int[] heights)
		{

			int[] count = new int[101];
			int[] target = new int[heights.Length];

			// clone array
			for (int i = 0; i < heights.Length; i++)
				target[i] = heights[i];

			// sort heights using counting sort
			for (int i = 0; i < heights.Length; i++)
				count[heights[i]]++;

			int j = 0;
			for (int i = 0; i < count.Length; i++)
				while (count[i] != 0)
				{
					heights[j++] = i;
					count[i]--;
				}

			// Just compare positions
			j = 0;
			for (int i = 0; i < target.Length; i++)
			{
				if (target[i] != heights[i]) j++;
			}
			return j;
		}
	}
}
