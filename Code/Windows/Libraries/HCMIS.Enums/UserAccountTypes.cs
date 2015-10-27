using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("UserAccountTypeCode")]
    public enum UserAccountTypes
    {
       [TableCode("RD")] 
        Reader,
       [TableCode("ED")] 
        Editor,
       [TableCode("HU")] 
        Hub,
       [TableCode("HHE")] 
        HCMISHE,
       [TableCode("HFE")] 
        HCMISFE,
       [TableCode("DC")] 
        DataCleanUpClerk,

    }
}
