using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("SoftwareSettingCategoryCode")]
    public enum SoftwareSettingCategories
    {
       [TableCode("AC")] 
        Account,
       [TableCode("CO")] 
        Configuration,
       [TableCode("CU")] 
        Customization,
       [TableCode("FI")] 
        Finance,
       [TableCode("FR")] 
        Formating,
       [TableCode("IV")] 
        Inventory,
       [TableCode("PR")] 
        Printing,
       [TableCode("TR")] 
        Transaction,

    }
}
