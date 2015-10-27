using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwAccountTreeMap : EntityTypeConfiguration<vwAccountTree>
    {
        public vwAccountTreeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.Type, t.Ordering });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.TextID)
                .HasMaxLength(41);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.ParentID)
                .HasMaxLength(41);

            this.Property(t => t.Ordering)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vwAccountTree");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.TextID).HasColumnName("TextID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
            this.Property(t => t.Ordering).HasColumnName("Ordering");
        }
    }
}
