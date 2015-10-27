using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwGetIssue
    {
        public Nullable<int> ItemID { get; set; }
        public int ID { get; set; }
        public Nullable<int> ReceivingUnitID { get; set; }
        public string LocalBatchNo { get; set; }
        public Nullable<long> Quantity { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string BatchNo { get; set; }
        public string RefNo { get; set; }
        public string Remark { get; set; }
        public string IssuedBy { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<bool> IsTransfer { get; set; }
        public string StockCode { get; set; }
        public string Strength { get; set; }
        public Nullable<int> IINID { get; set; }
        public string Name { get; set; }
        public string StoreName { get; set; }
        public Nullable<int> StoreId { get; set; }
        public string ItemName { get; set; }
        public string ATC { get; set; }
        public Nullable<int> DosageFormID { get; set; }
        public string DosageForm { get; set; }
        public string StockCodeDACA { get; set; }
        public string Code { get; set; }
        public Nullable<bool> NeedExpiryBatch { get; set; }
        public Nullable<System.DateTime> EurDate { get; set; }
        public Nullable<int> RecievDocID { get; set; }
        public Nullable<long> RecomendedQty { get; set; }
        public Nullable<long> DURequestedQty { get; set; }
        public Nullable<long> DUSOH { get; set; }
        public Nullable<int> QtyPerPack { get; set; }
        public Nullable<int> NoOfPack { get; set; }
        public Nullable<double> Cost { get; set; }
    }
}
