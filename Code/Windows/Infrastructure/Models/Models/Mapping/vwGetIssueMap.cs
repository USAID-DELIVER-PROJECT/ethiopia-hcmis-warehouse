using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwGetIssueMap : EntityTypeConfiguration<vwGetIssue>
    {
        public vwGetIssueMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LocalBatchNo)
                .HasMaxLength(50);

            this.Property(t => t.BatchNo)
                .HasMaxLength(50);

            this.Property(t => t.RefNo)
                .HasMaxLength(50);

            this.Property(t => t.IssuedBy)
                .HasMaxLength(50);

            this.Property(t => t.StockCode)
                .HasMaxLength(50);

            this.Property(t => t.Strength)
                .HasMaxLength(1500);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.StoreName)
                .HasMaxLength(50);

            this.Property(t => t.ItemName)
                .HasMaxLength(1500);

            this.Property(t => t.ATC)
                .HasMaxLength(50);

            this.Property(t => t.DosageForm)
                .HasMaxLength(50);

            this.Property(t => t.StockCodeDACA)
                .HasMaxLength(50);

            this.Property(t => t.Code)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vwGetIssues");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ReceivingUnitID).HasColumnName("ReceivingUnitID");
            this.Property(t => t.LocalBatchNo).HasColumnName("LocalBatchNo");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");
            this.Property(t => t.BatchNo).HasColumnName("BatchNo");
            this.Property(t => t.RefNo).HasColumnName("RefNo");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.IssuedBy).HasColumnName("IssuedBy");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.IsTransfer).HasColumnName("IsTransfer");
            this.Property(t => t.StockCode).HasColumnName("StockCode");
            this.Property(t => t.Strength).HasColumnName("Strength");
            this.Property(t => t.IINID).HasColumnName("IINID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.StoreName).HasColumnName("StoreName");
            this.Property(t => t.StoreId).HasColumnName("StoreId");
            this.Property(t => t.ItemName).HasColumnName("ItemName");
            this.Property(t => t.ATC).HasColumnName("ATC");
            this.Property(t => t.DosageFormID).HasColumnName("DosageFormID");
            this.Property(t => t.DosageForm).HasColumnName("DosageForm");
            this.Property(t => t.StockCodeDACA).HasColumnName("StockCodeDACA");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.NeedExpiryBatch).HasColumnName("NeedExpiryBatch");
            this.Property(t => t.EurDate).HasColumnName("EurDate");
            this.Property(t => t.RecievDocID).HasColumnName("RecievDocID");
            this.Property(t => t.RecomendedQty).HasColumnName("RecomendedQty");
            this.Property(t => t.DURequestedQty).HasColumnName("DURequestedQty");
            this.Property(t => t.DUSOH).HasColumnName("DUSOH");
            this.Property(t => t.QtyPerPack).HasColumnName("QtyPerPack");
            this.Property(t => t.NoOfPack).HasColumnName("NoOfPack");
            this.Property(t => t.Cost).HasColumnName("Cost");
        }
    }
}
