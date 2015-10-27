using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class ReceiptInvoice
    {
        [SelectQuery]
        public static string SelectLoadForPO(int POID)
        {
            string query =
                String.Format(
                    "select *,isNull((po.NBE/ case when po.TotalValue = 0 then 1 else po.TotalValue + isNull(po.AirFreight,0) end)*ri.TotalValue,0) proNBE,isNull((po.Insurance/(case when po.TotalValue = 0 then 1 else po.TotalValue + isNull(po.AirFreight,0) end))*ri.TotalValue,0) proInsurance from ReceiptInvoice ri join PO po on ri.POID = po.ID where ri.POID = {0}",
                    POID);
            return query;
        }

        [SelectQuery]
        public static string SelectGetIncompleteInvoices(int userID, bool getOnlyNonElectronic, int poTypeID, int documentTypeID)
        {
            var customeFilter = getOnlyNonElectronic ? "AND po.[IsElectronic] = 0" : string.Empty;

            return String.Format(@"Select *,
                        IIF((DoesOriginalHasReceive = 1 Or (HasReprint = 1 and HasReceive = 0) Or (IsConvertedFromDeliveryNote = 1 and HasReceive = 0)),0,1) Active from(
                          SELECT
                          rctInvoice.*,
                          str.ActivityName,
                          str.AccountName,
                          str.SubAccountName,
                          str.ModeName AS Mode,
                          po.RefNo PONo,
                          po.PONumber,
                          po.RefNo,
                          po.IsElectronic,
                          s.CompanyName SupplierName,
                          e.Name AS Shipper,
                         Case When x.TotalInvoiceQ is null or x.TotalInvoiceQ = 0 Then 100 Else CAST(Round(((IsNull(x.TotalReceiveDocQ,0))/IsNull(x.TotalInvoiceQ,1)) * 100,2) AS NUMERIC(36,2)) End PercentReceived,
					     Case When IsNull(x.TotalReceiveDocQ,0) = 0 then 0 else 1 end As HasReceive,
					     Case When rctInvoice.ID in (SELECT DISTINCT IsReprintOf From ReceiptInvoice Where IsReprintOf IS NOT NULL) then 1 else 0 end As HasReprint,
                         Case When rctInvoice.IsReprintOf Is Not Null AND rctInvoice.IsReprintOf in ((SELECT DISTINCT ReceiptInvoiceID From Receipt JOIN ReceiveDoc ON Receipt.ID = ReceiveDoc.ReceiptID)) then 1 else 0 end As DoesOriginalHasReceive

                        FROM ReceiptInvoice rctInvoice
                    JOIN PO po
                      ON rctInvoice.POID = po.ID 
                    JOIN vwAccounts str
                      ON rctInvoice.ActivityID = str.ActivityID
                    LEFT JOIN Supplier s
                      ON po.SupplierID = s.ID
					LEFT JOIN USM.Environment e ON e.rowguid = CAST(po.ShippingSite AS uniqueidentifier)
                    JOIN (SELECT ri.ID ReceiptInvoiceID, 
					      TotalInvoiceQ = (Select SUM(isNULL(Quantity,0)) From ReceiptInvoiceDetail Where ReceiptInvoiceID = ri.ID),
					      TotalReceiveDocQ = (Select SUM(isNULL(Quantity,0)) From ReceiveDoc rd join Receipt r on rd.ReceiptID = r.ID Where r.ReceiptInVoiceID = ri.ID)										
									From ReceiptInvoice ri
									GROUP BY ri.ID) AS x
                      ON rctInvoice.ID = x.ReceiptInvoiceID
                    WHERE po.PurchaseType = {0} AND rctInvoice.DocumentTypeID = {1} AND rctInvoice.IsVoided = 0
                    AND rctInvoice.ActivityID IN (SELECT us.StoreID FROM UserStore us WHERE us.UserID = {2}  AND CanAccess = 1) {3}
					)y
                    ORDER BY PercentReceived, PrintedDate ASC, PONo",poTypeID,documentTypeID, userID, customeFilter);
               
        }

        [SelectQuery]
        public static string SelectGetIncompleteInvoicesForCenter(int userID, bool isDeliveryNote)
        {
            var query = String.Format(@"Select 
                                         1 Active
                                        ,rctInvoice.*
                                        , str.ActivityName
                                        , str.AccountName
                                        , str.SubAccountName
                                        , m.TypeName as Mode
                                        , po.PONumber PONo
                                        , s.CompanyName SupplierName
                                        , po.ShippingSite as Shipper
                                        , CAST(Round((x.TotalReceiveDocQ/x.TotalInvoiceQ) * 100,2) AS NUMERIC(36,2)) PercentReceived
                                        From ReceiptInvoice rctInvoice 
                                        Join PO po on rctInvoice.POID = po.ID 
                                        Join vwAccounts str on po.StoreID = str.ActivityID 
                                        Join Supplier s on po.SupplierID = s.ID 
                                        Left join Mode m on str.ModeID = m.ID		
                                        JOIN (SELECT rid.ReceiptInvoiceID,SUM(ISNULL(rid.Quantity,0)) TotalInvoiceQ, SUM(isNULL(rd.Quantity,0)) TotalReceiveDocQ								
										FROM ReceiptInvoiceDetail rid
										JOIN ReceiptInvoice ri on rid.ReceiptInvoiceID = ri.id
										LEFT JOIN Receipt r
										  ON r.ReceiptInvoiceID = rid.ReceiptInvoiceID
										LEFT JOIN ReceiveDoc rd
										  ON rd.ReceiptID = r.ID
										GROUP BY rid.ReceiptInvoiceID) x
											ON rctInvoice.ID = x.ReceiptInvoiceID	
                                        Where rctInvoice.STVOrInvoiceNO Not like 'BeginningBalance' 
                                        And po.PONumber 
                                        Not like 'A2A-%'  
                                        And po.[IsElectronic] = 0 AND rctInvoice.IsDeliveryNote = {0}
                                        and po.StoreID in (   
								                            SELECT us.StoreID FROM UserStore us WHERE us.UserID= {1} and CanAccess=1
								                           )									
                                        Order By PercentReceived, PrintedDate asc, PONo",  isDeliveryNote ? "1" : "0",userID);
            return query;
        }


        [SelectQuery]
        public static string SelectGetDataTable()
        {
            string query =
                String.Format(
                    @"select *,isNull((po.NBE/po.TotalValue)*ri.TotalValue,0) proNBE,isNull((po.Insurance/po.TotalValue)*ri.TotalValue,0) proInsurance from ReceiptInvoice ri join PO po on ri.POID = po.ID where po.PurchaseType is not null");
            return query;
        }

        [SelectQuery]
        public static string SelectGetStatusOfInvoice(string invoiceNo)
        {
            string query =
                String.Format(
                    @"select r.ID ReceiptID, rcp.IDPrinted PrintoutNumber,rcp.Reason TypeOfPrintout, rcs.Name ReceiptStatus,rcs.[Description] StatusDescription from ReceiveDocConfirmation rdc left join ReceiptConfirmationStatus rcs 
                                        on rdc.ReceiptConfirmationStatusID=rcs.ID left join ReceiveDoc rd on rdc.ReceiveDocID=rd.ID left join Receipt r on rd.ReceiptID=r.ID
                                        left join ReceiptConfirmationPrintout rcp on rcp.ReceiptID=r.ID
                                        where rdc.ReceiveDocID in 
                                        (
                                        select ID from receivedoc where ReceiptID
                                        in(
                                         select ID from receipt where ReceiptInvoiceID in 
                                        (select ID from receiptinvoice where STVOrInvoiceNo='{0}')))",
                    invoiceNo);
            return query;
        }

        [SelectQuery]
        public static string SelectIsInvoiceEditable(int ID, int disableInvoiceEditAfterStepNo)
        {
            string query =
                String.Format(
                    @"select * from receivedoc rd join receipt rt on rd.ReceiptID = rt.ID 
							        Join ReceivedocConfirmation rdc on rdc.ReceiveDocID = rd.Id
                      where rt.ReceiptInvoiceID = {0} and rdc.ReceiptConfirmationStatusID > {1}",
                    ID, disableInvoiceEditAfterStepNo);
            return query;
        }

        [SelectQuery]
        public static string SelectGetRelatedReceives(int id)
        {
            string query =
                String.Format(@"select  v.ID
			                                , v.StockCode
	                                        , iu.ID as UnitID
	                                        , v.Name as CommodityType
	                                        , v.FullItemName
                                            , v.TypeID
	                                        , iu.Text as Unit
	                                        , rd.ManufacturerID
                                            , rd.BatchNo
                                            ,rd.ExpDate,rd.UnitPrice,rd.Margin
	                                        , Max(rd.InvoicedNoOfPack) InvoicedNoOfPack
	                                        , Max(rd.InvoicedNoOfPack) - sum(rd.NoOfPack) RemainingQty
                                            , sum(rd.NoOfPack) NoOfPack
	                                        , m.Name as Manufacturer
	                                        , CASE WHEN (SELECT COUNT(*) from ItemManufacturer i where i.ItemID = v.ID) > 0 then 1 else 0 end as HasManufacturer
	                                        , IsSelected = cast(1 as bit)
	                                        , IsReturnedStock=cast(0 as bit)
                                        from (select ItemID
					                                ,UnitID
                                                    , rd.BatchNo
                                                    ,rd.ExpDate
					                                ,ManufacturerID
					                                ,StoreID
					                                ,sum(NoOfPack) NoOfPack
					                                ,sum(rd.InvoicedNoOfPack) InvoicedNoOfPack
													,rd.PricePerPack UnitPrice,
													rd.Margin
				                                from ReceiveDoc rd 
						                                join receipt rt on rd.ReceiptID = rt.ID
				                                where rt.ReceiptInvoiceID = {0}
                                                group by ItemID ,UnitID
					                                ,ManufacturerID ,StoreID,ReceiptID, rd.BatchNo
                                                    ,rd.ExpDate,rd.PricePerPack,rd.Margin) as rd
		                                        join vwGetAllItems v   on rd.ItemID=v.ID 
                                                join Manufacturer m on m.ID = rd.ManufacturerID
                                                join ItemUnit iu on rd.UnitID = iu.ID
                                        where v.IsInHospitalList = 1
		                                group by v.ID,v.StockCode, m.Name, iu.ID, v.Name , v.FullItemName, v.TypeID, iu.Text,
		                                            rd.ManufacturerID, rd.BatchNo
                                                    ,rd.ExpDate ,rd.UnitPrice,rd.Margin
                                        ORDER BY v.FullItemName", id);
            return query;
        }

        [SelectQuery]
        public static string SelectIsInvoiceElectronic(string invoiceNo)
        {
            var query = String.Format(
                @"Select po.IsElectronic
                    From ReceiptInvoice ri
                    Join PO on ri.POID = PO.ID
                    Where STVOrInvoiceNo = '{0}'", invoiceNo);
            return query;
        }
        [SelectQuery]
        public static string SelectIfThisInvoiceHasBeenReceived(int recieptInvoiceId)
        {
            var query = String.Format(
                                        @"SELECT distinct ReceiptID FROM ReceiveDoc rd 
                                                           join Receipt r ON rd.ReceiptID = r.ID
                                                           join ReceiptInvoice rin ON r.ReceiptinvoiceID = rin.ID
                                                           WHERE rin.ID = {0}",
                recieptInvoiceId);
            return query;
        }
        [SelectQuery]
        public static string SelectGetInvoiceQuantity(string invoiceNo, string itemId, string unitId, string manufacturerId)
        {
            var query = String.Format(@"Select SUM(rid.Quantity) Quantity
                                        From ReceiptInvoice ri
                                        Join ReceiptInvoiceDetail rid on ri.ID = rid.ReceiptInvoiceID
                                        Where STVOrInvoiceNo = '{0}' and ItemID = {1} and UnitOfIssueID = {2} and ManufacturerID = {3}
                                        Group by ItemID, UnitOfIssueID, ManufacturerID, STVOrInvoiceNo
                                        ", invoiceNo, itemId, unitId, manufacturerId);
            return query;
        }

        public static string SelectGetPrintedDate(int receiptInvoiceID)
        {
            string query =
                String.Format(@"select receiptInvoice.PrintedDate from ReceiptInvoice receiptInvoice where receiptInvoice.id = {0} ", receiptInvoiceID);
            return query;
        }

        public static string SelectGetReprintedInvoice(int receiptInvoiceID)
        {
            string query = string.Format(@"Select * from ReceiptInvoice where isreprintOf = {0}", receiptInvoiceID);
            return query;
        }
    }
}
