using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ChangeLogMap : EntityTypeConfiguration<ChangeLog>
    {
        public ChangeLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.TableName)
                .HasMaxLength(255);

            this.Property(t => t.ColumnName)
                .HasMaxLength(255);

            this.Property(t => t.OldValue)
                .HasMaxLength(255);

            this.Property(t => t.NewValue)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("ChangeLog");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TableName).HasColumnName("TableName");
            this.Property(t => t.ColumnName).HasColumnName("ColumnName");
            this.Property(t => t.OldValue).HasColumnName("OldValue");
            this.Property(t => t.NewValue).HasColumnName("NewValue");
            this.Property(t => t.ChangedBy).HasColumnName("ChangedBy");
            this.Property(t => t.DateChanged).HasColumnName("DateChanged");
            this.Property(t => t.RefID).HasColumnName("RefID");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.ChangeLogs)
                .HasForeignKey(d => d.ChangedBy);

        }
    }
}
