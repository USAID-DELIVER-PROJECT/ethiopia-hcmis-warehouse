using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("DepartmentCode")]
    public enum Departments
    {
       [TableCode("DS")] 
        Distribution,
       [TableCode("FI")] 
        Finance,
       [TableCode("FC")] 
        Forecasting,
       [TableCode("AD")] 
        Administration,

    }
}
