using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class STVLogMap : EntityTypeConfiguration<STVLog>
    {
        public STVLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.RefNo)
                .HasMaxLength(50);

            this.Property(t => t.Reason)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("STVLog");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PrintedDate).HasColumnName("PrintedDate");
            this.Property(t => t.RefNo).HasColumnName("RefNo");
            this.Property(t => t.PickListID).HasColumnName("PickListID");
            this.Property(t => t.SupplierID).HasColumnName("SupplierID");
            this.Property(t => t.IsReprintOf).HasColumnName("IsReprintOf");
            this.Property(t => t.Reason).HasColumnName("Reason");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.IDPrinted).HasColumnName("IDPrinted");
            this.Property(t => t.VoidRequest).HasColumnName("VoidRequest");
            this.Property(t => t.VoidRequestDateTime).HasColumnName("VoidRequestDateTime");
            this.Property(t => t.VoidRequestUserID).HasColumnName("VoidRequestUserID");
            this.Property(t => t.IsVoided).HasColumnName("IsVoided");
            this.Property(t => t.VoidApprovedByUserID).HasColumnName("VoidApprovedByUserID");
            this.Property(t => t.VoidApprovalDateTime).HasColumnName("VoidApprovalDateTime");
            this.Property(t => t.PrePrintedInvoiceNo).HasColumnName("PrePrintedInvoiceNo");
            this.Property(t => t.ReceivingUnitID).HasColumnName("ReceivingUnitID");
            this.Property(t => t.IsDeliveryNote).HasColumnName("IsDeliveryNote");
            this.Property(t => t.HasDeliveryNoteBeenConverted).HasColumnName("HasDeliveryNoteBeenConverted");
            this.Property(t => t.HasInsurance).HasColumnName("HasInsurance");
            this.Property(t => t.InsuranceValue).HasColumnName("InsuranceValue");

            // Relationships
            this.HasOptional(t => t.Store)
                .WithMany(t => t.STVLogs)
                .HasForeignKey(d => d.StoreID);
            this.HasOptional(t => t.User)
                .WithMany(t => t.STVLogs)
                .HasForeignKey(d => d.UserID);
            this.HasOptional(t => t.User1)
                .WithMany(t => t.STVLogs1)
                .HasForeignKey(d => d.VoidApprovedByUserID);
            this.HasOptional(t => t.User2)
                .WithMany(t => t.STVLogs2)
                .HasForeignKey(d => d.VoidRequestUserID);

        }
    }
}
