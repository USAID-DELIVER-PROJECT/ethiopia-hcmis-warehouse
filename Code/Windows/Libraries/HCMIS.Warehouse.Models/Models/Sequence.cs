using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Sequence")]
    public class Sequence
    {
        public int SequenceID { get; set; }
        public int SequenceNo { get; set; }
        public int AccountID { get; set; }
        public int DocumentTypeID { get; set; }
        public int FiscalYearID { get; set; }
    }
}
