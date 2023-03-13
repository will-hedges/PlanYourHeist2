namespace PlanYourHeist2
{
    public class Bank
    {
        public int AlarmScore { get; set; }
        public int CashOnHand { get; set; }
        public int SecurityGuardScore { get; set; }
        public int VaultScore { get; set; }
        public bool IsSecure
        {
            get
            {
                // If all the scores are less than or equal to 0, this should be false
                if (CashOnHand <= 0 && AlarmScore <= 0 && VaultScore <= 0)
                {
                    return false;
                }
                // If any of the scores are above 0, this should be true
                else
                {
                    return true;
                }
            }
        }
    }
}
