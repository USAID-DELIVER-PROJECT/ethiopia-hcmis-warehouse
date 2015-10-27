using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ItemPrefferedLocationMap : EntityTypeConfiguration<ItemPrefferedLocation>
    {
        public ItemPrefferedLocationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ItemPrefferedLocation");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.PalletLocationID).HasColumnName("PalletLocationID");
            this.Property(t => t.IsFixed).HasColumnName("IsFixed");

            // Relationships
            this.HasOptional(t => t.PalletLocation)
                .WithMany(t => t.ItemPrefferedLocations)
                .HasForeignKey(d => d.PalletLocationID);
            this.HasOptional(t => t.Item)
                .WithMany(t => t.ItemPrefferedLocations)
                .HasForeignKey(d => d.ItemID);

        }
    }
}
