using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("InventoryStatusCode")]
    public enum InventoryStatus
    {
       [TableCode("BI")] 
        BeginInventory,
       [TableCode("PC")] 
        PrintCountSheet,
       [TableCode("DI")] 
        DraftInventorySaved,

    }
}
