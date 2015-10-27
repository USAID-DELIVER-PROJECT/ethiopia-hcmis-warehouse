using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMIS.Warehouse.Models
{
    [Table("Issue")]
    public class Issue
    {
        [Key][Column("ID")]
        public int IssueID { get; set; }

        public DateTime? PrintedDate { get; set; }
        [Column("RefNo")]
        public string ReferenceNumber { get; set; }
        public int? PickListID { get; set; }
        public int? SupplierID { get; set; }
        public int? IsReprintOf { get; set; }
        public string Reason { get; set; }
        public int? UserID { get; set; }
        public int? ActivityID { get; set; }
        public int? IDPrinted { get; set; }
        public bool? VoidRequest { get; set; }
        public DateTime? VoidRequestDateTime { get; set; }
       
        public int? VoidRequestUserID  { get; set; }
        public bool? IsVoided { get; set; }
        public int? VoidApprovedByUserID { get; set; }
        public DateTime? VoidApprovedDateTime { get; set; }
        public int? PrePrintedInvoiceNo { get; set; }
        public int? ReceivingUnitID { get; set; }
        public bool? IsDeliveryNote { get; set; }
        public bool? HasDeliveryNoteBeenConverted { get; set; }
        public bool? HasInsurance { get; set; }
        public double? InsuranceValue { get; set; }
        public int? WarehouseID { get; set; }
        public int? PaymentTypeID { get; set; }
        public int? OrderID { get; set; }
        public bool? IsChecked { get; set; }
        public string InstitutionName { get; set; }
        public int? FiscalYearID { get; set; }
        public int AccountID { get; set; }
        public int DocumentTypeID { get; set; }


    }
}
