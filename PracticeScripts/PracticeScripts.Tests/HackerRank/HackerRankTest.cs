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

        [Test]
        public void plusMinusTest()
        {
            //Arrange
            var array = new List<int>() { -4, 3, -9, 0, 4, 1 };
            var expected = new Tuple<string, string, string>("0.50000","0.33333","0.16667" );

            //Act
            Tuple<string, string, string> result = ScriptsHakerRank.plusMinus(array);

            //Assert
            Assert.IsTrue(result.Equals(expected));
        }

        [Test]
        public void staircaseTest()
        {
            //Arrange
            int n = 6;

            //Act
            List<string> result = ScriptsHakerRank.staircase(n);

            //Assert
            Assert.IsTrue(result.Count == n);
        }

        [Test]
        public void miniMaxSumTest()
        {
            //Arrange
            List<int> arr = [1, 3, 5, 7, 9];

            //Act
            string result = ScriptsHakerRank.miniMaxSum(arr);

            //Assert
            Assert.IsTrue(result == "16 24");
        }
    }
}