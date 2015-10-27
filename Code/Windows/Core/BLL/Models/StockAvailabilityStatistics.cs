namespace BLL.Models
{
    public class StockAvailabilityStatistics
    {
        public int OverStocked { get; set; }
        public int Normal { get; set; }
        public int NearEOP { get; set; }
        public int BelowEOP { get; set; }
        public int Stockout { get; set; }

        public StockAvailabilityStatistics(int overStocked,int normal,int nearEOP, int belowEOP, int stockOut)
        {
            OverStocked = overStocked;
            Normal = normal;
            NearEOP = nearEOP;
            BelowEOP = belowEOP;
            Stockout = stockOut;
        }
    }
}