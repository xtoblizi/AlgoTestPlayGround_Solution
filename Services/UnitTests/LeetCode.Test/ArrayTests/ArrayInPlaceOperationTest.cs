using FluentAssertions;
using LeetCode.Programming.Arrays;
using Xunit;

namespace LeetCode.Test.ArrayTests
{
    public class ArrayInPlaceOperationTest
    {
        [Fact]
        public void ReverseArrayInPlaceTest_ShouldReturnReversedArray()
        {
            //arrange 
            int[] input = {8, 3, 4, -1, 5};
            var arrayOperations = new ArrayInplaceOperations();
            int[] expectedResult = {5, 4, -1, 3, 8};
            // act 
            var result = arrayOperations.ReverseArray(input);
            
            // assert
            result.Should().BeEquivalentTo(expectedResult);
        }
        [Fact]
        public void RotateArrayInPlaceTest_ShouldReturnRotatedArray()
        {
            //arrange 
            int[] input = {8, 3, 4, 2};
            var arrayOperations = new ArrayInplaceOperations();
            int[] expectedResult = {2, 8, 3, 4};
            // act 
            var result = arrayOperations.RotateAnArray(input);
            
            // assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
    
}