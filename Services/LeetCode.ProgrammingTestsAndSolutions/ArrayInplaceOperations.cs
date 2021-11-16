using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Programming.Arrays
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

		public int[] RotateAnArray(int[] arr)
		{
			if (arr.Length == 1)
				return arr;
			
			var last = arr[^1];
			var temp = arr[0];
			for (var i = 1; i < arr.Length; i++)
			{
				(arr[i], temp) = (temp, arr[i]);
			}

			arr[0] = last;
			return arr;
		}
		public int[] ReverseArray(int[] arr)
		{
			for (var i = 0; i < arr.Length/2; i++)
				(arr[i], arr[arr.Length -i - 1]) = (arr[arr.Length -i - 1], arr[i]);

			// the code above is a deconstructed version of the one below. helps reassign values without create a temp memory location.
			// for (int i = 0; i < arr.Length/2; i++)
			// {
			// 	int temp = arr[i];
			// 	arr[i] = arr[arr.Length - i - 1];
			// 	arr[arr.Length - i - 1] = temp;
			// }

			return arr;
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
