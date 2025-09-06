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
            int result = ScriptsHakerRankStrings.camelCase(word);

            //Assert
            Assert.IsTrue(result == expected);
        }

        [Test]
        [TestCase("{[][()]}", true)]
        [TestCase("[({})]", true)]
        [TestCase("(){}[]", true)]
        [TestCase("{{([])}}}", false)]
        [TestCase("({}]", false)]
        public void isTheStruchtureValidTest(string braces, bool expected)
        {
            //Arrange

            //Act
            bool result = ScriptsHakerRankStrings.isTheStruchtureValid(braces);

            //Assert
            Assert.IsTrue(result == expected);
        }
    }
}