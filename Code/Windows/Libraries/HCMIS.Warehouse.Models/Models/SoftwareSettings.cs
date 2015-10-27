using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("SoftwareSettings")]
    public class SoftwareSettings
    {
        [Key][Column("ID")]
        public int SoftwareSettingsID { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }
        public string SystemType { get; set; }
        public int SettingCategoryID { get; set; }
        public string Description { get; set; }
    }
}
