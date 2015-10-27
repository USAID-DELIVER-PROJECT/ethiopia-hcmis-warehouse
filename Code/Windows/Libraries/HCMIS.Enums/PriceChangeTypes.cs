using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("PriceChangeTypeCode")]
    public enum PriceChangeTypes
    {
       [TableCode("REC")] 
        Receive,
       [TableCode("PO")] 
        PriceOverride,
       [TableCode("BEGB")] 
        BeginningBalance,

    }
}
