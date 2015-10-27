using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class PalletLocationMap : EntityTypeConfiguration<PalletLocation>
    {
        public PalletLocationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Label)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PalletLocation");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Label).HasColumnName("Label");
            this.Property(t => t.ShelfID).HasColumnName("ShelfID");
            this.Property(t => t.Row).HasColumnName("Row");
            this.Property(t => t.Column).HasColumnName("Column");
            this.Property(t => t.StorageTypeID).HasColumnName("StorageTypeID");
            this.Property(t => t.IsFullSize).HasColumnName("IsFullSize");
            this.Property(t => t.IsEnabled).HasColumnName("IsEnabled");
            this.Property(t => t.RackStatusID).HasColumnName("RackStatusID");
            this.Property(t => t.PalletID).HasColumnName("PalletID");
            this.Property(t => t.PercentUsed).HasColumnName("PercentUsed");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.Confirmed).HasColumnName("Confirmed");
            this.Property(t => t.IsExtended).HasColumnName("IsExtended");
            this.Property(t => t.ExtendedRows).HasColumnName("ExtendedRows");
            this.Property(t => t.AvailableVolume).HasColumnName("AvailableVolume");
            this.Property(t => t.UsedVolume).HasColumnName("UsedVolume");

            // Relationships
            this.HasOptional(t => t.Pallet)
                .WithMany(t => t.PalletLocations)
                .HasForeignKey(d => d.PalletID);
            this.HasOptional(t => t.RackStatu)
                .WithMany(t => t.PalletLocations)
                .HasForeignKey(d => d.RackStatusID);
            this.HasOptional(t => t.Shelf)
                .WithMany(t => t.PalletLocations)
                .HasForeignKey(d => d.ShelfID);
            this.HasOptional(t => t.StorageType)
                .WithMany(t => t.PalletLocations)
                .HasForeignKey(d => d.StorageTypeID);

        }
    }
}
