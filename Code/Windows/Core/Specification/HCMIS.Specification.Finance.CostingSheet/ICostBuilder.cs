namespace HCMIS.Specification.Finance.CostingSheet
{
    public interface ICostBuilder
    {
        decimal CostCoefficient { get; }

        decimal TotalCost { get; }

        decimal InitalCost { get; set; } 

        decimal GetUnitCost(decimal unitCost);

        decimal AddToTotalCost(decimal cost);


    }
}
