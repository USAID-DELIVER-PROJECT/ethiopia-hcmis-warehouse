using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("RequisitionPriorityCode")]
    public enum RequisitionPrioritys
    {
       [TableCode("HI")] 
        High,
       [TableCode("MED")] 
        Medium,
       [TableCode("LOW")] 
        Low,

    }
}
