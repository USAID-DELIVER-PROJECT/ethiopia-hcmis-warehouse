using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class PhysicalStoreMap : EntityTypeConfiguration<PhysicalStore>
    {
        public PhysicalStoreMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PhysicalStore");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.DoorSide).HasColumnName("DoorSide");
            this.Property(t => t.DoorSize).HasColumnName("DoorSize");
            this.Property(t => t.DistanceFromCornor).HasColumnName("DistanceFromCornor");
            this.Property(t => t.PhysicalStoreTypeID).HasColumnName("PhysicalStoreTypeID");

            // Relationships
            this.HasOptional(t => t.PhysicalStoreType)
                .WithMany(t => t.PhysicalStores)
                .HasForeignKey(d => d.PhysicalStoreTypeID);

        }
    }
}
