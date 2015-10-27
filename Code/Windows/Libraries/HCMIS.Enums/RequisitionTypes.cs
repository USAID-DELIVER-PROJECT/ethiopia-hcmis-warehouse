using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("RequisitionTypeCode")]
    public enum RequisitionTypes
    {
        [TableCode("DMN")]
        Demand,
        [TableCode("CNS")]
        Consumption,
        [TableCode("HST")]
        History,
        [TableCode("PPLN")]
        Population,
    }
}
