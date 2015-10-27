using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ProductReceivingUnitTypeMap : EntityTypeConfiguration<ProductReceivingUnitType>
    {
        public ProductReceivingUnitTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProductReceivingUnitType");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.ReceivingUnitTypeID).HasColumnName("ReceivingUnitTypeID");
            this.Property(t => t.AllowFully).HasColumnName("AllowFully");
            this.Property(t => t.Warning).HasColumnName("Warning");
            this.Property(t => t.Restriction).HasColumnName("Restriction");

            // Relationships
            this.HasOptional(t => t.Product)
                .WithMany(t => t.ProductReceivingUnitTypes)
                .HasForeignKey(d => d.ProductID);
            this.HasOptional(t => t.ReceivingUnitType)
                .WithMany(t => t.ProductReceivingUnitTypes)
                .HasForeignKey(d => d.ReceivingUnitTypeID);

        }
    }
}
