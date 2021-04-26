using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Programming.Array
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

		
	}
}
