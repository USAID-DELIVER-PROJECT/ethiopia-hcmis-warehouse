using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CategoryName)
                .HasMaxLength(50);

            this.Property(t => t.CategoryCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Category");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.CategoryCode).HasColumnName("CategoryCode");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
