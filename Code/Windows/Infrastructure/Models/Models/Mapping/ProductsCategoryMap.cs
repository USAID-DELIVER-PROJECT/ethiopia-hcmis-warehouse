using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ProductsCategoryMap : EntityTypeConfiguration<ProductsCategory>
    {
        public ProductsCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ProductsCategory");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.SubCategoryID).HasColumnName("SubCategoryID");
            this.Property(t => t.ItemId).HasColumnName("ItemId");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.ProductsCategories)
                .HasForeignKey(d => d.ItemId);
            this.HasOptional(t => t.SubCategory)
                .WithMany(t => t.ProductsCategories)
                .HasForeignKey(d => d.SubCategoryID);

        }
    }
}
