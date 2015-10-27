using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Operation")]
    public class Operation
    {
        public int OperationID { get; set; }
        public string Name { get; set; }
        public int MenuItemID { get; set; }
        public string Description { get; set; }
        public Guid? MenuItemGuid { get; set; }
        public bool? IsActive { get; set; }

        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
