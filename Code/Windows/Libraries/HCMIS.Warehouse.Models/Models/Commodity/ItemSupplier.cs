using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ItemSupplier")]
    public class ItemSupplier
    {
        [Key][Column("ID")]
        public int ItemSupplierID { get; set; }
        public int? ItemID { get; set; }
        public int? SupplierID { get; set; }
        public Guid? ItemGuid { get; set; }
        public Guid? SupplierGuid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        
    }
}
