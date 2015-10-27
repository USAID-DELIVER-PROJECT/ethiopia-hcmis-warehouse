using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Indicator")]
    public class Indicator
    {
        [Key]
        public int IndicatorID { get; set; }
        public string Name { get; set; }
        public int ItemID { get; set; }
        public int DemographicIndicatorID { get; set; }
        public bool? IsActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
