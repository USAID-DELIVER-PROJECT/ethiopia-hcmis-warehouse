using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwGetCategoryMap : EntityTypeConfiguration<vwGetCategory>
    {
        public vwGetCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.SubCategoryName)
                .HasMaxLength(50);

            this.Property(t => t.CategoryName)
                .HasMaxLength(50);

            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CategoryCode)
                .HasMaxLength(50);

            this.Property(t => t.SubCategoryCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vwGetCategory");
            this.Property(t => t.SubCategoryName).HasColumnName("SubCategoryName");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CategoryCode).HasColumnName("CategoryCode");
            this.Property(t => t.SubCategoryCode).HasColumnName("SubCategoryCode");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
        }
    }
}
