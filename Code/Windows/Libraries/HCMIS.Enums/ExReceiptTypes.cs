using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("ReceiptTypeCode")]
    public enum ExReceiptTypes
    {
       [TableCode("GIT")] 
        GIT,
       [TableCode("NA")] 
        NetAsset,

    }
}
