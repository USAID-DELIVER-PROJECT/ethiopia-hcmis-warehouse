using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwTreeMap : EntityTypeConfiguration<vwTree>
    {
        public vwTreeMap()
        {
            // Primary Key
            this.HasKey(t => t.Type);

            // Properties
            this.Property(t => t.ID)
                .HasMaxLength(31);

            this.Property(t => t.FullItemName)
                .HasMaxLength(3056);

            this.Property(t => t.Category)
                .HasMaxLength(31);

            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(6);

            // Table & Column Mappings
            this.ToTable("vwTree");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.FullItemName).HasColumnName("FullItemName");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.Type).HasColumnName("Type");
        }
    }
}
