using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ItemProgram")]
    public class ItemProgram
    {
        [Key][Column("ID")]
        public int ItemProgramID { get; set; }
        public int? ProgramID { get; set; }
        public int? ItemID { get; set; }
        public Guid? ProgramGuid { get; set; }
        public Guid? ItemGuid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
