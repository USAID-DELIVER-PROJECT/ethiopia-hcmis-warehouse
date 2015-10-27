using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Account", Schema = "ExportUtility")]
    public abstract class SageAccount
    {
        [Key]
        public int AccountID { get; set; }

        public string Number { get; set; }
        public int ActivityID { get; set; }
        public Guid? rowguid { get; set; }
        public Guid ActivityGuid { get; set; }
        public bool? IsActive { get; set; }
        public int SN { get; set; }
    }
}
