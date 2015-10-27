using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Pallet")]
    public class Pallet
    {
        [Key][Column("ID")]
        public int PalletID { get; set; }

        public int? PalletNo { get; set; }
        public int? StorageTypeID { get; set; }
    }
}
