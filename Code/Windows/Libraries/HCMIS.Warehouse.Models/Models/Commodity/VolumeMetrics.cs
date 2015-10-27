using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("VolumeMetrics")]
    public class VolumeMetrics
    {
        [Key]
        public int VolumeMetricsID { get; set; }
        public int ItemID { get; set; }
        public int ManufacturerID { get; set; }
        public int UnitOfIssueID { get; set; }
        public decimal? WidthMM { get; set; }
        public decimal? HeightMM { get; set; }
        public decimal? LengthMM { get; set; }
        public decimal? WeightG { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        
    }
}
