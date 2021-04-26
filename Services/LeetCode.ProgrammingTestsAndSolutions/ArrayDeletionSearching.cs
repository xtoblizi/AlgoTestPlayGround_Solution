using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Programming.Array
{
	public class ArrayDeletionSearching
	{
		/// <summary>
		// Given an array nums and a value val, remove all instances of that value in-place and return the new length.
		// Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
		//  The order of elements can be changed. It doesn't matter what you leave beyond the new length.
		/// </summary>
		// Test-case :  int[] nums = { 0, 1, 2, 2, 3, 0, 4, 2 };
		/// <param name="arr"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		public static int RemoveArrayValueInplace (int[] nums, int val)
		{	
			var last = nums.Length - 1;

			for (int i = nums.Length-1; i >= 0; i--)
			{
				if(nums[i] == val)
				{ 
					if(last != i)
					{
						for (int k = i; k < last; k++)
						{
							nums[k] = nums[k + 1];
						}
						nums[last] = val;
					}

					last--;
				}
			}

			return last+1;
		}
		
		/// <summary>
		/// This works
		/// </summary>
		/// <param name="nums"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		public static int RemoveArrayValueInplace_ENHANCED (int[] nums, int val)
		{	
			var last = 0;

			for (int i = 0; i < nums.Length; i++)
			{
				if(nums[i] != val)
				{
					nums[last] = nums[i];
					last++;
				}
			}

			return last;
		}

		/// <summary>
		//  Given a sorted array nums, remove the duplicates in-place such that each element appears only once and returns the new length.
		//	Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
		///	case1 : 
		///	
		// Input: nums = [0,0,1,1,1,2,2,3,3,4]
		// Output: 5, nums = [0,1,2,3,4]
		// Explanation: Your function should return length = 5, with the first five elements of nums being modified to 0, 1, 2, 3, and 4 respectively.It doesn't matter what values are set beyond the returned length.
		///
		/// </summary>
		/// <param name="nums"></param>
		/// <returns></returns>
		public static int RemoveDuplicatesFromSortedArray(int[] nums)
		{

			if (nums.Length == 0)
				return 0;

			int current = nums[0];
			int position = 1;
			for (int i = 0; i < nums.Length; i++)
			{
				if(nums[i] != current)
				{
					nums[position] = nums[i];
					position++;
					current = nums[i];
				}
			}

			return position;
		}

		/// <summary>
		/// Example array  int[] nnums = {10,2,5,3} ; This works
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		public static bool CheckIfDoubleExist(int [] arr)
		{
			HashSet<int> numsHash = new System.Collections.Generic.HashSet<int>();
			for (int i = 0; i < arr.Length; i++)
			{
				var ndouble = arr[i] * 2;
				var nhalf = arr[i] / 2;

				if (numsHash.Contains(ndouble) || (arr[i] % 2 == 0 && numsHash.Contains(nhalf)))
					return true;

				numsHash.Add(arr[i]);
			}

			return false;
		}

		public static bool ValidMountainArray(int[] arr)
		{
			if (arr.Length < 3)
				return false;

			if (arr[1] < arr[0])
				return false;

			var midpoint = -1;

			for (int i = 0; i < arr.Length-1; i++)
			{
				if (arr[i] == arr[i + 1])
					return false;

				if (arr[i] > arr[i + 1] && midpoint == -1)
					midpoint = arr[i];

				if (arr[i] < arr[i + 1] && midpoint != -1)
					return false;
			}

			return midpoint == -1 ? false : true;
		}
	}
}
