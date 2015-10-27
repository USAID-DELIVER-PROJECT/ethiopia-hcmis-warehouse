using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("PurchaseOrderType",Schema = "Procurement")]
    public class PurchaseOrderType
    {
        [Key]
        public int  PurchaseOrderTypeID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int ParentPurchaseOrderTypeID { get; set; }
        public bool IsActive { get; set; }
        public Guid? rowguid { get; set; }
        //public string ModifiedBy { get; set; }
        public string PurchaseOrderTypeCode { get; set; }
        public int SN { get; set; }
    }
}
