using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("ReceiptTypeCode")]
    public enum ReceiptTypes
    {
       [TableCode("SR")] 
        StandardReceipt,
       [TableCode("DN")] 
        DeliveryNote,
       [TableCode("SRM")] 
        StockReturnMemoSRM,
       [TableCode("BB")] 
        BeginningBalance,
       [TableCode("ACCT")] 
        AccountTransfer,
       [TableCode("ST")] 
        StoreTransfer,
       [TableCode("ERRC")] 
        ErrorCorrection,
       [TableCode("LP")]
       LocalPurchase,
       [TableCode("MDN")]
       ManualDeliveryNote

    }
}
