using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("SettingCategory")]
    public class SettingCategory
    {
        [Key]
        public int SettingCategoryID { get; set; }

        public string Name { get; set; }
    }
}
