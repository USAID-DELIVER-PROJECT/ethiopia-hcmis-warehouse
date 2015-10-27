using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("OrderSubTypeCode")]
    public enum OrderSubTypes
    {
       [TableCode("LTC")] 
        Longtermcontract,
       [TableCode("CSN")] 
        Consignment,
       [TableCode("DON")] 
        Donation,
       [TableCode("FOB")] 
        FOB,
       [TableCode("CF")] 
        CostandFreight,
       [TableCode("CIP")] 
        CIP,
       [TableCode("COSE")] 
        CostandEstimated,
       [TableCode("FRIG")] 
        Freight,

    }
}
