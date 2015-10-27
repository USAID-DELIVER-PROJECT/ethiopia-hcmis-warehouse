using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("LossAndAdjustmentReasonCode")]
    public enum LossAndAdjustmentReasons
    {
       [TableCode("EX")] 
        Expired,
       [TableCode("DM")] 
        Damaged,
       [TableCode("LQ")] 
        LowQuality,
       [TableCode("LO")] 
        Lost,
       [TableCode("FO")] 
        Found,
       [TableCode("RT")] 
        Returned,
       [TableCode("DE")] 
        DataEntryError,
       [TableCode("IV")] 
        Inventory,
       [TableCode("UR")] 
        UnidentifiedReason,
       [TableCode("UI")] 
        UnrecordedIssue,

    }
}
