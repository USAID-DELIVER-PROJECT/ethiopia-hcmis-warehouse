using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class TransferMap : EntityTypeConfiguration<Transfer>
    {
        public TransferMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Transfer");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.FromStoreID).HasColumnName("FromStoreID");
            this.Property(t => t.ToStoreID).HasColumnName("ToStoreID");
            this.Property(t => t.FromPhysicalStoreID).HasColumnName("FromPhysicalStoreID");
            this.Property(t => t.ToPhysicalStoreID).HasColumnName("ToPhysicalStoreID");
            this.Property(t => t.TransferTypeID).HasColumnName("TransferTypeID");

            // Relationships
            this.HasRequired(t => t.Order)
                .WithMany(t => t.Transfers)
                .HasForeignKey(d => d.OrderID);
            this.HasRequired(t => t.PhysicalStore)
                .WithMany(t => t.Transfers)
                .HasForeignKey(d => d.FromPhysicalStoreID);
            this.HasOptional(t => t.PhysicalStore1)
                .WithMany(t => t.Transfers1)
                .HasForeignKey(d => d.ToPhysicalStoreID);
            this.HasRequired(t => t.Store)
                .WithMany(t => t.Transfers)
                .HasForeignKey(d => d.FromStoreID);
            this.HasOptional(t => t.Store1)
                .WithMany(t => t.Transfers1)
                .HasForeignKey(d => d.ToStoreID);
            this.HasOptional(t => t.TransferType)
                .WithMany(t => t.Transfers)
                .HasForeignKey(d => d.TransferTypeID);

        }
    }
}
