using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("PickFace")]
    public class PickFace
    {
        [Key][Column("ID")]
        public int PickFaceID { get; set; }

        public int? PalletLocationID { get; set; }
        public int? DesignatedItem { get; set; }
        public int? Balance { get; set; }
        public int? LogicalStore { get; set; }

    }
}
