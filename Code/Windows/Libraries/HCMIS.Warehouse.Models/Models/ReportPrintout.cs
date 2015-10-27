using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("ReportPrintout")]
    public class ReportPrintout
    {
        [Key][Column("ID")]
        public int ReportPrintoutID { get; set; }

        public string ReportName { get; set; }
        public int? ObjectID { get; set; }
        public bool? UseCustomSize { get; set; }
        public int? WidthInMM { get; set; }
        public int? HeightInMM { get; set; }
        public int? DefaultPrinterID { get; set; }
    }
}
