using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("JobTitleCode")]
    public enum JobTitles
    {
       [TableCode("FO")] 
        FinanceOfficer,
       [TableCode("WM")] 
        WarehouseManager,
       [TableCode("SD")] 
        StockandDistributionOfficer,
       [TableCode("IN")] 
        Invoicer,
       [TableCode("DC")] 
        DataClerk,
       [TableCode("FC")] 
        Forcasting,
       [TableCode("IT")] 
        ICTTechnicianandSupport,

    }
}
