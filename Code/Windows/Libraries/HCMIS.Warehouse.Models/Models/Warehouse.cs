using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Warehouse")]
    public class Warehouse
    {
        [Key][Column("ID")]
        public int WarehouseID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ClusterID { get; set; }
        public bool? IsActive { get; set; }
    }
}
