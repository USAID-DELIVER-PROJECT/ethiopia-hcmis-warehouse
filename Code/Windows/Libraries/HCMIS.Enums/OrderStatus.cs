using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("OrderStatusCode")]
    public enum OrderStatus
    {
       [TableCode("DRFT")] 
        Draft,
       [TableCode("ORFI")] 
        OrderFilled,
       [TableCode("APRD")] 
        Approved,
       [TableCode("PIKL")] 
        PickListed,
       [TableCode("PLCN")] 
        PicklistConfirmed,
       [TableCode("ISUD")] 
        Issued,
       [TableCode("CNCL")] 
        Canceled,
       [TableCode("DSCN")] 
        DispatchConfirmed,

    }
}
