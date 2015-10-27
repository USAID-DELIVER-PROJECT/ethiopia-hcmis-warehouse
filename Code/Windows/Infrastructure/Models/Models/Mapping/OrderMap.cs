using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.RefNo)
                .HasMaxLength(50);

            this.Property(t => t.LicenseNo)
                .HasMaxLength(255);

            this.Property(t => t.LetterNo)
                .HasMaxLength(50);

            this.Property(t => t.ContactPerson)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Order");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.OrderStatusID).HasColumnName("OrderStatusID");
            this.Property(t => t.RequestedBy).HasColumnName("RequestedBy");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.EurDate).HasColumnName("EurDate");
            this.Property(t => t.RefNo).HasColumnName("RefNo");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.FromStore).HasColumnName("FromStore");
            this.Property(t => t.FromHCTS).HasColumnName("FromHCTS");
            this.Property(t => t.ConfirmedToHCTS).HasColumnName("ConfirmedToHCTS");
            this.Property(t => t.HCTSReferenceID).HasColumnName("HCTSReferenceID");
            this.Property(t => t.LicenseNo).HasColumnName("LicenseNo");
            this.Property(t => t.PaymentTypeID).HasColumnName("PaymentTypeID");
            this.Property(t => t.LetterNo).HasColumnName("LetterNo");
            this.Property(t => t.FilledBy).HasColumnName("FilledBy");
            this.Property(t => t.ApprovedBy).HasColumnName("ApprovedBy");
            this.Property(t => t.ContactPerson).HasColumnName("ContactPerson");
            this.Property(t => t.OrderTypeID).HasColumnName("OrderTypeID");

            // Relationships
            this.HasRequired(t => t.OrderStatu)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.OrderStatusID);
            this.HasOptional(t => t.ReceivingUnit)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.RequestedBy);
            this.HasOptional(t => t.User)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.ApprovedBy);
            this.HasOptional(t => t.User1)
                .WithMany(t => t.Orders1)
                .HasForeignKey(d => d.FilledBy);

        }
    }
}
