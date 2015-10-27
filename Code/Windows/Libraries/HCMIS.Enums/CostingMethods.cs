using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("CostingMethodCode")]
    public enum CostingMethods
    {
       [TableCode("MOVA")] 
        MovingAverage,
       [TableCode("FIFO")] 
        FIFO,
       [TableCode("LIFO")] 
        LIFO,

    }
}
