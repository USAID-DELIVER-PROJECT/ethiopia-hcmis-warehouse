using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ErrorCorrection")]
    public class ErrorCorrection
    {
        [Key][Column("ID")]
        public int ErrorCorrectionID { get; set; }

        public int UserID { get; set; }
        public string Reason { get; set; }
        public string LetterNumber { get; set; }
        public int? IssueID { get; set; }
        public int? ReceiptID { get; set; }
    }
}
