using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("AccountsPayable", Schema = "ExportUtility")]
    public class AccountsPayable:SageAccount
    {
       
       
        [Column("VendorID")]
        public int SupplierID { get; set; }
        public int? ReceiptTypeID { get; set; }
        public Guid? AccountGuid { get; set; }
        [Column("VendorGuid")]
        public Guid? SupplierGuid { get; set; }

        public Guid ReceiptTypeGuid { get; set; }
    }
}
