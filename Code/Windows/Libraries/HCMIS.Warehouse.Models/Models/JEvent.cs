using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("JEvent", Schema = "Core")]
    public class JEvent
    {
        [Key]
        public int JEventID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GlobalIdentifier { get; set; }
       
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        [Column("SN")]
        public int SerialNumber { get; set; }
      

    }
}
