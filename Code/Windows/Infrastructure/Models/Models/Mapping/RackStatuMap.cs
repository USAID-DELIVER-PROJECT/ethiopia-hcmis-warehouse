using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class RackStatuMap : EntityTypeConfiguration<RackStatu>
    {
        public RackStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Status)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("RackStatus");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
