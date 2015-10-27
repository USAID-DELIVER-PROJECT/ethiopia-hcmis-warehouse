using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class DisposalMap : EntityTypeConfiguration<Disposal>
    {
        public DisposalMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ApprovedBy)
                .HasMaxLength(50);

            this.Property(t => t.BatchNo)
                .HasMaxLength(50);

            this.Property(t => t.RefNo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Disposal");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.StoreId).HasColumnName("StoreId");
            this.Property(t => t.ReasonId).HasColumnName("ReasonId");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.ApprovedBy).HasColumnName("ApprovedBy");
            this.Property(t => t.Losses).HasColumnName("Losses");
            this.Property(t => t.BatchNo).HasColumnName("BatchNo");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.RefNo).HasColumnName("RefNo");
            this.Property(t => t.EurDate).HasColumnName("EurDate");
            this.Property(t => t.RecID).HasColumnName("RecID");

            // Relationships
            this.HasOptional(t => t.DisposalReason)
                .WithMany(t => t.Disposals)
                .HasForeignKey(d => d.ReasonId);
            this.HasOptional(t => t.Item)
                .WithMany(t => t.Disposals)
                .HasForeignKey(d => d.ItemID);

        }
    }
}
