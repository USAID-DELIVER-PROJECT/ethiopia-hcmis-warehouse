using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ShelfMap : EntityTypeConfiguration<Shelf>
    {
        public ShelfMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ShelfCode)
                .HasMaxLength(50);

            this.Property(t => t.ShelfType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Shelf");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.ShelfCode).HasColumnName("ShelfCode");
            this.Property(t => t.ShelfType).HasColumnName("ShelfType");
            this.Property(t => t.Rows).HasColumnName("Rows");
            this.Property(t => t.Columns).HasColumnName("Columns");
            this.Property(t => t.CoordinateX).HasColumnName("CoordinateX");
            this.Property(t => t.CoordinateY).HasColumnName("CoordinateY");
            this.Property(t => t.Rotation).HasColumnName("Rotation");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.ShelfStorageType).HasColumnName("ShelfStorageType");

            // Relationships
            this.HasOptional(t => t.PhysicalStore)
                .WithMany(t => t.Shelves)
                .HasForeignKey(d => d.StoreID);

        }
    }
}
