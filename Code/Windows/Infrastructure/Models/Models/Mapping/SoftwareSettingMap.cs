using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class SoftwareSettingMap : EntityTypeConfiguration<SoftwareSetting>
    {
        public SoftwareSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Value)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SoftwareSettings");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Value).HasColumnName("Value");
        }
    }
}
