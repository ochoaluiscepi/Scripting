namespace PracticeScripts.CompanyChallenges
{
    public class AmountPaid
    {
        public double CompanyAmountPaid(int salary, int[] debts, int[] interests)
        {
            double amountPaid = 0;
            bool mounthsCounter = true;
            do
            {
                double tenPorcent = salary * 0.10;
                for (int x = 0; x < debts.Length; x++)
                {
                    {
                        if (debts[x] <= tenPorcent)
                        {
                            tenPorcent = tenPorcent - debts[x];
                            amountPaid += debts[x];
                            debts[x] = 0;
                        }
                        else if (debts[x] > tenPorcent)
                        {
                            debts[x] = debts[x] - (int)tenPorcent + (debts[x] - (int)tenPorcent) * (interests[x] / 100);
                            amountPaid += (int)tenPorcent;
                            tenPorcent = 0;
                        }
                    }
                }
            } while (mounthsCounter);

            return amountPaid;

        }
    }
}
