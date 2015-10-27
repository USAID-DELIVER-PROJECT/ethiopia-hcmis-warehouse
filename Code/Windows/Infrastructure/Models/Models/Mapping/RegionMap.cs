using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class RegionMap : EntityTypeConfiguration<Region>
    {
        public RegionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RegionName)
                .HasMaxLength(50);

            this.Property(t => t.RegionCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Region");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RegionName).HasColumnName("RegionName");
            this.Property(t => t.RegionCode).HasColumnName("RegionCode");
        }
    }
}
