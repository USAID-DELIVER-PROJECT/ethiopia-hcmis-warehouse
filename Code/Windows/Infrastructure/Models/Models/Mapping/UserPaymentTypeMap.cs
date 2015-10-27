using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class UserPaymentTypeMap : EntityTypeConfiguration<UserPaymentType>
    {
        public UserPaymentTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserPaymentType");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.PaymentTypeID).HasColumnName("PaymentTypeID");
            this.Property(t => t.CanAccess).HasColumnName("CanAccess");
            this.Property(t => t.IsDefault).HasColumnName("IsDefault");

            // Relationships
            this.HasOptional(t => t.PaymentType)
                .WithMany(t => t.UserPaymentTypes)
                .HasForeignKey(d => d.PaymentTypeID);
            this.HasOptional(t => t.User)
                .WithMany(t => t.UserPaymentTypes)
                .HasForeignKey(d => d.UserID);

        }
    }
}
