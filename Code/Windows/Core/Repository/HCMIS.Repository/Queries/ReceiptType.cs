using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class ReceiptType
    {
        [SelectQuery]
        public static string SelectGetAllReceiptTypes()
        {
            return string.Format(@"Select * from ReceiptType where isActive = 1 and IsSystemReceiptType = 0 Order By Name");
        }
    }
}
