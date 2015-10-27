using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("AccountsReceivable", Schema = "ExportUtility")]
    public class AccountsReceivable:SageAccount
    {
      
        public int ReceivingUnitID { get; set; }
        public Guid? AccountGuid { get; set; }
        public Guid? InstitutionGuid { get; set; }
    }
}
