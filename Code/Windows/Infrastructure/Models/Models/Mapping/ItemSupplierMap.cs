using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ItemSupplierMap : EntityTypeConfiguration<ItemSupplier>
    {
        public ItemSupplierMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ItemSupplier");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SupplierID).HasColumnName("SupplierID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.ItemSuppliers)
                .HasForeignKey(d => d.ItemID);
            this.HasOptional(t => t.Supplier)
                .WithMany(t => t.ItemSuppliers)
                .HasForeignKey(d => d.SupplierID);

        }
    }
}
