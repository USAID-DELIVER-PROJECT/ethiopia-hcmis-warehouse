using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class PickListDetailMap : EntityTypeConfiguration<PickListDetail>
    {
        public PickListDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.BatchNumber)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PickListDetail");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PickListID).HasColumnName("PickListID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.PalletLocationID).HasColumnName("PalletLocationID");
            this.Property(t => t.BatchNumber).HasColumnName("BatchNumber");
            this.Property(t => t.ExpireDate).HasColumnName("ExpireDate");
            this.Property(t => t.ReceiveDocID).HasColumnName("ReceiveDocID");
            this.Property(t => t.BoxLevel).HasColumnName("BoxLevel");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.ManufacturerID).HasColumnName("ManufacturerID");
            this.Property(t => t.Packs).HasColumnName("Packs");
            this.Property(t => t.QtyPerPack).HasColumnName("QtyPerPack");
            this.Property(t => t.QuantityInBU).HasColumnName("QuantityInBU");
            this.Property(t => t.ReceivePalletID).HasColumnName("ReceivePalletID");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.DeliveryNote).HasColumnName("DeliveryNote");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.PickListDetails)
                .HasForeignKey(d => d.ItemID);
            this.HasOptional(t => t.ItemUnit)
                .WithMany(t => t.PickListDetails)
                .HasForeignKey(d => d.UnitID);
            this.HasOptional(t => t.PickList)
                .WithMany(t => t.PickListDetails)
                .HasForeignKey(d => d.PickListID);
            this.HasOptional(t => t.ReceiveDoc)
                .WithMany(t => t.PickListDetails)
                .HasForeignKey(d => d.ReceiveDocID);
            this.HasOptional(t => t.ReceivePallet)
                .WithMany(t => t.PickListDetails)
                .HasForeignKey(d => d.ReceivePalletID);
            this.HasOptional(t => t.Store)
                .WithMany(t => t.PickListDetails)
                .HasForeignKey(d => d.StoreID);

        }
    }
}
