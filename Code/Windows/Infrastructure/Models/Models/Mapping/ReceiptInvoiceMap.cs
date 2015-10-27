using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ReceiptInvoiceMap : EntityTypeConfiguration<ReceiptInvoice>
    {
        public ReceiptInvoiceMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.STVOrInvoiceNo)
                .HasMaxLength(50);

            this.Property(t => t.WayBillNo)
                .HasMaxLength(50);

            this.Property(t => t.TransitTransferNo)
                .HasMaxLength(50);

            this.Property(t => t.InsurancePolicyNo)
                .HasMaxLength(50);

            this.Property(t => t.Currency)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ReceiptInvoice");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.InvoiceTypeID).HasColumnName("InvoiceTypeID");
            this.Property(t => t.STVOrInvoiceNo).HasColumnName("STVOrInvoiceNo");
            this.Property(t => t.WayBillNo).HasColumnName("WayBillNo");
            this.Property(t => t.TransitTransferNo).HasColumnName("TransitTransferNo");
            this.Property(t => t.InsurancePolicyNo).HasColumnName("InsurancePolicyNo");
            this.Property(t => t.DateOfEntry).HasColumnName("DateOfEntry");
            this.Property(t => t.ReceiptInvoiceType).HasColumnName("ReceiptInvoiceType");
            this.Property(t => t.TotalValue).HasColumnName("TotalValue");
            this.Property(t => t.Insurance).HasColumnName("Insurance");
            this.Property(t => t.AirFreight).HasColumnName("AirFreight");
            this.Property(t => t.SeaFreight).HasColumnName("SeaFreight");
            this.Property(t => t.InlandFreight).HasColumnName("InlandFreight");
            this.Property(t => t.NBE).HasColumnName("NBE");
            this.Property(t => t.CBE).HasColumnName("CBE");
            this.Property(t => t.CustomDutyTax).HasColumnName("CustomDutyTax");
            this.Property(t => t.TransitServiceCharge).HasColumnName("TransitServiceCharge");
            this.Property(t => t.Provision).HasColumnName("Provision");
            this.Property(t => t.OtherExpense).HasColumnName("OtherExpense");
            this.Property(t => t.ExchangeRate).HasColumnName("ExchangeRate");
            this.Property(t => t.SavedByUserID).HasColumnName("SavedByUserID");
            this.Property(t => t.POID).HasColumnName("POID");
            this.Property(t => t.Currency).HasColumnName("Currency");
            this.Property(t => t.LCID).HasColumnName("LCID");

            // Relationships
            this.HasOptional(t => t.PO)
                .WithMany(t => t.ReceiptInvoices)
                .HasForeignKey(d => d.POID);

        }
    }
}
