using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class PrintLogMap : EntityTypeConfiguration<PrintLog>
    {
        public PrintLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Type)
                .HasMaxLength(100);

            this.Property(t => t.Printer)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("PrintLog");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Reference).HasColumnName("Reference");
            this.Property(t => t.Printer).HasColumnName("Printer");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.PrintedDate).HasColumnName("PrintedDate");
            this.Property(t => t.PrintedBy).HasColumnName("PrintedBy");
            this.Property(t => t.IsPrinted).HasColumnName("IsPrinted");
        }
    }
}
