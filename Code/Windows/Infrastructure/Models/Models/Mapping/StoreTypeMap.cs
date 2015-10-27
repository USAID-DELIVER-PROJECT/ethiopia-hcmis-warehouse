using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class StoreTypeMap : EntityTypeConfiguration<StoreType>
    {
        public StoreTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TypeName)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("StoreType");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TypeName).HasColumnName("TypeName");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
