using FluentAssertions;
using LeetCode.Programming.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode.Test
{
	public class StringTest
	{
		[Theory]
		[InlineData("ASdc", false, "Parameter is not all uppercase" )]
		[InlineData("ASdcDCW", false, "Parameter is not all uppercase" )]
		[InlineData("ASDCGF", true, "Parameter is all uppercase" )]
		public void IsUpperCaseTest_ReturnsTrueOrFalse_WhenWordIsAllUpperCase(string param, bool result, string because)
		{
			// Arrange 
			var word = param;

			// Act
			var evaluate = StringsTest.IsUpperCharacters(word);

			//Assert
			evaluate.Should().Equals(result);
		}
		
		[Fact]
		public void PairsTest_ReturnsCount_WhenCountOfPairsOfMultipleOf60()
		{
			// Arrange 
			int[] arrayPLaylist = { 30, 20, 150, 100 };
			List<int> playlist = arrayPLaylist.ToList();

			// Act
			var evaluate = StringsTest.Pairs(playlist);

			//Assert
			evaluate.Should().Equals(3);
		}
	}
}
