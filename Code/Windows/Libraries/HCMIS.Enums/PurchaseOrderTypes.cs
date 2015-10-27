using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("PurchaseOrderTypeCode")]
    public enum PurchaseOrderTypes
    {
       [TableCode("FOB")] 
        FOB,
       [TableCode("CSFR")] 
        CostandFreight,
       [TableCode("CIP")] 
        CIP,
       [TableCode("CEFR")] 
        CostandEstimatedFreight,
       [TableCode("LTC")] 
        LongTermContract,
       [TableCode("CNS")] 
        Consignment,
       [TableCode("DNT")] 
        Donation,
       [TableCode("INVT")] 
        Inventory,
       [TableCode("INTR")] 
        Internal,
        [TableCode("MDN")]
        ManualDeliveryNote,
        [TableCode("LP")]
        LocalPurchase,

        [TableCode("EPO")]
        EPurchaseOrder,

       [TableCode("A2A")]
       TransferAccount,

       [TableCode("S2S")]
       TransferStore,

       [TableCode("EC")]
       ErrorCorrection,

       [TableCode("H2H")]
       TransferHub,

       [TableCode("SRM")]
       StockReturnMemo,
    }
}
