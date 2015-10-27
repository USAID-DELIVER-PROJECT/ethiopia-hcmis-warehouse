using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwPhysicalStoreForItemMap : EntityTypeConfiguration<vwPhysicalStoreForItem>
    {
        public vwPhysicalStoreForItemMap()
        {
            // Primary Key
            this.HasKey(t => t.PhysicalStoreID);

            // Properties
            this.Property(t => t.PhysicalStoreID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vwPhysicalStoreForItems");
            this.Property(t => t.PhysicalStoreID).HasColumnName("PhysicalStoreID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.QuantityLeft).HasColumnName("QuantityLeft");
            this.Property(t => t.Balance).HasColumnName("Balance");
        }
    }
}
