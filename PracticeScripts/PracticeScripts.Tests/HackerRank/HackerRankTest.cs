using PracticeScripts.HakerRank;

namespace PracticeScripts.Tests.HackerRank
{
    public class HackerRankTest
    {
        [Test]
        public void diagonalDifferenceTest()
        {
            //Arrange
            var array = new List<List<int>> { new() { 11, 2, 4 }, new() { 4, 5, 6 }, new() { 10, 8, -12 } };
            int expected = 15;

            //Act
            int result = ScriptsHakerRank.diagonalDifference(array);

            //Assert
            Assert.IsTrue(result == expected);
        }
        [Test]
        [TestCase(new int[] { 11, 2, 4 }, new int[] { 4, 5, 6 }, new int[] { 10, 8, -12 } , 15)]
        public void diagonalDifferenceMultipleTest(int[] arr, int[] arr2, int[] ar3, int expected)
        {
            //Arrange
            var array = new List<List<int>> { arr.ToList(), arr2.ToList(), ar3.ToList() };

            //Act
            int result = ScriptsHakerRank.diagonalDifference(array);

            //Assert
            Assert.IsTrue(result == expected);
        }
    }
}