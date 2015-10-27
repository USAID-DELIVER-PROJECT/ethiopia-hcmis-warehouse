using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Warehouse.Models
{
    [Table("Population")]
    public class Population
    {
        [Key]
        public int PopulationID { get; set; }

        public int AdministrativeUnitID { get; set; }
        public int FiscalYearID { get; set; }
        public Int64? TotalCount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
