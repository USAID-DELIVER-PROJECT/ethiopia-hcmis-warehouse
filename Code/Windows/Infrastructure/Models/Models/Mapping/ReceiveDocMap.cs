using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ReceiveDocMap : EntityTypeConfiguration<ReceiveDoc>
    {
        public ReceiveDocMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.BatchNo)
                .HasMaxLength(50);

            this.Property(t => t.ReceivedBy)
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(50);

            this.Property(t => t.LocalBatchNo)
                .HasMaxLength(50);

            this.Property(t => t.RefNo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ReceiveDoc");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.BatchNo).HasColumnName("BatchNo");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.SupplierID).HasColumnName("SupplierID");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.ExpDate).HasColumnName("ExpDate");
            this.Property(t => t.Out).HasColumnName("Out");
            this.Property(t => t.ReceivedStatus).HasColumnName("ReceivedStatus");
            this.Property(t => t.ReceivedBy).HasColumnName("ReceivedBy");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.LocalBatchNo).HasColumnName("LocalBatchNo");
            this.Property(t => t.RefNo).HasColumnName("RefNo");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.QuantityLeft).HasColumnName("QuantityLeft");
            this.Property(t => t.NoOfPack).HasColumnName("NoOfPack");
            this.Property(t => t.QtyPerPack).HasColumnName("QtyPerPack");
            this.Property(t => t.EurDate).HasColumnName("EurDate");
            this.Property(t => t.BoxLevel).HasColumnName("BoxLevel");
            this.Property(t => t.SellingPrice).HasColumnName("SellingPrice");
            this.Property(t => t.PricePerPack).HasColumnName("PricePerPack");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.DeliveryNote).HasColumnName("DeliveryNote");
            this.Property(t => t.Confirmed).HasColumnName("Confirmed");
            this.Property(t => t.ConfirmedByUserID).HasColumnName("ConfirmedByUserID");
            this.Property(t => t.ConfirmedDateTime).HasColumnName("ConfirmedDateTime");
            this.Property(t => t.ReturnedStock).HasColumnName("ReturnedStock");
            this.Property(t => t.ReturnedFromIssueDocID).HasColumnName("ReturnedFromIssueDocID");
            this.Property(t => t.ReceiptID).HasColumnName("ReceiptID");
            this.Property(t => t.Margin).HasColumnName("Margin");
            this.Property(t => t.Insurance).HasColumnName("Insurance");
            this.Property(t => t.InvoicedNoOfPack).HasColumnName("InvoicedNoOfPack");
            this.Property(t => t.ShortageReasonID).HasColumnName("ShortageReasonID");

            // Relationships
            this.HasOptional(t => t.IssueDoc)
                .WithMany(t => t.ReceiveDocs)
                .HasForeignKey(d => d.ReturnedFromIssueDocID);
            this.HasOptional(t => t.Item)
                .WithMany(t => t.ReceiveDocs)
                .HasForeignKey(d => d.ItemID);
            this.HasOptional(t => t.ItemUnit)
                .WithMany(t => t.ReceiveDocs)
                .HasForeignKey(d => d.UnitID);
            this.HasOptional(t => t.Manufacturer)
                .WithMany(t => t.ReceiveDocs)
                .HasForeignKey(d => d.ManufacturerId);
            this.HasOptional(t => t.Receipt)
                .WithMany(t => t.ReceiveDocs)
                .HasForeignKey(d => d.ReceiptID);
            this.HasOptional(t => t.ShortageReason)
                .WithMany(t => t.ReceiveDocs)
                .HasForeignKey(d => d.ShortageReasonID);
            this.HasOptional(t => t.Supplier)
                .WithMany(t => t.ReceiveDocs)
                .HasForeignKey(d => d.SupplierID);

        }
    }
}
