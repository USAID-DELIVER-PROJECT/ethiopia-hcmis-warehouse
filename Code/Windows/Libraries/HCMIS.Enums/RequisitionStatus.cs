using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("RequisitionStatusCode")]
    public enum RequisitionStatus
    {
       [TableCode("DRF")] 
        Draft,
       [TableCode("SBL")] 
        SubmittedbutLocal,
       [TableCode("STC")] 
        SubmittedtoCenter,
       [TableCode("APP")] 
        Approved,
       [TableCode("PLP")] 
        PickListPrinted,
       [TableCode("INVP")] 
        InvoicePrinted,

    }
}
