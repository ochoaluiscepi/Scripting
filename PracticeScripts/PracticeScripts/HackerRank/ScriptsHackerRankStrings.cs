namespace PracticeScripts.HakerRank
{
    public class ScriptsHakerRankStrings
    {

        public static int CamelCase(string word)
        {
            /* There is a sequence of words in CamelCase as a string of letters,having the following properties:

            It is a concatenation of one or more words consisting of English letters.
            All letters in the first word are lowercase.
            For each of the subsequent words, the first letter is uppercase and rest of the letters are lowercase.

             * */
            int counter = 1;

            foreach (char letter in word)
            {
                if (char.IsUpper(letter))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
