using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("RequistionDetail")]
    public class RequistionDetail
    {
        [Key][Column("ID")]
        public int RequistionDetailID { get; set; }
        public Guid? Identifier { get; set; }
        public int? RequisitionID { get; set; }
        public int? ItemID { get; set; }
        public int? UnitID { get; set; }
        public decimal? RequestedQuantity { get; set; }
        public decimal? CurrentStock { get; set; }
        public decimal? AverageMonthlyConsumption { get; set; }
        public decimal? CurrentRequests { get; set; }
        public int? DaysOutOfStock { get; set; }
        
    }
}
