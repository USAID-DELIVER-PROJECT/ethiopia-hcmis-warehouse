using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("MovingAverageGroup")]
    public class MovingAverageGroup
    {
        [Key][Column("ID")]
        public int MovingAverageGroupID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime?  CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string MovingAverageGroupCode { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
