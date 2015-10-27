using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class StorageTypeMap : EntityTypeConfiguration<StorageType>
    {
        public StorageTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.StorageTypeName)
                .HasMaxLength(50);

            this.Property(t => t.Prefix)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("StorageType");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.StorageTypeName).HasColumnName("StorageTypeName");
            this.Property(t => t.IsSubTypeOf).HasColumnName("IsSubTypeOf");
            this.Property(t => t.Prefix).HasColumnName("Prefix");

            // Relationships
            this.HasOptional(t => t.StorageType2)
                .WithMany(t => t.StorageType1)
                .HasForeignKey(d => d.IsSubTypeOf);

        }
    }
}
