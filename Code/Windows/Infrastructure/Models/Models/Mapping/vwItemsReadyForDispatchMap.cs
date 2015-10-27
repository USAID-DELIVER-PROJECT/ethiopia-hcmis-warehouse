using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwItemsReadyForDispatchMap : EntityTypeConfiguration<vwItemsReadyForDispatch>
    {
        public vwItemsReadyForDispatchMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ReceivePalletID, t.ReservedStock, t.ReceiveDocID, t.DeliveryNote, t.PalletLocationID, t.IsFullSize, t.IsExtended, t.AvailableVolume, t.UsedVolume, t.FullItemName, t.Expr4, t.CategoryId, t.SubCategoryID, t.Expr6 });

            // Properties
            this.Property(t => t.ReceivePalletID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ReservedStock)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ReceiveDocID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

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

            this.Property(t => t.PalletLocationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Label)
                .HasMaxLength(50);

            this.Property(t => t.FullItemName)
                .IsRequired()
                .HasMaxLength(3056);

            this.Property(t => t.ItemName)
                .HasMaxLength(1500);

            this.Property(t => t.Strength)
                .HasMaxLength(1500);

            this.Property(t => t.DosageForm)
                .HasMaxLength(50);

            this.Property(t => t.Unit)
                .HasMaxLength(50);

            this.Property(t => t.StockCode)
                .HasMaxLength(50);

            this.Property(t => t.Expr4)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.CategoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SubCategoryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Expr6)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ManufacturerName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vwItemsReadyForDispatch");
            this.Property(t => t.DispatchableStock).HasColumnName("DispatchableStock");
            this.Property(t => t.ReceivePalletID).HasColumnName("ReceivePalletID");
            this.Property(t => t.ReceiveID).HasColumnName("ReceiveID");
            this.Property(t => t.PalletID).HasColumnName("PalletID");
            this.Property(t => t.ReceivedQuantity).HasColumnName("ReceivedQuantity");
            this.Property(t => t.Balance).HasColumnName("Balance");
            this.Property(t => t.ReservedStock).HasColumnName("ReservedStock");
            this.Property(t => t.ReserveOrderID).HasColumnName("ReserveOrderID");
            this.Property(t => t.ReceiveDocID).HasColumnName("ReceiveDocID");
            this.Property(t => t.BatchNo).HasColumnName("BatchNo");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.SupplierID).HasColumnName("SupplierID");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.ExpDate).HasColumnName("ExpDate");
            this.Property(t => t.Out).HasColumnName("Out");
            this.Property(t => t.ReceivedStatus).HasColumnName("ReceivedStatus");
            this.Property(t => t.Confirmed).HasColumnName("Confirmed");
            this.Property(t => t.ReceivedBy).HasColumnName("ReceivedBy");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.LocalBatchNo).HasColumnName("LocalBatchNo");
            this.Property(t => t.RefNo).HasColumnName("RefNo");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.QuantityLeft).HasColumnName("QuantityLeft");
            this.Property(t => t.NoOfPack).HasColumnName("NoOfPack");
            this.Property(t => t.QtyPerPack).HasColumnName("QtyPerPack");
            this.Property(t => t.EurDate).HasColumnName("EurDate");
            this.Property(t => t.BoxSize).HasColumnName("BoxSize");
            this.Property(t => t.BoxLevel).HasColumnName("BoxLevel");
            this.Property(t => t.SellingPrice).HasColumnName("SellingPrice");
            this.Property(t => t.DeliveryNote).HasColumnName("DeliveryNote");
            this.Property(t => t.PalletLocationID).HasColumnName("PalletLocationID");
            this.Property(t => t.Label).HasColumnName("Label");
            this.Property(t => t.ShelfID).HasColumnName("ShelfID");
            this.Property(t => t.Row).HasColumnName("Row");
            this.Property(t => t.Column).HasColumnName("Column");
            this.Property(t => t.StorageTypeID).HasColumnName("StorageTypeID");
            this.Property(t => t.IsFullSize).HasColumnName("IsFullSize");
            this.Property(t => t.IsEnabled).HasColumnName("IsEnabled");
            this.Property(t => t.RackStatusID).HasColumnName("RackStatusID");
            this.Property(t => t.Expr3).HasColumnName("Expr3");
            this.Property(t => t.PercentUsed).HasColumnName("PercentUsed");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.IsExtended).HasColumnName("IsExtended");
            this.Property(t => t.ExtendedRows).HasColumnName("ExtendedRows");
            this.Property(t => t.AvailableVolume).HasColumnName("AvailableVolume");
            this.Property(t => t.UsedVolume).HasColumnName("UsedVolume");
            this.Property(t => t.FullItemName).HasColumnName("FullItemName");
            this.Property(t => t.ItemName).HasColumnName("ItemName");
            this.Property(t => t.Strength).HasColumnName("Strength");
            this.Property(t => t.ABCID).HasColumnName("ABCID");
            this.Property(t => t.VENID).HasColumnName("VENID");
            this.Property(t => t.IsFree).HasColumnName("IsFree");
            this.Property(t => t.DosageFormID).HasColumnName("DosageFormID");
            this.Property(t => t.DosageForm).HasColumnName("DosageForm");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.StockCode).HasColumnName("StockCode");
            this.Property(t => t.IINID).HasColumnName("IINID");
            this.Property(t => t.Expr4).HasColumnName("Expr4");
            this.Property(t => t.IsInHospitalList).HasColumnName("IsInHospitalList");
            this.Property(t => t.TypeID).HasColumnName("TypeID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.IsStackStored).HasColumnName("IsStackStored");
            this.Property(t => t.NeedExpiryBatch).HasColumnName("NeedExpiryBatch");
            this.Property(t => t.Expr5).HasColumnName("Expr5");
            this.Property(t => t.NearExpiryTrigger).HasColumnName("NearExpiryTrigger");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.SubCategoryID).HasColumnName("SubCategoryID");
            this.Property(t => t.Expr6).HasColumnName("Expr6");
            this.Property(t => t.PalletNo).HasColumnName("PalletNo");
            this.Property(t => t.StorageTypeID2).HasColumnName("StorageTypeID2");
            this.Property(t => t.ManufacturerName).HasColumnName("ManufacturerName");
        }
    }
}
