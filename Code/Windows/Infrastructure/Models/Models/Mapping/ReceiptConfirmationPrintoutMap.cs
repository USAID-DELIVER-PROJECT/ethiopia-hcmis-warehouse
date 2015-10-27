using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ReceiptConfirmationPrintoutMap : EntityTypeConfiguration<ReceiptConfirmationPrintout>
    {
        public ReceiptConfirmationPrintoutMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Reason)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ReceiptConfirmationPrintout");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PrintedDate).HasColumnName("PrintedDate");
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
            this.Property(t => t.ReceiptID).HasColumnName("ReceiptID");

            // Relationships
            this.HasOptional(t => t.Receipt)
                .WithMany(t => t.ReceiptConfirmationPrintouts)
                .HasForeignKey(d => d.ReceiptID);
            this.HasOptional(t => t.Store)
                .WithMany(t => t.ReceiptConfirmationPrintouts)
                .HasForeignKey(d => d.StoreID);
            this.HasOptional(t => t.Supplier)
                .WithMany(t => t.ReceiptConfirmationPrintouts)
                .HasForeignKey(d => d.SupplierID);
            this.HasOptional(t => t.User)
                .WithMany(t => t.ReceiptConfirmationPrintouts)
                .HasForeignKey(d => d.UserID);
            this.HasOptional(t => t.User1)
                .WithMany(t => t.ReceiptConfirmationPrintouts1)
                .HasForeignKey(d => d.VoidRequestUserID);
            this.HasOptional(t => t.User2)
                .WithMany(t => t.ReceiptConfirmationPrintouts2)
                .HasForeignKey(d => d.VoidApprovedByUserID);

        }
    }
}
