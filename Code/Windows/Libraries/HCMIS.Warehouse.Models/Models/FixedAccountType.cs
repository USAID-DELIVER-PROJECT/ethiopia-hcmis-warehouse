using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("FixedAccountType", Schema = "ExportUtility")]
    public class FixedAccountType
    {
        [Key]
        [Column("FixedTypeID")]
        public int FixedAccountTypeID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public string FixedAccountTypeCode { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
