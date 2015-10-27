using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("HalfPalletLocation")]
    public class HalfPalletLocation
    {
        [Key][Column("ID")]
        public int HalfPalletLocationID { get; set; }
       
        public int? PalletLocationID { get; set; }
        public string Label { get; set; }
        public int? PalleteID { get; set; }
        public bool? Confirmed { get; set; }
        
    }
}
