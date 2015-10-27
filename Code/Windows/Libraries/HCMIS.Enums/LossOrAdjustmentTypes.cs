using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("LossOrAdjustmentTypeCode")]
    public enum LossOrAdjustmentTypes
    {
       [TableCode("LO")] 
        Loss,
       [TableCode("AD")] 
        Adjustment,

    }
}
