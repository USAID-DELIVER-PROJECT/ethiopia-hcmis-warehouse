using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("AdministrativeUnitTypeCode")]
    public enum AdministrativeUnitTypes
    {
       [TableCode("RE")] 
        Region,
       [TableCode("ZO")] 
        Zone,
       [TableCode("WE")] 
        Woreda,

    }
}
