using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Models
{
    [Table("PhysicalStore")]
    public class Store
    {
        [Key]
        [Column("ID")]
        public int StoreID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("Warehouse")]
        [Column("PhysicalStoreTypeID")]
        public int? WarehouseID { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual ICollection<StoreUser> StoreUsers { get; set; }

        [NotMapped]
        public string FullName { get { return string.Format("{0} - {1}", this.Warehouse.Name, this.Name); } }
    }
}
