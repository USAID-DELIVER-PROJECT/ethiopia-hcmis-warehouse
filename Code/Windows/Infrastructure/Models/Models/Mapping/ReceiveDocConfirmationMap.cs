using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ReceiveDocConfirmationMap : EntityTypeConfiguration<ReceiveDocConfirmation>
    {
        public ReceiveDocConfirmationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ReceiveDocConfirmation");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ReceiveDocID).HasColumnName("ReceiveDocID");
            this.Property(t => t.ReceiptConfirmationStatusID).HasColumnName("ReceiptConfirmationStatusID");
            this.Property(t => t.ReceivedByUserID).HasColumnName("ReceivedByUserID");
            this.Property(t => t.ReceiptQuantityConfirmedByUserID).HasColumnName("ReceiptQuantityConfirmedByUserID");
            this.Property(t => t.PriceAssignedByUserID).HasColumnName("PriceAssignedByUserID");
            this.Property(t => t.PriceConfirmedByUserID).HasColumnName("PriceConfirmedByUserID");
            this.Property(t => t.GRVPrintedByUserID).HasColumnName("GRVPrintedByUserID");
            this.Property(t => t.UnitCostCalculatedByUserID).HasColumnName("UnitCostCalculatedByUserID");

            // Relationships
            this.HasOptional(t => t.ReceiptConfirmationStatu)
                .WithMany(t => t.ReceiveDocConfirmations)
                .HasForeignKey(d => d.ReceiptConfirmationStatusID);
            this.HasOptional(t => t.ReceiveDoc)
                .WithMany(t => t.ReceiveDocConfirmations)
                .HasForeignKey(d => d.ReceiveDocID);
            this.HasOptional(t => t.User)
                .WithMany(t => t.ReceiveDocConfirmations)
                .HasForeignKey(d => d.UnitCostCalculatedByUserID);
            this.HasOptional(t => t.User1)
                .WithMany(t => t.ReceiveDocConfirmations1)
                .HasForeignKey(d => d.ReceivedByUserID);
            this.HasOptional(t => t.User2)
                .WithMany(t => t.ReceiveDocConfirmations2)
                .HasForeignKey(d => d.ReceiptQuantityConfirmedByUserID);
            this.HasOptional(t => t.User3)
                .WithMany(t => t.ReceiveDocConfirmations3)
                .HasForeignKey(d => d.GRVPrintedByUserID);
            this.HasOptional(t => t.User4)
                .WithMany(t => t.ReceiveDocConfirmations4)
                .HasForeignKey(d => d.PriceAssignedByUserID);
            this.HasOptional(t => t.User5)
                .WithMany(t => t.ReceiveDocConfirmations5)
                .HasForeignKey(d => d.PriceConfirmedByUserID);

        }
    }
}
