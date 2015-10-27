using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Warehouse.Models
{
    [Table("ReceivePallet")]
    public class ReceivePallet
    {
        [Key][Column("ID")]
        public int ReceivePalletID { get; set; }

        public int? ReceiveID { get; set; }
        public int? PalletID { get; set; }
        public decimal? ReceivedQuantity { get; set; }
        public decimal? Balance { get; set; }
        public decimal? ReservedStock { get; set; }
        public int? ReserveOrderID { get; set; }
        public int? BoxSize { get; set; }
        public int? PalletLocationID { get; set; }
    }
}
