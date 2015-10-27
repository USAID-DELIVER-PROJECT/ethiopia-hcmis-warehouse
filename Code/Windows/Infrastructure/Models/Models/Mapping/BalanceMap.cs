using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class BalanceMap : EntityTypeConfiguration<Balance>
    {
        public BalanceMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Balance");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.StoreId).HasColumnName("StoreId");
            this.Property(t => t.LastDate).HasColumnName("LastDate");
            this.Property(t => t.SOH).HasColumnName("SOH");
            this.Property(t => t.PhysicalCount).HasColumnName("PhysicalCount");
            this.Property(t => t.Month).HasColumnName("Month");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.AMC).HasColumnName("AMC");
            this.Property(t => t.SOHCost).HasColumnName("SOHCost");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.Balances)
                .HasForeignKey(d => d.ItemID);
            this.HasOptional(t => t.Store)
                .WithMany(t => t.Balances)
                .HasForeignKey(d => d.StoreId);

        }
    }
}
