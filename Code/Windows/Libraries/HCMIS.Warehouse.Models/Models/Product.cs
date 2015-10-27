using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Product")]
    public class Product
    {
        public int ProductID { get; set; }
        public string IIN { get; set; }
        public string ATC { get; set; }
        public string Description { get; set; }
        public int? TypeID { get; set; }
        public bool? IsActive { get; set; }
        public Guid? CommodityTypeGuid { get; set; }
        public Guid? rowguid { get; set; }
        public string LPName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }

    }
}
