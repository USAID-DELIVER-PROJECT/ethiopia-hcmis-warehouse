using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("TransferTypeCode")]
    public enum TransferTypes
    {
       [TableCode("HTH")] 
        HubToHub,
       [TableCode("ACA")] 
        AccountToAccount,
       [TableCode("STS")] 
        StoreToStore,

    }
}
