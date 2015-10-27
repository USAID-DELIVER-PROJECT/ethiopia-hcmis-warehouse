using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class OrderDetailMap : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("OrderDetail");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.Pack).HasColumnName("Pack");
            this.Property(t => t.QtyPerPack).HasColumnName("QtyPerPack");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.ApprovedQuantity).HasColumnName("ApprovedQuantity");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.HACTOrderDetailID).HasColumnName("HACTOrderDetailID");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.StockedOut).HasColumnName("StockedOut");
            this.Property(t => t.DeliveryNote).HasColumnName("DeliveryNote");
            this.Property(t => t.PreferredManufacturerID).HasColumnName("PreferredManufacturerID");
            this.Property(t => t.PreferredExpiryDate).HasColumnName("PreferredExpiryDate");
            this.Property(t => t.PreferredPhysicalStoreID).HasColumnName("PreferredPhysicalStoreID");

            // Relationships
            this.HasRequired(t => t.Item)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(d => d.ItemID);
            this.HasRequired(t => t.Item1)
                .WithMany(t => t.OrderDetails1)
                .HasForeignKey(d => d.ItemID);
            this.HasOptional(t => t.ItemUnit)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(d => d.UnitID);
            this.HasRequired(t => t.Order)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(d => d.OrderID);
            this.HasOptional(t => t.PhysicalStore)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(d => d.PreferredPhysicalStoreID);
            this.HasOptional(t => t.Store)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(d => d.StoreID);

        }
    }
}
