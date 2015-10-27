using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("ReportTypesCode")]
    public enum ReportTypess
    {
       [TableCode("ODD")] 
        Odd,
       [TableCode("EVEN")] 
        Even,

    }
}
