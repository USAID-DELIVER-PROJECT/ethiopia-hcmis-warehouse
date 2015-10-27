using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("RequisitionPriorityCode")]
    public enum RequisitionPriorities
    {
       [TableCode("HI")] 
        High,
       [TableCode("MED")] 
        Medium,
       [TableCode("LOW")] 
        Low,

    }
}
