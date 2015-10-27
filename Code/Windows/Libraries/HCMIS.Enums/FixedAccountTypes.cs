using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("FixedAccountTypeCode")]
    public enum FixedAccountTypes
    {
       [TableCode("PROV")] 
        Provision7pct,
       [TableCode("PRD")] 
        PriceDifference,
       [TableCode("CFI")] 
        ClaimFromInsurance,
       [TableCode("CFS")] 
        ClaimFromSupplier,
       [TableCode("OI")] 
        OtherIncome,
       [TableCode("IP")] 
        InsurancePayable,
       [TableCode("CS")] 
        CashSales,

    }
}
