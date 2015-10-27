using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("UnitOfIssue")]
    public class UnitOfIssue
    {
        [Key][Column("ID")]
        public int UnitOfIssueID { get; set; }
        [Column("Text")]
        public string DisplayText { get; set; }
        public int Quantity { get; set; }//Quantity is int on database
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }

    }
}
