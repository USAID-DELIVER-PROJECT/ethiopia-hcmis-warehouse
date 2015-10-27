using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("OrderTypeCode")]
    public enum OrderTypes
    {
       [TableCode("STDO")] 
        STANDARD_ORDER,
       [TableCode("CIO")] 
        CUSTOM_ISSUE_ORDER,
       [TableCode("STST")] 
        STORE_TO_STORE_TRANSFER,
       [TableCode("HTHT")] 
        HUB_TO_HUB_TRANSFER,
       [TableCode("ATAT")] 
        ACCOUNT_TO_ACCOUNT_TRANSFER,
       [TableCode("ECT")] 
        ERROR_CORRECTION_TRANSFER,
       [TableCode("PLITS")] 
        PLITS,
       [TableCode("INV")] 
        INVENTORY,
       [TableCode("BCO")] 
        BACK_ORDER,

    }
}
