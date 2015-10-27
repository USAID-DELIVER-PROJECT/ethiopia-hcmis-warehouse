using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("RRFDetail")]
    public class RRFDetail
    {
        [Key][Column("ID")]
        public int RRFDetailID { get; set; }
        public int RRFID { get; set; }
        public int ActivityID { get; set; }
        public int ItemID { get; set; }
        public decimal RequestedQuantity { get; set; }

    }
}
