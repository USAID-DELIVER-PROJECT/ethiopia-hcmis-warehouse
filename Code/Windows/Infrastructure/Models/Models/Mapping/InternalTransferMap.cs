using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class InternalTransferMap : EntityTypeConfiguration<InternalTransfer>
    {
        public InternalTransferMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.BatchNumber)
                .HasMaxLength(50);

            this.Property(t => t.Type)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("InternalTransfer");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.FromPalletLocationID).HasColumnName("FromPalletLocationID");
            this.Property(t => t.ToPalletLocationID).HasColumnName("ToPalletLocationID");
            this.Property(t => t.BatchNumber).HasColumnName("BatchNumber");
            this.Property(t => t.ExpireDate).HasColumnName("ExpireDate");
            this.Property(t => t.ReceiveDocID).HasColumnName("ReceiveDocID");
            this.Property(t => t.ManufacturerID).HasColumnName("ManufacturerID");
            this.Property(t => t.BoxLevel).HasColumnName("BoxLevel");
            this.Property(t => t.QtyPerPack).HasColumnName("QtyPerPack");
            this.Property(t => t.Packs).HasColumnName("Packs");
            this.Property(t => t.QuantityInBU).HasColumnName("QuantityInBU");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.IssuedDate).HasColumnName("IssuedDate");
            this.Property(t => t.ConfirmedDate).HasColumnName("ConfirmedDate");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.PrintNumber).HasColumnName("PrintNumber");
        }
    }
}
