using PracticeScripts.HakerRank;

namespace PracticeScripts.Tests.HackerRank
{
    public class HackerRankStringTest
    {
        [Test]
        [TestCase("saveChangesInTheEditor", 5)]
        [TestCase("products", 1)]
        [TestCase("productsAndDeliverables", 3)]
        public void diagonalDifferenceMultipleTest(string word, int expected)
        {
            //Arrange

            //Act
            int result = ScriptsHakerRankStrings.CamelCase(word);

            //Assert
            Assert.IsTrue(result == expected);
        }
    }
}