using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("MenuItem")]
    public class MenuItem
    {
        [Key]
        public int MenuItemID { get; set; }

        public string Text { get; set; }
        public string URL { get; set; }
        public int ResourceTypeID { get; set; }
        public string Icon { get; set; }
        public int? Order { get; set; }
        public string ToolTip { get; set; }
        public int? ParentID { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
