using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Repository.Helpers;

namespace HCMIS.Repository.Queries
{
    public class LossAndAdjustment
    {
        [SelectQuery]
        public static string SelectGetDocumentByRefNo(string refNo, int storeId, string adjDate)
        {
            string query = String.Format("SELECT (d.Quantity / rd.QtyPerPack) as Quantity, (d.Quantity / rd.QtyPerPack) * rd.Cost as Cost  , d.*, vw.FullItemName, vw.StockCode, dr.Reason FROM LossAndAdjustment d join ReceiveDoc rd on d.RecID = rd.ID join vwGetAllItems vw on d.ItemID = vw.ID join LossAndAdjustmentReason dr on d.ReasonID = dr.ID  WHERE (d.RefNo = '{0}') AND d.Date = '{2}' AND d.StoreId = {1}", refNo, storeId, adjDate);
            return query;
        }

        public static string SelectGetAllTransaction(int storeId)
        {
            string query = String.Format("SELECT (d.Quantity / rd.QtyPerPack) as Quantity, (d.Quantity / rd.QtyPerPack) * rd.Cost as Cost  , d.*, vw.FullItemName, vw.StockCode, dr.Reason FROM LossAndAdjustment d join ReceiveDoc rd on d.RecID = rd.ID join vwGetAllItems vw on d.ItemID = vw.ID join LossAndAdjustmentReason dr on d.ReasonID = dr.ID  WHERE StoreId = {0} ORDER BY Date DESC", storeId);
            return query;
        }

        public static string SelectGetTransactionByReason(int storeId, int reasonId)
        {
            string query = String.Format("SELECT (d.Quantity / rd.QtyPerPack) as Quantity, (d.Quantity / rd.QtyPerPack) * rd.Cost as Cost  , d.*, vw.FullItemName, vw.StockCode, dr.Reason FROM LossAndAdjustment d join ReceiveDoc rd on d.RecID = rd.ID join vwGetAllItems vw on d.ItemID = vw.ID join LossAndAdjustmentReason dr on d.ReasonID = dr.ID WHERE StoreId = {0} AND ReasonId = {1} ORDER BY Date DESC", storeId, reasonId);
            return query;
        }

        public static string SelectGetLossAdjustmentsForLastRRFPeriod(int itemID, int storeID, DateTime startDate, DateTime endDate)
        {
            string query = String.Format(
                "select * from disposal d join ReceiveDoc rd on d.RecID=rd.ID where  d.EurDate>cast('{0}' as datetime) and d.EurDate<=cast('{1}' as datetime) and rd.ItemID={2} and rd.StoreID={3}",
                startDate, endDate, itemID, storeID);
            return query;
        }

        public static string SelectGetTransactionByDateRange(int storeId, DateTime dt1, DateTime dt2)
        {
            string query = String.Format("SELECT ( CASE when Losses = 1 then 0 - d.Quantity else d.Quantity end / rd.QtyPerPack) as Quantity, (d.Quantity / rd.QtyPerPack) * rd.Cost as Cost  , d.*, vw.FullItemName, vw.StockCode, dr.Reason FROM LossAndAdjustment d join ReceiveDoc rd on d.RecID = rd.ID join vwGetAllItems vw on d.ItemID = vw.ID join LossAndAdjustmentReason dr on d.ReasonID = dr.ID WHERE d.StoreId = {0} AND (d.Date BETWEEN '{1}' AND '{2}' ) ORDER BY d.Date DESC", storeId, dt1.ToShortDateString(), dt2.ToShortDateString());
            return query;
        }

        public static string SelectGetDistinctAdjustmentDocments(int storeId)
        {
            string query = String.Format("SELECT DISTINCT RefNo, StoreId, Date, cast (Year(Date) as varchar) as ParentID, RefNo + cast(Date as varchar) as ID  FROM LossAndAdjustment WHERE StoreId = {0} ORDER BY Date DESC", storeId);
            return query;
        }

        public static string SelectDistinctYearGetDistinctAdjustmentDocments()
        {
            string query = "select distinct Year(Date) as Year from LossAndAdjustment order by year(Date) DESC";
            return query;
        }

        public static string SelectGetAdjustedQuantityTillMonth(int itemId, int storeId, DateTime dt1, DateTime dt2)
        {
            string query = String.Format("SELECT SUM(Quantity) AS Quantity FROM  LossAndAdjustment WHERE (Losses = 0) AND (ItemID = {0} AND StoreId = {1} AND (Date between '{2}' AND '{3}'))", itemId, storeId, dt1.ToString(), dt2.ToString());
            return query;
        }

        public static string SelectGetLossesQuantityTillMonth(int itemId, int storeId, DateTime dt1, DateTime dt2)
        {
            string query = String.Format("SELECT SUM(d.Quantity / rd.QtyPerPack ) AS Quantity FROM  LossAndAdjustment d join ReceiveDoc rd on d.RecID = rd.ID WHERE (d.Losses = 1) AND (d.ItemID = {0} AND d.StoreId = {1} AND (d.Date between '{2}' AND '{3}'))", itemId, storeId, dt1.ToString(), dt2.ToString());
            return query;
        }

        public static string SelectGenerateRefNo()
        {
            string query = "select MAX(cast(RefNo as int)) as NewRefNo from LossAndAdjustment";
            return query;
        }
    }
}
