using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ProductOwnershipType")]
    public class ProductOwnershipType
    {
        [Key][Column("ID")]
        public int ProductOwnershipTypeID { get; set; }

        public int? ProductID { get; set; }
        public int? RUOwnershipTypeID { get; set; }
        public bool? AllowFully { get; set; }
        public bool? Warning { get; set; }
        public bool? Restriction { get; set; }
    }
}
