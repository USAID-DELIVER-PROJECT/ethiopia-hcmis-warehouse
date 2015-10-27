using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("PaymentTypeCode")]
    public enum PaymentTypes
    {
       [TableCode("CRD")] 
        Credit,
       [TableCode("CAS")] 
        Cash,
       [TableCode("STV")] 
        STV,
       [TableCode("DN")] 
        DeliveryNote,
       [TableCode("ERCR")] 
        ErrorCorrection,
       [TableCode("ENIN")] 
        EndingInventory,
       [TableCode("DISP")] 
        Disposal,

    }
}
