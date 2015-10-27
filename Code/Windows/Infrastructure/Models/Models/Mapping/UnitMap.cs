using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class UnitMap : EntityTypeConfiguration<Unit>
    {
        public UnitMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Unit1)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Unit");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Unit1).HasColumnName("Unit");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
