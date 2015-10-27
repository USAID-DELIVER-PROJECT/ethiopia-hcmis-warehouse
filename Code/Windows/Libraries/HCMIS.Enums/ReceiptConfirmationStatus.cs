using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("ReceiptConfirmationStatusCode")]
    public enum ReceiptConfirmationStatus
    {
       [TableCode("DRRC")] 
        DraftReceive,
       [TableCode("REEN")] 
        ReceiveEntered,
       [TableCode("RECC")] 
        ReceiveConfirmed,
       [TableCode("UCC")] 
        UnitCostCalculated,
       [TableCode("PRC")] 
        PriceCalculated,
       [TableCode("PRCO")] 
        PriceConfirmed,
       [TableCode("GRVP")] 
        GRVPrinted,
       [TableCode("SREC")] 
        SuspendedReceives,
       [TableCode("CANC")] 
        Cancelled,
       [TableCode("GRNFP")] 
        GRNFPrinted,

    }
}
