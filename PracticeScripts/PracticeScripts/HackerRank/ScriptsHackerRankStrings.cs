namespace PracticeScripts.HakerRank
{
    public class ScriptsHakerRankStrings
    {

        public static int camelCase(string word)
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

        public static bool isTheStruchtureValid(string bracesBraketsParentesis)
        {
            /* calculate if parentesis braces and brakes are correctly set up 
             * example "{[][()]}", "[({})]", "(){}[]" is valid 
             * this is not "{[}" because is incomplete and "{{([])}}}" neither
            */

            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> matchingPairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

            foreach (char c in bracesBraketsParentesis)
            {
                // If it's an opening bracket, push to stack
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                // If it's a closing bracket
                else if (c == ')' || c == '}' || c == ']')
                {
                    // Check if stack is empty or top doesn't match
                    if (stack.Count == 0 || stack.Pop() != matchingPairs[c])
                    {
                        return false;
                    }
                }
            }

            // If stack is empty, all brackets were properly matched
            return stack.Count == 0;
        }
    }
}
