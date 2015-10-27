using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ReceivePalletMap : EntityTypeConfiguration<ReceivePallet>
    {
        public ReceivePalletMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ReceivePallet");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ReceiveID).HasColumnName("ReceiveID");
            this.Property(t => t.PalletID).HasColumnName("PalletID");
            this.Property(t => t.ReceivedQuantity).HasColumnName("ReceivedQuantity");
            this.Property(t => t.Balance).HasColumnName("Balance");
            this.Property(t => t.ReservedStock).HasColumnName("ReservedStock");
            this.Property(t => t.ReserveOrderID).HasColumnName("ReserveOrderID");
            this.Property(t => t.BoxSize).HasColumnName("BoxSize");
            this.Property(t => t.PalletLocationID).HasColumnName("PalletLocationID");

            // Relationships
            this.HasOptional(t => t.Pallet)
                .WithMany(t => t.ReceivePallets)
                .HasForeignKey(d => d.PalletID);
            this.HasOptional(t => t.PalletLocation)
                .WithMany(t => t.ReceivePallets)
                .HasForeignKey(d => d.PalletLocationID);
            this.HasOptional(t => t.ReceiveDoc)
                .WithMany(t => t.ReceivePallets)
                .HasForeignKey(d => d.ReceiveID);

        }
    }
}
