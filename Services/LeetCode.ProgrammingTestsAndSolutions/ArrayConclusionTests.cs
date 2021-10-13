using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Programming.Arrays
{
	public class ArrayConclusionTests
	{
		public static int ThirdMax(int [] nums)
		{
			SortedSet<int> sortedMax = new SortedSet<int>();

			// Transverse the array.
			// if the array has a value as already contained in the hashset. add . however it wont be added as sortedset doesnt accept duplicacy
			// if sortedhashset is less than 3 add to the sorted hashset
			// if its greater then. compare if its greater than the firstordefault if it is then remove firstordefault and add the new value
			// return the firstordefault if count = 3 else lastorfedault

			for (int i = 0; i < nums.Length; i++)
			{
				if(sortedMax.Count < 3)
					sortedMax.Add(nums[i]);
				else
				{
					var n3rd = sortedMax.FirstOrDefault();
					var checkexist = sortedMax.Any(x => x == nums[i]);
					if (!checkexist && n3rd < nums[i])
					{
						sortedMax.Remove(n3rd);
						sortedMax.Add(nums[i]);
					}
				}
			}

			return sortedMax.Count > 2 ? sortedMax.FirstOrDefault() : sortedMax.LastOrDefault();
		}

		/// <summary>
		/// Given an array nums of n integers where nums[i] is in the range [1,n] return an array of all the integers in the range [1,n] that donot appear in nums.
		/// Example1. Input nums = [4,3,2,7,8,2,3,1] Output=> [5,6]. Example2 Input nums=[1,1]. Output => [2]
		/// </summary>
		/// <param name="nums"></param>
		/// <returns></returns>
		public static IList<int> DisappearingNumbers(int [] nums)
		{
			HashSet<int> checker = new HashSet<int>();
			IList<int> result = new List<int>();

			for (int i = 0; i < nums.Length; i++)
			{
				checker.Add(nums[i]);
			}

			for (int i = 1; i <= nums.Length; i++)
			{
				if(!checker.Contains(i))
					result.Add(i);
			}

			return result;
			
		}

		/// <summary>
		/// Given an integer array nums sorted in non-decreasing order, return an array of the sqaures of each number sorted in non-decresing order.
		/// Example 1.  Input: = [-4,-1,0,3,10] Ouput => [0,1,9,16,100].
		/// Example 2.  Input = [17,-3,2,3,11] Output => [4,9,9,49,121]
		/// </summary>
		/// <param name="nums"></param>
		/// <returns></returns>
		public static int[] SortedArraySquares(int [] nums)
		{
			IDictionary<string,int> result = new SortedDictionary<string,int>();
			// do a binary search for 0 if exist if not then add values to the result array graccefully. since its sorted
			var i = Array.BinarySearch(nums, 0);
			int[] subarr;

			if (i != -1)
				subarr = new int[nums.Length-];
			for (int i = 0; i < nums.Length; i++)
			{
				nums[i] = nums[i] * nums[i];
				result.Add(nums[i]);
			}
			return result.ToArray();
		}

		
	}
}
