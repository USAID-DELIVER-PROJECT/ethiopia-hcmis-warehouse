using HCMIS.Extensions.Enums.Attributes;
namespace HCMIS.Enums
{
    [CodeColumn("CoreAccountCategoryCode")]
    public enum CoreAccountCategories
    {
       [TableCode("DB")] 
        Debit,
       [TableCode("CR")] 
        Credit,
       [TableCode("SU")] 
        Suspense,

    }
}
