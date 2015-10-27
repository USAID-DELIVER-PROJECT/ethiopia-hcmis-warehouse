using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class vwGetItemProgram
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
        public Nullable<int> ProgramID { get; set; }
        public string StockCode { get; set; }
        public Nullable<int> IINID { get; set; }
        public Nullable<bool> IsInHospitalList { get; set; }
        public string Name { get; set; }
        public Nullable<bool> NeedExpiryBatch { get; set; }
        public string Code { get; set; }
        public string StockCodeDACA { get; set; }
        public string FullItemName { get; set; }
        public Nullable<int> SubCategoryID { get; set; }
        public int ID { get; set; }
        public Nullable<int> CategoryId { get; set; }
    }
}
