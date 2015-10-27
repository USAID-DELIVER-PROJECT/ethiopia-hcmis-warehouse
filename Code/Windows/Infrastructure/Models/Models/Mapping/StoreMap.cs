using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class StoreMap : EntityTypeConfiguration<Store>
    {
        public StoreMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StoreName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Stores");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.HospitalID).HasColumnName("HospitalID");
            this.Property(t => t.StoreName).HasColumnName("StoreName");
            this.Property(t => t.UsesMovingAverage).HasColumnName("UsesMovingAverage");
            this.Property(t => t.StoreTypeID).HasColumnName("StoreTypeID");
            this.Property(t => t.StoreGroupDivisionID).HasColumnName("StoreGroupDivisionID");
            this.Property(t => t.StoreGroupID).HasColumnName("StoreGroupID");

            // Relationships
            this.HasOptional(t => t.GeneralInfo)
                .WithMany(t => t.Stores)
                .HasForeignKey(d => d.HospitalID);
            this.HasOptional(t => t.StoreGroup)
                .WithMany(t => t.Stores)
                .HasForeignKey(d => d.StoreGroupID);
            this.HasOptional(t => t.StoreGroupDivision)
                .WithMany(t => t.Stores)
                .HasForeignKey(d => d.StoreGroupDivisionID);
            this.HasOptional(t => t.StoreType)
                .WithMany(t => t.Stores)
                .HasForeignKey(d => d.StoreTypeID);

        }
    }
}
