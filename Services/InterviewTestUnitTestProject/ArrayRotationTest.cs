using InterviewTesterApp;
using NUnit.Framework;

namespace InterviewTestUnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ArrayrotationTest_TestRotationTwice_ReturnTheCommentAbove()
        {
            // arrange
            int[] expectedResult2 = new int[] { 6, 10, 1, 3, 5, 5 };
            int[] givenArr = new int[] { 1, 3, 5, 5, 6, 10 };


            // act
            var rotationArrayResult = InterviewQuestionSolutions.ArrayRotationAlgorithm(givenArr, 2);


            // assert
            Assert.That( rotationArrayResult,Is.EqualTo(expectedResult2));
        }
    }
}