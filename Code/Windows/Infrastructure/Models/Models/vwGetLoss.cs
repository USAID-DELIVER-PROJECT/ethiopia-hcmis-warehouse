using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwGetLoss
    {
        public string ItemName { get; set; }
        public string ATC { get; set; }
        public string Strength { get; set; }
        public Nullable<int> ABCID { get; set; }
        public string ABC { get; set; }
        public string VEN { get; set; }
        public Nullable<int> VENID { get; set; }
        public Nullable<bool> IsFree { get; set; }
        public Nullable<bool> IsDiscontinued { get; set; }
        public Nullable<bool> EDL { get; set; }
        public Nullable<bool> Refrigeratored { get; set; }
        public Nullable<bool> Pediatric { get; set; }
        public Nullable<int> DosageFormID { get; set; }
        public string DosageForm { get; set; }
        public int UnitID { get; set; }
        public string Unit { get; set; }
        public string StockCode { get; set; }
        public Nullable<int> IINID { get; set; }
        public int ID { get; set; }
        public Nullable<bool> IsInHospitalList { get; set; }
        public Nullable<int> StoreId { get; set; }
        public Nullable<int> ReasonId { get; set; }
        public Nullable<long> Quantity { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<bool> Losses { get; set; }
        public string Reason { get; set; }
        public string BatchNo { get; set; }
        public string Remark { get; set; }
        public string StockCodeDACA { get; set; }
        public string Code { get; set; }
        public Nullable<bool> NeedExpiryBatch { get; set; }
    }
}
