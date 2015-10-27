using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("PurchaseOrderParentType",Schema = "Procurement")]
    public class PurchaseOrderParentType
    {
        [Key]
        public int PurchaseOrderParentTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public Guid rowguid { get; set; }
        public string PurchaseOrderParentTypeCode { get; set; }
        public int SN { get; set; }
    }
}
