using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("InstitutionParentTypeCode")]
    public enum InstitutionParentTypes
    {
       [TableCode("AU")] 
        AdministrativeUnits,
       [TableCode("HB")] 
        HUB,
       [TableCode("SDU")] 
        ServiceDeliveryUnits,
       [TableCode("OT")] 
        Others,
       [TableCode("PH")] 
        Pharmacies,
       [TableCode("CN")] 
        Center,
       [TableCode("MC")] 
        Machine,

    }
}
