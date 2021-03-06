using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwReceivedDocMap : EntityTypeConfiguration<vwReceivedDoc>
    {
        public vwReceivedDocMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.BatchNo)
                .HasMaxLength(50);

            this.Property(t => t.LocalBatchNo)
                .HasMaxLength(50);

            this.Property(t => t.RefNo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vwReceivedDoc");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.BatchNo).HasColumnName("BatchNo");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.LocalBatchNo).HasColumnName("LocalBatchNo");
            this.Property(t => t.RefNo).HasColumnName("RefNo");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.EurDate).HasColumnName("EurDate");
        }
    }
}
