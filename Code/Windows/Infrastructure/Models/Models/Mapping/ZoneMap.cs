using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ZoneMap : EntityTypeConfiguration<Zone>
    {
        public ZoneMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ZoneName)
                .HasMaxLength(50);

            this.Property(t => t.ZoneCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Zone");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ZoneName).HasColumnName("ZoneName");
            this.Property(t => t.RegionId).HasColumnName("RegionId");
            this.Property(t => t.ZoneCode).HasColumnName("ZoneCode");

            // Relationships
            this.HasOptional(t => t.Region)
                .WithMany(t => t.Zones)
                .HasForeignKey(d => d.RegionId);

        }
    }
}
