using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("PurchaseOrderParentTypeCode")]
    public enum PurchaseOrderParentTypes
    {
       [TableCode("STD")] 
        Standard,
       [TableCode("NSTD")] 
        NonStandard,
       [TableCode("HPOT")]
       HubOnly,
    }
}
