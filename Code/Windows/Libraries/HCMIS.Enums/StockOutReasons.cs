using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("StockOutReasonCode")]
    public enum StockOutReasons
    {
       [TableCode("DTE")] 
        DuetoExpiry,
       [TableCode("DTL")] 
        DuetoLoss,
       [TableCode("DTD")] 
        DuetoDamage,
       [TableCode("LDP")] 
        LateDeliveryofproducts,
       [TableCode("EIR")] 
        Errorinrequesting,
       [TableCode("UCN")] 
        UnexpectedConsumption,
       [TableCode("LTDS")] 
        LimitedSupply,
       [TableCode("AID")] 
        AvailableintheDispensary,
       [TableCode("OTR")] 
        Others,

    }
}
