using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("RRF")]
    public class RRF
    {
        [Key][Column("ID")]
        public int RRFID { get; set; }

        public int FromMonth { get; set; }
        public int FromYear { get; set; }
        public int ToMonth { get; set; }
        public int ToYear { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public string LastRRFStatus { get; set; }
        public int RRFType { get; set; }
    }
}
