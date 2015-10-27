using HCMIS.Extensions.Enums.Attributes;

namespace HCMIS.Enums
{
    [CodeColumn("SupplierTypeCode")]
    public enum SupplierTypes
    {
       [TableCode("HO")] 
       HomeOffice,
       [TableCode("HU")]
       Hubs,
       [TableCode("FCL")]
       Facilities,
       [TableCode("AC")]
       Accounts,
       [TableCode("ST")]
       Stores,
       [TableCode("ES")]
       ExternalSuppliers
    }
}
