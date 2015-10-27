using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class PurchaseOrderType
    {
        [SelectQuery]
        public static string SelectGetAllPOTypes()
        {
            string query = string.Format(@"Select  pt.*,ptt.Name [Group] from Procurement.PurchaseOrderType PT
                                            Join Procurement.PurchaseOrderParentType ptt on pt.ParentPurchaseOrderTypeID = ptt.PurchaseOrderParentTypeID 
                                            Where pt.IsActive = 1 and pt.PurchaseOrderTypeCode not in ('H2H', 'A2A', 'EC', 'S2S','MDN', 'DN', 'EPO', 'SRM')");
            return query;
        }
            [SelectQuery]
        public static string SelectGetAllHubPOType()
        {
            string query =
                string.Format(@"Select  pt.*,ptt.Name [Group] from Procurement.PurchaseOrderType PT
                                Join Procurement.PurchaseOrderParentType ptt on pt.ParentPurchaseOrderTypeID = ptt.PurchaseOrderParentTypeID
                                where pt.issystem = 0 and pt.isactive = 1");
            return query;
        }
    }
}
