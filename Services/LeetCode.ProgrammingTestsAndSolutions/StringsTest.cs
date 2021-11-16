using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Programming.Arrays
{
	public class StringsTest
	{
		//public static string ReverseAString()
		//{

		//}

		public static bool IsUpperCharacters(string word)
		{
			return word.All(char.IsUpper);
		}
		public static bool IsLowerCharacters(string word)
		{
			return word.All(char.IsLower);
		}
		
		public static bool IsAtEvenLocation(string s, char item)
		{
			for (int i = 0; i < s.Length -1 ; i = 1+2)
			{
				if (s[i] == item && i % 2 == 0)
					return true;
			}

			return false;
		}
		public static int StringSubsequence(string s1, string s2)
		{
			HashSet<string> found = new HashSet<string>();
			int s1Length = s1.Length;
			int s2Length = s2.Length;

			if (string.IsNullOrEmpty(s1))
				return 0;

			if (string.IsNullOrEmpty(s2))
				return 0;


			Dictionary<char, List<int>> subsequenceDict = new Dictionary<char, List<int>>();
			for (int i = 0; i < s2.Length; i++)
			{
				if (subsequenceDict.ContainsKey(s2[i]))
					subsequenceDict[s2[i]].Add(i);
				
				else
				{
					var keyValues = new List<int>();
					keyValues.Add(i);
					subsequenceDict.Add(s2[i], keyValues);
				}
			}

			throw new NotImplementedException("This method has not been completly implemented");
		}


		public static int Pairs(List<int> songs)
		{
			int[] songsArray = songs.ToArray();
			var count = 0;
			for (int i = 0; i < songsArray.Length; i++)
			{
				for (int k = i+1; k < songsArray.Length; k++)
				{
					if ((songsArray[i] + songsArray[k]) % 60 == 0)
						count++;
				}
			}

			return count;
		}
	}
}
