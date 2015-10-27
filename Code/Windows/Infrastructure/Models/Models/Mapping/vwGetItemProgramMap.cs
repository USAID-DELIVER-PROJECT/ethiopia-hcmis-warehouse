using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCMIS.Concrete.Models.Mapping
{
    public class vwGetItemProgramMap : EntityTypeConfiguration<vwGetItemProgram>
    {
        public vwGetItemProgramMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UnitID, t.FullItemName, t.ID });

            // Properties
            this.Property(t => t.ItemName)
                .HasMaxLength(1500);

            this.Property(t => t.ATC)
                .HasMaxLength(50);

            this.Property(t => t.Strength)
                .HasMaxLength(1500);

            this.Property(t => t.ABC)
                .HasMaxLength(50);

            this.Property(t => t.VEN)
                .HasMaxLength(50);

            this.Property(t => t.DosageForm)
                .HasMaxLength(50);

            this.Property(t => t.UnitID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Unit)
                .HasMaxLength(50);

            this.Property(t => t.StockCode)
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.StockCodeDACA)
                .HasMaxLength(50);

            this.Property(t => t.FullItemName)
                .IsRequired()
                .HasMaxLength(3056);

            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vwGetItemPrograms");
            this.Property(t => t.ItemName).HasColumnName("ItemName");
            this.Property(t => t.ATC).HasColumnName("ATC");
            this.Property(t => t.Strength).HasColumnName("Strength");
            this.Property(t => t.ABCID).HasColumnName("ABCID");
            this.Property(t => t.ABC).HasColumnName("ABC");
            this.Property(t => t.VEN).HasColumnName("VEN");
            this.Property(t => t.VENID).HasColumnName("VENID");
            this.Property(t => t.IsFree).HasColumnName("IsFree");
            this.Property(t => t.IsDiscontinued).HasColumnName("IsDiscontinued");
            this.Property(t => t.EDL).HasColumnName("EDL");
            this.Property(t => t.Refrigeratored).HasColumnName("Refrigeratored");
            this.Property(t => t.Pediatric).HasColumnName("Pediatric");
            this.Property(t => t.DosageFormID).HasColumnName("DosageFormID");
            this.Property(t => t.DosageForm).HasColumnName("DosageForm");
            this.Property(t => t.UnitID).HasColumnName("UnitID");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.ProgramID).HasColumnName("ProgramID");
            this.Property(t => t.StockCode).HasColumnName("StockCode");
            this.Property(t => t.IINID).HasColumnName("IINID");
            this.Property(t => t.IsInHospitalList).HasColumnName("IsInHospitalList");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.NeedExpiryBatch).HasColumnName("NeedExpiryBatch");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.StockCodeDACA).HasColumnName("StockCodeDACA");
            this.Property(t => t.FullItemName).HasColumnName("FullItemName");
            this.Property(t => t.SubCategoryID).HasColumnName("SubCategoryID");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
        }
    }
}
