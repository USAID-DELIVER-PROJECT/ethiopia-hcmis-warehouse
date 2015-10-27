using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class HalfPalletLocationMap : EntityTypeConfiguration<HalfPalletLocation>
    {
        public HalfPalletLocationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Label)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("HalfPalletLocation");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PalletLocationID).HasColumnName("PalletLocationID");
            this.Property(t => t.Label).HasColumnName("Label");
            this.Property(t => t.PalleteID).HasColumnName("PalleteID");
            this.Property(t => t.Confirmed).HasColumnName("Confirmed");

            // Relationships
            this.HasOptional(t => t.PalletLocation)
                .WithMany(t => t.HalfPalletLocations)
                .HasForeignKey(d => d.PalletLocationID);

        }
    }
}
