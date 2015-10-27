using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class WoredaMap : EntityTypeConfiguration<Woreda>
    {
        public WoredaMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.WoredaName)
                .HasMaxLength(50);

            this.Property(t => t.WoredaCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Woreda");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.WoredaName).HasColumnName("WoredaName");
            this.Property(t => t.ZoneID).HasColumnName("ZoneID");
            this.Property(t => t.WoredaCode).HasColumnName("WoredaCode");

            // Relationships
            this.HasOptional(t => t.Zone)
                .WithMany(t => t.Woredas)
                .HasForeignKey(d => d.ZoneID);

        }
    }
}
