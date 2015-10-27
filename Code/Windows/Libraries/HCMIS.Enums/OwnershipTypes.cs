using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("OwnershipTypeCode")]
    public enum OwnershipTypes
    {
       [TableCode("PRVT")] 
        Private,
       [TableCode("PUB")] 
        Public,
       [TableCode("NGO")] 
        NGO,
       [TableCode("OGA")] 
        OGA,
       [TableCode("UNFR")] 
        Uniformed,

    }
}
