using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("InventoryPeriod")]
    public class InventoryPeriod
    {
        [Key][Column("ID")]
        public int InventoryPeriodID { get; set; }

        public int? PhysicalStoreID { get; set; }
        public int? InventoryStatusID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? StartBy { get; set; }
        public int? ApprovedBy { get; set; }
        public string Remark { get; set; }
        public int? FiscalYearID { get; set; }

    }
}
