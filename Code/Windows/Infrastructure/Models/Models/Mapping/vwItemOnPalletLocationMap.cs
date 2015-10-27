using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwItemOnPalletLocationMap : EntityTypeConfiguration<vwItemOnPalletLocation>
    {
        public vwItemOnPalletLocationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.FullItemName });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FullItemName)
                .IsRequired()
                .HasMaxLength(3056);

            // Table & Column Mappings
            this.ToTable("vwItemOnPalletLocation");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.FullItemName).HasColumnName("FullItemName");
            this.Property(t => t.Balance).HasColumnName("Balance");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.PalletID).HasColumnName("PalletID");
            this.Property(t => t.ExpDate).HasColumnName("ExpDate");
        }
    }
}
