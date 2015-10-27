using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("InvoiceTypeCode")]
    public enum InvoiceTypes
    {
       [TableCode("ITA")] 
        InvoiceTransportationbyAir,
       [TableCode("ITS")] 
        InvoiceTransportationbySea,
       [TableCode("CIP")] 
        CIP,
       [TableCode("STV")] 
        STV,
       [TableCode("INV")] 
        Inventory,
       [TableCode("LP")] 
        LocalPurchase,
       [TableCode("NS")] 
        NonStandard,
       [TableCode("EC")] 
        ErrorCorrection ,
       [TableCode("INT")]
       Internal,

    }
}
