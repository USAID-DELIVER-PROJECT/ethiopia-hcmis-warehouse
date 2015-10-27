using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class PalletMap : EntityTypeConfiguration<Pallet>
    {
        public PalletMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Pallet");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PalletNo).HasColumnName("PalletNo");
            this.Property(t => t.StorageTypeID).HasColumnName("StorageTypeID");
        }
    }
}
