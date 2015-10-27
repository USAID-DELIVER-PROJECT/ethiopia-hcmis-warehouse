using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("StorageTypeCode")]
    public enum StorageTypes
    {
       [TableCode("RS")] 
        RackStorage,
       [TableCode("CC")] 
        ColdChain,
       [TableCode("LFP")] 
        LowFlashPoint,
       [TableCode("CD")] 
        ControlledDrug,
       [TableCode("LQ")] 
        LowQuantity,
       [TableCode("PF")] 
        PickFace,
       [TableCode("SA")] 
        SuspensionArea,
       [TableCode("BS")] 
        BulkStorage,
       [TableCode("OPEN")] 
        Open,

    }
}
