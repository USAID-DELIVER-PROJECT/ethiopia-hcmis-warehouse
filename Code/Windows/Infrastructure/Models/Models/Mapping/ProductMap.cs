using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IIN)
                .HasMaxLength(1500);

            this.Property(t => t.ATC)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(1500);

            // Table & Column Mappings
            this.ToTable("Product");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.IIN).HasColumnName("IIN");
            this.Property(t => t.ATC).HasColumnName("ATC");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.TypeID).HasColumnName("TypeID");

            // Relationships
            this.HasOptional(t => t.Type)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.TypeID);

        }
    }
}
