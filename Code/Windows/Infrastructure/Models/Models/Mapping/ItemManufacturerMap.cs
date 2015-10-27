using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ItemManufacturerMap : EntityTypeConfiguration<ItemManufacturer>
    {
        public ItemManufacturerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.BrandName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ItemManufacturer");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.ManufacturerID).HasColumnName("ManufacturerID");
            this.Property(t => t.PackageLevel).HasColumnName("PackageLevel");
            this.Property(t => t.QuantityPerLevel).HasColumnName("QuantityPerLevel");
            this.Property(t => t.IsssuingDefault).HasColumnName("IsssuingDefault");
            this.Property(t => t.RecevingDefault).HasColumnName("RecevingDefault");
            this.Property(t => t.BoxWidth).HasColumnName("BoxWidth");
            this.Property(t => t.BoxHeight).HasColumnName("BoxHeight");
            this.Property(t => t.BoxLength).HasColumnName("BoxLength");
            this.Property(t => t.BrandName).HasColumnName("BrandName");
            this.Property(t => t.StackHeight).HasColumnName("StackHeight");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.ItemManufacturers)
                .HasForeignKey(d => d.ItemID);
            this.HasOptional(t => t.Manufacturer)
                .WithMany(t => t.ItemManufacturers)
                .HasForeignKey(d => d.ManufacturerID);

        }
    }
}
