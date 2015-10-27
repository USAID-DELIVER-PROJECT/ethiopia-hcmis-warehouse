using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class PO
    {
        [SelectQuery]
        public static string SelectGetUncompletePurchaseOrder()
        {
            string query =
                "select po.ID ID, po.LetterNo PurchaseNumber from PO po left join Receipt rt on rt.POID = po.ID where PO.ID in (Select PO.ID from po left join receipt rt on po.id = rt.poid Group by PO.ID,PO.LetterNo, po.TotalValue having Sum(isNull(rt.TotalValue,0))< po.TotalValue)";
            return query;
        }
        
        [SelectQuery]
        public static string SelectGetInvoiceForPO(int ID)
        {
            string query =
                String.Format(
                    @"select rt.ID,rt.STVOrInvoiceNo InvoiceNumber,rt.WayBillNo,rt.InsurancePolicyNo,rt.TransitTransferNo,rt.TotalValue from PO join Receipt rt on rt.POID = po.ID where PO.ID = {0}",
                    ID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetUncompleteInvoiceID()
        {
            string query = String.Format(@"select * from ReceiptInvoice");
            return query;
        }

        [SelectQuery]
        public static string SelectGetOrderForSelection(int userID, int? purchaseOrderTypeID )
        {
            string customFilter = string.Empty;
            if (purchaseOrderTypeID != null)
            {
                customFilter = string.Format(" AND PurchaseType = {0}", purchaseOrderTypeID);
            }
            string query =
                String.Format(@"select po.ID ID, po.PONumber OrderNumber,
                                s.CompanyName Supplier ,
								IIF(po.IsElectronic = 1 ,'True','False') IsElectronicString,po.IsElectronic, ptype.Name
                            from po left 
                                    join Supplier s on s.ID = po.SupplierID 
									left join vwAccounts acc on po.StoreID = acc.ActivityID
                                left join Procurement.PurchaseOrderType ptype on po.PurchaseType = ptype.PurchaseOrderTypeID
                            where po.PONumber not like 'BeginningBalance' 
                                        and po.PONumber not like 'A2A-%'
                                        and po.HeaderPurchaseOrderID is Null
                                        and po.SupplierID is Not Null 
                                        and ISNULL(po.ModeID,acc.ModeID) in (Select distinct ModeID from UserStore us join
										vwAccounts acc on us.StoreID = acc.ActivityID where UserID={0} and CanAccess=1) {1}", userID,customFilter);
            return query;
        }
        [SelectQuery]
        public static string SelectGetOrderAll(int userID)
        {
            string query =
                String.Format(
                    @"SELECT  po.ID ID ,
                                po.PONumber OrderNumber ,
                                s.CompanyName Supplier ,
                                IIF(po.IsElectronic = 1,'True','False') IsElectronic
                        FROM    po
                                LEFT 
                                                            JOIN Supplier s ON s.ID = po.SupplierID
                        WHERE   po.PONumber NOT LIKE 'BeginningBalance'
                                AND po.PONumber NOT LIKE 'A2A-%'
                                AND po.SupplierID IS NOT NULL
                                AND po.StoreID IN ( SELECT  StoreID
                                                    FROM    UserStore
                                                    WHERE   UserID = {0}
                                                            AND CanAccess = 1 )
                        ORDER BY IsElectronic",
                    userID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetOrderForSelection(int purchaseType, int userID)
        {
            string query =
                String.Format(
                    "select po.ID ID,po.PONumber OrderNumber, s.CompanyName Supplier from po left join Supplier s on s.ID = po.SupplierID where po.PurchaseType = {0} and  po.PONumber not like 'BeginningBalance' and po.PONumber not like 'A2A-%' and po.StoreID in (Select StoreID from UserStore where UserID={1} and CanAccess=1)",
                    purchaseType, userID);
            return query;
        }

        [SelectQuery]
        public static string SelectAllOrderForReport()
        {
            string query =
                String.Format(
                    "select po.ID ID,po.PONumber OrderNumber, s.CompanyName Supplier from po left join Supplier s on s.ID = po.SupplierID ");
            return query;
        }

        [SelectQuery]
        public static string SelectGetDataTable()
        {
            string query =
                String.Format(
                    "select po.ID,po.PONumber,po.RefNo,po.TotalValue,po.Insurance,po.NBE,PO.PurchaseType,s.CompanyName Supplier from Po left join Supplier s on s.ID = po.SupplierID  where purchasetype is not null");
            return query;
        }

        [SelectQuery]
        public static string SelectIsPOEditable(int ID, int disableInvoiceEditAfterStepNo)
        {
            string query =
                String.Format(
                    @"select * from receivedoc rd join receipt rt on rd.ReceiptID = rt.ID 
							        Join ReceivedocConfirmation rdc on rdc.ReceiveDocID = rd.Id
                                    Join ReceiptInvoice ri on ri.ID = rt.ReceiptInvoiceID 
                      where ri.POID = {0} and rdc.ReceiptConfirmationStatusID > {1}",
                    ID, disableInvoiceEditAfterStepNo);
            return query;
        }

        [SelectQuery]
        public static string SelectGetOrderSummary(int invoiceId)
        {
            string query = String.Format(
                @"select ri.STVOrInvoiceNo InvoiceNo,Po.PONumber OrderNumber,vw.FullItemName ItemName
                                ,iu.[Text] Unit,m.Name Manufacturer,rt.ID
                                ,(Select Max(rcp.IDPrinted) from ReceiptConfirmationPrintout rcp where rcp.ReceiptID = rt.ID) GRNFNumber 
                                ,Max(rd.InvoicedNoOfPack) InvoiceQty,sum(NoOfPack) ReceivedQty
                                from (Select Sum (InvoicedNoOfPack) InvoicedNoOfPack,sum(NoOfPack) NoOfPack,ItemID,UnitID,ManufacturerId,ReceiptID from receivedoc Group by ItemID,UnitID,ManufacturerId,ReceiptID) as rd 
			                                join vwGetAllItems vw on vw.ID = rd.ItemID
			                                join ItemUnit iu on iu.ID = rd.UnitID
			                                join Manufacturer m on m.ID = rd.ManufacturerId 
			                                join receipt rt on rd.ReceiptID = rt.ID 
			                                join receiptInvoice ri on ri.ID = rt.ReceiptInvoiceID
			                                join PO on po.ID = ri.POID
                                Where ri.ID = {0}
                                Group by vw.FullItemName,iu.[Text] ,m.Name,rt.ID,ri.STVOrInvoiceNo,Po.PONumber",
                invoiceId);
            return query;
        }

        [SelectQuery]
        public static string SelectIsPOElectronic(int id)
        {
            string query = String.Format(
                @"Select IsElectronic from PO Where ID = {0}", id);
            return query;
        }
        [SelectQuery]
        public static string DoesPONumberExists(string PoNumber)
        {
            return string.Format(@"SELECT PONumber FROM dbo.PO WHERE   PONumber ='{0}'", PoNumber);
        }

        [SelectQuery]
        public static string DoesPOHasDuplicateInvoiceNumbers(int poid, string invoiceNo)
        {
            return string.Format(@"Select StvOrInvoiceNo From ReceiptInvoice where POID = {0} and StvOrInvoiceNo = '{1}'", poid,invoiceNo);
        }

        [SelectQuery]
        public static string GetSelectPOReceives(int poID)
        {
            return string.Format(@"select * from po 
                                    join receiptinvoice ri on po.ID = ri.POID
                                    join receipt r on ri.id = r.receiptinvoiceid
                                    join ReceiptConfirmationStatus rcs on r.ReceiptStatusID = rcs.ID
                                    where po.id = {0} and rcs.ReceiptConfirmationStatusCode in
                                    (
	                                    'REEN', 'RECC', 'UCC', 'PRC', 'PRCO', 'GRVP', 'SREC', 'GRNFP'
                                    )", poID);
        }
    }
}
