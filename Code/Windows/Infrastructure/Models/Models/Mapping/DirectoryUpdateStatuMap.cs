using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class DirectoryUpdateStatuMap : EntityTypeConfiguration<DirectoryUpdateStatu>
    {
        public DirectoryUpdateStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DirectoryUpdateStatus");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LastVersion).HasColumnName("LastVersion");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
        }
    }
}
