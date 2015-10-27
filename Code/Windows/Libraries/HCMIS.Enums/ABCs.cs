using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("ABCCode")]
    public enum ABCs
    {
       [TableCode("A")] 
        A,
       [TableCode("B")] 
        B,
       [TableCode("C")] 
        C,

    }
}
