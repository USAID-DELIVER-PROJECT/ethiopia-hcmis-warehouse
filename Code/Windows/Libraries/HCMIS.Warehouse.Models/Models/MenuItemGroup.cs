using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("MenuItemGroup")]
    public class MenuItemGroup
    {
        public int MenuItemGroupID { get; set; }
        public int GroupID { get; set; }
        public int MenuItemID { get; set; }

    }
}
