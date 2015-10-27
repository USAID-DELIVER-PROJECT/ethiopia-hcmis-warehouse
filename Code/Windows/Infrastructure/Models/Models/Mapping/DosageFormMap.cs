using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class DosageFormMap : EntityTypeConfiguration<DosageForm>
    {
        public DosageFormMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Form)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DosageForm");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Form).HasColumnName("Form");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.TypeID).HasColumnName("TypeID");
        }
    }
}
