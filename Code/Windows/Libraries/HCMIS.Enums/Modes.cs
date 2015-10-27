using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("ModeCode")]
    public enum Modes
    {
       [TableCode("HPR")] 
        HealthProgram,
       [TableCode("RDF")] 
        RDF,

    }
}
