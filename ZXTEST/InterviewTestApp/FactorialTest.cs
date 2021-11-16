using System.Numerics;
using FluentAssertions;
using InterviewTesterApp;
using Xunit;

namespace ZXTEST.InterviewTestApp
{
    public class FactorialTest
    {
        [Theory]
        [InlineData(5, 120, "because that is the factorial of 5")]
        public void GetFactorialWithRecursionTest_ReturnFactorial_WhenANumberIsPassed(int number, BigInteger result, string reason)
        {
            // arrange 
            Factorial factorial = new Factorial();
            // act
            var fact = factorial.GetFactorialWithRecursion(number);

            // assert
            fact.Should().Be(result, reason);
        }
        
        [Theory]
        [InlineData(5, 120, "because that is the factorial of 5")]
        public void GetFactorialWithIterationTest_ReturnFactorial_WhenANumberIsPassed(int number, BigInteger result, string reason)
        {
            // arrange 
            Factorial factorial = new Factorial();
            // act
            var fact = factorial.GetFacorialWithIteration(number);

            // assert
            fact.Should().Be(result, reason);
        }
    }
}