using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Warehouse.Models
{

    [Table("Region")]
    public class Region
    {
        [Key][Column("ID")]
        public int RegionID { get; set; }

        public string RegionName { get; set; }
        public string RegionCode { get; set; }
        public Guid? rowguid { get; set; }
        public bool? IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
       
    }
}
