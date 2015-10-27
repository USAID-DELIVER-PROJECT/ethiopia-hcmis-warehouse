using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ItemSupplyCategoryMap : EntityTypeConfiguration<ItemSupplyCategory>
    {
        public ItemSupplyCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ItemSupplyCategory");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.ItemSupplyCategories)
                .HasForeignKey(d => d.ItemID);
            this.HasOptional(t => t.SupplyCategory)
                .WithMany(t => t.ItemSupplyCategories)
                .HasForeignKey(d => d.CategoryID);

        }
    }
}
