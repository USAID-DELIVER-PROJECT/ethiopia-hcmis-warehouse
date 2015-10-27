using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("YearEnd")]
    public class YearEnd
    {
        [Key][Column("ID")]
        public int YearEndID { get; set; }

        public int? ItemID { get; set; }
        public int? StoreID { get; set; }
        public int? Year { get; set; }
        public Int64? BBalance { get; set; }
        public Int64? EBalance { get; set; }
        public Int64? PhysicalInventory { get; set; }
        public string Remark { get; set; }
        public int? Month { get; set; }
        public decimal? EndingPrice { get; set; }
        public decimal? PhysicalInventoryPrice { get; set; }
        public decimal? BBPrice { get; set; }
        public int? UnitID { get; set; }
        public int? PhysicalStoreID { get; set; }
    }
}
