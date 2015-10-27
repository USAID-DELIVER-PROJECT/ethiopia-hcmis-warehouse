using HCMIS.Extensions.Enums.Attributes;

namespace HCMIS.Enums
{
    [CodeColumn("InvoiceStatusCode")]
    public enum InvoiceStatus
    {
        [TableCode("DRAFT")]
        Draft,
        [TableCode("PRNT")]
        Printed,
        [TableCode("PENV")]
        PendingVoid,
        [TableCode("VOID")]
        Void,
    }
}