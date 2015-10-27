using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class POMap : EntityTypeConfiguration<PO>
    {
        public POMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.PONumber)
                .HasMaxLength(50);

            this.Property(t => t.LetterNo)
                .HasMaxLength(50);

            this.Property(t => t.RefNo)
                .HasMaxLength(50);

            this.Property(t => t.Delivery)
                .HasMaxLength(200);

            this.Property(t => t.Currency)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PO");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PONumber).HasColumnName("PONumber");
            this.Property(t => t.LetterNo).HasColumnName("LetterNo");
            this.Property(t => t.SupplierID).HasColumnName("SupplierID");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.DateOfEntry).HasColumnName("DateOfEntry");
            this.Property(t => t.SavedbyUserID).HasColumnName("SavedbyUserID");
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
            this.Property(t => t.ExhangeRate).HasColumnName("ExhangeRate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.PurchaseType).HasColumnName("PurchaseType");
            this.Property(t => t.RefNo).HasColumnName("RefNo");
            this.Property(t => t.Delivery).HasColumnName("Delivery");
            this.Property(t => t.Currency).HasColumnName("Currency");
            this.Property(t => t.LCID).HasColumnName("LCID");
            this.Property(t => t.TermOfPayement).HasColumnName("TermOfPayement");
            this.Property(t => t.PODate).HasColumnName("PODate");

            // Relationships
            this.HasOptional(t => t.Store)
                .WithMany(t => t.POes)
                .HasForeignKey(d => d.StoreID);
            this.HasOptional(t => t.Supplier)
                .WithMany(t => t.POes)
                .HasForeignKey(d => d.SupplierID);
            this.HasOptional(t => t.User)
                .WithMany(t => t.POes)
                .HasForeignKey(d => d.SavedbyUserID);

        }
    }
}
