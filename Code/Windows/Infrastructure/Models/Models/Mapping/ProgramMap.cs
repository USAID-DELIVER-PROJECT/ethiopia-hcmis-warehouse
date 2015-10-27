using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ProgramMap : EntityTypeConfiguration<Program>
    {
        public ProgramMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.ProgramCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Programs");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
            this.Property(t => t.ProgramCode).HasColumnName("ProgramCode");
        }
    }
}
