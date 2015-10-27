using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class PickListMap : EntityTypeConfiguration<PickList>
    {
        public PickListMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.PickType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PickList");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.PickType).HasColumnName("PickType");
            this.Property(t => t.IssuedDate).HasColumnName("IssuedDate");
            this.Property(t => t.IsConfirmed).HasColumnName("IsConfirmed");
            this.Property(t => t.Remark).HasColumnName("Remark");
            this.Property(t => t.SavedDate).HasColumnName("SavedDate");
            this.Property(t => t.PickedDate).HasColumnName("PickedDate");
            this.Property(t => t.PickedBy).HasColumnName("PickedBy");
            this.Property(t => t.PrintedBy).HasColumnName("PrintedBy");

            // Relationships
            this.HasOptional(t => t.Order)
                .WithMany(t => t.PickLists)
                .HasForeignKey(d => d.OrderID);
            this.HasOptional(t => t.User)
                .WithMany(t => t.PickLists)
                .HasForeignKey(d => d.PrintedBy);

        }
    }
}
