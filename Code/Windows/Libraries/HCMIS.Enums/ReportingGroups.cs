using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("ReportingGroupCode")]
    public enum ReportingGroups
    {
       [TableCode("OD")] 
        Odd,
       [TableCode("EV")] 
        Even,

    }
}
