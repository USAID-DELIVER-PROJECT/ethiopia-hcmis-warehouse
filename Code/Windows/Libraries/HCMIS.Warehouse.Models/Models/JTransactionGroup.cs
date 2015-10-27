using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("JTransactionGroup",Schema = "Core")]
    public class JTransactionGroup
    {
        [Key]
        public int JTransactionGroupID { get; set; }
        public int UserAccountID { get; set; }
        public Guid rowguid { get; set; }
    }
}
