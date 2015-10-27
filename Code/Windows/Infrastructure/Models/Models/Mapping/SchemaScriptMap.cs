using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class SchemaScriptMap : EntityTypeConfiguration<SchemaScript>
    {
        public SchemaScriptMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ScriptName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SchemaScripts");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ScriptName).HasColumnName("ScriptName");
            this.Property(t => t.DateApplied).HasColumnName("DateApplied");
            this.Property(t => t.Successful).HasColumnName("Successful");
        }
    }
}
