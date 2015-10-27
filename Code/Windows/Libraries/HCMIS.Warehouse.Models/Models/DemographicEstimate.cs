using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("DemographicEstimate")]
    public class DemographicEstimate
    {
        [Key]
        public int DemographicEstimateID { get; set; }
        public int AdministrativeUnitID { get; set; }
        public int DemographicIndicatorID { get; set; }
        public int FiscalYearID { get; set; }
        public decimal EstimateValue { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
