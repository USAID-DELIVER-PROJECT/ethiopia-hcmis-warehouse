using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class SubCategoryMap : EntityTypeConfiguration<SubCategory>
    {
        public SubCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.SubCategoryName)
                .HasMaxLength(50);

            this.Property(t => t.SubCategoryCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SubCategory");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.SubCategoryName).HasColumnName("SubCategoryName");
            this.Property(t => t.SubCategoryCode).HasColumnName("SubCategoryCode");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ParentID).HasColumnName("ParentID");

            // Relationships
            this.HasOptional(t => t.Category)
                .WithMany(t => t.SubCategories)
                .HasForeignKey(d => d.CategoryId);

        }
    }
}
