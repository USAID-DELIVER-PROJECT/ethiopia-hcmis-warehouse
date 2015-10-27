using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("LogFinance",Schema = "dbo")]
   public class LogFinance
    {
        [Key][Column("ID")]
        public int LogFinanceID { get; set; }

        public int ReceiveDocID { get; set; }
        public int QuantityLeft { get; set; }
        public double? PreviousPricePerPack { get; set; }
        public double? NewPricePerPack { get; set; }
        public string ColumnName { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
    }
}
