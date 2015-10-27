using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Item")]
    public class Item
    {
       [Key][Column("ID")]
        public int ItemID { get; set; }

        public string StockCode { get; set; }
        public string Strength { get; set; }
        public int? DosageFormID { get; set; }
        public int? VEN { get; set; }
        public int? ABC { get; set; }
        public bool? IsFree { get; set; }
        public bool? IsDiscontinued { get; set; }
        public decimal? Cost { get; set; }
        public bool? EDL { get; set; }
        public bool? Refrigeratored { get; set; }
        public bool? Pediatric { get; set; }
        [Column("IINID")]
        public int? ProductID { get; set; }

        public bool? IsInHospitalList { get; set; }
        [Column("Code")]
        public string ItemCode { get; set; }

        public string StockCodeDACA { get; set; }
        public double? NearExpiryTrigger { get; set; }
        public int? StorageTypeID { get; set; }
        public bool? IsStackStored { get; set; }
        public bool? ProcessInDecimal { get; set; }
        public bool? IsActive { get; set; }
        
        public Guid? StorageLocationTypeGuid { get; set; }
        public Guid? ABCGuid { get; set; }
        public Guid? VENGuid { get; set; }
        public Guid? DosageFormGuid { get; set; }
        public Guid? UnitGuid { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }

        public bool NeedExpiryBatch { get; set; }

    }
}
