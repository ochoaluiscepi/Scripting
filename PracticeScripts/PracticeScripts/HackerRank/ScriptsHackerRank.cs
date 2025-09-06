namespace PracticeScripts.HakerRank
{
    public class ScriptsHakerRank
    {

        public static int diagonalDifference(List<List<int>> arr)
        {
            //arr = [[11, 2, 4], [4, 5, 6], [10, 8, -12]]
            /*
                1 2 3
                4 5 6
                9 8 9
                1+5+9 = 15
                3+5+9 = 17
                Result |15-17| = 2
             * */
            int one = 0; int two = 0;
            int size = arr.Count;
            for (int x = 0; x < size; x++)
            {
                one += arr[x][x];
                two += arr[x][arr.Count - 1 - x];
            }

            return Math.Abs(one - two);
        }

        public static Tuple<string,string,string> plusMinus(List<int> arr)
        {
            /*
             * Given an array of integers, calculate the ratios of its elements that are positive, negative and zero. 
             * Print the decimal value of each fraction on a new line with 6 places after the decimal.
             * */
            int size = arr.Count;
            double positiveRadio = (double)arr.Count(x => x > 0) / size;
            double negativeRadio = (double)arr.Count(x => x < 0) / size;
            double zeroRadio = (double)arr.Count(x => x == 0) / size;

            return new Tuple<string, string, string>(positiveRadio.ToString("F5"), negativeRadio.ToString("F5"), zeroRadio.ToString("F5"));
        }
        public static List<string> staircase(int n)
        {
            /*
             * This is a staircase of size 4
              #
             ##
            ###
           ####

           Its base and height are both equal to
           It is drawn using # symbols and spaces. The last line is not preceded by any
             */
            List<string> result = new List<string>();
            for (int x = 1; x <= n; x++)
            {
                string line = "";
                for (int y = 1; y <= n; y++)
                {
                    if (n - y < x)
                    {
                        line += "#";
                    }
                    else
                    {
                        line += " ";
                    }
                }
                result.Add(line);
            }
            return result;
        }

        public static string miniMaxSum(List<int> arr)
        {
            /*
             * Given five positive integers, find the minimum and maximum values that can be calculated by summing exactly 
             * four of the five integers. Then print the respective minimum and maximum values as a single line of two space-separated 
             *  long integers.

             Example arr = [1,3,5,7,9]
             The minimum sum 1+3+5+7 is and the maximum sum is 3+5+7+9 . The function prints 16 24
             * */
            arr.Sort();

            int max = arr.Skip(1).Sum();
            int min = arr.SkipLast(1).Sum(); 
            return $"{min} {max}";
        }
    }
}
