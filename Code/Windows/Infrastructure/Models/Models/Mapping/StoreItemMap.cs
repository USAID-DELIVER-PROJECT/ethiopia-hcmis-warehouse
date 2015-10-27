using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class StoreItemMap : EntityTypeConfiguration<StoreItem>
    {
        public StoreItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("StoreItem");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.UsedInThisStore).HasColumnName("UsedInThisStore");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.StoreItems)
                .HasForeignKey(d => d.ItemID);
            this.HasOptional(t => t.Store)
                .WithMany(t => t.StoreItems)
                .HasForeignKey(d => d.StoreID);

        }
    }
}
