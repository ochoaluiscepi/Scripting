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
    }
}
