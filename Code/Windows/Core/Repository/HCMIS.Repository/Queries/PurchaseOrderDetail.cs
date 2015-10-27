using  HCMIS.Repository.Helpers;
namespace HCMIS.Repository.Queries
{
    public class PurchaseOrderDetail
    {
        [SelectQuery]
        public static string SelectPurchaseOrderDetailForPO(int poid)
        {
            string query =
                string.Format(
                    @"SELECT pod.PurchaseOrderDetailID,
                       pod.PurchaseOrderID,
                       pod.ItemID,
                       pod.Quantity,
                       pod.UnitOfIssueID,
                       ISNULL(pod.PreferredManufacturerID,0) PreferredManufacturerID,
                       pod.ApprovedQuantity ,
                       ISNULL(pod.Amount,0) Amount,
                       man.Name Manufacturer,
                       vw.FullItemName,
                       iub.ID UnitID,
                       ui.[Text] Unit
                FROM PurchaseOrderDetail pod
                JOIN vwGetAllItems vw ON pod.ItemID = vw.ID
                JOIN UnitOfIssue ui ON ui.ID = pod.UnitOfIssueID
                JOIN itemunitbase iub ON iub.ID = pod.UnitOfIssueID
                LEFT JOIN Manufacturer man ON pod.PreferredManufacturerID = man.ID
                WHERE pod.PurchaseOrderID = {0}",
                    poid);
               
            return query;
        }
        [SelectQuery]
        public static string SelectUnitforUnitOfIssue(int unitOfIssueID,int itemID)
        {
            string query = string.Format("SELECT * FROM ItemUnitBase Where UnitOfIssueID =  {0} AND ItemID = {1}", unitOfIssueID,itemID);
            return query;
        }
    }
}
