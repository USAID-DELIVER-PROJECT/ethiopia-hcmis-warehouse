using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwGetAllItem
    {
        public int ID { get; set; }
        public string FullItemName { get; set; }
        public string ItemName { get; set; }
        public string Strength { get; set; }
        public Nullable<int> ABCID { get; set; }
        public Nullable<int> VENID { get; set; }
        public Nullable<bool> IsFree { get; set; }
        public Nullable<int> DosageFormID { get; set; }
        public string DosageForm { get; set; }
        public int UnitID { get; set; }
        public string Unit { get; set; }
        public string StockCode { get; set; }
        public Nullable<int> IINID { get; set; }
        public Nullable<bool> IsInHospitalList { get; set; }
        public Nullable<int> TypeID { get; set; }
        public string Code { get; set; }
        public Nullable<bool> IsStackStored { get; set; }
        public Nullable<bool> NeedExpiryBatch { get; set; }
        public Nullable<int> StorageTypeID { get; set; }
        public Nullable<double> NearExpiryTrigger { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
    }
}
