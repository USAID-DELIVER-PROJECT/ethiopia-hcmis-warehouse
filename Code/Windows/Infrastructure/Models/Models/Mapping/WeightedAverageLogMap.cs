using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class WeightedAverageLogMap : EntityTypeConfiguration<WeightedAverageLog>
    {
        public WeightedAverageLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("WeightedAverageLog");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.SupplierID).HasColumnName("SupplierID");
            this.Property(t => t.SOHWhenApplied).HasColumnName("SOHWhenApplied");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.Insurance).HasColumnName("Insurance");
            this.Property(t => t.ManufacturerID).HasColumnName("ManufacturerID");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.ReceiptId).HasColumnName("ReceiptId");
            this.Property(t => t.UPUnitCost).HasColumnName("UPUnitCost");
            this.Property(t => t.UPQty).HasColumnName("UPQty");
            this.Property(t => t.UPTotalCost).HasColumnName("UPTotalCost");
            this.Property(t => t.PQty).HasColumnName("PQty");
            this.Property(t => t.PUnitCost).HasColumnName("PUnitCost");
            this.Property(t => t.PTotalCost).HasColumnName("PTotalCost");
            this.Property(t => t.NTotalCost).HasColumnName("NTotalCost");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.NQty).HasColumnName("NQty");
            this.Property(t => t.NUnitCost).HasColumnName("NUnitCost");
            this.Property(t => t.PriceDifference).HasColumnName("PriceDifference");
            this.Property(t => t.Margin).HasColumnName("Margin");

            // Relationships
            this.HasOptional(t => t.Manufacturer)
                .WithMany(t => t.WeightedAverageLogs)
                .HasForeignKey(d => d.ManufacturerID);
            this.HasOptional(t => t.StoreGroup)
                .WithMany(t => t.WeightedAverageLogs)
                .HasForeignKey(d => d.StoreID);

        }
    }
}
