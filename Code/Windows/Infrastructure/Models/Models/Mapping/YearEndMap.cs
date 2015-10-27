using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class YearEndMap : EntityTypeConfiguration<YearEnd>
    {
        public YearEndMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Remark)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("YearEnd");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.BBalance).HasColumnName("BBalance");
            this.Property(t => t.EBalance).HasColumnName("EBalance");
            this.Property(t => t.PhysicalInventory).HasColumnName("PhysicalInventory");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.Month).HasColumnName("Month");
            this.Property(t => t.EndingPrice).HasColumnName("EndingPrice");
            this.Property(t => t.PhysicalInventoryPrice).HasColumnName("PhysicalInventoryPrice");
            this.Property(t => t.BBPrice).HasColumnName("BBPrice");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.PhysicalStoreID).HasColumnName("PhysicalStoreID");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.YearEnds)
                .HasForeignKey(d => d.ItemID);
            this.HasOptional(t => t.ItemUnit)
                .WithMany(t => t.YearEnds)
                .HasForeignKey(d => d.UnitID);
            this.HasOptional(t => t.PhysicalStore)
                .WithMany(t => t.YearEnds)
                .HasForeignKey(d => d.PhysicalStoreID);

        }
    }
}
