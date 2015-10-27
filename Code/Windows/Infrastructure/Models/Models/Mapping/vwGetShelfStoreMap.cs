using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwGetShelfStoreMap : EntityTypeConfiguration<vwGetShelfStore>
    {
        public vwGetShelfStoreMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ShelfCode)
                .HasMaxLength(50);

            this.Property(t => t.ShelfType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vwGetShelfStore");
            this.Property(t => t.ShelfCode).HasColumnName("ShelfCode");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ShelfType).HasColumnName("ShelfType");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
        }
    }
}
