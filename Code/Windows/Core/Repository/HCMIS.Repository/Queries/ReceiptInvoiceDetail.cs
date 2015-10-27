using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public  class ReceiptInvoiceDetail
    {
        [SelectQuery]
        public static string SelectReceiptInvoiceDetailsFromReceiptInvoice(int receiptInvoiceID)
        {
            string query = string.Format(@"Select rid.*, vw.FullItemName, ui.Text Unit ,man.Name Manufacturer, iub.ID UnitID
				from ReceiptInvoiceDetail rid
                JOIN vwGetAllItems vw ON rid.ItemID = vw.ID
                JOIN UnitOfIssue ui ON ui.ID = rid.UnitOfIssueID
                JOIN itemunitbase iub ON iub.ID = rid.UnitOfIssueID
                LEFT JOIN Manufacturer man ON rid.ManufacturerID = man.ID 
				where ReceiptInvoiceID = {0}",receiptInvoiceID);
            return query;
        }

        [SelectQuery]
        public static string SelectMergedDetailsFromInvoiceAndPO(int receiptInvoiceID)
        {
            string query = string.Format(@"SELECT rid.ReceiptInvoiceDetailID 
                                                   , rid.ReceiptInvoiceID 
                                                   , pod.ItemID 
                                                   , pod.UnitOfIssueID 
                                                   , pod.PreferredManufacturerID ManufacturerID 
                                                   , rid.ExpiryDate 
                                                   , rid.BatchNumber
                                                   , pod.Amount Amount 
                                                   , pod.Quantity OrderedQuantity 
                                                   , rid.Quantity InvoicedQuantity 
                                                   , rid.UnitPrice 
                                                   , rid.Margin 
                                                   , vwItems.FullItemName 
                                                   , ui.[Text]    Unit 
                                                   , man.NAME     Manufacturer 
                                            FROM   receiptinvoice ri 
                                                   JOIN po 
                                                     ON ri.POID = po.ID 
                                                   JOIN purchaseorderdetail pod 
                                                     ON pod.PurchaseOrderId = po.Id 
                                                   LEFT JOIN receiptinvoicedetail rid 
                                                          ON rid.ReceiptInvoiceID = ri.ID 
                                                             AND pod.ItemID = rid.ItemID 
                                                             AND pod.UnitOfIssueID = rid.UnitOfIssueID 
                                                             AND (
                                                                    pod.PreferredManufacturerID = NULL 
                                                                    OR pod.PreferredManufacturerID = rid.ManufacturerID 
                                                                    OR pod.PreferredManufacturerID <> rid.ManufacturerID
                                                                  ) 
                                                   JOIN vwgetallitems vwItems 
                                                     ON pod.ItemID = vwItems.ID 
                                                   JOIN unitofissue ui 
                                                     ON ui.ID = pod.UnitOfIssueID 
                                                   LEFT JOIN manufacturer man 
                                                          ON pod.PreferredManufacturerID = man.ID 
                            where ri.ID = {0}", receiptInvoiceID);
            return query;
        }
    }
}
