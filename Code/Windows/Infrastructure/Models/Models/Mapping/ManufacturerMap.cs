using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ManufacturerMap : EntityTypeConfiguration<Manufacturer>
    {
        public ManufacturerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.CountryOfOrigin)
                .HasMaxLength(50);

            this.Property(t => t.PFSAManufCode)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Manufacturers");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CountryOfOrigin).HasColumnName("CountryOfOrigin");
            this.Property(t => t.PFSAManufCode).HasColumnName("PFSAManufCode");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Address).HasColumnName("Address");
        }
    }
}
