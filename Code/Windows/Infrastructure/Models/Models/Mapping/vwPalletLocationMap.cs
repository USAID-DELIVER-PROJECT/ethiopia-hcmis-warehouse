using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwPalletLocationMap : EntityTypeConfiguration<vwPalletLocation>
    {
        public vwPalletLocationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.PalletLocation)
                .HasMaxLength(152);

            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vwPalletLocation");
            this.Property(t => t.PalletLocation).HasColumnName("PalletLocation");
            this.Property(t => t.ID).HasColumnName("ID");
        }
    }
}
