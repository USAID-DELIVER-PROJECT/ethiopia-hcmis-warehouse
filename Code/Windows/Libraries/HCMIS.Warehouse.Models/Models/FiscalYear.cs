using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("FiscalYear")]
    public class FiscalYear
    {
        [Key][Column("ID")]
        public int FiscalYearID { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Column("isCurrent")]
        public bool? IsCurrent { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
    }
}
