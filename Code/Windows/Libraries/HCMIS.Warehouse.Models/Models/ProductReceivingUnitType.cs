using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ProductReceivingUnitType")]
    public class ProductReceivingUnitType
    {
        [Key][Column("ID")]
        public int ProductReceivingUnitTypeID { get; set; }

        public int? ProductID { get; set; }
        public int? ReceivingUnitTypeID { get; set; }
        public bool? AllowFully { get; set; }
        public bool? Warning { get; set; }
        public bool? Restriction { get; set; }
    }
}
