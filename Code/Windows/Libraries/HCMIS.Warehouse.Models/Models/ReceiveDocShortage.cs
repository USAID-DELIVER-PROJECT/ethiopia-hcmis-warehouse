using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Warehouse.Models
{
    [Table("ReceiveDocShortage")]
    public class ReceiveDocShortage
    {
        [Key][Column("ID")]
        public int ReceiveDocShortageID { get; set; }

        public int? ReceiveDocID { get; set; }
        public int? ShortageReasonID { get; set; }
        public decimal? NoOfPacks { get; set; }
    }
}
