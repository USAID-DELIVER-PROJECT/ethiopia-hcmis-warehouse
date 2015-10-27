using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ReceiptType",Schema = "ExportUtility")]
    public class ExportUtilityReceiptType
    {
        public int ReceiptTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public string ReceiptTypeCode { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
