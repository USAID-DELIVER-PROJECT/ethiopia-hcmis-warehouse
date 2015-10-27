using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class DirectoryUpdateMap : EntityTypeConfiguration<DirectoryUpdate>
    {
        public DirectoryUpdateMap()
        {
            // Primary Key
            this.HasKey(t => t.ServiceName);

            // Properties
            this.Property(t => t.ServiceName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DirectoryUpdates");
            this.Property(t => t.ServiceName).HasColumnName("ServiceName");
            this.Property(t => t.LastCalled).HasColumnName("LastCalled");
        }
    }
}
