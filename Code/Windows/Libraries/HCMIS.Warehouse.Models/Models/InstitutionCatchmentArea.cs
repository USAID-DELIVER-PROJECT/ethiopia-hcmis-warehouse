using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("InstitutionCatchmentArea")]
    public class InstitutionCatchmentArea
    {
        [Key]
        public int InstitutionCatchmentAreaID { get; set; }
        public int InstitutionID { get; set; }
        public int FiscalYearID { get; set; }
        public int? CatchmentArea { get; set; }

    }
}
