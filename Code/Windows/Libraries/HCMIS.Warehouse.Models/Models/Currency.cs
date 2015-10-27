using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
   [Table("Currency")]
    public class Currency
    {
       [Key][Column("ID")]
        public int CurrencyID { get; set; }
        public string CurrencyCode { get; set; }
        public string Name { get; set; }
        public int LCID { get; set; }
        public bool IsActive { get; set; }
        public Guid rowguid { get; set; }
       [Column("SN")]
       public int SerialNumber { get; set; }
       public string ModifiedBy { get; set; }
       public int? CountryID { get; set; }
       public DateTime? CreatedDate { get; set; }
       public DateTime? ModifiedDate { get; set; }

    }
}
