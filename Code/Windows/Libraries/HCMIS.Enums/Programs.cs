using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("ProgramCode")]
    public enum Programs
    {
       [TableCode("ART")] 
        ART,
       [TableCode("VAC")] 
        Vaccine,

    }
}
