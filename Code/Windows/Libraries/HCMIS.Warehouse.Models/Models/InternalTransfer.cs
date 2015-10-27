using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("InternalTransfer")]
    public class InternalTransfer
    {
        [Key][Column("ID")]
        public int InternalTransferID { get; set; }
        public int? ItemID { get; set; }
        public int? FromPalletLocationID { get; set; }
        public int? ToPalletLocationID { get; set; }
        public string BatchNumber { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? ReceiveDocID { get; set; }
        public int? ManufacturerID { get; set; }
        public int? BoxLevel { get; set; }
        public int? QtyPerPack { get; set; }
        public decimal? Packs { get; set; }
        public decimal? QuantityInBU { get; set; }
        public string Type { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public int? Status { get; set; }
        public int? PrintNumber { get; set; }
    }
}
