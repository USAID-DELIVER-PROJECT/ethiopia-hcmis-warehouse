using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class ExchangeMap : EntityTypeConfiguration<Exchange>
    {
        public ExchangeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Exchange");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.ExchageTypeID).HasColumnName("ExchageTypeID");
            this.Property(t => t.From).HasColumnName("From");
            this.Property(t => t.To).HasColumnName("To");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.RecIDIssued).HasColumnName("RecIDIssued");
            this.Property(t => t.RecIDReceived).HasColumnName("RecIDReceived");
            this.Property(t => t.Date).HasColumnName("Date");
        }
    }
}
