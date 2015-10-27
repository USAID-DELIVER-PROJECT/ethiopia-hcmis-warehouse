using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Transfer")]
    public class Transfer
    {
        [Key][Column("ID")]
        public int TransferID { get; set; }

        public int OrderID { get; set; }
        public int FromStoreID { get; set; }
        public int? ToStoreID { get; set; }
        public int FromPhysicalStoreID { get; set; }
        public int? ToPhysicalStoreID { get; set; }
        public int? TransferTypeID { get; set; }
    }
}
