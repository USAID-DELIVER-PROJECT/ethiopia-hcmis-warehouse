using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("OtherAccount", Schema = "ExportUtility")]
    public class OtherAccount:SageAccount
    {
        public int FixedAccountTypeID { get; set; }
    }
}
