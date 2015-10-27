using HCMIS.Extensions.Enums.Attributes;

namespace HCMIS.Enums
{
    [CodeColumn("ExpenseTypeCode")]
    public enum ExpenseType
    {
        [TableCode("INS")]
        Insurance,
        [TableCode("SFRT")]
        SeaFrieght,
        [TableCode("AFRT")]
        AirFreight,
        [TableCode("IFRT")]
        InlandFreight,
        [TableCode("OEXP")]
        OtherExpense,
        [TableCode("NBE")]
        NBEServiceCharge,
        [TableCode("CBE")]
        CBEServiceCharge, 
        [TableCode("CTAX")]
        CustomDutyTax,
        [TableCode("TRAN")]
        TransitServiceCharge, 
    }
}