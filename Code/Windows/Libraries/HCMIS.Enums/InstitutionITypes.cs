using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("InstitutionITypeCode")]
    public enum InstitutionITypes
    {
       [TableCode("PFSAH")] 
        PFSAHub,
       [TableCode("VCCH")] 
        VaccineHub,

    }
}
