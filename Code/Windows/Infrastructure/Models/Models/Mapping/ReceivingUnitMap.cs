using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ReceivingUnitMap : EntityTypeConfiguration<ReceivingUnit>
    {
        public ReceivingUnitMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            this.Property(t => t.LicenseNo)
                .HasMaxLength(255);

            this.Property(t => t.VATNo)
                .HasMaxLength(255);

            this.Property(t => t.TinNo)
                .HasMaxLength(255);

            this.Property(t => t.Town)
                .HasMaxLength(50);

            this.Property(t => t.Kebele)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ReceivingUnits");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Woreda).HasColumnName("Woreda");
            this.Property(t => t.Route).HasColumnName("Route");
            this.Property(t => t.RouteSequence).HasColumnName("RouteSequence");
            this.Property(t => t.PaymentTypeID).HasColumnName("PaymentTypeID");
            this.Property(t => t.LicenseNo).HasColumnName("LicenseNo");
            this.Property(t => t.VATNo).HasColumnName("VATNo");
            this.Property(t => t.TinNo).HasColumnName("TinNo");
            this.Property(t => t.DateOfRegistration).HasColumnName("DateOfRegistration");
            this.Property(t => t.Town).HasColumnName("Town");
            this.Property(t => t.Kebele).HasColumnName("Kebele");
            this.Property(t => t.RUType).HasColumnName("RUType");
            this.Property(t => t.Ownership).HasColumnName("Ownership");
            this.Property(t => t.Zone).HasColumnName("Zone");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.InProcess).HasColumnName("InProcess");

            // Relationships
            this.HasOptional(t => t.ReceivingUnitType)
                .WithMany(t => t.ReceivingUnits)
                .HasForeignKey(d => d.RUType);
            this.HasOptional(t => t.RUOwnershipType)
                .WithMany(t => t.ReceivingUnits)
                .HasForeignKey(d => d.Ownership);
            this.HasOptional(t => t.Woreda1)
                .WithMany(t => t.ReceivingUnits)
                .HasForeignKey(d => d.Woreda);
            this.HasOptional(t => t.Zone1)
                .WithMany(t => t.ReceivingUnits)
                .HasForeignKey(d => d.Zone);

        }
    }
}
