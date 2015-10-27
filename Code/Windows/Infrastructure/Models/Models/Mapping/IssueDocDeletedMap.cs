using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class IssueDocDeletedMap : EntityTypeConfiguration<IssueDocDeleted>
    {
        public IssueDocDeletedMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LocalBatchNo)
                .HasMaxLength(50);

            this.Property(t => t.IssuedBy)
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(50);

            this.Property(t => t.RefNo)
                .HasMaxLength(50);

            this.Property(t => t.BatchNo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("IssueDocDeleted");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.StoreId).HasColumnName("StoreId");
            this.Property(t => t.ReceivingUnitID).HasColumnName("ReceivingUnitID");
            this.Property(t => t.LocalBatchNo).HasColumnName("LocalBatchNo");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.IsTransfer).HasColumnName("IsTransfer");
            this.Property(t => t.IssuedBy).HasColumnName("IssuedBy");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.RefNo).HasColumnName("RefNo");
            this.Property(t => t.BatchNo).HasColumnName("BatchNo");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.NoOfPack).HasColumnName("NoOfPack");
            this.Property(t => t.QtyPerPack).HasColumnName("QtyPerPack");
            this.Property(t => t.DUSOH).HasColumnName("DUSOH");
            this.Property(t => t.DURequestedQty).HasColumnName("DURequestedQty");
            this.Property(t => t.RecomendedQty).HasColumnName("RecomendedQty");
            this.Property(t => t.RecievDocID).HasColumnName("RecievDocID");
            this.Property(t => t.EurDate).HasColumnName("EurDate");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.STVID).HasColumnName("STVID");
            this.Property(t => t.DeletedBy).HasColumnName("DeletedBy");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeliveryNote).HasColumnName("DeliveryNote");
            this.Property(t => t.DispatchConfirmed).HasColumnName("DispatchConfirmed");
            this.Property(t => t.DispatchConfirmedByUserID).HasColumnName("DispatchConfirmedByUserID");
            this.Property(t => t.DispatchConfirmationDate).HasColumnName("DispatchConfirmationDate");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.IssueDocDeleteds)
                .HasForeignKey(d => d.DeletedBy);

        }
    }
}
