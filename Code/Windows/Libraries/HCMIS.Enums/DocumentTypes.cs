using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("DocumentTypeCode")]
    public enum DocumentTypes
    {
       [TableCode("STV ")] 
        STV,
       [TableCode("PO  ")] //~ This Space Has to be rmoved ~//
        PurchaseOrder,
       [TableCode("RINV")] 
        ReceiptInvoice,
       [TableCode("CASH")] 
        Cash,
       [TableCode("CRDT")] 
        Credit,
       [TableCode("IGRV")] 
        IGRV,
       [TableCode("GRV ")] 
        GRV,
       [TableCode("DLVN")] 
        DeliveryNote,
       [TableCode("SRM ")] 
        SRM,
       [TableCode("GRNF")] 
        GRNF,
       [TableCode("ERRC")] 
        ErrorCorrection,
       [TableCode("ENDB")] 
        EndingBalance,

    }
}
